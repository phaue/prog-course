using System;
using static System.Console;
using static System.Math;

public class main{
	
	public static vector f(double x, vector y){ // let f be [theta, omega]
		double[] firstorderdifs = new double[2];
		//b=0.25 and c=5.0
		firstorderdifs[0] = y[1];
		firstorderdifs[1] = -0.25*y[1]-5.0*Sin(y[0]);
		return new vector(firstorderdifs);
	}

	static int Main(){
	//solution of odeint
	WriteLine("Solution of odeint manual problem");	
	vector y0 = new vector(PI-0.1, 0);
	double ti = 0;
	double tf = 10;
	var (tsol, Ysol) = ODE.driver(f, (ti,tf), y0);
	WriteLine("t value, theta(t) value, omega(x) value");
        for(int i=0;i<tsol.size;i++){
        WriteLine($"{tsol[i]}, {Ysol[i][0]} {Ysol[i][1]}");
        }
		return 0;
	} //Main

}//main
