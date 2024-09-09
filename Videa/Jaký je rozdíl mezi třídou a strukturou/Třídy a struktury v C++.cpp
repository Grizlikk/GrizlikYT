#include <iostream>

// Definice nove tridy "Souradnice"
class Souradnice {
// Modifikator pristupu, aby byl obsah tridy pristupny i ze zbytku kodu
public:
	int x, y, z;

	// Tridy i struktury mohou v C++ obsahovat nejen promenne, ale i funkce, ktere mohou s promennymi pracovat
	void VypisPozici() {
		std::cout << "x: " << x << "\ty: " << y << "\tz: " << z;
	}
};

int main() {
	Souradnice poziceHrace;
	poziceHrace.x = 5;
	poziceHrace.y = 1;
	poziceHrace.z = 10;

	// Volani funkce pro objekt "poziceHrace"
	poziceHrace.VypisPozici();
	return 0;
}