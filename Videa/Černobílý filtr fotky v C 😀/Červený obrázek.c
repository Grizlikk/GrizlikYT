#pragma warning(disable:6276)
#include <stdio.h>
#include "IL/il.h"

#define TEST "D:\\.Programování\\C\\DevIL Test\\Test.png"
#define TEST2 "D:\\.Programování\\C\\DevIL Test\\Test 2.png"

void PrintError() {
	ILenum error;
	do {
		error = ilGetError();
		printf("\nError: %u", error);
	} while (error != IL_NO_ERROR);
}

int main() {
	ilInit();
	ILuint obrazek;
	ilGenImages(1, &obrazek);
	ilBindImage(obrazek);

	ilTexImage(100, 100, 1, 3, IL_RGB, IL_UNSIGNED_BYTE, NULL);
	ilClearImage();
	unsigned char data[3] = { 255, 0, 0 };
	for (int i = 0; i < 100; i++) {
		for (int j = 0; j < 100; j++) {
			ilSetPixels(i, j, 0, 1, 1, 1, IL_RGB, IL_UNSIGNED_BYTE, NULL);
		}
	}

	if (!ilSaveImage(TEST2)) {
		printf("Save error\n");
	}

	PrintError();
}