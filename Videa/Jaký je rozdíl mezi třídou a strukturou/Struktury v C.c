#include <stdio.h>

// Definice nove struktury "Souradnice", ktera obsahuje 3 promenne
struct Souradnice {
	int x, y, z;
};

// Funkce, ktera prebira strukturu jako parametr
void VypisPozici(struct Souradnice souradnice) {
	printf("x: %d\ty: %d\tz: %d",souradnice.x,souradnice.y,souradnice.z);
}

int main() {
	// Vytvoreni struktury "poziceHrace"
	struct Souradnice poziceHrace;
	// Ulozeni hodnot do promennych ve strukture
	poziceHrace.x = 5;
	poziceHrace.y = 1;
	poziceHrace.z = 10;
	// Predani struktury funkci
	VypisPozici(poziceHrace);
	return 0;
}