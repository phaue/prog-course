CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/

default : A-Out.txt lowfuncs.gnuplot.svg rmax.gnuplot.svg dr.gnuplot.svg

lowfuncs.gnuplot.svg : B-Out.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@";\
		set xlabel "r";\
		set ylabel "E";\
		set grid;\
		set term svg size 500,800;\
		set multiplot layout 2,1 columns;\
		set title "Lowest numerical eigenfunctions";\
		plot\
		"lowestinput.txt" using 5:1 with lines title "k=1"\
		,"lowestinput.txt" using 5:2 with lines title "k=2";\
		set title "Lowest analytical wavefunctions";\
		plot\
		"analytical.txt" using 1:2 with lines title "k=1"\
		,"analytical.txt" using 1:3 with lines title "k=2";\
		unset multiplot;\
		' | gnuplot

rmax.gnuplot.svg : B-Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "rmax" ;\
		set ylabel "E0" ;\
		set title "E0 as a function of rmax with a fixed dr";\
		set key right ;\
		set grid ;\
		plot \
		"convinput.txt" using 2:1 with lines title "E0(rmax)";\
		' | tee log1.gpi | gnuplot

dr.gnuplot.svg : B-Out.txt Makefile
	echo '\
                set terminal svg background "white" ;\
                set out "$@" ;\
                set xlabel "dr" ;\
                set ylabel "E0" ;\
                set title "E0 as a function of dr with a fixed rmax";\
                set key right ;\
                set grid ;\
                plot \
		"convinput.txt" using 4:3 with lines title "E0(dr)";\
                ' | tee log2.gpi | gnuplot


A-Out.txt : A-main.exe
	mono $< > $@

B-Out.txt : B-main.exe
	mono $< -rmax:10 -dr:0.1 >$@

B-main.exe : B-main.cs matrix.dll
	$(MKEXE)

A-main.exe : A-main.cs matrix.dll
	$(MKEXE)
	

matrix.dll : jacobi.cs $(LIBPATH)vector.cs $(LIBPATH)matrix.cs ; $(MKLIB)




.PHONEY : clean
clean:
	$(RM) [Oo]ut.txt *.exe *.dll [Ll]og.txt *.svg *.txt *.gpi

