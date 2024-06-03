CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/
QRPATH = ../1-LinearEquations/
ODEPATH = ../5-ODE/

default : epsconv.gnuplot.svg accconv.gnuplot.svg rminconv.gnuplot.svg rmaxconv.gnuplot.svg wf.gnuplot.svg Out_partc.txt

epsconv.gnuplot.svg: Outhyd.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "eps";\
		set ylabel "Energy";\
		set title "Convergence of energy as a function of epsilon";\
		set grid;\
		set key right;\
		plot\
		"conv_eps.txt"  using 1:2 with lines title "Estimated energy"\
		,"conv_eps.txt"  using 1:3 with lines title "Actual energy";\
		' | gnuplot

accconv.gnuplot.svg: Outhyd.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "acc";\
		set ylabel "Energy";\
		set title "Convergence of energy as a function of accuracy";\
		set grid;\
		set key right;\
		plot\
		"conv_acc.txt"  using 1:2 with lines title "Estimated energy"\
		,"conv_acc.txt"  using 1:3 with lines title "Actual energy";\
		' | gnuplot

rmaxconv.gnuplot.svg: Outhyd.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "rmax";\
		set ylabel "Energy";\
		set title "Convergence of energy as a function of rmax";\
		set grid;\
		set key right;\
		plot\
		"conv_rmax.txt"  using 1:2 with lines title "Estimated energy"\
		,"conv_rmax.txt"  using 1:3 with lines title "Actual energy";\
		' | gnuplot

rminconv.gnuplot.svg: Outhyd.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "rmin";\
		set ylabel "Energy";\
		set title "Convergence of energy as a function of rmin";\
		set grid;\
		set key right;\
		plot\
		"conv_rmin.txt"  using 1:2 with lines title "Estimated energy"\
		,"conv_rmin.txt"  using 1:3 with lines title "Actual energy";\
		' | gnuplot

wf.gnuplot.svg: Outhyd.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "r";\
		set ylabel "";\
		set title "Comparison of wavefunctions";\
		set grid;\
		set key right;\
		plot\
		"wf.txt"  using 1:2 with lines title "Numerical wavefunction"\
		,"wf.txt"  using 1:3 with lines title "Analytical wavefunction";\
		' | gnuplot

Outhyd.txt : hydro.exe
	mono $< > $@

Out.txt : main.exe
	mono $< > $@
Out_partc.txt : mainc.exe
	mono $< > $@

hydro.exe : hydro.cs lib.dll
	$(MKEXE)
main.exe : main.cs lib.dll
	$(MKEXE)
mainc.exe : mainc.cs lib.dll
	$(MKEXE)

lib.dll : $(LIBPATH)vector.cs $(LIBPATH)matrix.cs $(QRPATH)qrgs.cs $(ODEPATH)runge.cs $(LIBPATH)genlist.cs roots.cs
	$(MKLIB)


.PHONEY : clean
clean : 
	$(RM) *.exe *.dll *.svg *.txt *.log