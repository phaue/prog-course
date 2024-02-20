CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:,$(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Out.txt : main.exe Makefile 
	mono $< > $@


main.exe : main.cs cmath.dll; $(MKEXE)

cmath.dll : cmath.cs complex.cs ; $(MKLIB)


