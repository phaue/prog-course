Out.txt : epsimain.exe
	mono epsimain.exe > Out.txt

epsimain.exe : epsimain.cs
	mcs -target:exe -out:$@ $<


.PHONEY : clean
clean: 
	$(RM) epsimain.exe Out.txt

