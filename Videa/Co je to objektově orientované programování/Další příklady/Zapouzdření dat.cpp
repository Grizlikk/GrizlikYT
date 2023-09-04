#include <iostream>

class BankovniUcet {
private:
	// Vytvoreni privatnich atributu (promennych)
	std::string cisloUctu;
	double zustatek;

public:
	// Konstruktor tridy - "Funkce", ktera se zavola pri vytvoreni noveho objektu
	BankovniUcet(std::string cislo, double penize = 0) {
		cisloUctu = cislo;
		zustatek = penize;
	}

	// Pozadavky pro vypis
	std::string VypisCisloUctu() {
		return cisloUctu;
	}

	double VypisZustatek() {
		return zustatek;
	}

	// Pozadavky pro praci s promennymi
	void UlozPenize(double castka) {
		zustatek += castka;
	}

	void VyberPenize(double castka) {
		zustatek -= castka;
	}
};

int main() {
	// Vytvoreni objektu tridy
	BankovniUcet HlavniUcet("51453", 1000);
	BankovniUcet SporiciUcet("98514"); // Zustatek neni specifikovany, takze se pouzije defaultni hodnota: 0

	// Testovaci vypisy
	std::cout << "Cislo hlavniho uctu: " << HlavniUcet.VypisCisloUctu();
	std::cout << "\nZustatek hlavniho uctu: " << HlavniUcet.VypisZustatek();
	std::cout << "\nCislo sporiciho uctu: " << SporiciUcet.VypisCisloUctu();
	std::cout << "\nZustatek sporiciho uctu: " << SporiciUcet.VypisZustatek();

	// Prevod 250 penez z hlavniho uctu na sporici ucet
	HlavniUcet.VyberPenize(250);
	SporiciUcet.UlozPenize(250);

	// Testovaci vypis
	std::cout << "\n\nNovy zustatek hlavniho uctu: " << HlavniUcet.VypisZustatek();
	std::cout << "\nNovy zustatek sporiciho uctu: " << SporiciUcet.VypisZustatek() << std::endl;

	return 0;
}