CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/
QRPATH = ../1-LinearEquations/
ODEPATH = ../5-ODE/

Out.txt : main.exe
	mono $< > $@

main.exe : main.cs lib.dll
	$(MKEXE)

lib.dll : $(LIBPATH)vector.cs $(LIBPATH)matrix.cs $(QRPATH)qrgs.cs $(ODEPATH)runge.cs $(LIBPATH)genlist.cs mini.cs
	$(MKLIB)


.PHONEY : clean
clean : 
	$(RM) *.exe *.dll *.svg *.txt *.log