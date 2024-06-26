using System;
using static System.Console;
using static System.Math;

class main{

    
    public static double f(double a)
{
    return Sin(a);
}
    static int Main(){
        double[] dat = new double[] {0,1,2,3,4,5,6,7,8,9};
        vector x = new vector(dat);
        vector y = new vector(dat);
    
        y = y.map(f);

        /*want to integrate from 0 to 9*/
        double[] zrange = new double[] {0, 9};
        int nrpoints = 100;
        double dz = (zrange[1]-zrange[0])/(nrpoints-1);
        WriteLine("x value,eval value, deriv value, integral value");
        var qspline = new quadraticspline(x, y);
        for(int i=0;i<nrpoints;i++){
            double z = zrange[0] + dz*i;
            WriteLine($"{z} {qspline.evaluate(z)} {qspline.derivative(z)} {qspline.integral(z)}");
        }
        
        
        return 0;
    }
}
