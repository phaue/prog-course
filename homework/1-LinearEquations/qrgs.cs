using static System.Math;
using static System.Console;
using System;
public static partial class QRGS{

	public static matrix generatematrix(int col_size, int row_size){ 
		//colsize is the number of rows we want, meaning that will be the length of the columns. rowsize is the numer of columns we want, meaning that will be the length of the rows.

		var rnd = new System.Random();
		matrix M = new matrix(col_size,row_size);
		for(int j=0;j<col_size;j++)
		for(int i=0;i<row_size;i++)
		{
			M[i][j] = rnd.Next(11);
		}
	
		return M;
	}

	public static vector generatevector(int n){
		var rnd = new System.Random();
		vector v = new vector(n);
		for(int i=0;i<n;i++) v[i]=rnd.Next(11);
		return v;
	}

	public static (matrix, matrix) decomp(matrix a){
		int m = a.size2;
		matrix Q = a.copy();
		matrix R = new matrix(m,m);
		for(int i=0; i<m;i++){
			R[i][i]=Q[i].norm();//Sqrt(QT[i].dot(QT[i]));
			Q[i]= Q[i]/R[i][i];
			for(int j =i+1; j<m;j++){
				R[i][j]=Q[i].dot(Q[j]);
				Q[j]=Q[j]-Q[i]*R[i][j];
			}
		}
		return(Q,R.transpose());
	}
	


	public static vector solve(matrix Q, matrix R, vector b){
		/*if(Q.size1 != Q.size2){
	 		      throw new ArgumentException("Input must be a square matrix");
		}*/
		//this function should use Q and R from decomp and solvethe equation QRx=b for the given right hand side b
		vector c = Q.transpose()*b;
		vector x = new vector(c.size);
		matrix U = R.copy();
		U = U.transpose();
		for(int i=c.size-1; i>=0; i--){
			double sum = 0;
			for(int k=i+1;k<c.size;k++){
			       	sum+=U[i][k]*x[k];
			}
			x[i]=(c[i]-sum)/U[i][i];
		}
		return x;
	}

	public static double det(matrix R){
	
		double sum =1;
		for(int i=0;i<R.size2;i++) sum*=R[i][i];
	       return sum;
	}	       


	public static matrix inverse(matrix A){
		(matrix Q, matrix R) = decomp(A);
		matrix B = new matrix(A.size1, A.size2);
		matrix id = matrix.id(A.size1);
		for(int i=0;i<A.size1;i++){
		vector x = solve(Q, R, id[i]);
		B[i]=x;
		}
	return B;
	}


public static matrix GivensQR(matrix M){
matrix A = M.copy();
for(int q=0;q<A.size2;q++){
	for(int p=q+1;p<A.size1;p++){
      		double theta=Atan2(A[p,q],A[q,q]);
		double c=Cos(theta),s=Sin(theta);
		for(int k=q;k<A.size2;k++){
			double xq=A[q,k], xp=A[p,k];
			A[q,k]= xq*c+xp*s;
			A[p,k]=-xq*s+xp*c;
			}
		A[p,q]=theta;
		}
	}
return A;
}

public static vector givenssolve(vector r, matrix QR){
	vector b=r.copy();
	for(int q=0;q<QR.size2;q++){
		for(int p=q+1;p<QR.size1;p++){
			double theta = QR[p,q];
			double c=Cos(theta),s=Sin(theta);
			double bq=b[q], bp=b[p];
			b[q]=+bq*c+bp*s;
			b[p]=-bq*s+bp*c;
			}
		}
	vector x = new vector(QR.size2);
	for(int i=QR.size2-1;i>=0;i--){
		double s=0; for(int k=i+1;k<QR.size2;k++) s+=QR[i,k]*x[k];
		x[i]=(b[i]-s)/QR[i,i];
		}
	return x;
	}//solve


}

