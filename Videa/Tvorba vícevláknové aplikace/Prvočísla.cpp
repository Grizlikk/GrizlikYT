#include <iostream>

bool JePrvocislo(int cislo) {
	// Kdyz je cislo mensi nez 2, tak to neni prvocislo
	if (cislo < 2) {
		return false;
	}
	// Kdyz je cislo delitelne jakymkoliv cislem, neni to prvocislo
	for (int i = 2; i < cislo; i++) {
		if (cislo % i == 0) {
			return false;
		}
	}
	return true;
}

int main() {
	// Zadani limitu pro vypocet prvocisel
	int pocet;
	std::cout << "Zadejte do kolika se maji prvocisla pocitat: ";
	std::cin >> pocet;

	// Pokud je dane cislo prvocislo, program ho vypise
	for (int i = 2; i <= pocet; i++) {
		if (JePrvocislo(i)) {
			std::cout << i << "\n";
		}
	}

	system("pause");
	return 0;
}