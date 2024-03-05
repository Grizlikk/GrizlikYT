#include <iostream>
#include <string>
#include <filesystem>

namespace fs = std::filesystem;
int main() {
	setlocale(LC_ALL, "");
	std::string slozka;
	std::cout << "Zadejte slozku: ";
	std::getline(std::cin, slozka);
	try {
		for (fs::directory_entry file : fs::directory_iterator(slozka)) {
			std::cout << file.path().filename() << "\n";
		}
	}
	catch (const fs::filesystem_error error) {
		std::cout << error.what() << std::endl;
	}
	system("pause");
	return 0;
}