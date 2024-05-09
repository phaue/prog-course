using System;
using static System.Console;
using static System.Math;

class main{

	public static int Main(string[] args){
	//making it possible to read the input
	double rmax = 10; double dr = 0.01; // default values 
	foreach(var arg in args) {
   		var words = arg.Split(':');
   		if(words[0]=="-rmax") rmax=double.Parse(words[1]);
   		if(words[0]=="-dr"  ) dr =double.Parse(words[1]);
   	}	
	//finding solutions as a function of changing dr and checking the convergence of energy
	int size = (int)rmax;
	double[] Energies_drs = new double[size];
	double[] drs = new double[size];
	for(int i=0;i<size;i++){
		double idr = size*dr-i*dr;
		matrix H1 = jacobi.Hamiltonian(rmax, idr);
		(vector Hw1, matrix HV1) = jacobi.cyclic(H1);
		Energies_drs[i] = Hw1[0];
		WriteLine($"E0 is {Hw1[0]} for dr={idr}, i={i}");
		drs[i] = idr; /*creates energy, dr arrays */
	}
	// finding solutions as a function of changing rmax and checking the convergence of energy
	double[] Energies_rmaxs = new double[size];
	double[] rmaxs = new double[size];
	for(int i = 1;i<=size; i++){
		matrix H2 = jacobi.Hamiltonian(i, dr);
		(vector Hw2, matrix HV2) = jacobi.cyclic(H2);
		Energies_rmaxs[i-1] = Hw2[0];
		WriteLine($"E0 is {Hw2[0]} for rmax={i}");
		rmaxs[i-1] = i;
	}
	//writing the convergence check to an output file
	var outstream = new System.IO.StreamWriter("convinput.txt",append:false);
	for(int i =0;i<rmax;i++){
		outstream.WriteLine($"{Energies_rmaxs[i]} {rmaxs[i]} {Energies_drs[i]} {drs[i]}");
	}
	outstream.Close();
	

	//finding the solutions and saving them into a file so the wave functions can be plotted
	matrix H = jacobi.Hamiltonian(rmax,dr);
    (vector Hw, matrix HV) = jacobi.cyclic(H);
	double constant = 1/Sqrt(dr);
	int npoints = (int)(rmax/dr)-1;
    vector r = new vector(npoints);
	matrix f = new matrix(4,npoints);
	for(int i=0;i<npoints;i++)r[i]=dr*(i+1);
    for(int k=0;k<4;k++)f[k]= constant*HV[k];
	
	var outstream2 = new System.IO.StreamWriter("lowestinput.txt",append:false);
	for(int i=0;i<npoints;i++){
		outstream2.WriteLine($"{f[0][i]} {-f[1][i]} {f[2][i]} {f[3][i]} {r[i]}");
	}
	outstream2.Close();

	//finding the expression for the analytical wave functions
    vector ranalyt = new vector(npoints);
	for(int i=0;i<npoints;i++)ranalyt[i]=dr*(i+1);
	var outstream3 = new System.IO.StreamWriter("analytical.txt",append:false);
	for(int i=0;i<npoints;i++){
		outstream3.WriteLine($"{r[i]} {2*r[i]*Exp(-r[i])} {1/Sqrt(2)*r[i]*(1-r[i]/2)*Exp(-r[i]/2)}");
	}
	outstream3.Close();
	
		
	
	
	
		return 0;
	}
}
