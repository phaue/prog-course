Out.txt: main.exe main2.exe Makefile
	mono main.exe one two three > Out.txt
	mono main2.exe >> Out.txt
# ved at skrive en string, f.eks. one two three som ovenfor kan de værdier sendes ind i main.exe
# dette bliver argumentet til main.exe som så bliver sendt i gennem funktionen hvis vi har specificeret et input
main.exe: main.cs
	mcs -target:exe -out:$@ $<
	# -out:$@ er en pointer til vores output fil som er specificeret til at være main.exe
	#  $< er en pointer til vores prerequisite som er defineret til at være main.cs
	
main2.exe: main2.cs
	mcs -target:exe -out:$@ $<
# nu behøver jeg ligeledes ikke at specificere out filen og prerequiciten fordi der er brugt pointers
clean:
	$(RM) Out.txt main.exe
