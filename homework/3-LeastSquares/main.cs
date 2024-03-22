using System;
using static System.Math;
using static System.Console;
class main{
	
	static (vector ,matrix) lsfit(Func<double,double>[] fs , vector x, vector y, vector dy){
	       int n = x.size;
	       int m=fs.Length;
	       //WriteLine($"(xsize, n={n}, fslength, m={m}");
	       matrix A = new matrix(n,m);
	       vector b = new vector(n);
	       for(int i=0;i<n; i++){
		      // WriteLine($"i loop with i={i}");
		       b[i]=y[i]/dy[i];
		      // WriteLine($"b[{i}]={b[i]}, y[{i}]={y[i]}, dy[{i}]={dy[i]}");
		      
		      for(int k=0;k<m;k++){
			     // WriteLine($"A[{i}][{k}]=> fs[{k}]({x[i]})={fs[k](x[i])} dy[{i}]={dy[i]}");
			      A[k][i]=fs[k](x[i])/dy[i];

			     // WriteLine($"k loop with k={k}");
		      }
		      }
	       (matrix Q, matrix R) = QRGS.decomp(A);
	       vector c = QRGS.solve(Q, R, b); /* solves ||A∗c−b||−>min*/
	       matrix r = QRGS.inverse(R);
	       matrix sig = r*r.transpose();
	       return (c, sig);
	}
	
	

	public static int Main(){
		double[] time = new double[] {1,2,3,4,6,9,10,13,15};
		double[] y = new double[] {117,100,88,72,53,29.5,25.2,15.2,11.1};
		double[] yerr = new double[] {6,5,4,4,4,3,3,2,2};
		/* write the data values to an array */	
	       	var outstream2 = new System.IO.StreamWriter("datainput.txt", append:false);
                for(int i=0;i<time.Length;i++){
                        outstream2.WriteLine($"{time[i]} {y[i]} {yerr[i]}");
                }
                outstream2.Close();
		
		/* update data points to the fit */
		for(int i=0;i<yerr.Length;i++){
			yerr[i]=yerr[i]/y[i];
			y[i] = Log(y[i]);
		}
		var Fs = new Func<double,double>[] {z=>1.0, z=>z};
		(vector c, matrix vars) = lsfit(Fs, time, y, yerr);
		WriteLine("c vector gives: ");
		c.print();
		WriteLine("Error matrix gives: ");
		vars.print();
		/*define the values a and lambda from the fit*/
		double a = Exp(c[0]);
		double lambda = c[1];
		double lambdaerr = Sqrt(vars[1][1]);

		/*updated a and lambda according to uncertainties*/
		double aplus = Exp(c[0]+Sqrt(vars[0][0]));
		double aminus = Exp(c[0]-Sqrt(vars[0][0]));
		double lambdaplus = lambda+lambdaerr;
		double lambdaminus = lambda-lambdaerr;
		var funcs = new Func<double,double>[] {x=>a*Exp(lambda*x), x=>aplus*Exp(lambdaplus*x), x=>aminus*Exp(lambdaminus*x)};
		
		double stepsize = 0.1;
		int steps = (int)(time[time.Length-1]/stepsize);
		double[][] results = new double[funcs.Length][];
		double[] times = new double[steps];
		for(int k=0; k<funcs.Length;k++){
			results[k] = new double[steps];
			for(int i=0;i<steps;i++){
				double t = i*stepsize;
				results[k][i]=funcs[k](t);
				times[i]=i*stepsize;
				}
				}
		/*Writing all functions out to a file, with c, c+ and c-*/
		var outstream = new System.IO.StreamWriter("funcinput.txt", append:false);
		for(int i =0;i<steps;i++){
			outstream.WriteLine($"{times[i]} {results[0][i]}  {results[1][i]} {results[2][i]}");
		}
		outstream.Close();		
		
		/*determination of the halflife of Thx*/
		WriteLine($"The half-life can be found for the formula T½=ln(2)/lambda which in this case gives: ");
		double halflife = Log(2)/Abs(lambda);
		double halflifeerr = Log(2)/Pow(lambda,2) * lambdaerr;
		WriteLine($"{halflife} +- {halflifeerr}  days");
		WriteLine($"And the experimental halflife is 3.631 days, which means the found halflife is slightly wrong and not within the uncertainty");
		
/* plot resten af funcs funktionerne
 * estimer usikkerheden af halveringstiden vha den geometriske formel for usikkerheder ellers kig i noterne */

		return 0;
	}
}
