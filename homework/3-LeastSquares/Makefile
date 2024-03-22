CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/
QRPATH = ../1-LinearEquations/

default : Out.txt expplots.gnuplot.svg errorplot.gnuplot.svg

errorplot.gnuplot.svg : funcinput.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "time";\
		set ylabel "activity";\
		set title "Exponential fit and error functions to decay times";\
		set grid;\
		plot\
		"datainput.txt" with errorbars title "Data points" \
		, "funcinput.txt" using 1:2 with lines title "Fitted function" \
		, "funcinput.txt" using 1:3 with lines title "Fit +$\Delta$ C " \
		, "funcinput.txt" using 1:4 with lines title "Fit -$\Delta$ C" ;\
		' | gnuplot

expplots.gnuplot.svg : datainput.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "time" ;\
		set ylabel "activity" ;\
		set title "Exponential fit to decay times" ;\
		set key right ;\
		set grid ;\
		plot \
		"datainput.txt" with errorbars title "Data points" \
		, "funcinput.txt" using 1:2 with lines title "Fitted function" ;\
		' | gnuplot 

Out.txt : main.exe
	mono $< > $@

main.exe : main.cs matrix.dll
	$(MKEXE)

matrix.dll : $(QRPATH)qrgs.cs $(LIBPATH)matrix.cs $(LIBPATH)vector.cs
	$(MKLIB)



.PHONEY : clean
clean:
	$(RM) [Oo]ut.txt *.exe *.dll [Ll]og.txt *.svg *.txt *.gpi *.pdf

