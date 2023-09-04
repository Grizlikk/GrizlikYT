#include <iostream>

// Definice tridy
class BankovniUcet {
protected:
	// Atribut (promenna) oznaceny jako "protected" bude pristupny pouze z teto tridy a dalsich podtrid
	double zustatekNaUctu = 0;

public:
	// Metody (funkce) pro manipulaci s atributem (promennou) "zustatekNaUctu"
	void UlozPenize(double castka) {
		zustatekNaUctu += castka;
	}

	void VyberPenize(double castka) {
		zustatekNaUctu -= castka;
	}

	double ZiskejZustatek() {
		return zustatekNaUctu;
	}
};

// Definice podtridy "SporiciUcet", ktera ziska veskery obsah ze tridy "BankovniUcet"
class SporiciUcet : public BankovniUcet {
public:
	// Metoda (funkce) dokaze pristupovat k atributu (promenne) "zustatekNaUctu", protoze je oznaceny jako "protected"
	double ZustatekSporicihoUctu() {
		return zustatekNaUctu;
	}
};

int main() {
	// Vytvoreni objektu "hlavniUcet" podle tridy "BankovniUcet" a testovaci vypis
	BankovniUcet hlavniUcet;
	hlavniUcet.UlozPenize(100);
	std::cout << "Zustatek: " << hlavniUcet.ZiskejZustatek() << std::endl;
	hlavniUcet.VyberPenize(50);
	std::cout << "Novy zustatek: " << hlavniUcet.ZiskejZustatek() << std::endl;

	// Vytvoreni objektu "hlavniSporiciUcet" podle tridy "SporiciUcet" a testovaci vypis
	SporiciUcet hlavniSporiciUcet;
	hlavniSporiciUcet.UlozPenize(100);
	std::cout << "\nZustatek sporiciho uctu: " << hlavniSporiciUcet.ZustatekSporicihoUctu() << std::endl;

	return 0;
}