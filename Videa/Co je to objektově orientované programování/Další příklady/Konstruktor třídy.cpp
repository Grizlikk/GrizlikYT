#include <iostream>

class Automobil {
public:
	// Verejne atributy (promenne) uvnitr tridy s nazvem "Automobil"
	std::string znacka;
	int najeteKilometry;
	int stariAuta;

	// Konstruktor tridy, jedna se o "funkci" se stejnym nazvem jako samotna trida, ktera se zavola pri vytvoreni noveho objektu
	Automobil(std::string znack, int najeto, int stari) {
		// Do atributu (promennych) se ulozi hodnoty, ktere konstruktor prijme jako parametry
		znacka = znack;
		najeteKilometry = najeto;
		stariAuta = stari;
	}
};

int main() {
	// Vytvoreni objektu s nazvem "auto1" a predani parametru do konstruktoru tridy
	Automobil auto1("BMW", 250000, 10);

	// Vytvoreni objektu s nazvem "auto2" a predani parametru do konstruktoru tridy
	Automobil auto2("Toyota", 10000, 2);

	// Testovaci vypis
	std::cout << "Auto1\nZnacka: " << auto1.znacka << "\tNajete kilometry: " << auto1.najeteKilometry << " km \tStari auta: " << auto1.stariAuta << " let" << std::endl << std::endl;
	std::cout << "Auto2\nZnacka: " << auto2.znacka << "\tNajete kilometry: " << auto2.najeteKilometry << " km \tStari auta: " << auto2.stariAuta << " let" << std::endl;

	return 0;
}