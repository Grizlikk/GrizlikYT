#include <iostream>
#include <fstream>
#include <string>

int main() {
	system("pause");
	std::ifstream soubory[1000];
	std::ifstream seznam("Seznam.txt");
	std::string nazev;
	int i = 0;
	while (std::getline(seznam, nazev)) {
		soubory[i].open(nazev);
		i++;
	}
	std::cout << "Soubory uspesne otevreny\n";
	system("pause");
	return 0;
}