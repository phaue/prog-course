using System;
using static System.Math;
using static System.Console;

public class main{

    static int Main(){
        Func<vector, double> rb = delegate(vector xy) {return (1-xy[0])*(1-xy[0])+100*(xy[1]-xy[0]*xy[0])*(xy[1]-xy[0]*xy[0]);};
        Func<vector, double> hb = delegate(vector xy) {return (xy[0]*xy[0]+xy[1]-11)*(xy[0]*xy[0]+xy[1]-11)+(xy[0]+xy[1]*xy[1]-7)*(xy[0]+xy[1]*xy[1]-7);};
        vector rbstart = new vector(-3,1);
        (vector rbsol, int rbcount) = minimization.centralnewton(rb, rbstart);
        WriteLine($"Root of the Rosenbrock function with starting conditions=({rbstart[0]}, {rbstart[1]})");
        rbsol.print();
        WriteLine($"Steps taken to reach the minimum: {rbcount}");
        vector hbstart = new vector(-3,2);
        (vector hbsol, int hbcount) = minimization.centralnewton(hb, hbstart);
        WriteLine($"Root of the Himmelblau function with starting conditions=({hbstart[0]}, {hbstart[1]})");
        hbsol.print();
        WriteLine($"Steps taken to reach the minimum: {hbcount}");


    return 0;
    }
}