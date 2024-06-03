using System;
using static System.Math;

public partial class mc{
public static (double,double) plainmc(
Func<vector,double> f,
vector a,
vector b,
int N,
Random RND = null){

        int dim=a.size;
        double V=1;
        for(int i=0;i<dim;i++){
                V*=b[i]-a[i];
        }
        double sum=0;
        double sum2=0;
	var x=new vector(dim);
	if(RND == null) RND = new Random();
        for(int i=0;i<N;i++){ // sample 200 points and generate x each time with a new double
                for(int k=0;k<dim;k++){
                        x[k]=a[k]+RND.NextDouble()*(b[k]-a[k]); //makes sure x is within the interval!
                }
                double fx=f(x);
                double sum+=fx;
                double sum2+=fx*fx; //calculate the sum of all these N points
                }
        double mean=sum/N
        double sigma=Sqrt(sum2/N-mean*mean); //define mean as the mean value gained from the sample points
        var result=(mean*V,sigma*V/Sqrt(N)); //returnere V ved at gange med mean sampling og så brug starting conditions
        return result;
}



public static double corput(int n, int b){
        double q=0;
        double bk=1.0/b;
        while(n>0){
                q += (n%b)*bk;
                n /= b;
                bk /= b;
                } 
        return q;
        }

public static vector halton(int n, int d){
        int[] basevals = new int[18] {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61};
        int maxd= basevals.Length;
        vector x = new vector(d);
        if(d>maxd){
                throw new ArgumentException("dimension is bigger than the base");
        }
        else{
        for(int i=0;i<d; i++) x[i]=corput(n,basevals[i]);
        }
        return x;
        }

public static vector lattice(int n, int dim, vector alpha){
        vector new_alpha = new vector(dim);
        for(int i=0;i<dim;i++){
                new_alpha[i]=n*alpha[i] - Floor(n*alpha[i]);
        }
        return new_alpha;
}




public static (double,double) quasimc(
Func<vector,double> f,vector a,vector b,int N){
        int dim=a.size; double V=1; for(int i=0;i<dim;i++)V*=b[i]-a[i];
        double haltonsum=0,latticesum=0;
	
        vector alpha = new vector(dim);
        for(int i=0;i<dim;i++) alpha[i]=Sqrt(PI+i) - Floor(Sqrt(PI+i));

        vector xhalton = new vector(dim);
        vector xlattice = new vector(dim);

        for(int i=0;i<N;i++){
                xhalton = halton(i, dim);
                //Halton
                for(int k=0;k<dim;k++){
                        xhalton[k]=a[k]+xhalton[k]*(b[k]-a[k]);
                }
                double fxhalton=f(xhalton);
                haltonsum+=fxhalton;

                //Lattice
                xlattice = lattice(i, dim, alpha);
                for(int k=0;k<dim;k++){
                        xlattice[k]=a[k]+xlattice[k]*(b[k]-a[k]);
                }
                double fxlattice=f(xlattice);
                latticesum+=fxlattice;


                }
        double haltonmean=haltonsum/N;
        double latticemean=latticesum/N;
        double err = Abs(haltonmean-latticemean);
        var result=(haltonmean+latticemean)*0.5*V;
        return (result,err);
}

/*
If N<nmin return N-point plain Monte Carlo estimate of integral and variance;
Sample nmin points and estimate the integral and the variance;
Find the dimension with largest sub-variance;
Subdivide the volume along this dimension;
Divide the remaning points between the two sub-volumes proportional to sub-variances;
Dispatch two recursive calls on the sub-volumes;
Estimate the grand integral and grand error;
Return the grand integral and the grand error;

*/
public static (double,double) stratified(Func<vector,double> f,
vector a,
vector b,
int N,
int nmin=100){
        if(N<nmin){
        (res, var) = plainmc(f,a,b,N);
        }
        if(var<0.001){
                return (res,var);
        }

}
} 