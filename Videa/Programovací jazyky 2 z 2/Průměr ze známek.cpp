#include <iostream>
#include <string>
using namespace std;

int main() {
	string znamka;
	int zaci;
	float soucet = 0, chybi = 0;
	cout << "Zadejte pocet zaku ve tride: ";
	cin >> zaci;
	while (zaci < 1 or zaci > 30) {
		cout << "Zadejte platnou hodnotu: ";
		cin >> zaci;
	}
	for (int i = 0; i < zaci; i++) {
		cout << "Zadejte znamku: ";
		cin >> znamka;
		while (znamka != "1" and znamka != "2" and znamka != "3" and
			znamka != "4" and znamka != "5" and znamka != "n" and znamka != "N") {
			cout << "Zadejte platnou hodnotu: ";
			cin >> znamka;
		}
		if (znamka == "n" or znamka == "N") {
			chybi++;
			znamka = "0";
		}
		float znamkaInt = stoi(znamka);
		soucet = soucet + znamkaInt;
	}
	if (soucet != 0) {
		float vysledek = soucet / (zaci - chybi);
		cout << "Prumer tridy je: " << vysledek;
	}
	else {
		cout << "Ve tride bylo 0 zaku!";
	}
	cout << "\n\n";
	system("pause");
	return 0;
}


