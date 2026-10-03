## Jaký je rozdíl mezi asynchronním a paralelním zpracováním?

**[Video na YouTube](https://youtu.be/pCOO1532Mug "https://youtu.be/pCOO1532Mug")**

Program ve složce **"Čtení dat ze souboru"** se snaží přečíst do operační paměti obsah souboru ***"Video.mp4"***, který musí být umístěn ve stejné složce, jako program. Načítání souboru je možné zpracovávat buď synchronně, asynchronně nebo paralelně<br>
Program ve složce **"Náročná aplikace"** simuluje náročné zpracování čekáním po dobu 6 sekund. V případě synchronního spuštění celé uživatelské rozhraní zamrzne, asynchronní i paralelní zpracování bude zdánlivě fungovat stejně, ale paralelní zpracování bude blokovat jiné jádro (respektive vlákno) procesoru<br>
Program ve složce **"Výpočet prvočísel"** se snaží vypočítat 1000000. prvočíslo. V případě synchronního spuštění výpočtu celá aplikace zamrzne, v případě paralelního výpočtu poběží výpočet jen na pozadí. Jelikož se jedná o výpočet na procesoru který neobsahuje žádné čekání, asynchronní zpracování nedává smysl a funguje totožně, jako synchronní zpracování

*Všechny programy jsou nahrané jako projekty ve **Visual Studiu 2026**. Uživatelské rozhraní běží pomocí platformy **WPF**.*