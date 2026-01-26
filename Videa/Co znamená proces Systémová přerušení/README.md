## Co znamená proces "Systémová přerušení"?

**[Video na YouTube](https://youtu.be/y2JelklbaWU "https://youtu.be/y2JelklbaWU")**

**"FileAccess.cpp"** vytvoří pro každé jádro (respektive vlákno) procesoru samostatné vlákno programu, ve kterém bude v nekonečné smyčce otevírat soubor na disku, číst první znak ze souboru a tento znak zapisovat zpět. Pokud soubor neexistuje nebo je prázdný, program do něj připíše znak 'a'<br>
**"ThreadsSpam.cpp"** v nekonečné smyčce pořád dokola vytváří 2000 nových vláken procesu, které pouze čekají 10 milisekund a pak se vymažou. Tímto tento program výrazně zaměstnává operační systém, který musí mezi všemi těmito vlákny přepínat.