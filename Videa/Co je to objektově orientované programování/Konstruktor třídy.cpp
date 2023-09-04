#include <iostream>

// Definice tridy
class Ovoce {
public:
	// Verejny atribut (promenna)
	std::string barva;

	// Konstruktor tridy - Funkce, ktera se zavola pri vytvoreni noveho objektu
	Ovoce(std::string barvaOvoce) {
		// Parametr "barvaOvoce", ktery prijme konstruktor se ulozi do atributu (promenne) "barva"
		barva = barvaOvoce;
	}

	// Verejna metoda (funkce)
	void SpadniZeStromu() {
		std::cout << "Ovoce spadlo ze stromu.";
	}
};

int main() {
	// Vytvoreni objektu a odeslani hodnot do parametru "barvaOvoce"
	Ovoce jablko("cervena");
	Ovoce hruska("zelena");

	// Testovaci vypis obsahu atributu (promennych)
	std::cout << "Barva jablka: " << jablko.barva << "\nBarva hrusky: " << hruska.barva << std::endl;

	hruska.SpadniZeStromu();

	return 0;
}