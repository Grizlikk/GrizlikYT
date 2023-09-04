#include <iostream>

// Definice tridy
class Ovoce {
public:
	// Verejny atribut (promenna) "barva"
	std::string barva;

	// Verejna metoda (funkce) "SpadniZeStromu"
	void SpadniZeStromu() {
		std::cout << "Ovoce spadlo ze stromu.";
	}
};

int main() {
	// Vytvoreni objektu "jablko" a "hruska" podle tridy "Ovoce"
	Ovoce jablko;
	Ovoce hruska;

	// Nastaveni atributu (promenne) "barva" u objektu "jablko" na hodnotu "cervena"
	jablko.barva = "cervena";

	// Spusteni metody (funkce) s nazvem "SpadniZeStromu" u objektu "hruska"
	hruska.SpadniZeStromu();

	return 0;
}