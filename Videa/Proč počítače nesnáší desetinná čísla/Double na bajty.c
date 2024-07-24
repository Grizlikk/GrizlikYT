#include <stdio.h>

int main() {
	double input;
	printf("Zadejte cislo: ");
	scanf_s("%lf", &input);

	printf("\nCiselna hodnota: %0.25lf\nBinarni hodnota: ", input);
	for (char i = sizeof(input) - 1; i >= 0; i--) {
		unsigned char* part = ((unsigned char*)&input) + i;
		for (char j = 7; j >= 0; j--) {
			printf("%d", (*part >> j) & 1);
		}
		printf(" ");
	}
	system("pause>nul");
	return 0;
}