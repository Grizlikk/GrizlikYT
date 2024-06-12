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
	if (!ilLoadImage(TEST)) {
		printf("Load error\n");
	}

	if (!ilSaveImage(TEST2)) {
		printf("Save error\n");
	}

	PrintError();
}