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


// Funkce pro soucet vsech hodnot v poli
int Suma(int pole[], int delka) {
	int sum = 0;
	for (int i = 0; i < delka; i++) {
		sum += pole[i];
	}
	return sum;
}


// Funkce pro vypsani naucenych hodnot
void VypisHodnot(int pole[][10]) {
	std::cout << std::endl;
	for (int i = 0; i < 100; i++) {
		std::cout << "[" << i << "]\t";
		for (int j = 0; j < 10; j++) {
			if (pole[i][j] == 10) {
				std::cout << "10";
			}
			else if (pole[i][j] != 0) {
				std::cout << pole[i][j] << ";";
			}
			else {
				std::cout << ";";
			}
		} 
		std::cout << std::endl;
	}
}


// Funkce pro zjisteni, jestli se nekde v textu nachazi konkretni znak
bool ZnakVTextu(std::string text, char znak) {
	for (int i = 0; i < text.length(); i++) {
		if (text[i] == znak) {
			return true;
		}
	}
	return false;
}


// Funkce pro overeni, jestli soubor existuje
bool ExistujeSoubor(std::string soubor, std::string error = "") {
	std::ifstream infile(soubor);
	if (!infile.good()) {
		std::cout << error;
	}
	return infile.good();
}


// Funkce pro precteni jednoho radku ze souboru
std::string PrectiRadek(std::string soubor, int radek = 1) {
	std::string r;
	std::ifstream s(soubor);
	// Cyklus prochazi radky tak dlouho, nez narazi na pozadovany radek
	for (int i = 0; i < radek; i++) {
		std::getline(s, r);
	}
	return r;
}


// Funkce pro overeni, jestli je soubor platny
bool PlatnySoubor(std::string soubor, std::string error = "") {
	// Kontrola pro pocatecni text
	if (PrectiRadek(soubor) != "zcelanahodnytext,kteRymusIbytnazaCatKukazdehoplatnehosouboRu,abysezvysilacelkOvabLbuvzdornostceLehoprogramu") {
		std::cout << error;
		return false;
	}
	
	// Kontrola pro konec souboru
	int radky = 0;
	while (PrectiRadek(soubor, radky) != "zcelanahodnytext,kteRymusIbytnakonCiKazdehoplatnehosouboRu,abysezvysilacelkOvabLbuvzdornostceLehoprogramu") {
		radky++;
		if (radky > 103) {
			std::cout << error;
			return false;
		}
	}
	if (radky != 103) {
		std::cout << error;
		return false;
	}

	// Kontrola pro posledni hodnotu v radku
	int soucetradku = 0, soucetsouboru = 0;
	std::string radek;
	// Procházení souboru po řádcích
	for (int i = 2; i < 102; i++) {
		radek = PrectiRadek(soubor, i);
		for (int j = 0; j < 11; j++) {
			soucetradku += radek[j] - 48;
		}
		// Pokud poslední hodnota v řádku není rovna souctu radku % [hodnota], radek je neplatny
		if (radek[10] - 48 != (soucetradku - radek[10] + 48) % (PrectiRadek(soubor, 102)[17] - 48)) {
			std::cout << error;
			return false;
		}
		soucetsouboru += soucetradku;
		soucetradku = 0;
	}

	// Kontrola kontrolni hodnoty
	for (int i = 0; i < 17; i++) {
		if (PrectiRadek(soubor, 102)[i] != "KontrolniHodnota:"[i]) {
			std::cout << error;
			return false;
		}
	}
	std::string delka;
	for (int i = 18; i < PrectiRadek(soubor, 102).length(); i++) {
		delka += PrectiRadek(soubor, 102)[i];
	}
	if (!JeCislo(delka)) {
		std::cout << error;
		return false;
	}
	if (std::stoi(delka) != radky + soucetsouboru) {
		std::cout << error;
		return false;
	}
	return true;
}


// Funkce pro precteni dat ze souboru
void NactiSoubor(std::string soubor, int PoleOdpovedi[][10]) {
	// Prochazeni souboru po radcich, kazdy radek obsahuje 10 ulozenych hodnot
	for (int i = 2; i < 102; i++) {
		for (int j = 0; j < 10; j++) {
			// Pokud je dana hodnota na danem radku 1, odpovidajici pozice je rovna sve hodnote, pokud je tam 0, pozice je 0
			// Napriklad: Na 5. radku je 7. hodnota 1, takze odpovedi[2][7] = 8
			PoleOdpovedi[i - 2][j] = (PrectiRadek(soubor, i)[j] == '1') ? j + 1 : 0;
		}
	}
}


// Funkce pro ulozeni naucenych hodnot do souboru
void UlozSoubor(std::string soubor, int PoleOdpovedi[][10]) {
	std::ofstream file(soubor);
	int soucetradku, soucetsouboru = 0, kontrola = rand() % 4 + 2;
	file << "zcelanahodnytext,kteRymusIbytnazaCatKukazdehoplatnehosouboRu,abysezvysilacelkOvabLbuvzdornostceLehoprogramu\n";
	for (int i = 0; i < 100; i++) {
		soucetradku = 0;
		for (int j = 0; j < 10; j++) {
			if (PoleOdpovedi[i][j] != 0) {
				file << 1;
				soucetsouboru++;
				soucetradku++;
			}
			else {
				file << 0;
			}
		}
		file << soucetradku % kontrola << "\n";
		soucetsouboru += soucetradku % kontrola;
	}
	file << "KontrolniHodnota:" << kontrola << soucetsouboru + 103 << "\nzcelanahodnytext,kteRymusIbytnakonCiKazdehoplatnehosouboRu,abysezvysilacelkOvabLbuvzdornostceLehoprogramu";
	file.close();
}

int main() {
	// Vytvoreni promennych
	int odpovedi[100][10], soucet = 0, pozice;
	std::string volba, nactenisouboru, ulozenisouboru;

	// Reset generatoru nahodnych cisel
	srand(time(NULL));

	// Zacatek je v batchi, jako easter egg na puvodni video (rozhodne ne proto, ze by se mi to nechtelo delat v C++) :)
	system("title Umela inteligence");
	system("color e");

	// Nacteni moznosti odpovedi
	do {
		std::cout << "Chcete nacist naucena data ze souboru? (ANO/NE): ";
		std::cin >> nactenisouboru;
		nactenisouboru = MalePismena(nactenisouboru);
	} while (nactenisouboru != "ano" && nactenisouboru != "ne");

	if (nactenisouboru == "ano") {
		// Nacitani dat ze souboru
		do {
			std::cout << "Zadejte nazev souboru: ";
			std::cin >> nactenisouboru;
		} while (!ExistujeSoubor(nactenisouboru, "Error! Soubor neexistuje\n") || !PlatnySoubor(nactenisouboru, "Error! Soubor neni platny\n"));
		std::cout << "Nacitam data ze souboru \"" << nactenisouboru << "\"";
		NactiSoubor(nactenisouboru, odpovedi);

	}
	else {
		// Vygenerovani novych dat
		std::cout << "Generuji moznosti odpovedi...";
		for (int i = 0; i < 100; i++) {
			for (int j = 0; j < 10; j++) {
				odpovedi[i][j] = j + 1;
			}
		}
	}

	// Zadani poctu pruchodu treninku od uzivatele
	int trenink = ZadejCisloRozsah("\nZadejte uroven treninku od 0 do 2 000 000 000: ", "Error! Zadejte platnou hodnotu: ", 0, 2000000000);

	// Hrani her proti generatoru nahodnych cisel
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
			std::cout << "Trenovani ukonceno\nZadejte H pro hrani hry, V pro vypis naucenych hodnot, S pro ulozeni naucenych hodnot, K pro konec: ";
			std::cin >> volba;
			volba = MalePismena(volba);
			if (volba == "k") {
				std::cout << "Opravdu chcete skoncit? Napiste ANO pro potvrzeni: ";
				std::cin >> volba;
				volba = (MalePismena(volba) == "ano") ? "k" : "ne";
			}
		} while (!ZnakVTextu("hvsk", volba[0]));

		// Hra proti umele inteligenci
		if (volba == "h") {
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

		// Vypis hodnot
		if (volba == "v") {
			VypisHodnot(odpovedi);
			system("pause>nul");
		}

		// Ulozeni do souboru
		if (volba == "s") {
			std::cout << "Zadejte nazev souboru nebo zadejte \"KONEC\" pro zruseni: ";
			std::cin >> ulozenisouboru;
			if (ExistujeSoubor(ulozenisouboru)) {
				do {
					std::cout << "Soubor jmenem \"" << ulozenisouboru << "\" jiz existuje, chcete pokracovat? (ANO/NE): ";
					std::cin >> volba;
					volba = MalePismena(volba);
				} while (volba != "ano" && volba != "ne");
			}
			if (ulozenisouboru != "KONEC" && volba != "ne") {
				std::cout << "Probiha ukladani...";
				UlozSoubor(ulozenisouboru, odpovedi);
			}
			std::cout << "\n\nUlozeni probehlo uspesne! Stiskem libovolne klavesy se vratite zpet...";
			system("pause>nul");
		}

	} while (volba != "k");
	system("cls");
	std::cout << "Dekujeme za pouzivani programu.\nStisknete libovolnou klavesu pro konec.";
	system("pause>nul");
	return 0;
}