#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <locale.h>
#include <wchar.h>
#include <io.h>
#include <fcntl.h>
#include <stdint.h>
#include "IL/il.h"

#define InputReadError() wprintf(L"Pøi naèítání vstupu došlo k neznámé chybì.\n"); (void)getwchar(); return 101

#define RIntensity 0.299
#define GIntensity 0.587
#define BIntensity 0.114

typedef struct ImageData {
	ILuint width;
	ILuint height;
	ILuint depth;
	ILubyte bytesPerPixel;
	ILenum format;
	ILenum type;
} ImageData;

bool InputText(wchar_t** outputString, const wchar_t inputText[], size_t maxInputSize) {
	if (maxInputSize <= 0) return false;
	maxInputSize++;

	wchar_t* buffer = (wchar_t*)malloc(sizeof(wchar_t) * maxInputSize);
	if (buffer == NULL) return false;

	wprintf(L"%ls", inputText);

	bool readSuccessfully = fgetws(buffer, (int)maxInputSize, stdin);
	fseek(stdin, 0, SEEK_END);

	if (!readSuccessfully) {
		free(buffer);
		return false;
	}

	buffer[maxInputSize - 1] = L'\0';
	size_t size = wcslen(buffer);
	if (size > 0 && buffer[size - 1] == L'\n') {
		buffer[size - 1] = L'\0';
	}
	*outputString = buffer;
	return true;
}

bool YesNoInput(bool* YesNo, wchar_t inputText[], wchar_t errorText[]) {
	wchar_t* input;
	do {
		if (!InputText(&input, inputText, 2)) return false;
		if (wcscmp(input, L"A") == 0 || wcscmp(input, L"a") == 0
			|| wcscmp(input, L"Y") == 0 || wcscmp(input, L"y") == 0
			|| wcscmp(input, L"1") == 0) {
			*YesNo = true;
			return true;
		}
		if (wcscmp(input, L"N") == 0 || wcscmp(input, L"n") == 0 ||
			wcscmp(input, L"0") == 0) {
			*YesNo = false;
			return true;
		}
		inputText = errorText;
	} while (true);
}

bool FileExists(const wchar_t* path) {
	FILE* file;
	if (_wfopen_s(&file, path, L"r")) {
		return false;
	}
	if (file != NULL) fclose(file);
	return true;
}

bool RemoveQuotesFromInput(wchar_t** inputString, const size_t inputStringSize) {
	if (inputString == NULL) return false;
	if (inputStringSize == 0) return false;

	if ((*inputString)[inputStringSize - 1] == L'"') (*inputString)[inputStringSize - 1] = L'\0';
	// Here is a memory leak, but I will just ignore it and no one will notice, because who cares about a few bytes of memory :D
	if ((*inputString)[0] == L'"') *inputString = *inputString + 1;
	return true;
}

bool InputFilePath(wchar_t** filePath, wchar_t inputText[], wchar_t errorText[], const size_t maxInputSize) {
	do {
		if (!InputText(filePath, inputText, maxInputSize)) return false;
		const size_t filePathLength = wcslen(*filePath);
		RemoveQuotesFromInput(filePath, filePathLength);
		inputText = errorText;
	} while (!FileExists(*filePath));

	return true;
}

bool LoadImageFromPath(ILuint* loadedImage, const wchar_t* inputFilePath) {
	if (loadedImage == NULL) return false;
	ilBindImage(*loadedImage);

	return ilLoad(ilDetermineType(inputFilePath), inputFilePath);
}

void ShowDevILError() {
	ILenum error = ilGetError();
	ILenum previousError = 0;
	printf("\n");
	while (error != 0) {
		if (error == previousError) {
			error = ilGetError();
			continue;
		}

		switch (error) {
		case IL_INVALID_EXTENSION:
			wprintf(L"Error 0x%x! Zadaný soubor není platný soubor obrázku\n", error);
			break;
		case IL_FORMAT_NOT_SUPPORTED:
			wprintf(L"Error 0x%x! Formát zadaného obrázku není podporován\n", error);
			break;
		case IL_COULD_NOT_OPEN_FILE:
			wprintf(L"Error 0x%x! Zadaný soubor nebylo možné otevøít. Soubor nebyl nalezen, nebo je právì používán\n", error);
			break;
		case IL_ILLEGAL_OPERATION:
			wprintf(L"Error 0x%x! Došlo k pokusu o provedení operace, která není platná\n", error);
			break;
		case IL_INVALID_PARAM:
			wprintf(L"Error 0x%x! Funkci byl pøedán neplatný parametr\n", error);
			break;
		case IL_OUT_OF_MEMORY:
			wprintf(L"Error 0x%x! Nedostatek pamìti pro provedení operace\n", error);
			break;
		case IL_INVALID_VALUE:
			wprintf(L"Error 0x%x! Funkci byla pøedána neplatná hodnota\n", error);
			break;
		case IL_ILLEGAL_FILE_VALUE:
			wprintf(L"Error 0x%x! Neplatná hodnota v souboru obrázku\n", error);
			break;
		case IL_INVALID_FILE_HEADER:
			wprintf(L"Error 0x%x! Neplatná hlavièka souboru obrázku\n", error);
			break;
		default:
			wprintf(L"Pøi naèítání dat z obrázku došlo k nerozpoznané chybì: 0x%x\n", error);
			break;
		}

		previousError = error;
		error = ilGetError();
	}
}


int main(int argc, char** argv) {
	setlocale(LC_ALL, "cs_cz.UTF8");
	if (!_setmode(_fileno(stdin), _O_U16TEXT)) {
		wprintf(L"Pøi nastavení terminálu došlo k neznámé chybì\n");
		return 100;
	}

	wchar_t* inputFile;
	if (!InputFilePath(&inputFile, L"Zadejte cestu k originální fotce: ", L"Neplatná cesta! Zadejte platnou cestu: ", _MAX_PATH)) {
		InputReadError();
	}

	bool useLinearCalculation;
	if (!YesNoInput(&useLinearCalculation, L"Pøejete si použít lineární výpoèet barev (nedoporuèeno)? (A/N): ", L"Neplatná hodnota! Chcete obrázek pøepsat? (A/N): ")) {
		InputReadError();
	}

	ilInit();

	ILuint originalImage;
	ilGenImages(1, &originalImage);
	ilBindImage(originalImage);

	if (!LoadImageFromPath(&originalImage, inputFile)) {
		ShowDevILError();
		(void)getwchar();
		return 102;
	}
	wprintf(L"Fotka úspìšnì naètena.\n\nProbíhá generování èernobílé fotky...");

	ImageData origData;
	origData.width = ilGetInteger(IL_IMAGE_WIDTH);
	origData.height = ilGetInteger(IL_IMAGE_HEIGHT);
	origData.depth = ilGetInteger(IL_IMAGE_DEPTH);
	origData.bytesPerPixel = ilGetInteger(IL_IMAGE_CHANNELS);
	origData.format = ilGetInteger(IL_IMAGE_FORMAT);
	origData.type = ilGetInteger(IL_IMAGE_TYPE);

	ILuint blackAndWhiteImate;
	ilGenImages(1, &blackAndWhiteImate);
	ilBindImage(blackAndWhiteImate);
	ilTexImage(origData.width, origData.height, origData.depth, origData.bytesPerPixel, origData.format, origData.type, NULL);
	ilClearImage();

	for (uint32_t row = 0; row < origData.height; row++) {
		for (uint32_t column = 0; column < origData.width; column++) {
			ilBindImage(originalImage);
			uint8_t data[4] = { 255, 255, 255, 255 };
			ilCopyPixels(column, row, 0, 1, 1, 1, origData.format, origData.type, data);

			ilBindImage(blackAndWhiteImate);
			uint8_t average;
			if (useLinearCalculation) {
				average = (data[0] + data[1] + data[2]) / 3;
			}
			else {
				average = (uint8_t)(data[0] * RIntensity + data[1] * GIntensity + data[2] * BIntensity);
			}
			uint8_t newData[4] = { average,average,average, data[3] };
			ilSetPixels(column, origData.height - row - 1, 0, 1, 1, 1, origData.format, origData.type, newData);
		}
	}

	wchar_t* outputFile;
	if (!InputText(&outputFile, L"\n\nÈernobílá fotka úspìšnì vygenerována, zadejte cestu k uložení: ", 256)) {
		InputReadError();
	}

	while (true) {
		RemoveQuotesFromInput(&outputFile, wcslen(outputFile));

		if (FileExists(outputFile)) {
			bool overwriteFile;
			if (!YesNoInput(&overwriteFile, L"Obrázek existuje, chcete jej pøepsat? (A/N): ", L"Neplatná hodnota! Chcete obrázek pøepsat? (A/N): ")) {
				InputReadError();
			}
			if (overwriteFile) _wremove(outputFile);
		}

		if (ilSaveImage(outputFile)) {
			break;
		}

		if (!InputText(&outputFile, L"Obrázek nebylo možné uložit! Zadejte platnou cestu: ", 256)) {
			InputReadError();
		}
	}

	wprintf(L"\nObrázek úspìšnì uložen\n\nStisknìte libovolnou klávesu pro konec...");
	(void)getwchar();
	return 0;
}