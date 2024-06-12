#pragma warning(disable:6276)
#include <stdio.h>
#include "IL/il.h"

#define AHOJ "D:\\.Programování\\C\\DevIL Test\\Ahoj.png"

void PrintError() {
	ILenum error;
	do {
		error = ilGetError();
		printf("\nError: %u", error);
	} while (error != IL_NO_ERROR);
}

int main() {
	ilInit();
	
	ILuint ahoj, ahojEdited;

	ilGenImages(1, &ahoj);
	ilBindImage(ahoj);
	if (!ilLoadImage(AHOJ)) {
		printf("Error load");
		PrintError();
		return 1;
	}

	ILint width = ilGetInteger(IL_IMAGE_WIDTH);
	ILint height = ilGetInteger(IL_IMAGE_HEIGHT);
	ILint depth = ilGetInteger(IL_IMAGE_DEPTH);
	ILint numChannels = ilGetInteger(IL_IMAGE_CHANNELS);
	ILint format = ilGetInteger(IL_IMAGE_FORMAT);
	ILint type = ilGetInteger(IL_IMAGE_TYPE);

	ilGenImages(1, &ahojEdited);
	ilBindImage(ahojEdited);

	ilTexImage(width, height, depth, numChannels, format, type, NULL);
	ilClearImage();

	for (int row = 0; row < height; row++) {
		for (int column = 0; column < width; column++) {
			ilBindImage(ahoj);
			unsigned char ahojData[3];
			ilCopyPixels(column, height - row, 0, 1, 1, 1, format, type, ahojData);

			ilBindImage(ahojEdited);
			ahojData[0] = 255;
			ilSetPixels(column, row, 0, 1, 1, 1, format, type, ahojData);
		}
	}
	
	if (!ilSaveImage("Ahoj edited.png")) {
		printf("Error save");
		PrintError();
		return 10;
	}

	printf("Successully saved!");

	return 0;
}