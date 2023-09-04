#include <iostream>

class Vozidlo {
// Pristupne zevnitr i zvenku tridy a ve vsech podtridach
public:
	std::string znacka;

// Pristupne pouze zevnitr tridy, nepristupne zvenku tridy a v podtridach
private:
	int najeteKilometry;

// Pristupne zevnitr tridy a v podtridach, nepristupne zvenku tridy
protected:
	int stariVozidla;
};

// Podtrida tridy "Vozidlo"
class Automobil : public Vozidlo {
public:
	// Testovaci metoda (funkce) pro nastaveni atributu (promennych)
	void nastaveni() {
		// Z podtridy mohu pristupovat pouze k "public" a "protected"
		znacka = "Audi";
		stariVozidla = 5;

		//najeteKilometry = 20000;			Error! Nejde ziskat pristup k promenne "najeteKilometry"
	}
};

int main() {
	Vozidlo obecneVozidlo;
	// Zvenku mohu pristupovat pouze k "public"
	obecneVozidlo.znacka = "BMW";

	Automobil osobniAutomobil;
	// Zvenku mohu pristupovat pouze k "public"
	osobniAutomobil.znacka = "Audi";

	// Zavolane metody (funkce) mohou upravovat atributy (promenne) nastavene jako "protected", zvenku tridy je vsak nemozne tyto promenne upravovat
	osobniAutomobil.nastaveni();
	
	std::cout << "Obecne vozidlo\nZnacka: " << obecneVozidlo.znacka;
	std::cout << "\n\nOsobni automobil\nZnacka: " << osobniAutomobil.znacka;

	std::cout << std::endl << std::endl;

	return 0;
}