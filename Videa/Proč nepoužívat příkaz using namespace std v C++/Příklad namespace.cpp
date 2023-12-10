#include <iostream>

namespace cisla {
	int Soucet(int a, int b) {
		return a + b;
	}

	int Rozdil(int a, int b) {
		return a - b;
	}
}

namespace text {
	char PrvniZnak(char text[]) {
		return text[0];
	}

	bool JeCislo(char znak) {
		return isdigit(znak);
	}
}

int main() {
	std::cout << cisla::Soucet(5, 3);
	std::cout << std::endl;
	std::cout << text::JeCislo('4');

	return 0;
}