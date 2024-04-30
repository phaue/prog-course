CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/

ann.gnuplot.svg : Out.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "x";\
		set ylabel "f(x)";\
		set title "Network training vs analytical function";\
		set grid;\
		set key right;\
		plot\
		"Out.txt" using 1:2 with points title "Neural net training function"\
		,"Out.txt"  using 1:3 with lines title "Analytical function";\
		' | gnuplot


Out.txt : main.exe
	mono $< > $@ 

main.exe : main.cs lib.dll
	$(MKEXE)

lib.dll : ../9-Minimization/mini.cs ../8-Roots/roots.cs $(LIBPATH)vector.cs $(LIBPATH)matrix.cs ../1-LinearEquations/qrgs.cs $(LIBPATH)genlist.cs neural.cs
	$(MKLIB)

.PHONEY : clean
clean : 
	$(RM) *.exe *.dll *.svg Out*.txt