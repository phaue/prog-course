Out.txt:main.exe
	mono $< 1> Out.txt 2>log

main.exe: main.cs genlist.dll
	mcs -target:exe -reference:genlist.dll -out:$@ $<

genlist.dll : genlist.cs
	mcs -target:library -out:$@ $<

.PHONEY : clean
clean:
	$(RM) *.dll *.exe log* [Oo]ut*

#[Oo]ut* fjerner alle filer der starter enten med O eller o efterfult af -ut.

