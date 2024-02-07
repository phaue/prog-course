Out.txt : main.exe
	#mono main.exe > Out.txt 
	mono $< > $@ #alternative way of writing the above by the use of shortcuts
	#the first one points to the first dependency and the second points to the desired target

main.exe : main.cs sfuns.dll
       	# main kan afhænge af flere forskellige filer, sfuns bliver brugt som en reference fil
	mcs -target:exe -reference:sfuns.dll -out:main.exe main.cs
	# dvs at sfuns bliver lavet når main.exe skal laves
	
sfuns.dll : sfuns.cs 
	# denne fil laver et library og ikke en executable, dette gøres når filen ikke skal "gøre" noget
	# men derimod være et bibliotek af funktioner som man senere kan kalde i andre filer
	mcs -target:library -out:sfuns.dll sfuns.cs

clean: 
	#vi skal altid have defineret en clean function - dog skal den konstrueres med en PHONEY hvis det skal gøres korrekt
	$(RM) sfuns.dll main.exe Out.txt 
	#$RM er en command som fjerner de følgende filer

test: 
	# forstod ikke helt hvad test gør? måske viser den bare hvad RM funktionen gør ved at kalde dens string?
	echo $(RM)
