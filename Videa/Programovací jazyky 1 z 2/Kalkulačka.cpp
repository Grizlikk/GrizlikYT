#include <iostream>
using namespace std;

int main() {
	float a, b;
	cout << "Kalkulacka\n\nZadejte prvni cislo: ";
	cin >> a;
	cout << "Zadejte druhe cislo: ";
	cin >> b;

	cout << "\nSoucet cisel je " << a + b;
	cout << "\nRozdil cisel je " << a - b;
	cout << "\nSoucin cisel je " << a * b;
	if (b != 0) {
		cout << "\nPodil cisel je " << a / b;
	}
	cout << "\n\n";

	system("pause");
	return 0;
}