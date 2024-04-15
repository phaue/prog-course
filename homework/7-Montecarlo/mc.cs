using System;
using static System.Math;

public partial class mc{
public static (double,double) plainmc(
Func<vector,double> f,vector a,vector b,int N, Random RND = null
	){
        int dim=a.size; double V=1; for(int i=0;i<dim;i++)V*=b[i]-a[i];
        double sum=0,sum2=0;
	var x=new vector(dim);
	if(RND == null) RND = new Random();
        for(int i=0;i<N;i++){ // sample 200 points and generate x each time with a new double
                for(int k=0;k<dim;k++)x[k]=a[k]+RND.NextDouble()*(b[k]-a[k]); //makes sure x is within the interval!
                double fx=f(x); sum+=fx; sum2+=fx*fx; //calculate the sum of all these N points
                }
        double mean=sum/N, sigma=Sqrt(sum2/N-mean*mean); //define mean as the mean value gained from the sample points
        var result=(mean*V,sigma*V/Sqrt(N)); //returnere V ved at gange med mean sampling og så brug starting conditions
        return result;
}
/* for at lave den pseudo random skal jeg implementere genereringen af x ved brug af halton metoden
så initialiser x som værende af en bestemt dimension ligesom før
så generer halton, med dimension d og x som har dimension d
for i,i<N;i++ halton(i, dim, vector x(dim))
f(x) udregn summer
hvad med error?????
*/


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

} 