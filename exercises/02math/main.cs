using static System.Math;
using static System.Console;

static class main{
	static double sqrt2 = Sqrt(2.0);
	static double pot2 = Pow(2.0, 0.2);
	static double etopi = Pow(E, PI);
	static double pitoe = Pow(PI, E);

	static int Main(){
		Write($"Sqrt(2)={sqrt2}, and Sqrt(2)^2={sqrt2*sqrt2} should equal 2\n");
		Write($"2 to the power of 1/5={pot2}, and 2^(1/5)*2^5={Pow(pot2, 5)} should equal 2\n");
		Write($"e to the power of pi ={etopi}, and e^pi * e^1/pi ={etopi*Pow(E, 1/PI)} should equal e\n");
		Write($"pi to the power of e ={pitoe}, and pi^e * pi^1/e ={pitoe*Pow(PI, 1/E)} should equal pi\n");
		return 0;
	}
}


