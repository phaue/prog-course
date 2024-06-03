using System;
using static System.Console;
using static System.Math;

class main{

    static int Main(){
        double[] zrange = new double[] {0, 9};
        int nrpoints = 25;
        double dz = (zrange[1]-zrange[0])/(nrpoints-1);
        vector dat = new vector(nrpoints);
        for(int i=0;i<nrpoints;i++){
            dat[i]  = zrange[0] + dz*i;
        }
        vector x = new vector(dat);
        vector y = new vector(dat);
        y = y.map(Cos);
        WriteLine("x value, y value, integral value");
        for(int i=0;i<nrpoints;i++){
            WriteLine($"{x[i]} {linearsplines.linearinterpolation(x,y,x[i])} {linearsplines.linearinterpolation_integration(x,y,x[i])}");
        }
        
        
        return 0;
    }
}

