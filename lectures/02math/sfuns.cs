using static System.Math;
public static class sfuns{
// vigtigt vi deklerere den til at public ellers vil den være private og hvis den er privat kan den ikke kaldes i andre dokumenter, og det er meningen med et bibliotek at kunne kalde dem i andre filer.
//static double PI = 3.1415927;

public static double fgamma(double x){
///single precision gamma function (formula from Wikipedia)
	if(x<0)return PI/Sin(PI*x)/fgamma(1-x); // Euler's reflection formula
	if(x<9)return fgamma(x+1)/x; // Recurrence relation
	double lnfgamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
	return Exp(lnfgamma);
}
//ovenfor har vi defineret klassen sfuns som er public og så i den klasse har vi defineret funktionen fgamma som også er public, statisk og en double. Den tager argumentet x som også er en double, men den kan også tage ints da ints også kan betragtes som en double, men ikke omvendt.
//funktionen indeholder to if statements der afhænger af værdien af x og den returnere lnfgamma hvis x er større end 9

}//class sfuns
