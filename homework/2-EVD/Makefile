CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/

default : A-Out.txt B-Out.txt lowfuncs.gnuplot.svg rmax.gnuplot.svg dr.gnuplot.svg


lowfuncs.gnuplot.svg : lowestinput.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "r" ;\
		set ylabel "E" ;\
		set title "Lowest numerical eigenfunctions";\
	        set key right;\
		set grid; \
		plot\
		"$<" using 5:1 with lines title "k=1"\
		, "$<" using 5:2 with lines title "k=2"\
		, "$<" using 5:3 with lines title "k=3"\
		, "$<" using 5:4 with lines title "k=4";\
		' | gnuplot	

rmax.gnuplot.svg : convinput.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "rmax" ;\
		set ylabel "E0" ;\
		set title "E0 as a function of rmax with a fixed dr";\
		set key right ;\
		set grid ;\
		plot \
		"$<" using 2:1 with lines title "E0(rmax)";\
		' | tee log1.gpi | gnuplot

dr.gnuplot.svg : convinput.txt Makefile
	echo '\
                set terminal svg background "white" ;\
                set out "$@" ;\
                set xlabel "dr" ;\
                set ylabel "E0" ;\
                set title "E0 as a function of dr with a fixed rmax";\
                set key right ;\
                set grid ;\
                plot \
		"$<" using 4:3 with lines title "E0(dr)";\
                ' | tee log2.gpi | gnuplot


A-Out.txt : A-main.exe
	mono $< > $@

B-Out.txt : B-main.exe
	mono $< -rmax:10 -dr:0.3 >$@

B-main.exe : B-main.cs matrix.dll
	$(MKEXE)

A-main.exe : A-main.cs matrix.dll
	$(MKEXE)
	

matrix.dll : jacobi.cs $(LIBPATH)vector.cs $(LIBPATH)matrix.cs ; $(MKLIB)




.PHONEY : clean
clean:
	$(RM) [Oo]ut.txt *.exe *.dll [Ll]og.txt *.svg *.txt *.gpi

