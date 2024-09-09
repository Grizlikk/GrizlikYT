#include <iostream>

struct Souradnice {
public:
	int x, y, z;
};

// Funkce prebira strukturu/tridu jako parametr
void VypisPozici(Souradnice souradnice) {
	std::cout << "x: " << souradnice.x << "\ty: " << souradnice.y << "\tz: " << souradnice.z;
}

int main() {
	Souradnice pozice1;
	pozice1.x = 5;
	pozice1.y = 1;
	pozice1.z = 10;
	// Prirazeni jedne promenne do druhe vzdy vytvari kopii dat, nezavisle na tom, jestli je "Souradnice" trida nebo struktura
	Souradnice pozice2 = pozice1;

	VypisPozici(pozice1);
	VypisPozici(pozice2);
	pozice1.x = 25;
	VypisPozici(pozice1);
	VypisPozici(pozice2);
}