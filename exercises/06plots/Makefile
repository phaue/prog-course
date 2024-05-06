CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:,$(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)


default : Gamma.gnuplot.svg lnGamma.gnuplot.svg Erf.gnuplot.svg

Erf.gnuplot.svg : Outerr.txt Makefile
	echo '\
		set terminal svg background "white" ; \
		set out "$@" ;\
		set key left; \
		set xlabel "x" ;\
		set ylabel "erf(x)" ;\
		set tics out ;\
		set grid;\
		set title "Error function" ;\
		plot [-3:3] \
       			"$<" with lines notitle \
			,"erf.data.txt" using 1:2 with points pointtype 6 notitle \
			,"erf.data.txt" using (-($$1)):(-($$2)) with points pointtype 6 notitle;\
		' | tee log.gpi | gnuplot

Gamma.gnuplot.svg : Outgam.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "x" ;\
		set ylabel " " ;\
		set title "Comparison of Gammafunction and stirlings approximation with some factorials plotted." ;\
		set key left ;\
		set grid ;\
		plot [0:3] \
		"$<" using 1:2 with lines title "Gamma(x+1)"\
		,"$<" using 1:3 with lines title "Stirling(x)" \
		,"log.txt" using 1:2 with points pointtype 7 title "x!" ;\
		' | tee log1.gpi | gnuplot

lnGamma.gnuplot.svg : Outgam.txt Makefile
	echo '\
                set terminal svg background "white";\
                set out "$@" ;\
                set xlabel "x" ;\
                set ylabel " " ;\
                set title "Comparison of lnGammafunction and stirlings approximation with some factorials plotted." ;\
                set key left ;\
                set grid ;\
                plot [0:3] \
                "$<" using 1:4 with lines title "lnGamma(x+1)"\
                ,"$<" using 1:5 with lines title "lnStirling(x)" \
                ,"log.txt" using 1:3 with points pointtype 7 title "ln(x!)" ;\
                ' | tee log2.gpi | gnuplot
Outerr.txt : main.exe
	mono $< > $@

Outgam.txt : main2.exe
	mono $< 1> $@ 2>loggam.txt

main.exe : main.cs sfuns.dll
	$(MKEXE)
sfuns.dll : sfuns.cs ; $(MKLIB)
main2.exe : main2.cs sfuns.dll ; $(MKEXE)

.PHONEY : clean
clean : 
	$(RM) log* Out*.txt *gnuplot.svg *.exe *.dll
