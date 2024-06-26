using System;
using static System.Math;
using static System.Console;


public partial class roots{

public static matrix jacobian
(Func<vector,vector> f,vector x,vector fx=null,vector dx=null){
	if(dx == null) dx = x.map(xi => Abs(xi)*Pow(2,-26));
	if(fx == null)fx=f(x);
	matrix J=new matrix(x.size);
	for(int j=0;j < x.size;j++){
		x[j]+=dx[j];
		vector df=f(x)-fx;
		for(int i=0;i < x.size;i++) J[i,j]=df[i]/dx[j];
		x[j]-=dx[j];
		}
	return J;
}


public static vector newton(
	Func<vector,vector>f /* the function to find the root of */
	,vector x            /* the start point */
	,double acc=1e-2     /* accuracy goal: on exit ‖f(x)‖ should be <acc */
	,vector δx=null      /* optional δx-vector for calculation of jacobian */
	){
vector fx=f(x),z,fz;
do{ /* Newton's iterations */
	if(fx.norm() < acc) break; /* job done */
	matrix J=jacobian(f,x,fx,δx);
	(matrix Q, matrix R) = QRGS.decomp(J);
	vector Dx = QRGS.solve(Q,R,-fx); /* Newton's step */
	double λ=1;
    double λmin=1/1024;
	do{ /* linesearch */
		z=x+λ*Dx; //x
		fz=f(z); //eval of x
		if( fz.norm() < (1-λ/2)*fx.norm() ) break; //check condition for tolerance
		if( λ < λmin ) break; //check stepsize
		λ/=2; //reduce stepsize
		}while(true);
	x=z; fx=fz;
	}while(true);
return x;
}
public static double newton(Func<double,double>f, double x, double acc=1e-2){
    //rewrite input to multidimensional
    Func<vector,vector> newf = delegate(vector a) {return new vector(f(a[0]));};
    vector newx = new vector(x);

    vector resx = newton(newf, newx);

    return resx[0];
}   


public static vector quadraticnewton(
	Func<vector,vector>f /* the function to find the root of */
	,vector x            /* the start point */
	,double acc=1e-2     /* accuracy goal: on exit ‖f(x)‖ should be <acc */
	,vector δx=null      /* optional δx-vector for calculation of jacobian */
	){
vector fx=f(x),z,fz;
do{ /* Newton's iterations */
	if(fx.norm() < acc) break; /* job done */
	matrix J=jacobian(f,x,fx,δx);
	(matrix Q, matrix R) = QRGS.decomp(J);
	vector Dx = QRGS.solve(Q,R,-fx); /* Newton's step */
	double λ=1;
    double λmin=1/1024;
	double phi0 = 0.5*fx.norm();
	double phiprime0 = -fx.norm();
	do{ /* linesearch */
		z=x+λ*Dx; //x
		fz=f(z); //eval of x
		if( fz.norm() < (1-λ/2)*fx.norm() ) break; //check condition for tolerance
		if( λ < λmin ) break; //check stepsize
		double c = (0.5*fz.norm()-phi0-phiprime0*λ)/(λ*λ);
		λ = -phiprime0/(2*c); //reduce stepsize
		}while(true);
	x=z; fx=fz;
	}while(true);
return x;
}
public static double quadraticnewton(Func<double,double>f, double x, double acc=1e-2){
    //rewrite input to multidimensional
    Func<vector,vector> newf = delegate(vector a) {return new vector(f(a[0]));};
    vector newx = new vector(x);

    vector resx = quadraticnewton(newf, newx);

    return resx[0];
}   

}//roots