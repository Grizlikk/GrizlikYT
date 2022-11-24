#include <stdio.h>
#include <math.h>
#include <stdlib.h>

int main() {
	float a, b, c;
	printf("Program na vypocet kvadraticke rovnice\nTvar kvadraticke rovnice: ax^2+bx+c=0\n");
	printf("Zadej koeficient a: ");
	scanf_s("%f", &a);
	printf("Zadej koeficient b: ");
	scanf_s("%f", &b);
	printf("Zadej koeficient c: ");
	scanf_s("%f", &c);

	//Výpočet diskriminantu
	float d = pow(b, 2) - 4 * a * c;

	//Vyřešení rovnice
	if (d < 0) {
		printf("Rovnice nema reseni v oboru realnych cisel");
	}
	if (d == 0) {
		float x = -b / (2 * a);
		printf("Rovnice ma jedno reseni \nx = %f", x);
	}
	if (d > 0) {
		float x1 = (-b + sqrt(d)) / (2 * a);
		float x2 = (-b - sqrt(d)) / (2 * a);
		printf("Rovnice ma dve reseni \nx1 = %f \nx2 = %f", x1, x2);
	}
	printf("\n\nStisknete enter pro konec programu...");
	system("pause>nul");
	return 0;
}


