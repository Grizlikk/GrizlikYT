#include <iostream>

class Zvire {
public:
	void ZvukZvirete() {
		std::cout << "Zvire udelalo zvuk.\n";
	}
};

class Pes : public Zvire {
public:
	void ZvukZvirete() {
		std::cout << "Pes udelal: Haf haf\n";
	}
};

class Kocka : public Zvire {
public:
	void ZvukZvirete() {
		std::cout << "Kocka udelala: Mnau mnau\n";
	}
};

class Prase : public Zvire {
public:
	void ZvukZvirete() {
		std::cout << "Prase udelalo: Chro chro\n";
	}
};

class Ryba : public Zvire {
public:
	void ZvukZvirete() {
		throw std::exception("Error! \"Zvuk zvirete\" neni definovany :)");
	}
};

int main() {
	// Vytvoreni objektu tridy
	Zvire obecneZvire;
	Pes Doge;
	Kocka kockaDomaci;
	Prase praseDomaci;
	Ryba Nemo;

	// Volani metod (funkci) ze trid
	obecneZvire.ZvukZvirete();
	Doge.ZvukZvirete();
	kockaDomaci.ZvukZvirete();
	praseDomaci.ZvukZvirete();
	try {
		Nemo.ZvukZvirete();
	}
	catch (std::exception vyjimka) {
		std::cout << vyjimka.what();
	}

	std::cout << std::endl;
	return 0;
}