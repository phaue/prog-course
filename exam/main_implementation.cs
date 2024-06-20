using System;
using static System.Math;
using static System.Console;

class main{



   static int Main(string[] args){
        int n =2; //basecase
	    foreach(string arg in args){
		    var words=arg.Split(':');
		    if(words[0]=="matrixsize") n=int.Parse(words[1]);
            else WriteLine("incorrect input the matrix size is reset to n=2");
	    }

        /////////////////// decomp routine check
        matrix A = cholesky.generate_posdef_matrix(n);
        WriteLine($"Randomly generated positive definite {n}x{n} matrix:");
        A.print();
        // check of the two decomp routines
        WriteLine("Decompositioned matrix into L using the Cholesky-Banachiewicz method");
        matrix Lbana = cholesky.banach_decomp(A);
        Lbana.print();
        WriteLine($"Is L*L.T = A? {A.approx(Lbana*Lbana.T)} \n");

        WriteLine("Decompositioned matrix into L using the Cholesky-Crout method");
        matrix Lcro = cholesky.crout_decomp(A);
        Lcro.print();
        WriteLine($"Is L*L.T = A? {A.approx(Lcro*Lcro.T)} \n");
        /////////////////// decomp routine check

        ////Linear eq solver
        WriteLine("Randomly generated vector:");
        vector b = cholesky.generatevector(n);
        b.print();
        vector xsol = cholesky.lineqsolver(A, b);
        WriteLine("Solution vector x to the equation Ax=b");
        xsol.print();
        vector sol = A*xsol;
		WriteLine($"Is A*x = b? {sol.approx(b)}\n");

        ///// determinant calculator
        double det = cholesky.determinant(A);
        WriteLine($"The determinant of matrix A is = {det}");


        ////inverse matrix calculator
        matrix inv = cholesky.inverse(A);
        WriteLine("The calculated inverse matrix of A is:");
        inv.print();
        matrix AB = A*inv;
        matrix id = matrix.id(A.size1);
        WriteLine($"is A*inv = 1? {AB.approx(id)}");


        return 0;
    }//Main
}//main