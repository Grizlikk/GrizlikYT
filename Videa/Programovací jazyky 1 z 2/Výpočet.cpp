#include <iostream>
#include <math.h>
using namespace std;

int main() {
	float y;
	for (int x = 0; x < 50000000; x++) {
		y = pow(x, 2);
		if (y == 1797634243799289) {
			cout << x << "\n";
			break;
		}
	}
	system("pause");
	return 0;
}

