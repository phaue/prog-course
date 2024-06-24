CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../homework/Library/

default: Out_test.txt time.gnuplot.svg

time.gnuplot.svg: Out_time.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "Size, N, of matrix(NxN)";\
		set ylabel "Time(s)";\
		set title "Time it takes to decomp different sizes of matrices using different algorithms";\
		set grid;\
		set key right top;\
		set style line 1 lt 1 dt (7,7) lw 3 lc rgb "black";\
		a=1/3; f(n) = a*n*n*n;\
		fit f(x) "$<" using 1:2 via a;\
		plot\
		"$<"  using 1:2 with lp lc rgb "blue" title "Banach-decomp"\
		,"$<" using 1:3 with lp lc rgb "red" title "Crout-decomp"\
		,f(x) with lines linestyle 1 title "1/3*N^3 fit to data";\
		' | gnuplot

Out_test.txt : main_imp.exe
	mono $< matrixsize:5 1> $@ 2>testerror.txt

Out_time.txt : main_time.exe
	mono $< lowlim:5 uplim:600 stepsize:5 >$@

main_time.exe : main_timecheck.cs lib.dll
	$(MKEXE)

main_imp.exe : main_implementation.cs lib.dll
	$(MKEXE)

lib.dll : $(LIBPATH)matrix.cs $(LIBPATH)vector.cs algorithms.cs ../homework/1-LinearEquations/qrgs.cs
	$(MKLIB)

.PHONEY : clean
clean : 
	$(RM) *.exe *.dll *.svg [Oo]ut*.txt testerror.txt