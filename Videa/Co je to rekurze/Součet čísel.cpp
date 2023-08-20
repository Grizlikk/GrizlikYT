#include <iostream>
#include <chrono>
#include <array>

// Definice aktualiho casu pro zkraceni zapisu prikazu
#define ted std::chrono::high_resolution_clock::now()
// Definice vypoctu doby behu programu
#define doba std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count()

int SoucetCiselRekurze(int hodnota) {
	// Pokud je hodnota mensi nez 1, vysledek je 0
	if (hodnota < 1) {
		return 0;
	}

	// Pokud je hodnota 1, vysledek je 1
	if (hodnota == 1) {
		return 1;
	}

	// Pokud je hodnota vetsi nez 1, vysledek je predchozi soucet + hodnota
	// Napriklad: "SoucetCiselRekurze(9) + 10"
	return SoucetCiselRekurze(hodnota - 1) + hodnota;
}

int SoucetCiselDefinice(int hodnota) {
	int soucet = 0;

	// Vypocitej soucet vsech predchazejicich cisel az po zadanou hodnotu
	for (int i = 1; i <= hodnota; i++) {
		soucet += i;
	}

	return soucet;
}

int SoucetCiselExplicitne(int hodnota) {
	// Explicitni definice pro hodnotu "n" je: "(n * (n + 1)) / 2"
	return (hodnota * (hodnota + 1)) / 2;
}

int main() {
	// Rekurzivni vypocet
	auto t1 = ted;
	for (int i = 0; i <= 3500; i++) {
		SoucetCiselRekurze(i);
	}
	auto t2 = ted;
	float prodleva = doba;

	std::cout << "Rekurzivni funkce celkem bezela: " << prodleva / 1000 << " milisekund" << std::endl << std::endl;

	// Rekurzivni vypocet s ukladanim mezivysledku
	t1 = ted;
	for (int i = 0; i <= 3500; i++) {
		SoucetCiselDefinice(i);
	}
	t2 = ted;
	prodleva = doba;

	std::cout << "Funkce s ukladanim mezivysledku celkem bezela: " << prodleva / 1000 << " milisekund" << std::endl << std::endl;

	// Explicitni vypocet
	t1 = ted;
	for (int i = 0; i <= 3500; i++) {
		SoucetCiselExplicitne(i);
	}
	t2 = ted;
	prodleva = doba;

	std::cout << "Explicitni funkce celkem bezela: " << prodleva / 1000 << " milisekund" << std::endl << std::endl;

	system("pause>nul");
	return 0;
}