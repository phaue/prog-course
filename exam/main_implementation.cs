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


        WriteLine("\n \n");
        WriteLine($"Test of 50 such matrices of size {n}x{n} on the 4 different calculations above:\n");
        int N = 50;
        int fails = 0;
        int succes = 0;
        for(int i=1;i<=N;i++){
            matrix M = cholesky.generate_posdef_matrix(n);
            matrix Lbanach = cholesky.banach_decomp(M);

            if(M.approx(Lbanach*Lbanach.T)==false){
                fails += 1;
                Error.WriteLine($"Error in cholesky-banach decomposition in iteration{i}");
            }
            else succes +=1;

            matrix Lcrout = cholesky.crout_decomp(M);
            if(M.approx(Lcrout*Lcrout.T)==false){
                fails += 1;
                Error.WriteLine($"Error in cholesky-crout decomposition in iteration{i}");
            }
            else succes +=1;

            vector B = cholesky.generatevector(n);
            vector x = cholesky.lineqsolver(M, B);
            vector solx = M*x;
		    if(solx.approx(B)==false){
                fails += 1;
                Error.WriteLine($"Error in linear equation solver in iteration{i}");
            }else succes +=1;

            matrix inver = cholesky.inverse(M);
            matrix one = M*inver;
            if(one.approx(id)==false){
                fails += 1;
                Error.WriteLine($"Error in inverse calculation in iteration{i}");
            }else succes+=1;
        }
        WriteLine("Errors can be found in testerror.txt if any.");
        WriteLine($"These 200 tests revealed {succes} successful checks & {fails} failed checks");

        return 0;
    }//Main
}//main