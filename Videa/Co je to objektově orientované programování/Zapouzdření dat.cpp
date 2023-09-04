#include <iostream>

// Definice tridy
class BankovniUcet {
private:
	// Atribut (promenna) oznaceny jako "private" bude pristupny pouze z teto, ale zvenku tridy je k nemu nemozne pristupovat
	double zustatekNaUctu = 0;

public:
	// Verejne metody (funkce) pro manipulaci s atributem (promennou) "zustatekNaUctu"
	// Tyto metody (funkce) dovedou k atributu (promenne) pristupovat, protoze jsou ve stejne tride, jako je tento atribut (promenna) definovany
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

int main() {
	// Vytvoreni objektu
	BankovniUcet hlavniUcet;

	// Spusteni metody (funkce) "UlozPenize" pro objekt "hlavniUcet"
	hlavniUcet.UlozPenize(100);

	// Testovaci vypis a precteni atributu (promenne) "zustatekNaUctu" pomoci metody (funkce) "ZiskejZustatek"
	std::cout << "Zustatek: " << hlavniUcet.ZiskejZustatek() << std::endl;

	// Spusteni metody (funkce) "VyberPenize" pro objekt "hlavniUcet"
	hlavniUcet.VyberPenize(50);

	// Testovaci vypis a precteni atributu (promenne) "zustatekNaUctu" pomoci metody (funkce) "ZiskejZustatek"
	std::cout << "Novy zustatek: " << hlavniUcet.ZiskejZustatek() << std::endl;

	return 0;
}