default : Outeps.txt Outvec.txt

Outeps.txt : epsimain.exe
	mono $< > $@

Outvec.txt : vecmain.exe vecmain.dll
	mono $< > $@

epsimain.exe : epsimain.cs
	mcs -target:exe -out:$@  $<

vecmain.exe : vecmain.cs vecclass.dll
	mcs -target:exe -out:$@ -reference:vecclass.dll $<

vecclass.dll : vecclass.cs
	mcs -target:library -out:$@ $<

.PHONEY : clean
clean: 
	$(RM) Out*.txt *.exe

