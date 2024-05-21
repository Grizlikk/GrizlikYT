#include <iostream>
#include <Windows.h>
#include <thread>

void ThreadCode1() {
	while (true) {
		std::cout << "Ahoj";
		Sleep(500);
	}
}

void ThreadCode2() {
	while (true) {
		std::cout << "Čau";
		Sleep(500);
	}
}

int main() {
	setlocale(LC_ALL, "cs_cz");
	std::thread thread(ThreadCode1);
	ThreadCode2();
}