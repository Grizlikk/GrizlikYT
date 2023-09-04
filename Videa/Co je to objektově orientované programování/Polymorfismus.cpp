#include <iostream>

// Definice tridy
class Zvire {
public:
	// Verejna metoda (funkce)
	void UdelejZvuk() {
		std::cout << "Zvire udelalo zvuk\n";
	}
};

// Vytvoreni tridy "Pes", ktera ziska veskery obsah ze tridy "Zvire"
class Pes : public Zvire {
public:
	// Nova definice metody (funkce) prepise definici ze tridy "Zvire"
	void UdelejZvuk() {
		std::cout << "Pes udelal: haf haf\n";
	}
};

// Vytvoreni tridy "Kocka", ktera ziska veskery obsah ze tridy "Zvire"
class Kocka : public Zvire {
public:
	// Nova definice metody (funkce) prepise definici ze tridy "Zvire"
	void UdelejZvuk() {
		std::cout << "Kocka udelala: mnau mnau\n";
	}
};

int main() {
	// Vytvoreni objektu podle trid
	Zvire obecneZvire;
	Pes pesDomaci;
	Kocka kockaObecnoObecna;

	// Testovaci vypis
	// Ackoliv se metody (funkce) jmenuji stejne, kazda dela neco jineho
	obecneZvire.UdelejZvuk();
	pesDomaci.UdelejZvuk();
	kockaObecnoObecna.UdelejZvuk();

	return 0;
}