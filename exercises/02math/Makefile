Out.txt: main.exe 
	mono main.exe > Out.txt

main.exe : main.cs sfuns.dll
	mcs -target:exe -reference:sfuns.dll -out:main.exe main.cs

sfuns.dll : sfuns.cs
	mcs -target:library -out:sfuns.dll sfuns.cs


.PHONEY : clean
clean:
	rm -f main.exe main Out.txt

