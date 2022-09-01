#include <iostream>
using namespace std;

int main() {
	// Příprava proměnných
	int ram;
	string text, pole[25000];

	// Zadání množství průchodů pro zabírání paměti
	cout << "Zadejte mnozstvi pruchodu: ";
	cin >> ram;

	// C++ nedovoluje absurně velká pole
	if (ram > 25000 || ram < 1) {
		cout << "C++ neni rozbity jako python, takze hodnota musi byt od 1 do 25 000!\n";
		system("pause");
		return 0;
	}

	// Vytvoření proměnné text, která má 200000 × 36 B, neboli 720 kB
	for (int i = 0; i < 20000; i++) {
		text = text + "abcdefghijklmnopqrstuvwxyz123456789";
	}

	// Kopírování proměnné do pole, kolikrát zvolí uživatel
	for (int i = 0; i < ram; i++) {
		pole[i] = text;
	}

	// Konec programu
	system("pause");
	return 0;
}