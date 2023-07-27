#include <iostream>
#include <array>

int main() {
	std::array<int, 10> cisla = { 4, 9, 6, 0, 1, 8, 7, 3, 2, 5 };
	std::cout << "Obsah pole: ";
	for (int i = 0; i < cisla.size(); i++) {
		std::cout << cisla[i];
		if (i != cisla.size() - 1) {
			std::cout << ", ";
		}
	}
	for (int i = 0; i < cisla.size(); i++) {
		for (int j = 1; j < cisla.size(); j++) {
			if (cisla[j - 1] > cisla[j]) {
				cisla[j - 1] = cisla[j - 1] ^ cisla[j];
				cisla[j] = cisla[j - 1] ^ cisla[j];
				cisla[j - 1] = cisla[j - 1] ^ cisla[j];
			}
		}
	}
	std::cout << std::endl << "Obsah pole: ";
	for (int i = 0; i < cisla.size(); i++) {
		std::cout << cisla[i];
		if (i != cisla.size() - 1) {
			std::cout << ", ";
		}
	}
	return 0;
}