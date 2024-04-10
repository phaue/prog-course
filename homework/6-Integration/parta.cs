using System;
using static System.Console;
using static System.Math;

public class main{

//test functions
public static double f1(double x){return Sqrt(x);}
public static double f2(double x){return 1/Sqrt(x);}
public static double f3(double x){return 4*Sqrt(1-Pow(x,2));}
public static double f4(double x){return Log(x)/Sqrt(x);}

public static double erf(double z, double ep=0.001, double delta=0.001){
    if(z<0) return -erf(-z);
    var f = new Func<double,double> (x=>Exp(-x*x));
    if(z <= 1) {
        return 2/Sqrt(PI)*integration.integrate(f, 0, z, delta, ep);
        }
    else{
        var g = new Func<double,double> (t=>f((z+(1-t)/t))/t/t);
        return 1-2/Sqrt(PI)*integration.integrate(g, 0, 1, delta, ep);
    }
}

    static int Main(){ 
        // Integration checks
        double a = 0;
        double b = 1;

        WriteLine("Check of 4 basic functions using the integrator:");
        WriteLine($"The first function gives: {integration.integrate(f1, a, b)} and should equal 2/3");
        WriteLine($"The second function gives: {integration.integrate(f2, a, b)} and should equal 2");
        WriteLine($"The third function gives: {integration.integrate(f3, a, b)} and should equal pi");
        WriteLine($"The fourth function gives: {integration.integrate(f4, a, b)} and should equal -4");
        WriteLine($"The error margin is set to be 0.001 \n");

        //error function output
        var outstream = new System.IO.StreamWriter("out_erf.txt", append:false);
        for(double k=-3;k<=3;k+=1.0/8){
            outstream.WriteLine($"{k} {erf(k)}");
        }
        outstream.Close();

        // accuracy estimation
        WriteLine("Deviation from tabulated values for this error function in comparrison to the one from lecture 6");
        WriteLine("x value | This erf error=  |  Other erf error=");
        var instream = new System.IO.StreamReader("erf.data.txt");
        genlist<double> xs = new genlist<double>();
        genlist<double> ys = new genlist<double>();
        for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
            string[] words = line.Split('\t', ' ');
			xs.add(double.Parse(words[0]));
            ys.add(double.Parse(words[1]));
			}
		instream.Close();
        vector erf_errors = new vector(xs.size);
        vector olderf_errors = new vector(xs.size);
        for(int j =0;j<xs.size;j++){
            WriteLine($"{xs[j]} {ys[j]-erf(xs[j])} {ys[j]-sfuns.olderf(xs[j])}");
            erf_errors[j] = ys[j]-erf(xs[j]);
            olderf_errors[j] = ys[j]-sfuns.olderf(xs[j]);
        }
        int maxindex = Array.IndexOf(erf_errors, erf_errors.max());
        WriteLine($"\n The worst accuracy is at {xs[maxindex]}, so now we check for lower epsilons if it is possible to get a better accuracy");
        vector epsis = new vector(0.001, 0.0001, 0.00001, 0.000001, 0.0000001, 0.00000001, 0.000000001, 0.0000000001);
        
        
        for(int i=0;i<epsis.size;i++){
            WriteLine($"{epsis[i]} {(ys[maxindex]-erf(xs[maxindex], epsis[i], epsis[i]))} {olderf_errors[maxindex]}");
        } 
        
        WriteLine($"Thus we achieve a better accuracy when epsilon and delta become small enough");
    return 0;
    }

}