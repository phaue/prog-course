using System;
using static System.Console;

class main{
	static int Main(){//skal lige lave n og m som input og ikke hardcoded
		//generere en høj matrix, og printer den
		int n =5;int m=2; // Default values


		WriteLine("Part A.1) \n");
		matrix M = QRGS.generatematrix(n, m); // n is number of rows i want, m is the number of columns i want
		System.Console.WriteLine($"Randomly generated {m}x{n} matrix : ");
		M.print();

		//laver decomp og printer både Q og R
		(matrix q,matrix r) = QRGS.decomp(M);
		System.Console.WriteLine("Q matrix : ");
		q.print();
		System.Console.WriteLine("R matrix : ");
		r.print();
		
		//check QR=A
		matrix A = q*r;
		System.Console.WriteLine($"Q*R = ");
		A.print();
		System.Console.WriteLine($"Is Q*R = A? {M.approx(A)} ");

		//check Q^T*Q=1
		matrix qinner = q.transpose();
		var g = qinner*q;
		System.Console.WriteLine($"Q^T*Q = ");
		g.print();
		matrix id = matrix.id(m);
		System.Console.WriteLine($"Is Q^T*Q=1? {id.approx(g)}\n");
		
		WriteLine("Part A.2) \n");
		//genererer en square matrix og genererer en vector b som er lige så høj som matricen
		matrix SM = QRGS.generatematrix(n, n);
		WriteLine("Generated square matrix: ");
		SM.print();
		vector b = QRGS.generatevector(n);
		WriteLine("Generated vector : ");
		b.print();
		(matrix Q, matrix R) = QRGS.decomp(SM);
		WriteLine("Q matrix from decomp :");
		Q.print();
		WriteLine("R matrix from decomp :");
		R.print();
		//solve QRx=b
		vector y = QRGS.solve(Q, R, b);
		WriteLine("Solution vector x = ");
		y.print();
		vector sol = SM*y;
		WriteLine($"Is A*x = b? {sol.approx(b)}\n");
		WriteLine("Part A.3)");
		double D = QRGS.det(R);
		WriteLine($"The determinant of R and thus A is: {D}\n");
		
		WriteLine("Part B)");
		matrix inv = QRGS.inverse(SM);
		WriteLine("The inverse of matrix A is ");
		inv.print();
		matrix id2 = matrix.id(n);
		matrix res = SM*inv;
		WriteLine($"Is A*B = 1? {res.approx(id2)} ");


		return 0;
	}
}
