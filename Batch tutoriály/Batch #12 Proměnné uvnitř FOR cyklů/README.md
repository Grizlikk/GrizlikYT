**"And.bat"** ukazuje, jak je možné ovlivnit chování symbolu ***&*** zapnutím opožděné aktualizace proměnných<br>
**"enabledelayedexpansion.bat"** ukazuje použití příkazu ***"setlocal EnableDelayedExpansion"*** pro zapnutí opožděné aktualizace proměnných. Pro specifikaci proměnných, které se mají aktualizovat opožděně, musíte použít zápis ***!nazev_promenne!***<br>
**"Náhodné čísla.bat"** vygeneruje zadané množství náhodných čísel. Aby se při každém průchodu cyklem vygenerovalo jiné náhodné číslo, proměnná ***random*** se musí aktualizovat opožděně<br>
**"Počet souborů.bat"** vypíše počet souborů v aktuální složce a u každého souboru také vypisuje o kolikátý soubor se zrovna jedná. Proměnná ***soubory*** se tedy musí aktualizovat při každém průchodu cyklem<br>
**"usebackq.bat"** ukazuje použití parametru ***usebackq*** u ***for /f*** cyklu, aby dokázal vypsat data ze souboru **"Webove stranky.txt"**. Parametr ***usebackq*** změní chování uvozovek, takže cyklus s tímto parametrem může přijmout i soubor s mezerou v názvu<br>
**"Vyhledání.bat"** vyhledává zadané číslo v souborech ze složky **Soubory**. V této složce se pak nachází program **"Generování.bat"**, který vygeneruje 1000 souborů obsahujících náhodné číslo.

Soubor **"Seznam.txt"** a složka **"Data"** patří k souboru **"Batch 12.bat"**, zadaného na konci videa a jsou vyžadovány pro správné spuštění tohoto programu.