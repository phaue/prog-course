
class main{
	static int Main(){
		//generere en høj matrix, og printer den
		int n =2;int m=5;
		matrix M = QRGS.generatematrix(n, m);
		System.Console.WriteLine($"Randomly generated {m}x{n} matrix : ");
		for(int i=0;i<M.colsize;i++) M[i].print();

		//laver decomp og printer både Q og R
		(matrix q,matrix r) = QRGS.decomp(M);
		System.Console.WriteLine("Q matrix : ");
		for(int i=0;i<q.colsize;i++) q[i].print();
		System.Console.WriteLine("R matrix : ");
		for(int i=0;i<r.rowsize;i++) r[i].print();
		/*
		//check QR=A
		matrix A = r*q;
		for(int i=0;i<A.rowsize;i++) A[i].print();
*/

		//check Q^T*Q=1
		System.Console.WriteLine("\n \n");
		matrix qinner = q.transpose();
//		System.Console.WriteLine($"({qinner}\n");
		for(int i=0;i<qinner.colsize;i++) qinner[i].print();
		System.Console.WriteLine("\n");
		var g = qinner*q;
		//for(int i=0;i<g.colsize;i++) g[i].print();

		return 0;
	}
}

