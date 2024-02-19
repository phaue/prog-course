Out.txt: main.exe Makefile
	mono main.exe < input.txt >$@

main.exe : main.cs genlist.dll
	mcs -target:exe -reference:genlist.dll -out:main.exe $<

genlist.dll : genlist.cs
	mcs -target:library -out:genlist.dll $<

.PHONEY : clean
clean:
	$(RM) Out.txt main.exe

