CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/
QRPATH = ../1-LinearEquations/
ODEPATH = ../5-ODE/

default : Outparta.txt fit.gnuplot.svg

fit.gnuplot.svg: Outpartb.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "Energy";\
		set ylabel "F";\
		set title "Breit-Wigner function fit to experimental data";\
		set grid;\
		set key right;\
		plot\
		"higgsdata.txt" with errorbars title "datapoints"\
		,"fitdata.txt"  using 1:2 with lines title "Breit Wigner fit";\
		' | gnuplot

Outpartb.txt : partb.exe
	mono $< < higgsdata.txt >$@

Outparta.txt : parta.exe
	mono $< > $@

parta.exe : parta.cs lib.dll
	$(MKEXE)

partb.exe : partb.cs lib.dll
	$(MKEXE)

lib.dll : $(LIBPATH)vector.cs $(LIBPATH)matrix.cs $(QRPATH)qrgs.cs $(ODEPATH)runge.cs $(LIBPATH)genlist.cs mini.cs
	$(MKLIB)


.PHONEY : clean
clean : 
	$(RM) *.exe *.dll *.svg Out*.txt fitdata.txt