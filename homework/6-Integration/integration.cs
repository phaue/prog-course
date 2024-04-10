using System;
using static System.Math;
using static System.Console;
using static System.Double;

public partial class integration{
//skal lige implementere NaN funktionen eller finde ud af hvordan den skal bruges for at jeg kan compile det her
    public static double integrate
    (Func<double,double> f, double a, double b,
    double δ=0.001, double ε=0.001, double f2=NaN, double f3=NaN)
    {
        double h=b-a;
        if(IsNaN(f2)){ f2=f(a+2*h/6); f3=f(a+4*h/6); } // first call, no points to reuse
        double f1=f(a+h/6), f4=f(a+5*h/6);
        double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // higher order rule
        double q = (  f1+f2+f3+  f4)/4*(b-a); // lower order rule
        double err = Abs(Q-q);
        if(err<= δ+ε*Abs(Q)) return Q;
        else return integrate(f,a,(a+b)/2,δ/Sqrt(2),ε,f1,f2)+integrate(f,(a+b)/2,b,δ/Sqrt(2),ε,f3,f4);
}
public static double erf(double z, double ep=0.001, double delta=0.001){
    if(z<0) return -erf(-z);
    var f = new Func<double,double> (x=>Exp(-x*x));
    if(z <= 1) {
        return 2/Sqrt(PI)*integrate(f, 0, z, delta, ep);
        }
    else{
        var g = new Func<double,double> (t=>f((z+(1-t)/t))/t/t);
        return 1-2/Sqrt(PI)*integrate(g, 0, 1, delta, ep);
    }
}

public static double openquad
(Func<double,double> f,double a,double b,double acc=1e-3,double eps=1e-3)
{
Func<double,double> fcc = t => f((a+b)/2+(b-a)/2*Cos(t))*Sin(t)*(b-a)/2;
return integrate(fcc,0,PI,acc,eps);
}




}