using System;
using static System.Console;
using static System.Math;

class main{
	static int Main(){
	WriteLine("Calculations done using complex numbers:\n");
	complex a = new complex();
	a = -1;
	WriteLine($"sqrt of -1 = {cmath.sqrt(a)}\n");
	WriteLine($"sqrt of i = {cmath.sqrt(complex.I)}\n");
	WriteLine($"e to the i = {cmath.exp(complex.I)}\n");
	WriteLine($"e to i*pi = {cmath.exp(complex.I*PI)}\n");
	WriteLine($"i to the i = {cmath.pow(complex.I, complex.I)}\n");
	WriteLine($"Log of i = {cmath.log(complex.I)}\n");
	WriteLine($"sin(i*pi) = {cmath.sin(complex.I*PI)}\n");
	WriteLine("Now we check if the calculated values are the same as the correct values: \n");
	
	complex s = new complex();
	s = cmath.sqrt(a);
	WriteLine($"is sqrt of -1 correct?: {cmath.approx(cmath.arg(s), cmath.arg(complex.I))}\n");
	//WriteLine($"is sqrt of -1 correct?: {cmath.arg(complex.I)}\n");

	WriteLine($"is Log of i correct?: {cmath.approx(cmath.arg(cmath.log(complex.I)),cmath.arg(complex.I*PI/2))}\n");
	 WriteLine($"is sqrt of i correct?: {cmath.approx(cmath.arg(cmath.sqrt(complex.I)),cmath.arg( 1/cmath.sqrt(2) + complex.I/cmath.sqrt(2)))}\n");
	 

 
	WriteLine($"is i to the i correct?: {cmath.approx(cmath.arg(cmath.pow(complex.I, complex.I)),cmath.arg(0.208))} \n");



	return 0;
		
	}
}

