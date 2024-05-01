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
	double acc=1e-3        /* accuracy goal, on exit |∇φ| should be < acc */
){
	int counter = 0;
	double epsi = 1e-6;
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
				vector y = gradient(phi,x+lambda*dx) - grad;
				x += lambda*dx;
				vector u = lambda*dx- B*y ;
				if(u.dot(y)>epsi){ //SR1 broyden update
					matrix U = matrix.outer(u, u);
					matrix dB = U/(u.dot(y));
					B += dB;	//broyden update of the inverse hessian is needed here
				}
				break;
			}
			lambda /=2;
			if(lambda< 1.0/1024){
				x += lambda*dx;
				B.set_identity();
				break;
			}
		}while(true);//second while loop
		counter++;
		if(counter>10000) break;
	}while(true);//first while loop
	
	return (x, counter);


}//newton

}