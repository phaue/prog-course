using System;
using static System.Math;
using static System.Console;

class main{


    
    public static vector Function(double t, vector z){
        Func<double,double,double,double,double> r = delegate(double xx, double XX, double yy, double YY) {return Pow((XX-xx),2)+Pow((YY-yy),2);};
        double x1=z[6], y1=z[7], x2=z[8], y2=z[9], x3=z[10], y3=z[11]; 
        double vxprime1 = (x2-x1)/Pow(r(x1,x2,y1,y2),1.5)+(x3-x1)/Pow(r(x1,x3,y1,y3),1.5);
        double vyprime1 = (y2-y1)/Pow(r(x1,x2,y1,y2),1.5)+(y3-y1)/Pow(r(x1,x3,y1,y3),1.5);
        double vxprime2 = (x1-x2)/Pow(r(x2,x1,y2,y1),1.5)+(x3-x2)/Pow(r(x2,x3,y2,y3),1.5);
        double vyprime2 = (y1-y2)/Pow(r(x2,x1,y2,y1),1.5)+(y3-y2)/Pow(r(x2,x3,y2,y3),1.5);
        double vxprime3 = (x2-x3)/Pow(r(x3,x2,y3,y2),1.5)+(x1-x3)/Pow(r(x3,x1,y3,y1),1.5);
        double vyprime3 = (y2-y3)/Pow(r(x3,x2,y3,y2),1.5)+(y1-y3)/Pow(r(x3,x1,y3,y1),1.5);
        vector newz = new vector(vxprime1,vyprime1,vxprime2,vyprime2,vxprime3,vyprime3, z[0], z[1], z[2], z[3], z[4], z[5]);
    return newz;   
    } 

    static int Main(){
        double tini = 0;
        double tfinal = 2.1;
        vector zini = new vector(0.4662036850,0.4323657300,-0.93240737,-0.86473146,0.4662036850,0.4323657300,-0.97000436,0.24308753,0,0,0.97000436,-0.24308753);
        (var tlist, var zlist) = ODE.driver(Function, (tini,tfinal), zini);
        WriteLine("# Solution of the newtonian gravitational three body problem");
        WriteLine("# t,vx1,vy1,vx2,vy2,vx3,vy3,x1,y1,x2,y2,x3,y3");
        for(int  i=0;i<zlist.size;i++){
		WriteLine($"{tlist[i]} {zlist[i][0]} {zlist[i][1]} {zlist[i][2]} {zlist[i][3]} {zlist[i][4]} {zlist[i][5]} {zlist[i][6]} {zlist[i][7]} {zlist[i][8]} {zlist[i][9]} {zlist[i][10]} {zlist[i][11]}");
        }

        return 0;
    }//Main
}//main