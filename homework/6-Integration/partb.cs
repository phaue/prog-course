using System;
using static System.Console;
using static System.Math;

public class main{

static int Main(){ 
        WriteLine("Normal integrator:");
        int n1calls = 0;
        int n2calls = 0;
        Func<double,double> f1 = x => {n1calls++;return 1/Sqrt(x);};
        Func<double,double> f2 = x => {n2calls++;return Log(x)/Sqrt(x);};
        double a = 0;
        double b = 1;
        double res1 = integration.integrate(f1, a, b);
        WriteLine($"ncalls={n1calls} int={res1}");
        double res2 = integration.integrate(f2, a, b);
        WriteLine($"ncalls={n2calls} int={res2} \n");

        WriteLine("Variable transformation integrator:");
        n1calls = 0;
        n2calls = 0;
        double resq1 = integration.openquad(f1, a, b);
        WriteLine($"ncalls={n1calls} int={resq1}");
        double resq2 = integration.openquad(f2, a, b);
        WriteLine($"ncalls={n2calls} int={resq2} \n");


        return 0;
}
}