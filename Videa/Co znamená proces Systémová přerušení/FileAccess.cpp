#include <thread>
#include <fstream>
#include <vector>
#include <format>

void WriteFile(std::string fileName) {
	while (true) {
		std::ifstream fileIn(fileName);
		char c;
		if (!fileIn.good() || (c = fileIn.get()) == -1) c = 'a';
		fileIn.close();
		std::ofstream fileOut(fileName, std::ios_base::app);
		fileOut << c;
		fileOut.close();
	}
}

int main() {
	std::vector<std::thread> threads;
	for (uint16_t i = 0; i < std::thread::hardware_concurrency() - 1; i++) {
		threads.push_back(std::thread(WriteFile, std::format("File {0}.txt", i)));
	}
	WriteFile(std::format("File {0}.txt", std::thread::hardware_concurrency() - 1));
}