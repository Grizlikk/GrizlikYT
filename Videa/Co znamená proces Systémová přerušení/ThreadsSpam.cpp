#include <thread>
#include <array>
#include <chrono>

int main() {
	std::array<std::thread, 2000> array;
	while (true) {
		for (size_t i = 0; i < array.max_size(); i++) array[i] = std::thread([] {std::this_thread::sleep_for(std::chrono::milliseconds(10)); });
		for (size_t i = 0; i < array.max_size(); i++) array[i].join();
	}
}