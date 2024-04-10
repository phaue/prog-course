CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/

default : Out_partb.txt erf.gnuplot.svg

erf.gnuplot.svg : Out_parta.txt
	echo '\
                set terminal svg background "white";\
                set out "$@" ;\
                set xlabel "x";\
                set title "Error function";\
                set grid;\
                plot[-3:3]\
                "out_erf.txt" using 1:2 with lines title "erf(x)"\
				,"erf.data.txt" using 1:2 with points pointtype 3 lc rgb "green" title "Tabulated values" \
				,"erf.data.txt" using (-($$1)):(-($$2)) with points pointtype 3 lc rgb "green" notitle;\
                ' | gnuplot


Out_parta.txt : parta.exe
	mono $< > $@
Out_partb.txt : partb.exe
	mono $< > $@
parta.exe : parta.cs lib.dll
	$(MKEXE)
partb.exe : partb.cs lib.dll
	$(MKEXE)
lib.dll : integration.cs sfuns.cs $(LIBPATH)genlist.cs $(LIBPATH)vector.cs
	$(MKLIB)

.PHONEY : clean
clean : 
	$(RM)  *.dll *.exe *.svg [Oo]u*.txt