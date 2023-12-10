#include <iostream>
#include <filesystem>

void Pozdrav() {
	using std::cout;
	cout << "Ahoj\n";
	cout << "Dej like :D\n";
	cout << "A taky odber :D";
}

int main() {
	namespace fs = std::filesystem;

	fs::directory_entry
		Pozdrav();

	return 0;
}