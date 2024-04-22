using System;
using static System.Console;
using static System.Math;

public class main{

    public static double M(double E, double rmin, double rmax, double acc=0.01, double eps=0.01){
        Func<double,vector,vector> f = delegate(double r, vector y) {return new vector(y[1], -2/r*y[0]-2*E*y[0]);};
        vector fstart = new vector((rmin-rmin*rmin), 1-2*rmin);
        var (rsol, fsol) = ODE.driver(f, (rmin,rmax), fstart, acc, eps);
        int s = rsol.size;
        return fsol[s-1][0]; //solution at rmax
        }

    static int Main(){
        double rmin = 0.1;
        double rmax = 8;    
        double Estart = -0.7;
        Func<double, double> m = delegate(double E) {return M(E, rmin, rmax);};
        double Efound = roots.newton(m, Estart);
        WriteLine($"The estimated ground state energy from the auxilary function is{Efound}");
        
        double Eactual = -0.5;
        Func<double, double> f0 = delegate(double r) {return r*Exp(-r);};
        Func<double,vector,vector> fnum = delegate(double r, vector y) {return new vector(y[1], -2/r*y[0]-2*Efound*y[0]);};
        vector fini = new vector((rmin-rmin*rmin), 1-2*rmin);
        var ysol = ODE.make_ode_ivp_interpolant(fnum, (rmin,rmax), fini);

        var outstream = new System.IO.StreamWriter("wf.txt", append:false);
        for(double  r=rmin;r<rmax;r+=0.1){
		    outstream.WriteLine($"{r:f5} {ysol(r)[0]:f5} {f0(r):f5}");
        }
        outstream.Close();

        //conv with respect to rmax
        var outrmax = new System.IO.StreamWriter("conv_rmax.txt", append:false);
        for(double rm = 2;rm<=10;rm+=0.5){
            Func<double, double> ms = delegate(double E) {return M(E, rmin, rm);};
            double Ef = roots.newton(ms, Estart);
            outrmax.WriteLine($"{rm:f5} {Ef} {Eactual}");
        }
        outrmax.Close();

         //conv with respect to rmin
        var outrmin = new System.IO.StreamWriter("conv_rmin.txt", append:false);
        for(double rm = 0.05;rm<=1;rm+=0.05){
            Func<double, double> ms = delegate(double E) {return M(E, rm, rmax);};
            double Ef = roots.newton(ms, Estart);
            outrmin.WriteLine($"{rm:f5} {Ef} {Eactual}");
        }
        outrmin.Close();

        //conv with respect to acc and eps
   
        var outacc = new System.IO.StreamWriter("conv_acc.txt", append:false);
        for(double i=1;i>0.000000000000001;i/=2){

            Func<double, double> ms = delegate(double E) {return M(E,rmin,rmax, i);};
            double Ef = roots.newton(ms, Estart);
            outacc.WriteLine($"{i} {Ef} {Eactual}");
        }
        outacc.Close();
        //conv with respect to acc and eps
        var outeps = new System.IO.StreamWriter("conv_eps.txt", append:false);
        for(double i=1;i>0.000000000000001;i/=2){
            Func<double, double> ms = delegate(double E) {return M(E,rmin,rmax, 0.01, i);};
            double Ef = roots.newton(ms, Estart);
            outeps.WriteLine($"{i} {Ef} {Eactual}");
        }
        outeps.Close();
        return 0;
    }
}