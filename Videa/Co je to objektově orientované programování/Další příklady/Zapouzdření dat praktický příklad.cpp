#include <iostream>

class Obdelnik {
private:
	// Rozmery obdelniku jsou privatni, aby je nebylo mozno upravovat
	double sirka;
	double vyska;

	// Prevod na metry
	double StopyNaMetry(double stopy) {
		return stopy * 0.3048;
	}

	// Prevod na stopy
	double MetryNaStopy(double metry) {
		return metry * 3.28084;
	}

	// Prevod na stopy ctverecni
	double MetryCtvNaStopyCtv(double metry) {
		// Ctverecni jednotky jsou na druhou, takze se v podstate provedou dva prevody
		return MetryNaStopy(MetryNaStopy(metry));
	}

public:
	// Konstruktor tridy, kde se zadavaji hodnoty VE STOPACH
	Obdelnik(double length, double height) {
		// Konstruktor prevede hodnoty na metry
		sirka = StopyNaMetry(length);
		vyska = StopyNaMetry(height);
	}

	// Vypocty v metrech, ale vypis VE STOPACH
	double Perimeter() {
		return MetryNaStopy(2 * (sirka + vyska));
	}

	double Area() {
		return MetryCtvNaStopyCtv(sirka * vyska);
	}
};

int main() {
	// Vytvoreni obdelniku s sirkou 8 stop a vyskou 5 stop
	Obdelnik obdelnik1(8, 5);

	// Testovaci vypis
	std::cout << "Obvod obdelniku je: " << obdelnik1.Perimeter();
	std::cout << "\nObsah obdelniku je: " << obdelnik1.Area() << std::endl;

	return 0;
}