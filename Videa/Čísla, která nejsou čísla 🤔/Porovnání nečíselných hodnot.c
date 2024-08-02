#include <stdio.h>

int main() {
	float a = 1, b = 0;
	float values[] = { -a / b, -b, b, a, a / b * b, a / b };

	for (int i = 0; i < 6; i++) {
		a = values[i];
		for (int j = 0; j < 6; j++) {
			b = values[j];

			printf("%f > %f:  \t%s\n", a, b, (a > b) ? "true" : "false");
			printf("%f == %f: \t%s\n", a, b, (a == b) ? "true" : "false");
			printf("%f < %f:  \t%s\n", a, b, (a < b) ? "true" : "false");
			printf("\n");
		}
		printf("\n");
	}

	system("pause>nul");
	return 0;
}