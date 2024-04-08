CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/

qsplines.gnuplot.svg : Out_qsplines.txt
	echo '\
                set terminal svg background "white";\
                set out "$@" ;\
                set xlabel "x";\
                set title "";\
                set grid;\
				set label "Integration gives 48.2" at -0.7,26 ;\
				show label;\
				set key left;\
                plot\
				"Out_qsplines.txt"  using ($$1):($$2)title "data" \
				,"Out_qsplines.txt" using ($$1):($$3) title "deriv"\
				,"Out_qsplines.txt" using ($$1):($$4) title "integ" \
				,"Out_qsplines.txt" using ($$1):($$2) with lines title "eval" \
				,"Out_qsplines.txt" using ($$1):($$3) with lines title "deriv" \
				,"Out_qsplines.txt" using ($$1):($$4) with lines title "integ" \
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
                "Out_linsplines.txt" using ($$1):($$2) with lines title "x(t)";\
                ' | gnuplot

Out_qsplines.txt : qsplines.exe
	mono $< > $@
Out_linsplines.txt : linearspline.exe
	mono $< > $@
linearspline.exe : linearspline.cs lib.dll
	$(MKEXE)
qsplines.exe : qspline.cs lib.dll
	$(MKEXE)
lib.dll : $(LIBPATH)vector.cs splines.cs
	$(MKLIB)

.PHONEY : clean
clean : 
	$(RM) *.txt 