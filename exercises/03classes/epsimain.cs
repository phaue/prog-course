using static System.Console;
using static System.Math;

class main{
	public static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
                if(Abs(a-b)<=acc) return true;
                if(Abs(a-b)<= Max(Abs(a), Abs(b))*eps) return true;
                else return false;
        }
	static int Main(){
	
	
	Write("Epsilon exercise\n");
	Write("Task 1: Maximum/minimum representable intergers\n");
	int i=1; while(i+1>i) {i++;}
	Write($"my max int = {i}\n");
	Write($"max int value = {int.MaxValue}\n");
	int j=1; while(j-1<j) {j++;}
	Write($"my min int = {j}\n");
	Write($"min int value = {int.MinValue}\n \n");

	Write("Task 2: The machine epsilon\n");
	double x=1; while(1+x!=1){x/=2;} x*=2;
	float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
	Write($"The double machine epsilon was found to be {x} and it should be around {Pow(2,-52)}\n");
	Write($"The float machine epsilon was found to be {y} and it should be around {Pow(2,-23)}\n \n");

	Write("Task 3: tiny=epsilon/2\n");
	double epsilon=Pow(2,-52);
	double tiny=epsilon/2;
	double a=1+tiny+tiny;
	double b=tiny+tiny+1;
	Write($"a==b ? {a==b}\n");
	Write($"a>1  ? {a>1}\n");
	Write($"b>1  ? {b>1}\n");
	Write("1+tiny+tiny is therefore not larger than one and tiny+tiny+1 is. \n");
	Write("This is because two doubles in a finite digit representation can only be compared with the given absolute and/or relative precision\n");
	Write("So when comparing 1 and tiny+tiny we lose precision because 1 cannot be compared to tiny and then tiny again, but in the reverse order it is okay because tiny can be related to tiny first and then we add 1.\n \n");

	Write("Task 4: Comparing doubles\n");
	double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	double d2 = 8*0.1;
	Write($"Are 0.1+0.1...(8 times) the same as 8*0.1 according to ==? d1==d2 ? => {d1==d2}\n");
	Write($"Are 0.1+0.1...(8 times) the same as 8*0.1 according to approx function? {approx(d1,d2)}\n");


	return 0;
	}
}

