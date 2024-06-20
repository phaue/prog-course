CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../homework/Library/



out.txt : main.exe
	mono $< > $@

main.exe : main.cs lib.dll
	$(MKEXE)

lib.dll : $(LIBPATH)matrix.cs $(LIBPATH)vector.cs algorithms.cs ../homework/1-LinearEquations/qrgs.cs
	$(MKLIB)

.PHONEY : clean
clean : 
	$(RM) *.exe *.dll *.svg Out*.txt