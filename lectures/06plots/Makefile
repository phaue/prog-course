CODE = $(filter %.cs,$^)#filters files given as the argument, in this case % is equal to * in the terminal
# A macro - automatic variable, bliver først expanded når den kaldes senere, hvis istedet vi bruer := bliver den expanded med
# # det samme
LIBS = $(addprefix -reference:,$(filter %.dll,$^))#filter dlls from all prerequisites
# sæt reference på så den bliver ligesom i en normal makefile
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
# makroer til at hurtigt kalde om vi skal generere et library eller en exe istedet for at skrive det hver eneste gang


Erf.gnuplot.svg : Out.txt Makefile
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
	#Kan plotte flere plots som gjort ovenfor | "using 1:2" betyder at vi skal plotte kolonne 1 mod kolonne 2
	# har en indbygget manual some kan findes ved at skrive "gnuplot" i terminal og så help "somecommand"

#Det der bliver sendt over i log filen kan bruges til at lave plottet igen. Hvis der kaldes gnuplot "log" så generes plottet 
# på ny

#png eller svg , png er et bitmap og svg er et vector map - dvs svg holder opløsningen efter indzomming

Out.txt: main.exe
	mono $< > $@

sfuns.dll: sfuns.cs ; $(MKLIB)
main.exe : main.cs sfuns.dll; $(MKEXE)



