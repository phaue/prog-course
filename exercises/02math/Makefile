Out.txt: main.exe
	mono main.exe > Out.txt

main.exe : main.cs
	mcs -target:exe -out:main.exe main.cs

.PHONEY : clean
clean:
	rm -f main.exe main Out.txt

