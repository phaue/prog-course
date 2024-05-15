using System;
using static System.Console;

static class main{

	static int Main(string[] arg){
	    int N = (int)double.Parse(arg[0]);
	    matrix M = jacobi.gensymmatrix(N);
	    (vector w, matrix V) = jacobi.cyclic(M);
        return 0;
    }//Main
}//main