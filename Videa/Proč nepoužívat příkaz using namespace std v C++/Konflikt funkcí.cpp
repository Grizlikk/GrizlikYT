#include <iostream>

namespace cisla {
	int Soucet(int a, int b) {
		std::cout << "A ";
		return a + b;
	}
}

namespace matematika {
	double Soucet(double a, double b) {
		std::cout << "B ";
		return a + b;
	}
}

using namespace cisla;
using namespace matematika;

int main() {
	std::cout << Soucet(8, 9.5);

	return 0;
}