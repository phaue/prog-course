using static System.Console;
public class my_class { public string s; } 
// definere en klasse som har en egenskab som er defineret som s hvoraf at s er en streng.
// når klasser refereres gøres det som en reference til pladsen i hukommelsen og ikke værdien som den holder selv. dvs at klasser er bare referencer og disse kan overwrites nemt

public struct my_struct { public string s; } 
//definere en struct som har samme egenskab som klassen ovenfor.
//forskellen mellen struct og klasse er at structs refererer værdien og ikke referencen dette betyder at structs laver kopier når der referes istedet for bare at sætte den sammen med referencen så de vil ikke overwrites

static class main{
//static void set_to_7(ref double tmp){ tmp=7; }
static void set_to_7(double tmp){ tmp=7; }
static void set_to_7(double[] tmp){ for(int i=0;i<tmp.Length;i++)tmp[i]=7; }
//definition af to funktioner som gør et eller andet hvor den første tar en double som argument og den anden tar en double array som argument
//
static int Main(){
	my_class A=new my_class();
	my_struct a=new my_struct();
	A.s="hello";
	a.s="hello";
	WriteLine($"A.s={A.s}");
	WriteLine($"a.s={a.s}");
	my_class B=A;
	my_struct b=a;
	WriteLine($"B.s={B.s}");
	WriteLine($"b.s={b.s}");
	B.s="new string";
	b.s="new string";
	WriteLine($"A.s={A.s}");
	WriteLine($"a.s={a.s}");
// her vises der hvad forskellen på struct og class gør hvor at struct ikke overwriter den første definition når vi sætter den lig med dvs den har bare kopieret den originale version og ikke blevet "til" den originale version. Dette er lige anderledes for klassen som overwriter den oprindelige definition fordi den bare er blevet viderreferet istedet fo at blive kopieret. For at undgå dette skal man istedet anvende .Copy(eller noget)


	double x=1;
	//set_to_7(ref x);
	set_to_7(x);
	Write($"x={x}\n");
	double[] v = new double[5];
	set_to_7(v);
	foreach(var vi in v)Write(vi);
	Write("\n");
return 0;
}
}
