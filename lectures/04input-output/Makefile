default: Out-stdio.txt out.txt
# Hvis flere end 1 fil skal laves laves der et dummy target som afhænger af begge de filer som gerne skal laves	


Out-stdio.txt : stdio.exe input Makefile
	mono $< <input 1>$@ 2>log-stdio.txt
	# $< henviser til den første prerequisite stdio.exe hvor der bliver specificeret at den skal tage filen input som sit 	#input og gøre noget med. Så bliver "Out" delen sendt over i $@ ved hjælp af 1tallet og Errordelen sendes over i en log fil
	echo "\n" >> $@
	# dobbelt >> står for append, ellers hvis > have været brugt havde den overwrited
	cat input | mono $< 1>>$@ 2>>log-stdio.txt
	# dette er en anden måde at skrive at input filen bliver smidt ind som input i stdio.exe og så appender vi tingene ige

stdio.exe: stdio.cs
	mcs -target:exe -out:$@ $<


cmdline.exe: cmdline.cs
	mcs -target:exe -out:$@ $<

out.txt : cmdline.exe input.txt
	mono cmdline.exe -input:input.txt -output:$@ -numbers:2,3.45,6
	# her igen specificeres der en input fil som hedder input.txt og så giver vi den også en string igennem -numbers hvor # at den streng bliver sendt over i programmet så vi kan hente informationen.
