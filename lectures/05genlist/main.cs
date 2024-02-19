class main{

static double a=1;
//definerer en funktion uden for Main scopet dvs at vi sagtens kan bruge værdien f eftersom at den ikke længere er besat 
public static System.Func<double,double> make_power(int i){
	System.Func<double,double> f = delegate(double x){return System.Math.Pow(a,1);};
		return f;
	       	//lambda function in c# is the delegate call
//it captures a by reference not value thus one needs to be careful when redefining a
}	



	public static int Main(){
		genlist<double> list = new genlist<double>();//definerer en ny genlist at type T- double
		list.add(1.2);//tilføj til genlist som data
		list.add(2.0);
		for(int i=0;i<list.size;i++)System.Console.WriteLine(list[i]);
		list[0] = 1;
		list[1] = 0;		
		for(int i=0;i<list.size;i++)System.Console.WriteLine(list[i]);
		double a=7, x=10;
		System.Func<double,double> f = delegate(double tmp){return a*x;};
		//return type followed by type argument in func call
		a=9;
		System.Console.WriteLine($"f({x})={f(x)}");
		
		//vil gerne lave en liste af funktioner dette gøres som følger
		var flist = new genlist<System.Func<double,double>>();
		flist.add(f);
		flist.add(System.Math.Sin);
		flist.add(System.Math.Cos);
		//vi har tilføjet 3 funktioner til vores genlist liste
		//typen som vi har sendt ind i genlist er den funktionen delegate
		for(int i=0;i<flist.size;i++){
			System.Console.WriteLine($"f[{i}]({x})={flist[i](x)}");
			}


		return 0;
	}
}
