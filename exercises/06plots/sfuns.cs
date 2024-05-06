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

public static double erf(double x){
/// single precision error function (Abramowitz and Stegun, from Wikipedia)
if(x<0) return -erf(-x);
double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
double t=1/(1+0.3275911*x);
double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));/* the right thing */
return 1-sum*Exp(-x*x);
} 
	

	}
