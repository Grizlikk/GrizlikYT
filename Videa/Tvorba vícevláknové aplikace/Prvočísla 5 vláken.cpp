#include <iostream>
#include <thread>

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

void UlozeniPrvocisel(int min, int max, int pole[], int index, int konec) {
	// Pokud je dane cislo prvocislo, program ho ulozi do pole
	for (int i = min; i <= max; i++) {
		if (JePrvocislo(i)) {
			pole[index] = i;
			index++;
		}
	}
	// Za prvocisla ulozi ukoncovaci hodnotu -1 nebo -2
	pole[index] = konec;
}

void VypisPrvocisel(int pole[], int velikost) {
	// Vypisovani prvocisel
	int index = 0;
	while (index < velikost) {
		// Cislo -1 znamena ukonceni vypisu
		if (pole[index] == -1) {
			return;
		}
		// Cislo -2 znamena, ze po mezere nasleduji dalsi prvocisla
		if (pole[index] == -2) {
			// Program preskoci 0 a pokracuje ve vypisu u nasledujiciho prvocisla
			while (pole[index + 1] == 0) {
				index++;
			}
			index++;
		}
		// Pokud v poli neni ulozena 0, program danou hodnotu vypise
		if (pole[index] != 0) {
			std::cout << pole[index] << "\n";
			index++;
		}
	}
}

int main() {
	// Zadani limitu pro vypocet prvocisel
	int minimum, maximum, prvocisla[100000];
	std::cout << "Zadejte minimum pro vypocet prvocisel: ";
	std::cin >> minimum;
	std::cout << "Zadejte maximum pro vypocet prvocisel: ";
	std::cin >> maximum;

	// Vynulovani pole
	for (int i = 0; i < 100000; i++) {
		prvocisla[i] = 0;
	}

	// Vytvoreni 4 vlaken pro vypocet a 1 vlakna pro vypis
	// Kazdemu vlaknu pro vypocet je prirazena 1/4 rozsahu prvocisel a 1/4 pozic v poli vysledku
	std::thread vypocet1(UlozeniPrvocisel, minimum, maximum / 4, prvocisla, 0, -2);
	std::thread vypocet2(UlozeniPrvocisel, maximum / 4 + 1, maximum / 2, prvocisla, 25000, -2);
	std::thread vypocet3(UlozeniPrvocisel, maximum / 2 + 1, maximum / 4 * 3, prvocisla, 50000, -2);
	std::thread vypocet4(UlozeniPrvocisel, maximum / 4 * 3 + 1, maximum, prvocisla, 75000, -1);

	std::thread vypis(VypisPrvocisel, prvocisla, 100000);

	// Ukonceni behu vsech vlaken
	vypocet1.join();
	vypocet2.join();
	vypocet3.join();
	vypocet4.join();
	vypis.join();

	system("pause");
	return 0;
}