#include <iostream>

int SoucetCiselDefinice(int hodnota) {
	int soucet = 0;

	// Vypocitej soucet vsech predchazejicich cisel, az po zadanou hodnotu
	for (int i = 1; i <= hodnota; i++) {
		soucet += i;
	}

	return soucet;
}

int main() {
	// Testovaci vypis
	for (int i = 0; i <= 20; i++) {
		std::cout << "[" << i << "]\t" << SoucetCiselDefinice(i) << std::endl;
	}

	system("pause>nul");
	return 0;
}