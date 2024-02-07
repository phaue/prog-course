using static System.Math;
using static System.Console;

static class main{
	static double sqrt2 = Sqrt(2.0);
	static double pot2 = Pow(2.0, 0.2);
	static double etopi = Pow(E, PI);
	static double pitoe = Pow(PI, E);
	
	

	static int Main(){
		Write("Task 1:\n");
		Write($"Sqrt(2)={sqrt2}, and Sqrt(2)^2={sqrt2*sqrt2} should equal 2\n");
		Write($"2 to the power of 1/5={pot2}, and 2^(1/5)*2^5={Pow(pot2, 5)} should equal 2\n");
		Write($"e to the power of pi ={etopi}, and e^pi should equal 23.14 \n");
		
		Write($"pi to the power of e ={pitoe}, and pi^e should equal 22.46 \n");
		
		Write("\n");
		Write("Task 2:\n");
		for(int i=1; i<=10; i++)Write($"gamma({i})={sfuns.fgamma(i)}\n");
		
		Write("\n Task 3:\n");
		for(int i=1; i<=10; i++)Write($"lngamma({i})={sfuns.lngamma(i)}\n");
		
		

		return 0;
	}
}


