#include <iostream>

int SoucetCiselRekurze(int hodnota) {
	// Pokud je hodnota mensi nez 1, vysledek je 0
	if (hodnota < 1) {
		return 0;
	}

	// Pokud je hodnota 1, vysledek je 1
	if (hodnota == 1) {
		return 1;
	}

	// Pokud je hodnota vetsi nez 1, vysledek je predchozi soucet + hodnota
	// Napriklad: "SoucetCiselRekurze(9) + 10"
	return SoucetCiselRekurze(hodnota - 1) + hodnota;
}

int main() {
	// Testovaci vypis
	for (int i = 0; i <= 20; i++) {
		std::cout << "[" << i << "]\t" << SoucetCiselRekurze(i) << std::endl;
	}

	system("pause>nul");
	return 0;
}