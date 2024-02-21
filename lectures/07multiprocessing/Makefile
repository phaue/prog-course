CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
TIME = time --output=$@ --append --format "$$nthreads %e %U"


Out.times.svg : out.times.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "number of threads" ;\
		set ylabel "real time" ;\
		set title "running time as a function of threads" ;\
		plot "$<" using 1:2 with lp ;\
		'| tee log.gpi | gnuplot


N=2e9
out.times.txt : main.exe
	for nthreads in 1 2 3 4; do\
		$(TIME) mono main.exe -nthreads:$$nthreads -nterms:$(N); \
		done

main.exe : main.cs ; $(MKEXE)

clean:	
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
