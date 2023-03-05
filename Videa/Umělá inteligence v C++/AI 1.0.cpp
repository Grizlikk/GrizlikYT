#include <iostream>
#include <string>
#include <fstream>


// Funkce pro overeni, jestli je promenna cislo
bool JeCislo(std::string cislo) {
	// Prochazeni promenne a kontrola pro text
	for (int i = 0; i < cislo.length(); i++) {
		if (!isdigit(cislo[i])) {
			// Pokud je kdekoliv v promenne text, promenna neni cislo
			return false;
		}
	}
	return true;
}


// Funkce pro zadani cisla v urcitem rozsahu
int ZadejCisloRozsah(std::string vypis = "Zadej cislo: ", std::string error = "Error! Zadejte platnou hodnotu: ", int min = -2147483648, int max = 2147483647) {
	std::string vstup;
	std::cout << vypis;
	std::cin >> vstup;

	while (true) {
		// Pokud je "vstup" cislo a je v platnem rozsahu, vrati se jako vystup funkce
		if ((JeCislo(vstup)) && (std::stoi(vstup) >= min) && (std::stoi(vstup) <= max)) {
			return std::stoi(vstup);
		}
		// Pokud podminka neplati, vypise se chybova hlaska a proces se zopakuje
		std::cout << error;
		std::cin >> vstup;
	}

}


// Funkce pro zjisteni, jestli je pole prazdne
bool PrazdnePole(int pole[], int velikost) {
	// Pokud jsou vsechny hodnoty v poli nastavene na cislo 0, pole je prazdne
	for (int i = 0; i <= velikost; i++) {
		if (pole[i] != 0) {
			return false;
		}
	}
	return true;
}


// Funkce pro kontrolu vycerpani moznosti odpovedi
void KontrolaMoznosti(int PoleOdpovedi[], int velikost = 9) {
	if (PrazdnePole(PoleOdpovedi, velikost)) {
		for (int i = 0; i <= velikost; i++) {
			PoleOdpovedi[i] = i + 1;
		}
	}
}


// Funkce pro spusteni jednoho kola hry proti generatoru nahodnych cisel
void HraProtiRng(int PoleOdpovedi[][10]) {
	int pozice, vybraneodpovedi[50][2], kolo = 0, soucet = 0;

	while (true) {
		// Vybrani nahodne odpovedi
		do {
			pozice = rand() % 10;
		} while (PoleOdpovedi[soucet][pozice] == 0);

		
		// Zahrani odpovedi a ulozeni vybrane hodnoty
		vybraneodpovedi[kolo][0] = soucet;
		vybraneodpovedi[kolo][1] = pozice;
		soucet += PoleOdpovedi[soucet][pozice];
		if (soucet == 100) {
			return;
		}

		// RNG
		soucet += rand() % 10 + 1;
		if (soucet >= 100) {
			// Odstraneni spatnych odpovedi
			for (int i = 0; i <= kolo; i++) {
				PoleOdpovedi[vybraneodpovedi[i][0]][vybraneodpovedi[i][1]] = 0;
			}
			return;
		}
		kolo++;
	}
}


// Funkce pro prevod velkych pismen na male
std::string MalePismena(std::string text) {
	std::string vysledek = "";
	for (int i = 0; i < text.length(); i++) {
		vysledek += tolower(text[i]);
	}
	return vysledek;
}



// Funkce pro vypsani naucenych hodnot
void VypisHodnot(int pole[][10]) {
	std::cout << std::endl;
	for (int i = 0; i < 100; i++) {
		std::cout << "[" << i << "] ";
		for (int j = 0; j < 10; j++) {
			if (pole[i][j] != 0) {
				std::cout << pole[i][j] << ";";
			}
			else {
				std::cout << ";";
			}
		} 
		std::cout << std::endl;
	}
}


int main() {
	// Vytvoreni promennych
	int odpovedi[100][10], soucet = 0, pozice;
	std::string volba;

	// Reset generatoru nahodnych cisel
	srand(time(NULL));

	// Zacatek je v batchi, jako easter egg na puvodni video (rozhodne ne proto, ze by se mi to nechtelo delat v C++) :)
	system("title Umela inteligence");
	system("color e");

	// Zadani poctu pruchodu treninku od uzivatele
	int trenink = ZadejCisloRozsah("Zadejte uroven treninku od 1 do 2 000 000 000: ", "Error! Zadejte platnou hodnotu: ", 1, 2000000000);

	// Generovani moznosti odpovedi
	std::cout << "Generuji moznosti odpovedi...";
	for (int i = 0; i < 100; i++) {
		for (int j = 0; j < 10; j++) {
			odpovedi[i][j] = j + 1;
		}
	}

	// Hrani her proti generatoru nahodnych cisel
	system("cls");
	for (int i = 1; i <= trenink; i++) {
		std::cout << "\nPostup: " << i << " z " << trenink;
		// Kontrola pro vycerpani moznosti
		for (int j = 0; j < 100; j++) {
			KontrolaMoznosti(odpovedi[j]);
		}

		// Spusteni jednoho kola hry
		HraProtiRng(odpovedi);
	}

	// Konec trenovani
	do {
		do {
			system("cls");
			std::cout << "Trenovani ukonceno\nZadejte A pro vypis naucenych hodnot, zadejte B pro hrani hry, zadejte C pro ukonceni programu: ";
			std::cin >> volba;
			volba = MalePismena(volba);
			if (volba == "c") {
				std::cout << "Opravdu chcete skoncit? Napiste ANO pro potvrzeni: ";
				std::cin >> volba;
				volba = (MalePismena(volba) == "ano") ? "c" : "ne";
			}
		} while (volba != "a" && volba != "b" && volba != "c");

		if (volba == "a") {
			VypisHodnot(odpovedi);
			system("pause>nul");
		}

		if (volba == "b") {
			while (soucet < 100) {
				system("cls");
				// Vybrani nahodne odpovedi
				do {
					pozice = rand() % 10;
				} while (odpovedi[soucet][pozice] == 0);

				// Tah pocitace
				std::cout << "Pocitac zahral: " << odpovedi[soucet][pozice];
				soucet += odpovedi[soucet][pozice];
				std::cout << std::endl << "Aktualni soucet: " << soucet;

				if (soucet >= 100) {
					std::cout << "\n\nPocitac jako prvni dosahl souctu 100. Prohrali jste.";
					break;
				}

				// Tah uzivatele
				soucet += ZadejCisloRozsah("\nVas tah: ", "Neplatna hodnota! Zadejte platnou hodnotu: ", 1, 10);
				if (soucet >= 100) {
					std::cout << "\nGratulace! Dosahli jste souctu 100. Vyhrali jste.";
				}
			}
			system("pause>nul");
			soucet = 0;
		}
	} while (volba != "c");
	system("cls");
	std::cout << "Dekujeme za pouzivani programu.\nStisknete libovolnou klavesu pro konec.";
	system("pause>nul");
	return 0;
}