using System;
using static System.Math;

public class ann{
    public int n; /* number of hidden neurons */
    public Func<double,double> f = x => x*Exp(-x*x); /* activation function */

    /* network parameters */
    public vector p;
    public double a(int i) {return p[i];}
    public double b(int i) {return p[i+n];}
    public double w(int i) {return p[i+2*n];}
    public void seta(int i, double k) {p[i]=k;}
    public void setb(int i, double k) {p[i+n]=k;}
    public void setw(int i, double k) {p[i+n*2]=k;}
    public ann(int n){this.n=n; p = new vector(3*n);} // initialize p which are parameters for each neuron
    public ann(vector p) {this.n=p.size/3; this.p=p;}
    public double response(double x){
      /* return the response of the network to the input signal x */
        double sum = 0;
        for(int i =0; i<n;i++) sum+= f((x-a(i))/b(i))*w(i);
        return sum;
        }//response
    public void train(vector x,vector y){
      /* train the network to interpolate the given table {x,y} */
      for(int i=0;i<n;i++){
        setb(i, 1);
        setw(i,1);
        seta(i, x[0]+(x[x.size-1]-x[0])*i/(n-1)); // why do i need different a's?
      }
      Func<vector,double> cost = delegate(vector u) {
        ann newann = new ann(u);
        double sum=0;
        for(int j=0;j<x.size;j++) sum+= Pow(newann.response(x[j])-y[j],2);
        return sum/x.size;
        };
      (vector resp, int count) = minimization.newton(cost, p, 1e-3);
      p = resp;
      }//train
    }//class