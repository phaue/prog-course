CODE = $(filter %.cs ,$^)
LIBS = $(addprefix -reference:,$(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
#TIME = time --output=$@ --append --format "$$nthreads %e %U"
TIME = time --portability --append --output $@

N=1e8

default: Out.txt out-for.txt out-for2.txt
out-for2.txt : main-for2.exe Makefile
	>$@
	$(TIME) mono $< -terms:$(N) -threads:1 >>$@
	$(TIME) mono $< -terms:$(N) -threads:2 >>$@
	$(TIME) mono $< -terms:$(N) -threads:3 >>$@
	$(TIME) mono $< -terms:$(N) -threads:4 >>$@



out-for.txt : main-for.exe Makefile
	>$@
	$(TIME) mono $< -terms:$(N) -threads:1 >>$@
	$(TIME) mono $< -terms:$(N) -threads:2 >>$@
	$(TIME) mono $< -terms:$(N) -threads:3 >>$@
	$(TIME) mono $< -terms:$(N) -threads:4 >>$@


Out.txt : main.exe Makefile
	>$@
	$(TIME) mono $< -terms:$(N) -threads:1 >>$@
	$(TIME) mono $< -terms:$(N) -threads:2 >>$@
	$(TIME) mono $< -terms:$(N) -threads:3 >>$@
	$(TIME) mono $< -terms:$(N) -threads:4 >>$@

main.exe : main.cs ; $(MKEXE)
main-for.exe : main-for.cs ; $(MKEXE)
main-for2.exe : main-for2.cs ; $(MKEXE)

.PHONEY : clean
clean:
	$(RM) [Oo]ut.txt [Ll]og.txt *.exe *.dll
	
