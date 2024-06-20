using System;
using static System.Math;
using static System.Console;

class main{



    static int Main(){

        int n = 4;
        /////////////////// decomp routine check
        // matrix with a known solution from wiki
        /*
        matrix A = new matrix(3);
        A[0][0] = 4; A[0][1] = 12; A[1][0] = 12; A[1][1] = 37; A[0][2] = -16; A[2][0] = -16; A[2][1] = -43; A[1][2] = -43; A[2][2] = 98;
        */
        matrix A = cholesky.generate_posdef_matrix(n);
        
        A.print();
        // check of the two decomp routines
        matrix Lbana = cholesky.banach_decomp(A);
        Lbana.print();
        matrix Lcro = cholesky.crout_decomp(A);
        Lcro.print();
        /////////////////// decomp routine check

        WriteLine("Randomly generated vector");
        vector b = cholesky.generatevector(n);
        b.print();
        vector xsol = cholesky.lineqsolver(A, b);
        WriteLine("Solution x vector to the equation Ax=b");
        xsol.print();
        vector sol = A*xsol;
		WriteLine($"Is A*x = b? {sol.approx(b)}\n");

        double det = cholesky.determinant(A);
        WriteLine($"The determinant of matrix A is = {det}");

        matrix inv = cholesky.inverse(A);
        WriteLine("The calculated inverse matrix of A is:");
        inv.print();
        matrix AB = A*inv;
        matrix id = matrix.id(A.size1);
        WriteLine($"is A*inv = 1? {AB.approx(id)}");

        matrix M = cholesky.generate_posdef_matrix(3);
        M.print();

        return 0;
    }//Main
}//main