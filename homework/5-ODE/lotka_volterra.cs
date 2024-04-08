using System;
using static System.Console;
using static System.Math;

class main{
	public static vector f(double x, vector y){ // let f be [theta, omega]
		double[] firstorderdifs = new double[2];
		//a=1.5 ,b=1, c=3, d=1
		firstorderdifs[0] = 1.5*y[0]-y[0]*y[1];
		firstorderdifs[1] = -3*y[1]+y[0]*y[1];
		return new vector(firstorderdifs);
	}


	static int Main(){
		
		WriteLine("Solution of Lotka Volterra problem");	
		vector y0 = new vector(10, 5);
	double ti = 0;
	double tf = 15;
	var (tsol, xysol) = ODE.driver(f, (ti,tf), y0);
	WriteLine("t value, x(t) value, y(t) value");
        for(int i=0;i<tsol.size;i++){
        WriteLine($"{tsol[i]}, {xysol[i][0]} {xysol[i][1]}");
        }	
		return 0;
	}
}
