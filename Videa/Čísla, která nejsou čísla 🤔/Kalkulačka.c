#include <stdio.h>
#include <math.h>

int main() {
	float num1, num2, result = 0;
	char operation;

	printf("Zadejte operaci (+ - * / s p): ");
	scanf_s(" %c", &operation);
	printf("Zadejte prvni cislo: ");
	scanf_s("%f", &num1);
	if (operation != 's') {
		printf("Zadejte druhe cislo: ");
		scanf_s("%f", &num2);
	}

	switch (operation) {
	case '+': result = num1 + num2; break;
	case '-': result = num1 - num2; break;
	case '*': result = num1 * num2; break;
	case '/': result = num1 / num2; break;
	case 's': result = sqrtf(num1); break;
	case 'p': result = powf(num1, num2); break;
	}

	printf("\nCiselna hodnota: %0.50f\nBinarni hodnota: ", result);
	for (char i = sizeof(result) - 1; i >= 0; i--) {
		unsigned char* part = ((unsigned char*)&result) + i;
		for (char j = 7; j >= 0; j--) {
			printf("%d", (*part >> j) & 1);
		}
		printf(" ");
	}
	system("pause>nul");
	return 0;
}