using System;
using static System.Console;
using static System.Math;

public class main{
	
	public static vector u(double x, vector y){
		double[] firstorderdifs = new double[2];
		firstorderdifs[0] = y[1]; // u' = u''
		firstorderdifs[1] = -y[0]; // u'' = -u
		return new vector(firstorderdifs);
	}
	
	public static vector f(double x, vector y){ // let f be [theta, omega]
		double[] firstorderdifs = new double[2];
		//b=0.25 and c=5.0
		firstorderdifs[0] = y[1];
		firstorderdifs[1] = -0.25*y[1]-5.0*Sin(y[0]);
		return new vector(firstorderdifs);
	}

	static int Main(){
	/*
	//Solution of u''=-u differential equation
	double a = 0;
	double b = 10;
	vector ystart = new vector(1,0);
	var (xsol, ysol) = runge.driver(u, (a,b), ystart);

	
	var outstream = new System.IO.StreamWriter("u''.txt", append:false);
	outstream.WriteLine($"The solution of u''=-u given an interval of [{a},{b}] and starting conditions for u''={ystart[0]} and u={ystart[1]}");
	outstream.WriteLine("x value, u''(x) value, u(x) value");
	for(int i=0;i<xsol.size;i++){
	outstream.WriteLine($"{xsol[i]}, {ysol[i][0]} {ysol[i][1]}");
	}
	outstream.Close();
	*/
	//solution of odeint
	WriteLine("Solution of odeint manual problem");	
	vector y0 = new vector(PI-0.1, 0);
	double ti = 0;
	double tf = 10;
	var (tsol, Ysol) = runge.driver(f, (ti,tf), y0);
	WriteLine("t value, theta(t) value, omega(x) value");
        for(int i=0;i<tsol.size;i++){
        WriteLine($"{tsol[i]}, {Ysol[i][0]} {Ysol[i][1]}");
        }
		return 0;
	} //Main

}//main
