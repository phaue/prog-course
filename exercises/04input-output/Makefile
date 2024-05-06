default: Out1.txt Out2.txt Out3.txt

Out1.txt : main.exe Makefile
	mono main.exe -numbers:1,2,3,4,5 1> Out1.txt
	
Out2.txt : main2.exe
	echo 1 2 3 4 5 > task2input.txt
	mono main2.exe < task2input.txt 2> Out2.txt

Out3.txt : main3.exe
	mono main3.exe -input:task3input.txt -output:Out3.txt

main.exe : main.cs
	mcs -target:exe -out:$@ $<

main2.exe : main2.cs
	mcs -target:exe -out:$@ $<

main3.exe : main3.cs
	mcs -target:exe -out:$@ $<

.PHONEY : clean
clean : 
	$(RM) *.exe Out*.txt

