using System;
using static System.Console;
using static System.Math;
public class main{


static int Main(string[] args){
    int nrpoints = 1000;
    if(args.Length>0)nrpoints=(int)double.Parse(args[0]);
    Func<vector, double> f= x =>{
        return 1/((1-Cos(x[0])*Cos(x[1])*Cos(x[2]))*Pow(PI,3));
    };
    vector a = new vector(0.0,0.0,0.0); //starting conditions
	vector b = new vector(PI, PI, PI); // end conditions
	(double res, double err) = mc.plainmc(f,a,b,nrpoints);
	double exactarea = 1.3932039296856768591842462603255; //of a quarter of the unit circle


	WriteLine($"{nrpoints} {res} {err} {Abs(res-exactarea)}");
    return 0;
	}

}// main