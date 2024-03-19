using System;
using static System.Console;

class main{

	public static int Main(){
	int m = 3;
	matrix M = jacobi.gensymmatrix(m);
	WriteLine("Generated symmetric matrix :");
	M.print();

	(vector w, matrix V) = jacobi.cyclic(M);
	WriteLine("Eigenvector matrix V: ");
	V.print();
	WriteLine("Eigenvalue matrix D: ");
	matrix D = new matrix(w);
	D.print();

	WriteLine("Numeric checks :");
	matrix s = V.transpose()*M*V;
	WriteLine($"Is V^TAV=D? {D.approx(s)}\n");
	matrix d = V*D*V.transpose();
	WriteLine($"Is VDV^T==A? {d.approx(M)}\n");
	matrix id = matrix.id(m);
	matrix v = V.transpose()*V;
	WriteLine($"Is V^TV=1? {v.approx(id)}\n");
	matrix f = V*V.transpose();
	WriteLine($"Is V*V^T=1? {f.approx(id)}\n");
	
	return 0;
	}
}
