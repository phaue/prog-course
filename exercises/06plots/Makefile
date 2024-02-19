CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:,$(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)


default : Gamma.gnuplot.svg lnGamma.gnuplot.svg


Gamma.gnuplot.svg : Out.txt Makefile
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

lnGamma.gnuplot.svg : Out.txt Makefile
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

Out.txt : main.exe
	mono $< 1> $@ 2>log.txt

sfuns.dll : sfuns.cs ; $(MKLIB)
main.exe : main.cs sfuns.dll ; $(MKEXE)

.PHONEY : clean
clean : 
	$(RM) log* [Oo]ut.txt *gnuplot.svg *.exe *.dll
