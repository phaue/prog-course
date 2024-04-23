using System;
using static System.Math;

public partial class minimization{
        
    public static vector gradient(Func<vector,double> φ,vector x){
	vector dφ = new vector(x.size);
	double φx = φ(x); /* no need to recalculate at each step */
	for(int i=0;i<x.size;i++){
	    double dx=Abs(x[i])*Pow(2,-26);
	    x[i]+=dx;
	    dφ[i]=(φ(x)-φx)/dx;
	    x[i]-=dx;
	}
	return dφ;
}

    public static matrix hessian(Func<vector,double> φ,vector x){
	matrix H=new matrix(x.size);
	vector dφx=gradient(φ,x);
	for(int j=0;j<x.size;j++){
	    double dx=Abs(x[j])*Pow(2,-13); /* for numerical gradient */
	    x[j]+=dx;
	    vector ddφ=gradient(φ,x)-dφx;
	    for(int i=0;i<x.size;i++) H[i,j]=ddφ[i]/dx;
	    x[j]-=dx;
	    }
	    //return H;
	return (H+H.T)/2; // you think?
}

public static (vector,int) newton(
	Func<vector,double> φ, /* objective function */
	vector x,              /* starting point */
	double acc=1e-3,        /* accuracy goal, on exit |∇φ| should be < acc */
    double λmin = 1/1024
){
	int counter = 0;
	do{ /* Newton's iterations */
		var dφ = gradient(φ,x);
		if(dφ.norm() < acc) break; /* job done */
		var H = hessian(φ,x);
		(matrix QH, matrix RH) = QRGS.decomp(H);   /* QR decomposition */
		var dx = QRGS.solve(QH, RH,-dφ); /* Newton's step */
		double λ=1,φx=φ(x);
		do{ /* linesearch */
			if( φ(x+λ*dx) < φx ) break; /* good step: accept */
			if( λ < λmin ) break; /* accept anyway */
			λ/=2;
		}while(true);
		x+=λ*dx;
		counter +=1;
		if(counter > 1000) break;
	}while(true);
	return (x, counter);
}//newton

}