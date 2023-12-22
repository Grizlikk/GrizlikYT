#include <iostream>

int main() {
	srand(time(NULL));
	int pocet;
	std::cout << "Zadejte pocet emailu k vygenerovani: ";
	std::cin >> pocet;

	std::string koncovky[] = { "@gmail.com","@email.com","@outlook.com","@seznam.cz" };
	std::cout << std::endl;
	for (int i = 0; i < pocet; i++) {
		std::string zacatek = "", prostredek = ".", konec = "";
		int opakovani;
		opakovani = rand() % 10 + 2;
		for (int i = 0; i < opakovani; i++) {
			zacatek += rand() % 26 + 97;
		}
		opakovani = rand() % 10 + 2;
		for (int i = 0; i < opakovani; i++) {
			prostredek += rand() % 26 + 97;
		}
		if (rand() % 2 == 0) {
			konec += '.';
			opakovani = rand() % 10 + 2;
			for (int i = 0; i < opakovani; i++) {
				konec += rand() % 26 + 97;
			}
		}
		std::cout << zacatek << prostredek << konec << koncovky[rand() % 4] << "\n";
	}
	std::cout << std::endl << std::endl;
	for (int i = 0; i < pocet; i++) {
		std::string heslo = "";
		int opakovani = rand() % 20 + 3;
		for (int i = 0; i < opakovani; i++) {
			heslo += tolower(rand() % 42 + 48);
		}
		std::cout << heslo << "\n";
	}
	return 0;
}