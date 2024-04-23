using System;
using static System.Math;
using static System.Console;


public class main{

    public static double F(double E, double m, double L, double A){
        return A/(Pow(E-m, 2)+Pow(L,2)/4);
    }
    public static double D(double m, double L, double A, genlist<double> energy, genlist<double> signal, genlist<double> error){
        double summ = 0;
        for(int i=0;i<energy.size;i++){
            summ+=Pow((F(energy[i], m, L, A)-signal[i]),2)/Pow(error[i],2);
        }
        return summ;
    }
    static int Main(){
        var energy = new genlist<double>();
        var signal = new genlist<double>();
        var error  = new genlist<double>();
        var separators = new char[] {' ','\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;
        do{
            string line=Console.In.ReadLine();
            if(line==null)break;
            string[] words=line.Split(separators,options);
            energy.add(double.Parse(words[0]));
            signal.add(double.Parse(words[1]));
            error.add(double.Parse(words[2]));
        }while(true);

    Func<vector, double> Dev = delegate(vector mLA) {return D(mLA[0], mLA[1], mLA[2], energy, signal, error);};
  
    vector startmLA = new vector(125.3,-2,10);
    (vector mLAsol, int count) = minimization.newton(Dev, startmLA);
    WriteLine($"The found values from the minimization routine is: m={mLAsol[0]}, gamma={mLAsol[1]}, A={mLAsol[2]}");

    var outstream = new System.IO.StreamWriter("fitdata.txt", append:false);
    int points = 1000;
    double stepsize = (energy[energy.size-1]-energy[0])/points;
    for(double e=energy[0];e<=energy[energy.size-1];e+=stepsize){
        outstream.WriteLine($"{e} {F(e, mLAsol[0], mLAsol[1], mLAsol[2])}");
    }
    outstream.Close();
    return 0;
    }


}