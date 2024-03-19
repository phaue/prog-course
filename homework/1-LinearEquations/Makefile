CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/


Out.txt : main.exe
	mono $< > $@

main.exe : main.cs matrix.dll
	$(MKEXE)
	

matrix.dll : $(LIBPATH)vector.cs qrgs.cs $(LIBPATH)matrix.cs ; $(MKLIB)




.PHONEY : clean
clean:
	$(RM) [Oo]ut.txt *.exe *.dll [Ll]og.txt

