using static System.Math;
using System;

public static class sfuns{
	
	//gamma function
	public static double gamma(double x){
	///single precision gamma function (Gergo Nemes, from Wikipedia)
	if(x<0)return PI/Sin(PI*x)/gamma(1-x);
	if(x<9)return gamma(x+1)/x;
	double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
	return Exp(lngamma);
	}

	//factorial function
	public static int factorial(int x){
		if(x==0) return 1;
		else return  x*factorial(x-1);
	}
	
	//lnfactorial function
        public static double lnfactorial(double x){
                if(x==0) return 0;
                else return  Log(x)+ lnfactorial(x-1);
        }

		
	//stirling
	public static double stirling(double x){
		double approxn = Sqrt(2*PI*x)*Pow((x/E),x);
		return approxn;
	}

	//lnstirling
	public static double lnstirling(double x){
                double approxn = Sqrt(2*PI*x)*Pow((x/E),x);
                return Log(approxn);
        }
	

	//log gamma function
	public static double lngamma(double x){
	if(x<=0) throw new ArgumentException("lngamma: x<=0");
	if(x<9) return lngamma(x+1)-Log(x);
	return x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
}
	

	}
