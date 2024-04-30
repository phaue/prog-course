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
	return (H+H.T)/2;
}

public static (vector,int) newton(
	Func<vector,double> phi, /* objective function */
	vector x,              /* starting point */
	double acc=1e-3,        /* accuracy goal, on exit |∇φ| should be < acc */
){
	int counter = 0;

/*i dont want to calculate the hessian and gradient each time
B = inverse hessian H^-1
secant eq (B+dB)*y=s or in short dB*y=u where y=gradiant(phi(x+s))-gradiant(phi(x)) and u =s-B*y

start with identity matrix as the inverse hessian and then apply updates
if lambda min in reached then reset hessian matrix and start again
*/
	matrix B = matrix.id(x.size);

	do{
		var grad = gradient(phi,x);
		if(grad.norm() < acc) break;
		vector dx = -B*grad;
		double lambda = 1;
		do{
			if(phi(x+lambda*dx) < phi(x)){
				x += lambda*dx
				B += //broyden update of the inverse hessian is needed here
				break;
			}
			lambda /=2;
			if(lambda< 1/1024){
				x += lambda *dx;
				set_identity(B);
				break;
			}
		}while(true);
	}while(true);
	

/*
	do{ 
		var dφ = gradient(φ,x);
		if(dφ.norm() < acc) break; 
		var H = hessian(φ,x);
		var QRH = QRGS.GivensQR(H);   
		var dx = QRGS.givenssolve(-dφ, QRH); 
		double λ=1,φx=φ(x);
		
		do{ 
			if( φ(x+λ*dx) < φx ) break; 
			if( λ < λmin ) break; 
			λ/=2;
		}while(true);

		x+=λ*dx;
		counter +=1;
		if(counter > 100) break;
	}while(true);
*/

	return (x, counter);


}//newton

}