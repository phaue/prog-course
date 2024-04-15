using System;
using static System.Console;
using static System.Math;
public class main{


static int Main(string[] args){
    int nrpoints = 1000;
    if(args.Length>0)nrpoints=(int)double.Parse(args[0]);
    Func<vector, double> f= x =>{
        return x[0];// return radius
        }; 
    vector a = new vector(0.0,0.0); //starting conditions, r=0, phi=0
	vector b = new vector(1.0,2*PI); // end conditions, r=1, phi=2pi
	(double res, double err) = mc.plainmc(f,a,b,nrpoints);
	double exactarea = PI; 
	WriteLine($"{nrpoints} {res} {err} {Abs(res-exactarea)}");
    return 0;
	}

}// main
