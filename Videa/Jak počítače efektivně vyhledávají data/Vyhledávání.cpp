#include <iostream>
#include <chrono>
#include <array>
#include <random>

// Linearni vyhledavani
bool LinearniVyhledavani(std::array<int, 100000>& pole, int hodnota) {
	for (int i = 0; i < pole.size(); i++) {
		if (pole[i] == hodnota) {
			return true;
		}
	}
	return false;
}

// Binarni vyhledavani
bool BinarniVyhledavani(std::array<int, 100000>& pole, int hodnota) {
	int zacatek = 0;
	int konec = pole.size() - 1;
	int stred;

	while (zacatek <= konec) {
		stred = (zacatek + konec) / 2;

		if (pole[stred] == hodnota) {
			return true;
		}
		else if (pole[stred] > hodnota) {
			konec = stred - 1;
		}
		else {
			zacatek = stred + 1;
		}
	}
	return false;
}

// Interpolacni vyhledavani
bool InterpolacniVyhledavani(std::array<int, 100000>& pole, int hodnota) {
	float zacatek = 0;
	float konec = pole.size() - 1;
	float pozice;

	while (zacatek <= konec && hodnota >= pole[zacatek] && hodnota <= pole[konec]) {
		if (pole[konec] == pole[zacatek]) {
			return pole[zacatek] == hodnota;
		}
		pozice = zacatek + (hodnota - pole[zacatek]) * ((konec - zacatek) / (pole[konec] - pole[zacatek]));

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
	// Zaplneni pole nahodnymi cisly
	std::mt19937 gen(time(NULL));
	std::uniform_int_distribution<int> random(1, 1000000);
	std::array<int, 100000> cisla;
	for (int i = 0; i < cisla.size(); i++) {
		cisla[i] = random(gen);
	}
	// Vygenerovani hodnot k vyhledavani
	std::array<int, 2000> vyhledavani;
	for (int i = 0; i < vyhledavani.size(); i++) {
		vyhledavani[i] = random(gen);
	}

	// Serazeni pole
	std::cout << "Stisknete libovolnou klavesu pro serazeni pole..." << std::endl;
	system("pause>nul");

	auto t1 = std::chrono::high_resolution_clock::now();
	std::sort(cisla.begin(), cisla.end());
	auto t2 = std::chrono::high_resolution_clock::now();
	float prodleva = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();

	std::cout << std::endl << "Pole bylo serazeno za " << prodleva / 1000 << " milisekund" << std::endl;


	// Linearni vyhledavani
	std::cout << std::endl << std::endl << "Stisknete libovolnou klavesu pro spusteni linearniho vyhledavani..." << std::endl;
	system("pause>nul");

	int nalezeno;
	t1 = std::chrono::high_resolution_clock::now();
	nalezeno = 0;
	for (int i = 0; i < vyhledavani.size(); i++) {
		if (LinearniVyhledavani(cisla, vyhledavani[i])) {
			nalezeno++;
		}
	}
	t2 = std::chrono::high_resolution_clock::now();
	prodleva = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	std::cout << std::endl << "Bylo nalezeno " << nalezeno << " cisel z " << vyhledavani.size() << "." << std::endl;
	std::cout << "Vyhledavani celkem zabralo " << prodleva / 1000 << " milisekund" << std::endl;

	// Binarni vyhledavani
	std::cout << std::endl << std::endl << "Stisknete libovolnou klavesu pro spusteni binarniho vyhledavani..." << std::endl;
	system("pause>nul");

	t1 = std::chrono::high_resolution_clock::now();
	nalezeno = 0;
	for (int i = 0; i < vyhledavani.size(); i++) {
		if (BinarniVyhledavani(cisla, vyhledavani[i])) {
			nalezeno++;
		}
	}
	t2 = std::chrono::high_resolution_clock::now();
	prodleva = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	std::cout << std::endl << "Bylo nalezeno " << nalezeno << " cisel z " << vyhledavani.size() << "." << std::endl;
	std::cout << "Vyhledavani celkem zabralo " << prodleva / 1000 << " milisekund" << std::endl;


	// Interpolacni vyhledavani
	std::cout << std::endl << std::endl << "Stisknete libovolnou klavesu pro spusteni interpolacniho vyhledavani..." << std::endl;
	system("pause>nul");

	t1 = std::chrono::high_resolution_clock::now();
	nalezeno = 0;
	for (int i = 0; i < vyhledavani.size(); i++) {
		if (InterpolacniVyhledavani(cisla, vyhledavani[i])) {
			nalezeno++;
		}
	}
	t2 = std::chrono::high_resolution_clock::now();
	prodleva = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();
	std::cout << std::endl << "Bylo nalezeno " << nalezeno << " cisel z " << vyhledavani.size() << "." << std::endl;
	std::cout << "Vyhledavani celkem zabralo " << prodleva / 1000 << " milisekund" << std::endl;


	system("pause>nul");
	return 0;
}