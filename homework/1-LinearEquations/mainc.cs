using System;
using static System.Console;
using static System.Math;

class main{

    static int Main(string[] args){
        int N = 2; // standard size
        foreach(var arg in args){
            var words = arg.Split(':');
            if(words[0]=="-size") N = (int)double.Parse(words[1]);
        }
        matrix M = QRGS.generatematrix(N, N);
        (matrix Q, matrix R) = QRGS.decomp(M);
        return 0;
    }//Main
}//main
