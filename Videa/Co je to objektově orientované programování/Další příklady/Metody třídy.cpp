#include <iostream>

class Automobil {
public:
	// Verejne atributy (promenne) uvnitr tridy s nazvem "Automobil"
	std::string znacka;
	int najeteKilometry;
	int stariAuta;

	// Verejna metoda (funkce) uvnitr tridy
	void Zatroubit() {
		std::cout << "tuuuuuuuuuuuuuuuuuuuuuuuuuut";
	}
};

int main() {
	// Vytvoreni objektu s nazvem "auto1" a definice atributu (promennych)
	Automobil auto1;
	auto1.znacka = "BMW";
	auto1.najeteKilometry = 250000;
	auto1.stariAuta = 10;

	// Vytvoreni objektu s nazvem "auto2" a definice atributu (promennych)
	Automobil auto2;
	auto2.znacka = "Toyota";
	auto2.najeteKilometry = 10000;
	auto2.stariAuta = 2;

	// Testovaci vypis
	std::cout << "Auto1\nZnacka: " << auto1.znacka << "\tNajete kilometry: " << auto1.najeteKilometry << " km \tStari auta: " << auto1.stariAuta << " let" << std::endl << std::endl;
	std::cout << "Auto2\nZnacka: " << auto2.znacka << "\tNajete kilometry: " << auto2.najeteKilometry << " km \tStari auta: " << auto2.stariAuta << " let" << std::endl;

	// Volani metody (funkce) uvnitr tridy
	// Metody take dokazi prijimat parametry, stejne jako klasicke funkce
	std::cout << "\nZkouska klaxonu prvniho auta: ";
	auto1.Zatroubit();
	std::cout << "\nZkouska klaxonu druheho auta: ";
	auto2.Zatroubit();

	std::cout << std::endl;

	return 0;
}