CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/

default : annA.gnuplot.svg annB.gnuplot.svg

annB.gnuplot.svg : Out2.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "x";\
		set ylabel "f(x)";\
		set grid;\
		set term svg size 700,1000;\
		set multiplot layout 4,1 columns;\
		set title "Neural net training response";\
		plot\
		"Out2.txt" using 1:2 with lines notitle ;\
		set title "Neural net training 1st-deriv response";\
		plot\
		"Out2.txt"  using 1:3 with lines lc rgb "red" notitle;\
		set title "Neural net training 2nd-deriv response";\
		plot\
		"Out2.txt" using 1:4 with lines lc rgb "blue" notitle;\
		set title "Neural net training anti-deriv response";\
		plot\
		"Out2.txt"  using 1:5 with lines lc rgb "green" notitle;\
		unset multiplot;\
		' | gnuplot


annA.gnuplot.svg : Out.txt Makefile
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

Out2.txt : main2.exe
	mono $< > $@

Out.txt : main.exe
	mono $< > $@ 

main.exe : main.cs lib.dll
	$(MKEXE)

main2.exe : main2.cs lib.dll
	$(MKEXE)

lib.dll : ../9-Minimization/mini.cs ../8-Roots/roots.cs $(LIBPATH)vector.cs $(LIBPATH)matrix.cs ../1-LinearEquations/qrgs.cs $(LIBPATH)genlist.cs neural.cs
	$(MKLIB)

.PHONEY : clean
clean : 
	$(RM) *.exe *.dll *.svg Out*.txt