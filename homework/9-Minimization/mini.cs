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
		Console.Write("grad=");
		grad.print();
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
		if(counter>10) break;
	}while(true);//first while loop
	
	return (x, counter);


}//newton



//Part C implementation failed dunno why

    public static (vector,matrix) centralhessian(Func<vector,double> phi,vector x){
	matrix H=new matrix(x.size);
	vector grad = new vector(x.size);
	vector x1 = x.copy();
	vector x2 = x.copy();
	vector x3 = x.copy();
	vector x4 = x.copy();
	////
	////
	for(int k=0;k<x.size;k++)
	for(int j=0;j<x.size;j++){
		double dxj=Abs(x[j])*Pow(2,-13);
		double dxk=Abs(x[k])*Pow(2,-13);
		x1[k] += dxk;
		x2[k] += dxk;
		x3[k] -= dxk;
		x4[k] -= dxk;
		x1[j] -= dxj;
		x2[j] += dxj;
		x3[j] -= dxj;
		x4[j] += dxj;

		double phipp = phi(x1);
		double phimm = phi(x3);
		double phipm = 0;
		double phimp = 0;

		if(j==k){
			grad[k] = (phipp-phimm)/(4*dxk); // calculation of the gradient
			phipm = phi(x);
			phimp = phi(x);
			H[j,k] = (phipp-phipm-phimp+phimm)/(4*dxj*dxk); 
		}
		else{
			phipm = phi(x2);
			phimp = phi(x4);
			H[j,k] = (phipp-phipm-phimp+phimm)/(4*dxj*dxk); 
		}
		x1[k] -= dxk;
		x2[k] -= dxk;
		x3[k] += dxk;
		x4[k] += dxk;
		x1[j] += dxj;
		x2[j] -= dxj;
		x3[j] += dxj;
		x4[j] -= dxj;
	    //return H;
	}
	return (grad,H);
}
public static (vector,int) centralnewton(
	Func<vector,double> phi, /* objective function */
	vector x,              /* starting point */
	double acc=1e-3        /* accuracy goal, on exit |∇φ| should be < acc */
){
	int counter = 0;

	do{
		(vector grad, matrix H) = centralhessian(phi,x);
		Console.Write($"H=");
		H.print();
		Console.Write($"x=");
		x.print();
		if(grad.norm() < acc) break;
		matrix QR = QRGS.GivensQR(H);
		Console.Write($"QR=");
		QR.print();
		vector dx = QRGS.givenssolve(-grad,QR);
		double phix = phi(x);
		double lambda = 1;
		double lambdamin = 1/1024;
		do{ /* linesearch */
			if( phi(x+lambda*dx) < phix ) break; /* good step: accept */
			if( lambda < lambdamin ) break; /* accept anyway */
			lambda/=2;
		}while(true);
		x += lambda*dx;
		Console.Write($"dx=");
		dx.print();
		counter++;
		if(counter>1000) break;
	}while(true);//first while loop
	
	return (x, counter);


}//newton

}