using System;
using static System.Console;
using static System.Math;

public class main{
	
	public static vector u(double x, vector y){
		double[] firstorderdifs = new double[2];
		firstorderdifs[0] = y[1]; // y0'=y1
		firstorderdifs[1] = 1-y[0];//+0*y[0]*y[0]; // y1' = 1-y0+eps*y0*y0
		return new vector(firstorderdifs);
    }

    static int Main(){
    WriteLine("Solution of general relativity problem");	
	vector yi = new vector(1, 0);
	double ti = 0;
	double tf = 10;
	var (xisol, yisol) = ODE.make_ode_ivp_interpolant(u, (ti,tf), yi);
	WriteLine("t value, theta(t) value, omega(x) value");
    for(int i=0;i<xisol.size;i++){
        WriteLine($"{xisol[i]}, {yisol[i][0]} {yisol[i][1]}");
    }
		return 0;
	} //Main

}//main