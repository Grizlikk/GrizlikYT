## Jak vytvořit video s průhledným pozadím? 🤔

**[Video na YouTube](https://youtu.be/7zwqC6DYnZo "https://youtu.be/7zwqC6DYnZo")**

**"Průhledné video.webm"** je video v kodeku ***VP9*** se zoomujícím se logem Windows 10 a průhledným pozadím<br>
**"Scéna v Blenderu.blend"** obsahuje kostku na podložce se zdrojem světla nad ní. Pozadí je nastaveno na průhledné, aby bylo možné scénu vyexportovat jako video s průhledným pozadím<br>
**"Web.html"** vkládá video s průhledným pozadím na webovou stránku s pevně nastavenou barvou pozadí. Vzhledem k tomu, že video má průhledné pozadí, jeho obsah bude vždy automaticky ořezaný a skrz video uvidíte barvu pozadí celé stránky

*Příkaz pro vygenerování průhledného videa z obrázku přes FFmpeg:*
> ffmpeg -framerate 30 -t 10 -i "Windows 10.png" -vf "zoompan=z=zoom+0.0005:x=iw/2-(iw/zoom/2):y=ih/2-(ih/zoom/2):d=300:fps=30:s=3840x2160" -c:v libvpx-vp9 -crf 30 "Průhledné video.webm"