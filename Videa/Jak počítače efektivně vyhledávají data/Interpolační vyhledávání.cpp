#include <iostream>
#include <array>

// Interpolacni vyhledavani
bool InterpolacniVyhledavani(std::array<int, 1000>& pole, int hodnota) {
	float zacatek = 0;
	float konec = pole.size() - 1;
	float pozice;

	while (zacatek <= konec && hodnota >= pole[zacatek] && hodnota <= pole[konec]) {
		if (pole[konec] == pole[zacatek]) {
			return pole[zacatek] == hodnota;
		}
		pozice = zacatek + (hodnota - pole[zacatek]) * ((konec - zacatek) / (pole[konec] - pole[zacatek]));

		std::cout << "Zacatek: " << zacatek << "\tKonec: " << konec << "\t\tPozice: " << pozice << std::endl;
		if (pole[pozice] == hodnota) {
			return true;
		}
		else if (pole[pozice] > hodnota) {
			konec = pozice - 1;
		}
		else {
			zacatek = pozice + 1;
		}
	}
	return false;
}


int main() {

	std::array<int, 1000> hodnoty;
	for (int i = 0; i < hodnoty.size(); i++) {
		hodnoty[i] = 2 * i + 1;
	}


	std::cout << InterpolacniVyhledavani(hodnoty, 215) << std::endl;

	system("pause>nul");
	return 0;
}