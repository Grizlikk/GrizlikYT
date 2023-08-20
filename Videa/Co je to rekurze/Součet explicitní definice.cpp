#include <iostream>

int SoucetCiselExplicitne(int hodnota) {
	// Explicitni definice pro hodnotu "n" je: "(n * (n + 1)) / 2"
	return (hodnota * (hodnota + 1)) / 2;
}

int main() {
	// Testovaci vypis
	for (int i = 0; i <= 20; i++) {
		std::cout << "[" << i << "]\t" << SoucetCiselExplicitne(i) << std::endl;
	}

	system("pause>nul");
	return 0;
}