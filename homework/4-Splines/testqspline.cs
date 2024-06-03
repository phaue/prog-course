 using System;
using static System.Console;
using static System.Math;

class main{

       
    public static double f(double a)
{
    return a*a;
}
    static int Main(){
        double[] dat = new double[] {1,2,3,4,5};
        vector x = new vector(dat);
        vector y1 = new vector(1,1,1,1,1);
        vector y2 = new vector(dat);
        vector y3 = new vector(x.map(f));
        
        //calculated b's and c's for the 3 cases
        vector b1 = new vector(0,0,0,0);
        vector b2 = new vector(1,1,1,1);
        vector b3 = new vector(2,4,6,8);
        vector c1 = new vector(0,0,0,0);
        vector c2 = new vector(0,0,0,0);
        vector c3 = new vector(1,1,1,1);

       
        var qspline1 = new quadraticspline(x, y1);
        var qspline2 = new quadraticspline(x, y2);
        var qspline3 = new quadraticspline(x, y3);
        
        WriteLine("The first {xi,yi} table gives the following:");
        WriteLine("Manually calculated b values:");
        b1.print();
        WriteLine("Program calculated b values:");
        qspline1.bprint();
        WriteLine("Manually calculated c values:");
        c1.print();
        WriteLine("Program calculated c values:");
        qspline1.cprint();
        WriteLine("\n");

        WriteLine("The second {xi,yi} table gives the following:");
        WriteLine("Manually calculated b values:");
        b2.print();
        WriteLine("Program calculated b values:");
        qspline2.bprint();
        WriteLine("Manually calculated c values:");
        c2.print();
        WriteLine("Program calculated c values:");
        qspline2.cprint();
        WriteLine("\n");


        WriteLine("The third {xi,yi} table gives the following:");
        WriteLine("Manually calculated b values:");
        b3.print();
        WriteLine("Program calculated b values:");
        qspline3.bprint();
        WriteLine("Manually calculated c values:");
        c3.print();
        WriteLine("Program calculated c values:");
        qspline3.cprint();
        
        return 0;
    }
}