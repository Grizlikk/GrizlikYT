#include <Windows.h>

#pragma comment(linker, "/SUBSYSTEM:windows /ENTRY:mainCRTStartup")

int main() {
	MessageBox(NULL, L"Aplikace právě byla úspěšně spuštěna.\n\n(Dejte like a odběr :D)", L"Aplikace spuštěna :)", MB_OK | MB_ICONWARNING);

	return 0;
}