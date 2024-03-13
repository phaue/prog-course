using static System.Math;

public static class QRGS{

	public static matrix generatematrix(int row_size, int col_size){
		var rnd = new System.Random(1);
		matrix M = new matrix(row_size,col_size);
		for(int j=0;j<row_size;j++)
		for(int i=0;i<col_size;i++)
		{
			M[i][j] = rnd.NextDouble();
		}
	
		return M;
	}

	public static (matrix, matrix) decomp(matrix a){
		int m = a.colsize;
		matrix Q = a.copy();
		matrix R = new matrix(m,m);
		
		for(int i=0; i<m;i++){
			R[i][i]=Q[i].norm();
			Q[i]/=R[i][i];
			
			for(int j =i+1; j<m;j++){
				R[i][j]=Q[i].dot(Q[j]);
				Q[j]-=Q[i]*R[i][j];
			}
		}
		return(Q,R);
	}
	



}

