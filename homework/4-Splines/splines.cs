using System;
using static System.Console;
using static System.Math;

public class linearsplines{

public static double linearinterpolation(vector x, vector y, double z){
    int i=binsearch(x,z);
        double dx=x[i+1]-x[i];
        if(!(dx>0)){
            throw new Exception("x must be increasing");
        }
        double dy=y[i+1]-y[i];
        return y[i]+dy/dx*(z-x[i]);
        }

//Location of the index i of the interval containing z (such that x[i]<z<x[i+1]) determined by binary search
public static int binsearch(double[] x, double z)
	{/* locates the interval for z by bisection */ 
	if( z<x[0] || z>x[x.Length-1] ) throw new Exception("binsearch: bad z");
	int i=0, j=x.Length-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
	}

//integrate from x[0] to the desired z value
public static double linearinterpolation_integration(vector x, vector y, double z){
int i=binsearch(x,z);
double result =0;
for(int j=0;j<=i;j++){
    double dx=x[j+1]-x[j];
    double dy=y[j+1]-y[j];
    /*
    result += y[i]*dx+((dy/dx)*Pow(dx,2)/2);
}
double dx0 = z-x[i];
return result+y[i]*dx0+(((y[i+1]-y[i])/dx0) * Pow(dx0,2)/2);
}
*/ 
    if(j==i){
        result+= 0.5*dy/dx*z*z +(y[j]-dy/dx*x[j])*z; //adding the contribution from this segment to the result
        result -= 0.5*dy/dx*x[j]*x[j]+(y[j]-dy/dx*x[j])*x[j]; //subtracting the overlap
    }
    else{
        result += 0.5*dy/dx*x[j+1]*x[j+1]+(y[j+1]-dy/dx*x[j+1])*x[j+1]; //adding the contribution from the current pos to the next pos
        result -= 0.5*dy/dx*x[j]*x[j]+(y[j]-dy/dx*x[j])*x[j]; // subtracting the overlap
    }
}
return result;
}

}
public class quadraticspline {
	private vector x,y,b,c;
	public quadraticspline(vector xs,vector ys){
		/* x=xs.copy(); y=ys.copy(); calculate b and c */
        x = xs.copy();
        y = ys.copy();
        int n = x.size;
        b = new vector(n-1);
        c = new vector(n-1);
        vector p=new vector(n-1);
	    vector h=new vector(n-1);

        for(int i=0;i<n-1;i++){
		h[i]=x[i+1]-x[i];
		p[i]=(y[i+1]-y[i])/h[i];
		}
        c[0] = 0;
        for(int j=0;j<n-2;j++){ /*upwards recursion*/
            c[j+1]=(p[j+1]-p[j]-c[j]*h[j])/h[j+1];}
        c[n-2] /=2.0;
        for(int j=n-3;j>=0;j--){ /*downwards recursion*/
            c[j] =(p[j+1]-p[j]-c[j+1]*h[j+1])/h[j];}
        for(int j=0;j<n-1;j++){ /*filling in b*/
            b[j] = p[j]-c[j]*h[j];
        }
    } //quadraticspline function       

	public double evaluate(double z){
        /* evaluate the spline */
        int i = linearsplines.binsearch(x, z);
        double h = z-x[i];
        double s = y[i]+h*(b[i]+h*c[i]);
        return s;
        }
        
	public double derivative(double z){
        int i = linearsplines.binsearch(x,z);
        return b[i]+2*c[i]*(z-x[i]);
        }
	public double integral(double z){
        /* evaluate the integral */
        int i = linearsplines.binsearch(x,z);
        double result = 0;
        for(int j=0;j<i;j++){
            double h = x[j+1]-x[j];
            result+= y[j]*h+(b[j]*Pow(h, 2))/2+ (c[j]*Pow(h,3))/3;
        }
        double h0 = z-x[i];
        return result+y[i]*h0+(b[i]*Pow(h0, 2))/2+ (c[i]*Pow(h0,3))/3;

        }

    public void bprint(){
        b.print();
    }
    public void cprint(){
        c.print();
    }

	} // quadraticspline class

    public class cubicspline {
	vector x,y,b,c,d;
    
    	public cubicspline(vector xs,vector ys){
		/* x=xs.copy(); y=ys.copy(); calculate b and c */
        x = xs.copy();
        y = ys.copy();
        int n = x.size;
        b = new vector(n);
        c = new vector(n-1);
        d = new vector(n-1);
        vector p=new vector(n-1);
	    vector h=new vector(n-1);

        for(int i=0;i<n-1;i++){
		h[i]=x[i+1]-x[i];
		p[i]=(y[i+1]-y[i])/h[i];
		}

        vector D = new vector(n);
        vector Q = new vector(n-1);
        vector B = new vector(n);
        D[0] = 2;
        Q[0]=1;
        D[n-1]=2;
        B[0]=3*p[0];
        B[n-1]=3*p[n-2];
        for(int i=0;i<n-2;i++){
            D[i+1]=2*h[i]/h[i+1]+2;
            Q[i+1]=h[i]/h[i+1];
            B[i+1]=3*(p[i]+p[i+1]*h[i]/h[i+1]);
        }
        for(int i=1;i<n;i++){
            D[i]-=Q[i-1]/D[i-1];
            B[i]-=B[i-1]/D[i-1];
        }
        b[n-1]=B[n-1]/D[n-1];
        for(int i=n-2;i>=0;i--){
            b[i]=(B[i]-Q[i]*b[i+1])/D[i];
        }
        for(int i=0;i<n-1;i++){
            c[i]=(-2*b[i]-b[i+1]+3*p[i])/h[i];
            d[i]=(b[i]+b[i+1]-2*p[i])/h[i]/h[i];
        }
        }//cubic spline function
        
         public double evaluate(double z){
        /* evaluate the spline */
        int i = linearsplines.binsearch(x, z);
        double h = z-x[i];
        double s = y[i]+b[i]*h+c[i]*Pow(h,2)+d[i]*Pow(h,3);
        return s;
        }
        
        public double derivative(double z){
        int i = linearsplines.binsearch(x,z);
        return b[i]+2*c[i]*(z-x[i])+3*d[i]*(z-x[i])*(z-x[i]);
        }

        public double integral(double z){
        /* evaluate the integral */
        int i = linearsplines.binsearch(x,z);
        double result = 0;
        for(int j=0;j<i;j++){
            double h = x[j+1]-x[j];
            result+= y[j]*h+(b[j]*Pow(h, 2))/2+ (c[j]*Pow(h,3))/3 +(d[j]*Pow(h,4))/4;
        }
        double h0 = z-x[i];
        return result+y[i]*h0+(b[i]*Pow(h0, 2))/2+ (c[i]*Pow(h0,3))/3 +(d[i]*Pow(h0,4))/4;

        }
    }