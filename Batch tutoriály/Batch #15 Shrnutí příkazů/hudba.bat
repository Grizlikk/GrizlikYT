forfiles /m *.webm /c "cmd /c ffmpeg -i @file @fname.mp3"
del *.webm