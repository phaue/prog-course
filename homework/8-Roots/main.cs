using System;
using static System.Console;
using static System.Math;

class main{

    static vector rosenbrockgradient(vector xy){
        vector dxdy = new vector(xy.size);
        dxdy[0] = (-2)*(1-xy[0])-400*xy[0]*(xy[1]-xy[0]*xy[0]);
        dxdy[1] = 200*(xy[1]-xy[0]*xy[0]);
        return dxdy;
    }
    static vector himmelblaugradient(vector xy){
        vector dxdy = new vector(xy.size);
        dxdy[0] = 2*(2*xy[0]*(xy[0]*xy[0]+xy[1]-11)+xy[0]+xy[1]*xy[1]-7);
        dxdy[1] = 2*(xy[0]*xy[0]+2*xy[1]*(xy[0]+xy[1]*xy[1]-7)+xy[1]-11);
        return dxdy;
    }


    static int Main(){
        double[] rbstart = new double[] {-3,1};
        vector rbsol = roots.newton(rosenbrockgradient, rbstart);
        WriteLine($"Root of the Rosenbrock function with starting conditions=({rbstart[0]}, {rbstart[1]})");
        rbsol.print();
        double[] hbstart = new double[] {4,-3};
        vector hbsol = roots.newton(himmelblaugradient, hbstart, 0.0000001);
        WriteLine($"Root of the Himmelblau function with starting conditions=({hbstart[0]}, {hbstart[1]})");
        hbsol.print();
        return 0;
    }//Main
}//main