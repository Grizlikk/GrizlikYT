#include <iostream>

// Definice tridy
class Automobil {
public:
	// Verejne atributy (promenne)
	int pocetSedadel;
	int najeteKilometry;
	int stariVozdila;

	// Verejna metoda (funkce)
	void Zatroubit() {
		std::cout << "tuuuuuuuuuuuuuuuuuuut";
	}
};

// Definice podtridy - Trida "Dodavka" ziska veskery obsah tridy "Automobil"
class Dodavka : public Automobil {
public:
	// K atributum (promennym) ze tridy "Automobil" se prida novy verejny atribut (promenna) s nazvem "velikostNakladovehoProstoru"
	int velikostNakladovehoProstoru;
};

int main() {
	// Vytvoreni objektu podle tridy "Automobil" a nastaveni atriubutu
	Automobil auto1;
	auto1.pocetSedadel = 2;
	auto1.najeteKilometry = 25000;

	Automobil auto2;
	auto2.pocetSedadel = 4;
	auto2.najeteKilometry = 150000;

	// Vytvoreni objektu podle tridy "Dodavka", ktery bude obsahovat vsechny atributy (promenne) a metody (funkce) ze tridy "Automobil"
	Dodavka dodavka1;
	dodavka1.stariVozdila = 4;

	return 0;
}