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

using text::PrvniZnak;
using std::cout;

namespace t = text;

int main() {
	cout << cisla::Soucet(9, 4);
	char text[] = "Ahoj :D";
	cout << PrvniZnak(text);
	cout << t::JeCislo('8');

	return 0;
}