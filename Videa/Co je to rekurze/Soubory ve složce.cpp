#include <iostream>
#include <filesystem>

// Definice pouzivani tridy pro zkraceni zapisu prikazu
namespace fs = std::filesystem;

// Vypis vsech souboru ve slozce a vsech podslozkach
// Ano, na tohle existuje "std::filesystem::recursive_directory_iterator()", ale nejaky priklad do toho videa uvest musim :D
void SouboryVeSlozce(fs::path cesta) {
	try {
		for (fs::directory_entry soubor : fs::directory_iterator(cesta)) {
			// Pokud se jedna o slozku, spust rekurzivni vyhledavani
			if (soubor.is_directory()) {
				SouboryVeSlozce(soubor.path());
			}
			// Pokud se jedna o soubor, vypis jeho nazev
			else {
				std::cout << soubor.path().string() << std::endl;
			}
		}
	}
	catch (std::exception vyjimka) {
		std::cout << vyjimka.what();
	}
}

int main() {
	// Povoleni specialnich znaku ve VYSTUPU konzole
	std::setlocale(LC_ALL, "");

	// Zadani cesty ke slozce
	std::string slozka;
	std::cout << "Zadejte cestu ke slozce: ";
	std::getline(std::cin, slozka);
	
	// Odstraneni uvozovek ze vstupu
	if (slozka[0] == '"' && slozka[slozka.length() - 1] == '"') {
		slozka = slozka.substr(1, slozka.length() - 2);
	}
	std::cout << slozka;

	SouboryVeSlozce(slozka);

	system("pause>nul");
	return 0;
}