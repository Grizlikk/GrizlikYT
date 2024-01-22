#include <iostream>
#include <fstream>
#include <string>

int main(int argc, char** argv) {
	std::setlocale(LC_ALL, "");
	if (argc < 2) {
		return 1;
	}
	std::ifstream soubor(argv[1]);
	if (!soubor.good()) {
		return 2;
	}
	std::string obsah;
	std::getline(soubor, obsah);
	std::string prikaz = "start https://www.youtube.com/@" + obsah;
	const char* spustit = prikaz.c_str();
	system(spustit);
	return 0;
}