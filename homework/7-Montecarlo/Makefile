CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/

default : Out_mc.txt err.gnuplot.svg int.gnuplot.svg err_partb.gnuplot.svg

err_partb.gnuplot.svg: Out_partb.txt Out_mctest.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "number of points";\
		set ylabel "Error";\
		set title "Comparison of errors of different sampling methods";\
		set grid;\
		set key right top;\
		a=1; f(n) = a/sqrt(n);\
		fit f(x) "Out_mctest.txt" using 1:4 via a;\
		plot\
		"Out_partb.txt"  using 1:3 with lp lc rgb "cyan" title "Estimate of error, quasi"\
		,"Out_partb.txt"  using 1:4 with lp lc rgb "dark-turquoise" title "Actual error, quasi"\
		,"Out_mctest.txt"  using 1:3 with lp lc rgb "yellow" title "Estimate of error, plain"\
		,"Out_mctest.txt"  using 1:4 with lp pointtype 16 lc rgb "goldenrod" title "Actual error, plain"\
		,f(x) with lines lc rgb "red" title "1/sqrt(N) fit to actual error";\
		' | gnuplot

err.gnuplot.svg: Out_mctest.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "number of points";\
		set ylabel "Error";\
		set title "Error of the integral evaluation using montecarlo";\
		set grid;\
		set key right top;\
		a=1; f(n) = a/sqrt(n);\
		fit f(x) "Out_mctest.txt" using 1:4 via a;\
		plot\
		"Out_mctest.txt"  using 1:3 with linespoints title "Estimate of error"\
		,"Out_mctest.txt"  using 1:4 with linespoints title "Actual error"\
		,f(x) with lines title "1/sqrt(N) fit to actual error";\
		' | gnuplot

int.gnuplot.svg: Out_mctest.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "number of points";\
		set ylabel "Integral value";\
		set title "Integral evaluation using montecarlo";\
		set grid;\
		set key right bottom;\
		plot\
		"Out_mctest.txt"  using 1:2 with linespoints title "integral value"\
		,pi with lines title "exact value";\
		' | gnuplot


Out_partb.txt : montec_b.exe
	>$@ #clears the outfile
	for N in $$(seq 100 100 10000);\
	do echo $$N; mono $< $$N >> $@;\
	done
Out_mctest.txt : montec_test.exe
	>$@ #clears the outfile
	for N in $$(seq 100 100 10000);\
	do echo $$N; mono $< $$N >> $@;\
	done
Out_mc.txt : montec.exe
	>$@ #clears the outfile
	for N in $$(seq 100 100 10000);\
	do echo $$N; mono $< $$N >> $@;\
	done
montec_b.exe : montec_b.cs lib.dll
	$(MKEXE)
montec_test.exe : montec_test.cs lib.dll
	$(MKEXE)
montec.exe : montec.cs lib.dll
	$(MKEXE)

lib.dll : $(LIBPATH)vector.cs mc.cs
	$(MKLIB)

.PHONEY : clean
clean : 
	$(RM) *.exe *.dll *.svg *.txt *.log
