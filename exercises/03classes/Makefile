Out.txt : main.exe vecmain.dll #epsimain.exe
	mono main.exe > Out.txt
	#mono $< 1> $@ 2> log.txt 1> sends standard output, 2> sends standard error

epsimain.exe : epsimain.cs
	mcs -target:exe -out:$@  $<

main.exe : main.cs vecmain.dll
	mcs -target:exe -out:$@ -reference:vecmain.dll $<

vecmain.dll : vecmain.cs
	mcs -target:library -out:$@ $<

.PHONEY : clean
clean: 
	$(RM) epsimain.exe Out.txt main.exe

