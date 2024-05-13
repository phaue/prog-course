CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/

default : Out.txt time.gnuplot.svg

time.gnuplot.svg: out.times.data Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "Size, N, of matrix(NxN)";\
		set ylabel "Time";\
		set title "Time it takes to decomp different sizes of matrices using QR";\
		set grid;\
		set key right top;\
		a=1; f(n) = a*n*n*n;\
		fit f(x) "out.times.data" using 1:2 via a;\
		plot\
		"$<"  using 1:2 with lp lc rgb "blue" title "data"\
		,f(x) with lines lc rgb "red" title "N^3 fit to data";\
		' | gnuplot

out.times.data : mainc.exe
	>$@
	for N in $$(seq 100 20 500); do \
		time --format "$$N %e" --output $@ --append \
		mono $< -size:$$N 1>out 2>err ;\
	done

Out.txt : main.exe
	mono $< -size:5,2 > $@

main.exe : main.cs matrix.dll
	$(MKEXE)

mainc.exe : mainc.cs matrix.dll
	$(MKEXE)

matrix.dll : $(LIBPATH)vector.cs qrgs.cs $(LIBPATH)matrix.cs ; $(MKLIB)




.PHONEY : clean
clean:
	$(RM) [Oo]ut.txt *.exe *.dll [Ll]og.txt *.data err *.svg

