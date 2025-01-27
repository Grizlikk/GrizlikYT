## Jak zpracovávat videa přes FFmpeg?

**[Video na YouTube](https://youtu.be/SAaogLp4nWs "https://youtu.be/SAaogLp4nWs")**

*[Stránky FFmpegu](https://ffmpeg.org "https://ffmpeg.org")*

# Přehled funkcí FFmpegu:

- [Načítání souborů](#načítání-souborů)
- [Mapování stop](#mapování-stop)
- [Specifikace kodeku](#specifikace-kodeku)
- [Vyříznutí části videa](#vyříznutí-části-videa)
- [Nastavení metadat](#nastavení-metadat)
- [Filtry](#filtry)
- [Příklady](#příklady)

<br>

## Načítání souborů

### Specifikace vstupu přes `-i`
- Pomocí parametru `-i` vyberete vstupní soubor (nebo více souborů)
```
ffmpeg -i Vstup.mp4
```

### Specifikace výstupu
- Výstupní soubor napíšete na konec příkazu bez jakýchkoliv dalších parametrů
```
ffmpeg -i Vstup.mp4 Výstup.mkv
```

<br>

## Mapování stop
- Provádí se parametrem `-map` a jednotlivé části se oddělují dvojtečkou

### Pořadí podle vstupů
- FFmpeg označí jednotlivé vstupní soubory indexy začínajícími od 0
- *např. ID 1 označí v pořadí druhý vstupní soubor*

### Specifikace absolutního indexu stopy
- Jednotlivé stopy ve zvoleném vstupním souboru mají indexy začínající od 0
- *např. ID 2 označí v pořadí třetí stopu z vybraného souboru*

### Specifikace typu stopy
- Pro výběr stopy můžete také použít její typ
- Typy stop se specifikují pomocí zkratek `v` (video), `a` (audio), `s` (titulky).
- Tímto defaultně označíte **všechny** stopy daného typu
- *např. `0:s` označí **všechny titulkové stopy** prvního vstupního souboru*

### Specifikace konkrétní stopy podle typu
- Pokud specifikujete typ stopy, můžete specifikovat také konkrétní stopu podle indexu začínajícího od 0
- *např. `0:s:1` označí **druhou titulkovou stopu** prvního vstupního souboru*

### Příklady výběru stop:
*Výběr **všech stop** z **prvního vstupního souboru**:*
```
-map 0
```
*Výběr **všech video stop** z **prvního vstupního souboru** a výběr **všech zvukových stop** z **druhého souboru**:*
```
-map 0:v -map 1:a
```
*Výběr **první video stopy** z **prvního vstupního souboru**, výběr **první zvukové stopy** z **druhého souboru** a výběr **první** a **třetí titulkové stopy** ze **třetího souboru**:*
```
-map 0:v:0 -map 1:a:0 -map 2:s:0 -map 2:s:2 
```

<br>

## Specifikace kodeku
- K určení kodeku slouží parametr `-c`
- Pro nastavení kodeku stopy určitého typu specifikujete typ stopy za dvojtečku, *např. `-c:v` (video) nebo `-c:a` (audio)*
- Pro nastavení kodeku konkrétní stopy použijete ID stopy, *např. `-c:a:0` nastaví kodek **první audio stopy***

### Kopírování kodeků
*Bezztrátové zkopírování kodeků všech stop do výstupního souboru:*
```
-c copy
```

### Určení konkrétního kodeku stopy
- Za výběr stop pomocí `-c` napíšete **název enkodéru**, který se na stopu použije
- Všechny dostupné enkodéry zobrazíte přes `ffmpeg -encoders` (pro jeden kodek si můžete vybrat z více různých enkodérů)

*Překódování videa do kodeku **H.264** a překopírování kodeku audia:*
```
-c:v libx264 -c:a copy
```

### Další parametry enkódování
- **Kvalitu výstupu** nastavíte přes `-crf` (čím **nižší** číslo, tím **lepší** kvalita)
- **Encoder preset** nastavíte přes `-preset`
- **Encoder profile** nastavíte přes `-profile`
- **Encoder level** nastavíte přes `-level`
- **Bitrate** natavíte přes `-b`
- *(Více informací o těchto parametrech naleznete ve [videu o HandBraku](https://youtu.be/pzEcD_GcbhY))

*Překódování videa do kodeku **H.264** s výpočtem **na NVIDIA grafické kartě** s kvalitou **25**, presetem **slow**, profilem **high**, levelem **4.1** a překódování audia do kodeku **AAC** s bitratem **192 kb/s**:*
```
-c:v h264_nvenc -crf 25 -preset:v slow -profile:v high -level:v 4.1 -c:a aac -b:a 192k
```

<br>

## Vyříznutí části videa
- Všechny časové údaje se zapisují ve formátu: **HH:MM:SS.ms**
- Pokud uvedete jednom některé údaje, vždy se počítají od menší jednoty: *Např. **10** je 10 sekund, nebo **1:45** je 1 minuta 45 sekund*

### Start od pozice: `-ss`
- Určí konkrétní pozici, od které se video začne zpracovávat

*Zpracování videa až od 2. minuty a 52. sekundy:*
```
-ss 2:52
```

### Délka zpracované části: `-t`
- Určí délku záznamu, která se má zpracovávat

*Zpracování prvních 30,85 sekund videa:*
```
-t 30.85
```

### Absolutní pozice ukončení zpracování: `-to`
- Určí konkrétní pozici, po kterou se má video zpracovávat

*Zpracování videa od 31. sekundy po 1. minutu a 8. sekundu:*
```
-ss 31 -to 1:08
```

<br>

## Nastavení metadat
- ***Zápis metadat je v FFmpegu dost nepřehledný, takže osobně radši doporučuji metadata nastavovat přes nějaký grafický program, jako je např. [MKVToolNix](https://mkvtoolnix.download)***
- Pro nastavení metadat slouží tag `-metadata`
- Metadata nastavujete vždy pro **konkrétní stopu výstupního souboru**

### Označení stop pro nastavení metadat
- Za tagem `metadata` napíšete `:s` a ID stopy **výsledného videa**, na kterou metadata nastavujete
- Také můžete použít označení stopy podle typu: `v` (video), `a` (audio), `s` (titulky) a následně specifikovat konkrétní ID *(stejně jako výběr stop u parametru `-map`)*

*Nastavení metadat pro první audio stopu výsledného videa:*
```
-metadata:s:a:0
```

### Název a hodnota metadat
- Po označení konkrétní stopy nastavíte konkrétní hodnotu metadat pomocí zápisu: **název=hodnota**
- Seznam názvů jednotlivých metadat si můžete prohlédnout např. zde: [Multimedia Wiki](https://wiki.multimedia.cx/index.php/FFmpeg_Metadata "https://wiki.multimedia.cx/index.php/FFmpeg_Metadata")

*Nastavení názvu druhé titulkové stopy výsledného videa na "Titulky čeština" a nastavení jazyka na češtinu:*
```
-metadata:s:s:1 title="Titulky čeština" -metadata:s:s:1 language=cs
```

<br>

## Filtry
- Pomocí tagu `-vf` nastavíte filtry pro **video**, pomocí tagu `-af` nastavíte filtry pro **zvuk**
- Obecný zápis filtru je: **filtr=parametr**
- Pokud filtr bere více parametrů, oddělují se dvojtečkou: **filtr=parametr1:parametr2:parametr3**
- Pokud chcete nastavit parametr s konkrétním názvem, použijete **parametr=hodnota**, tedy obecně: **filtr=parametr1:parametr3=hodnota**
- Pokud chcete aplikovat více filtrů současně, oddělíte je čárkou: **filtr1=parametr,filtr2=parametr,filtr3=parametr**

### Příklady filtrů
*Změnit rozlišení videa na 1920x1080:*
```
-vf "scale=1920:1080"
```
*Změnit rozlišení videa na 1280x720 a převést video na černobílé:*
```
-vf "scale=1280:720,hue=s=0"
```
*Zesílit zvuk o 3 dB:*
```
-af "volume=3dB"
```
*Spustit analýzu hlasitosti:*
```
-af "volumedetect"
```

<br>


## Příklady
*Změna kontejneru videa z .mp4 na .mkv bez překódování jakýchkoliv stop:*
```
ffmpeg -i Video.mp4 -c copy Video.mkv
```
*Vyextrahování první audio stopy z videa do souboru "Audio.wav":*
```
ffmpeg -i Video.mp4 -map 0:a:0 -c copy Audio.wav
```
*Překódování video stop do kodeku H.265 a překódování audio stop do kodeku AC3:*
```
ffmpeg -i Video.mp4 -c:v libx265 -c:a ac3 "Překódované video.mp4"
```
*Převod videa na HD rozlišení a uložení v kodeku H.264 s kvalitou 24 přes grafickou kartu a přidání audio stopy ze souboru "Zvuk.mp3" s převodem do kodeku AAC s bitratem 160 kb/s:*
```
ffmpeg -i Video.mp4 -i Zvuk.mp3 -map 0:v:0 -map 1:a:0 -vf "scale=1280:720" -c:v h264_nvenc -crf 24 -c:a aac -b:a 160k Výstup.mp4
```
*Převod obrázku na černobílý:*
```
ffmpeg -i Obrázek.jpg -vf "hue=s=0" "Černobílý obrázek.jpg"
```