CODE = $(filter %.cs , $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)


default : matrix.dll



matrix.dll : vectorclass.cs matrixclass.cs ; $(MKLIB)




.PHONEY : clean
clean:
	$(RM) [Oo]ut.txt *.exe *.dll [Ll]og.txt
