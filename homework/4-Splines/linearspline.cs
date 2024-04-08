using System;
using static System.Console;
using static System.Math;

class main{
    static int Main(){ 
        double[] dat = new double[] {0,1,2,3,4,5,6,7,8,9};
        vector x = new vector(dat);
        vector y = new vector(dat);
        y = y.map(Cos);
        x.print();
        y.print();

        /*want to integrate from 0 to 9*/
        double[] zrange = new double[] {0, 9};
        int nrpoints = 100;
        double dz = (zrange[1]-zrange[0])/(nrpoints-1);
        WriteLine("x value, y value, integral value");
        for(int i=0;i<nrpoints;i++){
            double z = zrange[0] + dz*i;
            WriteLine($"{z} {linearsplines.linearinterpolation(x,y,z)} {linearsplines.linearinterpolation_integration(x, y, z)}");
        }
        
        
        return 0;
    }


}