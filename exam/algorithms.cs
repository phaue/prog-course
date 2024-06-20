using static System.Math;
using static System.Console;

public static class cholesky{


public static matrix generate_posdef_matrix(int n){ 
		//generatiion of a random real symmetric positive-definite matrix
		var rnd = new System.Random();
		matrix M = new matrix(n);
		for(int j=0;j<n;j++){
		for(int i=0;i<j;i++){
			M[i][j] = rnd.Next(-10, 11);
            M[j][i] = M[i][j];
		}
        M[j][j] = rnd.Next(-10,11);
        }

		return M*M.T;
	}

	public static vector generatevector(int n){
		var rnd = new System.Random();
		vector v = new vector(n);
		for(int i=0;i<n;i++) v[i]=rnd.Next(11);
		return v;
	}
    public static matrix banach_decomp(matrix A){
        matrix L = new matrix(A.size1);
        for(int i=0; i<A.size1;i++){
        for(int j=0; j<=i; j++){
            double sum = 0;
            for(int k=0; k< j;k++) sum += L[i][k] * L[j][k];
            
            if(i==j) L[i][j] = Sqrt(A[i][i]-sum);

            else L[i][j] = (1.0/L[j][j] *(A[i][j]-sum));
        }
        }
    return L.T;
    }

    public static matrix crout_decomp(matrix A){
        matrix L = new matrix(A.size1);
        for(int j=0; j<A.size1;j++){
            double sum = 0;
            for(int k=0;k<j;k++) sum+= L[j][k] * L[j][k];

            L[j][j] = Sqrt(A[j][j]-sum);

            for(int i=j+1;i<A.size1;i++){
                sum = 0;
                for(int k=0; k<j; k++) sum+= L[i][k] *L[j][k];
                L[i][j] = (1.0/L[j][j] * (A[i][j]-sum));
            }
        }
    return L.T;
    }


public static vector lineqsolver(matrix A, vector b){ //want to solve Ax=b
    matrix L = crout_decomp(A); //decomp into the L's
    matrix Ltrans = L.T;
    int n = b.size;
    //do the forward substitution Ly=b 
    // a lower triangular system solution
    vector y = new vector(n);

    for(int i=0; i<n;i++){
        double sum=0;
        for(int k=0 ; k<i ; k++){
            sum += L[k][i] * y[k];
        }
        y[i] = (b[i]-sum)/L[i][i];

    }//forward

    // do the backward substitution Ltrans*x=y 
    // an upper triangular system solution
    vector x = new vector(n);
    for(int i=n-1; i>=0; i--){
        double sum =0;
        for(int k=i+1;k<n;k++){
            sum+=Ltrans[k][i]*x[k];
        }
        x[i]=(y[i]-sum)/Ltrans[i][i];
    }//backward
    
    return x;
}

public static double determinant(matrix A){
    // determinant of a LU decomp is given as det(L)*det(U) and since they share the diagonal its the same as det(L)^2
    matrix L = crout_decomp(A);
    double det = 1;
    for(int i =0;i<L.size1;i++){
        det *=L[i][i]*L[i][i];
    }
    return det;
}

public static matrix inverse(matrix A){
		matrix B = new matrix(A.size1, A.size2);
		matrix id = matrix.id(A.size1);
		for(int i=0;i<A.size1;i++){
		vector x = lineqsolver(A, id[i]);
		B[i]=x;
		}
	return B;
	}


}//cholesky