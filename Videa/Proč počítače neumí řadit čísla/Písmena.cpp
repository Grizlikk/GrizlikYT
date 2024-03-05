#include <fstream>
#include <string>

int main() {
	for (int i = 1; i <= 500; i++) {
		std::string name = std::to_string(i);
		for (int i = 0; i < name.length(); i++) {
			name[i] += 17;
		}
		std::ofstream file(name + " Soubor.txt");
		file.close();
	}
	return 0;
}