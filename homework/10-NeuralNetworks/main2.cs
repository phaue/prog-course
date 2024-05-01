using System;
using static System.Math;
using static System.Console;

class main{

    static Func<double, double> f = delegate(double x) {return Cos(5*x-1)*Exp(-x*x);};
    static int Main(){
        int n = 6;
        var neuralnet = new ann(n);
        double x0 = -1;
        double x1 = 1; 
        int npoints = 20;
        vector xs = new vector(npoints);
        vector ys = new vector(npoints);
        for(int i=0;i<npoints;i++){
            xs[i]=x0+(x1-x0)*i/(npoints-1);
            ys[i] = f(xs[i]);}
        neuralnet.train(xs,ys);
        WriteLine($"{x0}");
        for(double k=x0;k<=x1;k+=1.0/64){
            WriteLine($"{k} {neuralnet.response(k)} {neuralnet.derivative(k)} {neuralnet.derivative2(k)} {neuralnet.antiderivative(x0, k)}");
        }

        
        return 0;
    }
}