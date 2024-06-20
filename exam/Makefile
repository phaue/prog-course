CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../homework/Library/

default: Out_test.txt time.gnuplot.svg

time.gnuplot.svg: Out_time.txt
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "Size, N, of matrix(NxN)";\
		set ylabel "Time";\
		set title "Time it takes to decomp different sizes of matrices using different algorithms";\
		set grid;\
		set key right top;\
		plot\
		"$<"  using 1:2 with lp lc rgb "blue" title "Banach-decomp"\
		,"$<" using 1:3 with lp lc rgb "red" title "Crout-decomp";\
		' | gnuplot

Out_test.txt : main_imp.exe
	mono $< matrixsize:5 > $@

Out_time.txt : main_time.exe
	mono $< lowlim:20 uplim:1200 stepsize:20 >$@

main_time.exe : main_timecheck.cs lib.dll
	$(MKEXE)

main_imp.exe : main_implementation.cs lib.dll
	$(MKEXE)

lib.dll : $(LIBPATH)matrix.cs $(LIBPATH)vector.cs algorithms.cs ../homework/1-LinearEquations/qrgs.cs
	$(MKLIB)

.PHONEY : clean
clean : 
	$(RM) *.exe *.dll *.svg [Oo]ut*.txt