**"Import konkrétních funkcí.cpp"** ukazuje, jak je možné naimportovat pouze ty funkce, které plánuji používat a neimportovat vše ze standardních funkcí<br>
**"Import namespace ve funkci.cpp"** importuje vše pouze v rámci jedné funkce, takže ve zbytku programu import neplatí<br>
**"Import namespace.cpp"** ukazuje, jak je monžné ulehčit si zápis příkazů jejich načtením z ***namespace***<br>
**"Konflikt funkcí.cpp"** nebude fungovat, protože obě ***namespace*** jsou naimportované a kompilátor neví, kterou z funkcí ***Soucet()*** má použít<br>
**"Konflikt proměnných.cpp"** ukazuje problém importu všeho z ***std***, protože text ***cout*** se v obou případech vyhodnotí jako proměnná jménem ***cout***, místo aby došlo k výpisu<br>
**"Příklad namespace.cpp"** ukazuje praktické použití příkazu ***namespace*** pro rozdělení funkcí do skupin<br>
**"Ukázka namespace.cpp"** ukazuje zápis a použití příkazu ***namespace***<br>
**"Úrovně přístupu.cpp"** ukazuje, že každá funkce může přistupovat pouze k proměnným, které jsou vytvoření uvnitř ní *(pro přístup k proměnné **hodnota** z funkcí byste ji museli definovat nad definicemi funkcí)*<br>
**"Zkrácení zápisu namespace.cpp"** použije příkaz ***namespace*** pro zkrácení zápisu ***std::filesystem*** na ***fs***