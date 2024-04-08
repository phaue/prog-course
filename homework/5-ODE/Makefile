CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
LIBPATH = ../Library/

default : genrel.gnuplot.svg odeint.gnuplot.svg  lotka_volterra.gnuplot.svg


genrel.gnuplot.svg : Out_genrel.txt
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "x";\
		set xlabel "y";\
		set title "Different solutions to the general relativity problem";\
		set grid;\
		set key right bottom;\
		set xrange[-2.7:2.7];\
		set yrange[-2:3.5];\
		plot\
		"genrel_i.txt"  using 4:5 with lines title "i) eps=0, u0=1, uprime0=0"\
		,"genrel_ii.txt"  using 4:5 with lines title "ii) eps=0, u0=1, uprime0=-0.5"\
		,"genrel_iii.txt"  using 4:5 with lines title "iii) eps=0.01, u0=1, uprime0=-0.7";\
		' | gnuplot

lotka_volterra.gnuplot.svg : Out_lotka_volterra.txt
	echo '\
                set terminal svg background "white";\
                set out "$@" ;\
                set xlabel "t";\
                set title "Lotka-Volterra 2nd order dif";\
                set grid;\
                plot\
                "Out_lotka_volterra.txt" using ($$1):($$2) with lines title "x(t)"\
                ,"Out_lotka_volterra.txt" using ($$1):($$3) with lines title "y(t)";\
                ' | gnuplot


odeint.gnuplot.svg : Out_odeint.txt
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "t";\
		set title "2nd order dif eq of a pendulum with friction";\
		set grid;\
		plot\
		"Out_odeint.txt"  using ($$1):($$2) with lines title "theta(t)"\
		,"Out_odeint.txt"  using ($$1):($$3) with lines title "omega(t)";\
		' | gnuplot

Out_lotka_volterra.txt : lotka_volterra.exe
	mono $< > $@
Out_odeint.txt : odeint.exe
	mono $< > $@
Out_genrel.txt : genrel.exe
	mono $< > $@

genrel.exe : genrel.cs lib.dll
	$(MKEXE)

lotka_volterra.exe : lotka_volterra.cs lib.dll
	$(MKEXE)

odeint.exe : odeint.cs lib.dll
	$(MKEXE)


lib.dll : $(LIBPATH)vector.cs runge.cs genlist.cs
	$(MKLIB)


.PHONEY : clean
clean : 
	$(RM) *.exe *.dll *.svg *.txt






