#pragma warning(disable:6276)
#include <stdio.h>
#include "IL/il.h"

#define Min(a, b) (a > b) ? b : a

#define IMAGE_1 "D:\\.Programování\\C\\DevIL Test\\Like.png"
#define IMAGE_2 "D:\\.Programování\\C\\DevIL Test\\Odbìr.png"

void PrintError() {
	ILenum error;
	do {
		error = ilGetError();
		printf("\nError: %u", error);
	} while (error != IL_NO_ERROR);
}

int main() {
	ilInit();
	
	ILuint like, odber;

	ilGenImages(1, &like);
	ilBindImage(like);
	if (!ilLoadImage(IMAGE_1)) {
		printf("Error 1");
		PrintError();
		return 1;
	}

	ilGenImages(1, &odber);
	ilBindImage(odber);
	if (!ilLoadImage(IMAGE_2)) {
		printf("Error 2");
		PrintError();
		return 2;
	}

	ILuint combinedImage;
	ILint width = ilGetInteger(IL_IMAGE_WIDTH);
	ILint height = ilGetInteger(IL_IMAGE_HEIGHT);

	ILint depth = ilGetInteger(IL_IMAGE_DEPTH);
	ILint numChannels = ilGetInteger(IL_IMAGE_CHANNELS);
	ILint format = ilGetInteger(IL_IMAGE_FORMAT);
	ILint type = ilGetInteger(IL_IMAGE_TYPE);

	ilGenImages(1, &combinedImage);
	ilBindImage(combinedImage);

	ilTexImage(width, height, depth, numChannels, format, type, NULL);
	ilClearImage();

	for (int row = 0; row < height; row++) {
		for (int column = 0; column < width; column++) {
			unsigned char dataLike[3];
			unsigned char dataOdber[3];
			unsigned char dataCombined[3];

			ilBindImage(like);
			ilCopyPixels(column, row, 0, 1, 1, 1, IL_RGB, IL_UNSIGNED_BYTE, dataLike);

			ilBindImage(odber);
			ilCopyPixels(column, row, 0, 1, 1, 1, IL_RGB, IL_UNSIGNED_BYTE, dataOdber);

			ilBindImage(combinedImage);
			for (int i = 0; i < sizeof(dataLike); i++) {
				dataCombined[i] = Min(dataLike[i], dataOdber[i]);
			}
			ilSetPixels(column, height - row, 0, 1, 1, 1, IL_RGB, IL_UNSIGNED_BYTE, dataCombined);
		}
	}
	
	if (!ilSaveImage("Combined.png")) {
		printf("Error save");
		PrintError();
		return 10;
	}

	printf("Successully saved!");

	return 0;
}