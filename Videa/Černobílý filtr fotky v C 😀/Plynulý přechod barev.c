#pragma warning(disable:6276)
#include <IL/il.h>

int main() {
	ilInit();
	ILuint obrazek;
	ilGenImages(1, &obrazek);
	ilBindImage(obrazek);

	ilTexImage(256, 256, 1, 3, IL_RGB, IL_UNSIGNED_BYTE, NULL);
	ilClearImage();

	for (int radek = 0; radek < 256; radek++) {
		for (int sloupec = 0; sloupec < 256; sloupec++) {
			unsigned char data[] = { 255, radek, sloupec };
			ilSetPixels(sloupec, radek, 0, 1, 1, 1, IL_RGB, IL_UNSIGNED_BYTE, data);
		}
	}
	ilSaveImage("Strana 1.png");

	return 0;
}