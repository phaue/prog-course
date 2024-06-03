CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/


default : csplines.gnuplot.svg qsplines.gnuplot.svg linsplines.gnuplot.svg Out_testqspline.txt

csplines.gnuplot.svg : Out_csplines.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "x";\
		set grid;\
		set term svg size 700,1000;\
		set multiplot layout 3,1 columns;\
		set title "Evaluation of the function";\
		plot\
		"$<" using ($$1):($$3) with lines title "Implemented cspline" \
		,"$<" using ($$1):($$2) smooth cspline title "Gnuplot cspline";\
		set title "Derivative of the function";\
		plot\
		"$<"  using ($$1):($$4) with lines lc rgb "red" notitle;\
		set title "Integral of the function";\
		plot\
		"$<" using ($$1):($$5) with lines lc rgb "blue" notitle;\
		unset multiplot;\
		' | gnuplot

qsplines.gnuplot.svg : Out_qsplines.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "x";\
		set grid;\
		set term svg size 700,1000;\
		set multiplot layout 3,1 columns;\
		set title "Evaluation of the function";\
		plot\
		"$<" using ($$1):($$2) with lines notitle ;\
		set title "Derivative of the function";\
		plot\
		"$<"  using ($$1):($$3) with lines lc rgb "red" notitle;\
		set title "Integral of the function";\
		plot\
		"$<" using ($$1):($$4) with lines lc rgb "blue" notitle;\
		unset multiplot;\
		' | gnuplot           

linsplines.gnuplot.svg : Out_linsplines.txt
	echo '\
                set terminal svg background "white";\
                set out "$@" ;\
                set xlabel "x";\
                set title "";\
                set grid;\
				set label "Integration gives 0.377" at 6.8,0.8 ;\
				show label;\
                plot\
                "Out_linsplines.txt" using ($$1):($$2) with lines title "x";\
                ' | gnuplot
Out_csplines.txt : cspline.exe
	mono $< > $@
Out_qsplines.txt : qsplines.exe
	mono $< > $@
Out_linsplines.txt : linearspline.exe
	mono $< > $@
Out_testqspline.txt : testqspline.exe
	mono $< > $@
linearspline.exe : linearspline.cs lib.dll
	$(MKEXE)
qsplines.exe : qspline.cs lib.dll
	$(MKEXE)
cspline.exe : cspline.cs lib.dll
	$(MKEXE)
testqspline.exe : testqspline.cs lib.dll
	$(MKEXE)
lib.dll : $(LIBPATH)vector.cs splines.cs
	$(MKLIB)

.PHONEY : clean
clean : 
	$(RM) *.txt *.svg *.exe *.dll