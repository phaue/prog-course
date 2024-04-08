using System;
using static System.Console;
using static System.Math;

public class main{
	static public double epsilon=0;
	
	public static vector u(double x, vector y){
		double[] firstorderdifs = new double[2];
		firstorderdifs[0] = y[1]; // y0'=y1
		firstorderdifs[1] = 1-y[0]+epsilon*y[0]*y[0];
		return new vector(firstorderdifs);
    }

    static int Main(string[] args){
	    foreach(string arg in args){
		    var words=arg.Split('=');
		    if(words[0]=="epsilon")epsilon=double.Parse(words[1]);
	    }
	    System.Console.Error.WriteLine($"epsilon={epsilon}");

	double phi_ini = 0;
	double phi_final = 20;

	// part i) of genrel exercise
	var outstream_i = new System.IO.StreamWriter("genrel_i.txt", append:false);
	vector yi_i = new vector(1, 0);
	var y_isol = ODE.make_ode_ivp_interpolant(u, (phi_ini,phi_final), yi_i);
	outstream_i.WriteLine("# Solution of general relativity problem");	
	outstream_i.WriteLine("# Phi:, inverse r:, derivative of inverse r:, x:, y:");
	for(double  phi=0;phi<phi_final;phi+=0.2){
		outstream_i.WriteLine($"{phi:f5} {y_isol(phi)[0]:f5} {y_isol(phi)[1]:f5} {1/y_isol(phi)[0]*Cos(phi)} {1/y_isol(phi)[0]*Sin(phi)}");
	}
	outstream_i.Close();

// part ii) of genrel exercise
	var outstream_ii = new System.IO.StreamWriter("genrel_ii.txt", append:false);
	vector yi_ii = new vector(1, -0.5);
	var y_iisol = ODE.make_ode_ivp_interpolant(u, (phi_ini,phi_final), yi_ii);
	outstream_ii.WriteLine("# Solution of general relativity problem");	
	outstream_ii.WriteLine("# Phi:, inverse r:, derivative of inverse r:, x:, y:");
	for(double  phi=0;phi<phi_final;phi+=0.2){
		outstream_ii.WriteLine($"{phi:f5} {y_iisol(phi)[0]:f5} {y_iisol(phi)[1]:f5} {1/y_iisol(phi)[0]*Cos(phi)} {1/y_iisol(phi)[0]*Sin(phi)}");
	}
	outstream_ii.Close();

// part iii) of genrel exercise
	var outstream_iii = new System.IO.StreamWriter("genrel_iii.txt", append:false);
	epsilon = 0.01;
	vector yi_iii = new vector(1, -0.7);
	var y_iiisol = ODE.make_ode_ivp_interpolant(u, (phi_ini,phi_final), yi_iii);
	outstream_iii.WriteLine("# Solution of general relativity problem");	
	outstream_iii.WriteLine("# Phi:, inverse r:, derivative of inverse r:, x:, y:");
	for(double  phi=0;phi<phi_final;phi+=0.2){
		outstream_iii.WriteLine($"{phi:f5} {y_iiisol(phi)[0]:f5} {y_iiisol(phi)[1]:f5} {1/y_iiisol(phi)[0]*Cos(phi)} {1/y_iiisol(phi)[0]*Sin(phi)}");
	}
	outstream_iii.Close();

		return 0;
	} //Main

}//main
//skal omskrive outputtet til x og y coordinater som der står på hjemmesiden hvor $2 er inverse r og $1 er phi