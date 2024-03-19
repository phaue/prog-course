using static System.Math;

public partial class jacobi{
	
	public static matrix gensymmatrix(int n){
		var rnd = new System.Random();
		matrix M = new matrix(n, n);
		for(int i=0;i<n;i++)
		for(int j=i;j>=0;j--)
		{
			M[i][j]= rnd.Next(11);
			M[j][i]=M[i][j];
		}
		return M;
	}
	

	public static void timesJ(matrix A, int p, int q, double theta){
		double c=Cos(theta),s=Sin(theta);
		for(int i=0;i<A.size1;i++){
			double aip=A[i,p],aiq=A[i,q];
			A[i,p]=c*aip-s*aiq;
			A[i,q]=s*aip+c*aiq;
		}
	}

	public static void Jtimes(matrix A, int p, int q, double theta){
		double c=Cos(theta),s=Sin(theta);
		for(int j=0;j<A.size1;j++){
			double apj=A[p,j],aqj=A[q,j];
			A[p,j]= c*apj+s*aqj;
			A[q,j]=-s*apj+c*aqj;
		}
	
	}
	public static (vector, matrix) cyclic(matrix M){
	matrix A=M.copy();
	matrix V=matrix.id(M.size1);
	vector w=new vector(M.size1);

	bool changed;
	do{
	changed=false;
	for(int p=0;p<M.size1-1;p++)
	for(int q=p+1;q<M.size1;q++){
		double apq=A[p,q], app=A[p,p], aqq=A[q,q];
		double theta=0.5*Atan2(2*apq,aqq-app);
		double c=Cos(theta),s=Sin(theta);
		double new_app=c*c*app-2*s*c*apq+s*s*aqq;
		double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
		if(new_app!=app || new_aqq!=aqq) // do rotation
			{
			changed=true;
			timesJ(A,p,q, theta); // A←A*J
			Jtimes(A,p,q,-theta); // A←JT*A
			timesJ(V,p,q, theta); // V←V*J
			}
	}
	}while(changed);
	for(int i=0;i<M.size1;i++){
		w[i]=A[i][i];
	}
	return (w,V);
	}
	
	public static matrix Hamiltonian(double rmax, double dr){
		int npoints = (int)(rmax/dr)-1;
        	vector r = new vector(npoints);
        	for(int i=0;i<npoints;i++)r[i]=dr*(i+1);
        	matrix H = new matrix(npoints,npoints);
        	for(int i=0;i<npoints-1;i++){
                	H[i,i]  =-2*(-0.5/dr/dr);
                	H[i,i+1]= 1*(-0.5/dr/dr);
                	H[i+1,i]= 1*(-0.5/dr/dr);
                	}
        	H[npoints-1,npoints-1]=-2*(-0.5/dr/dr);
        	for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];
		return H;
	}

}
