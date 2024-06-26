using System;
using static System.Console;
using static System.Math;

public class ODE{
	public static (vector,vector) rkstep12(Func<double,vector,vector> f,double x,vector y,double h){
	vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
	vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
	vector yh = y+k1*h;              /* y(x+h) estimate */
	vector δy = (k1-k0)*h;           /* error estimate */
	return (yh,δy);
}

public static (genlist<double>,genlist<vector>) driver(
		Func<double,vector,vector> F,/* the f from dy/dx=f(x,y) */
		(double,double) interval,    /* (start-point,end-point) */
		vector ystart,               /* y(start-point) */
		double h=0.125,              /* initial step-size */
		double acc=0.01,             /* absolute accuracy goal */
		double eps=0.01,              /* relative accuracy goal */
		int maxit = 1000
		){
	var (a,b)=interval; double x=a; vector y=ystart.copy();
	var xlist=new genlist<double>(); xlist.add(x);
	var ylist=new genlist<vector>(); ylist.add(y);
	int iteration = 1;
	do{
        	if(x>=b) return (xlist,ylist); /* job done */
        	if(x+h>b) h=b-x;               /* last step should end at b */
        	var (yh,δy) = rkstep12(F,x,y,h);
        	double tol = (acc+eps*yh.norm()) * Sqrt(h/(b-a));
        	double err = δy.norm();
        	if(err<=tol){ // accept step
			x+=h; y=yh;
			xlist.add(x);
			ylist.add(y);
			}
		h *= Min( Pow(tol/err,0.25)*0.95 , 2); // readjust stepsize
		iteration += 1;						       
        }while(iteration<=maxit);
	return (xlist,ylist);
	}//driver

public static int binsearch(genlist<double> x, double z)
	{/* locates the interval for z by bisection */ 
	if( z<x[0] || z>x[x.size-1] ) throw new Exception("binsearch: bad z");
	int i=0, j=x.size-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
	}


public static Func<double,vector> make_linear_interpolant(genlist<double> x,genlist<vector> y)
{
	Func<double,vector> interpolant = delegate(double z){
		int i=binsearch(x,z);
		double Δx=x[i+1]-x[i];
		vector Δy=y[i+1]-y[i];
		return y[i]+Δy/Δx*(z-x[i]);
	};
	return interpolant;
}
/*
public static Func<double,vector> make_quadratic_interpolant(genlist<double> x,genlist<vector> y)
{
	Func<double,vector> s = delegate(double z){
		int n = x.size;
		vector b = new vector(n-1);
        vector c = new vector(n-1);
        vector p=new vector(n-1);
	    vector h=new vector(n-1);

        for(int i=0;i<n-1;i++){
		h[i]=x[i+1]-x[i];
		p[i]=(y[i+1]-y[i])/h[i];
		}
		c[0] = 0;
            for(int j=0;j<n-2;j++){ /*upwards recursion
                c[j+1]=(p[j+1]-p[j]-c[j]-h[j])/h[j+1];}
            c[n-2] /=2.0;
            for(int j=n-3;j>=0;j--){ /*downwards recursion
                c[j] =(p[j+1]-p[j]-c[j+1]*h[j+1])/h[j];}
            for(int j=0;j<n-1;j++){ /*filling in b
                b[j] = p[j]-c[j]*h[j];
            }
		//interpolation
		int k=binsearch(x,z);
		double dx = z-x[k];
        return y[k]+dx*(b[k]+dx*c[k]);
};
	return s;
}
*/
public static Func<double,vector> make_ode_ivp_interpolant
(Func<double,vector,vector> f,(double,double)interval,vector y,double acc=0.01,double eps=0.01,double hstart=0.01 )
{
	(var xlist,var ylist) = driver(f,interval,y,acc,eps,hstart);
	return make_linear_interpolant(xlist,ylist);
}

}//ODE class
