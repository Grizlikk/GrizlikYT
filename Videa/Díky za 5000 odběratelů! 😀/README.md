# Instrukce k instalaci:

Pokud chcete používat ***Microsoft office Proffesional Plus 2019***, tak ho musíte nejdříve nainstalovat. K tomu slouží instalační programy zabalené v ***.zip*** formátu a zašifrované heslem ***grizlik*** (stejně jako všechny ostatní aplikace zde na GitHubu).<br>
Pokud se ptáte, proč jsou soubory zašifrované, tak je to proto, že prohlížeč by vám zablokoval stahování nějaké neověřené .exe aplikace z internetu, jak jste mohli vidět například v [tomto videu](https://youtu.be/ZxfocSABL9g "www.youtube.com - Nefunkční aplikace vs prohlížeče :D #shorts")

### Instalace Microsoft Office:
Jako první zvolte verzi, buď 32 bitovou (**"Setup32.zip"**) nebo 64 bitovou (**"Setup64.zip"**). Pokud si nejste jistí, kterou verzi máte nainstalovat, tak se podívejte na váš disk ***C:\\***. Pokud tam vidíte ***dvě*** složky: ***"Program Files" a "Program Files (x86)"***, tak máte 64 bitový Windows a doporučuji použít 64 bitovou verzi (i když by vám měly fungovat obě). V dnešní době je naprostá většina počítačů 64 bitová.<br>
Aplikace, které dostanete po extrahování, jsou ***oficiální aplikace od Microsoftu***, které stáhnou a nainstalují Microsoft Office. Aplikace by měly vše potřebné stáhnout z internetu (takže potřebujete připojení k internetu), ale pokud zde dojde k chybě, tak vám s tím moc nepomůžu :(

### Aktivace Microsoft Office:
Jakmile se dokončí instalace, potřebujete program aktivovat. K tomu slouží **"Aktivace MS Office 2019 a 2021.bat"** (přidal jsem do toho programu i podporu jiných verzí, ale nemám to otestované).<br>
Když si rozkliknete soubor **"Aktivace MS Office 2019 a 2021.bat"** uvidíte jeho zdrojový kód. V pravém horním rohu nad kódem naleznete tlačítko s logem stažení, na které když najedete myškou, tak se zobrazí ***Download raw file***.<br>
Tento soubor následně spusťte, pokud jste ho stáhli přímo z GitHubu, zobrazí se hláška od Windows defenderu, že se jedná o nerozpoznanou aplikaci, pokud jste zkopírovali zdrojový kód a vložili ho do nového .bat souboru, tato hláška se nezobrazí.<br>
Následně musíte programu zadat oprávnění správce, také může programu bránit ve spuštění váš antivirus, který tedy možná bude nutné pozastavit, ale ***pokud tomuto (nebo jakémukoliv jinému) programu nedůvěřujete, NIKDY nepozastavujte váš antivirus, většina programů, které tohle vyžadují, se snaží dělat nějaké škodlivé úkony!***

Program běží pouze v rozhraní příkazového řádku a jako první se vás zeptá, jakou verzi Microsoft Office máte, pokud jste použili výše uvedené instalační programy, máte ***Microsoft office Proffesional Plus 2019***, takže stiskněte ***C***.<br>
Následně musíte aktivaci potvrdit, takže stiskněte ***A*** (pro potvrzení) nebo ***N*** (pro zamítnutí).<br>
Poté se spustí aktivace přes vzdálený KMS server (pokud vás zajímají detaily, prohlédněte si kód programu). Program dovede vyzkoušet různé KMS servery, přes které se váš produkt pokusí aktivovat. Pokud se k danému serveru půl roku nepřipojíte (tedy že nebudete přes půl roku připojení k internetu), platnost licence skončí.<br>
Program následně vypíše, jestli byla aktivace úspěšná nebo ne, také vám dá na výběr vypsat detaily o aktivaci nainstalovaných licencí, osobně to nedoporučuji, protože se v tom asi moc nevyznáte, tento výpis jsem používal hlavně při tvorbě toho programu, ale pokud přesto zvolíte výpis, ***napřed počkejte až se výpis dokončí, skládá se totiž ze dvou částí*** (detailní a stručný :D) a poté by v úplně posledním výpisu (stručném) mělo být napsané ***něco jiného než "LICENSE STATUS:  ---UNLICENSED---"*** (takže tam bude s největší pravděpodobností napsané ***"LICENSED"***).<br>
Jestli aktivace selhala, zkuste to přes VPN, jednou se mi to takto podařilo opravit, i když nemůžu garantovat, jestli to bude fungovat i ve vašem případě.
<hr>

### Děkuji za podporu při tvorbě videí a snad vám ten aktivátor bude fungovat a zase se to nerozbije xD