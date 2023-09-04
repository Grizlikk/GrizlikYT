#include <iostream>

// Obecna trida pro jakekoliv vozidlo
class Vozidlo {
public:
	// Verejne atributy (promenne), ktere se prenesou na jakekoliv podtridy
	std::string znacka;
	int najeteKilometry;
	int stariVozidla;

	// Verejna metoda (funkce), ktera se prenese na jakekoliv podtridy
	void Zatroubit() {
		std::cout << "tuuuuuuuuuuuuuuuuuuuuuuuuuut";
	}
};

// Trida "Automobil" zdedi veskery obsah tridy "Vozidlo"
class Automobil : public Vozidlo {
public:
	int pocetMist;
};

// Trida "Dodavka" zdedi veskery obsah tridy "Vozidlo"
class Dodavka : public Vozidlo {
public:
	int velikostNakladovehoProstoru;
	std::string naklad;

	void NalozNaklad(std::string nakladKNalozeni) {
		naklad += nakladKNalozeni + ", ";
	}
};

// Trida "Autobus" zdedi veskery obsah tridy "Vozidlo"
class Autobus : public Vozidlo {
public:
	int pocetSedadel;
	std::string nazevTrasy;

	// Definice konstruktoru tridy pro tridy "Autobus"
	Autobus(std::string znack, int najeto, int stari, int sedadla, std::string trasa) {
		znacka = znack;
		najeteKilometry = najeto;
		stariVozidla = stari;
		pocetSedadel = sedadla;
		nazevTrasy = trasa;
	}
};

int main() {
	// Vytvoreni objektu tridy "Automobil"
	Automobil osobniAuto;
	osobniAuto.znacka = "BMW";
	osobniAuto.najeteKilometry = 50000;
	osobniAuto.stariVozidla = 3;
	osobniAuto.pocetMist = 4;

	// Vytvoreni objektu tridy "Dodavka"
	Dodavka nakladniDodavka;
	nakladniDodavka.znacka = "Volkswagen";
	nakladniDodavka.najeteKilometry = 200000;
	nakladniDodavka.stariVozidla = 10;
	nakladniDodavka.velikostNakladovehoProstoru = 8;
	nakladniDodavka.NalozNaklad("Rohliky z Kauflandu");

	// Vytvoreni objektu tridy "Autobus" podle konstruktoru
	Autobus dalkovyAutobus("Fiat", 700000, 10, 50, "Praha-Brno");


	// Testovaci vypis auta
	std::cout << "Osobni auto\nZnacka: " << osobniAuto.znacka << "\tNajete kilometry: " << osobniAuto.najeteKilometry << " km\tStari auta: " << osobniAuto.stariVozidla
		<< " let\tPocet mist: " << osobniAuto.pocetMist << std::endl;

	std::cout << "Zkouska klaxonu auta: ";
	osobniAuto.Zatroubit();

	// Testovaci vypis dodavky
	std::cout << "\n\nNakladni dodavka\nZnacka: " << nakladniDodavka.znacka << "\tNajete kilometry : " << nakladniDodavka.najeteKilometry << " km\tStari dodavky: " << nakladniDodavka.stariVozidla
		<< " let\tNakladovy prostor: " << nakladniDodavka.velikostNakladovehoProstoru << " m2\tNalozeny naklad: " << nakladniDodavka.naklad << std::endl;

	std::cout << "Zkouska klaxonu dodavky: ";
	nakladniDodavka.Zatroubit();

	// Testovaci vypis autobusu
	std::cout << "\n\nDalkovy autobus\nZnacka: " << dalkovyAutobus.znacka << "\tNajete kilometry: " << dalkovyAutobus.najeteKilometry << " km\tStari autobusu: " << dalkovyAutobus.stariVozidla
		<< " let\tPocet sedadel: " << dalkovyAutobus.pocetSedadel << " sedadel\tTrasa: " << dalkovyAutobus.nazevTrasy << std::endl;

	std::cout << "Zkouska klaxonu autobusu: ";
	dalkovyAutobus.Zatroubit();

	std::cout << std::endl << std::endl;
	return 0;
}