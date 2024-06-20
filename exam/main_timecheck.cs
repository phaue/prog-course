using System;
using static System.Math;
using static System.Console;

class main{
   static int Main(string[] args){
        int lowlim = 0; int uplim = 10; int stepsize=2;
	    foreach(string arg in args){
		    var words=arg.Split(':');
		    if(words[0]=="lowlim") lowlim=int.Parse(words[1]);
            if(words[0]=="uplim") uplim=int.Parse(words[1]);
            if(words[0]=="stepsize") stepsize=int.Parse(words[1]);
   }
    WriteLine($"#Interval of matrixsizes({lowlim},{uplim}) of stepsize={stepsize}");
    WriteLine($"#Size of matrix: time elapsed for banach method: time elapsed for crout method:");
    
    for(int i=lowlim;i<=uplim; i+=stepsize){
        matrix A = cholesky.generate_posdef_matrix(i);
        var stopwatch1 = System.Diagnostics.Stopwatch.StartNew();
        cholesky.banach_decomp(A);
        stopwatch1.Stop();
        var time1 = stopwatch1.Elapsed.TotalSeconds;

        var stopwatch2 =  System.Diagnostics.Stopwatch.StartNew();
        cholesky.crout_decomp(A);
        stopwatch2.Stop();
        var time2 = stopwatch2.Elapsed.TotalSeconds;
        WriteLine($"{i} {time1} {time2}");
    }

    return 0;
}
}
