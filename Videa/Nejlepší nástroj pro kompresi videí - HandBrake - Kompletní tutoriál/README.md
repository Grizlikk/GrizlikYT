## Nejlepší nástroj pro kompresi videí: HandBrake - Kompletní tutoriál

**[Video na YouTube](https://youtu.be/pzEcD_GcbhY "https://youtu.be/pzEcD_GcbhY")**

**"HandBrake přednastavení.zip"** obsahuje mé *(aktuální)* přednastavení enkódování videí pro HandBrake *(Často ale přednastavení ještě upravuji pro konkrétní videa)*. Po stažení a extrahování souboru ***"User Presets.json"*** je naimportujete následujícím způsobem:<br>
*Otevřete HandBrake -> Načtete nějaké náhodné video, ať se vám zobrazí nastavení enkódování -> Na horní liště vpravo zvolíte **Presets** -> V otevřeném panelu kliknete na **Options** -> Možnost **Import Preset(s) from file** -> Vyberete soubor s přednastaveními -> Zvolíte **Otevřít***<br>
*Počítejte však s tím, že tato přednastavení jsem vytvářel na základě svých požadavků a podpory v zařízeních, takže nemusí být pro vaši potřebu nutně nejlepší!*

**"voldetect.bat"** je můj pomocný program k detekci hlasitosti zvukové stopy videa přes ***FFmpeg***. Program předpokládá, že programy ***FFmpeg*** a ***FFprobe*** máte přidané do systémové proměnné ***PATH***, abyste je mohli spouštět z libovolné složky. Já osobně mám i tento program v proměnné ***PATH***, abych jej mohl v libovolné složce použít pomocí: ***voldetect \[parametry\]***<br>
**Použití:**<br>
Pro výpis všech stop videa zadejte jako první parametr cestu k video souboru, např.: ***voldetect "C:\Users\User\video.mp4"***<br>
Pro analýzu hlasitosti **konkrétní zvukové stopy** zadejte číslo stopy jako druhý parametr, např.: ***voldetect "C:\Users\User\video.mp4" 1***<br>
*PS: Příkazový řádek podporuje přetahování souborů, takže stačí daný video soubor přetáhnout na okno příkazového řádku a do příkazu se automaticky vloží kompletní cesta k souboru*
*PPS: Program není zcela blbuvzdorný, psal jsem ho pro vlastní potřebu :D*