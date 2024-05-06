class main{
public static int Main(){
	for(double x=-3;x<=3;x+=1.0/8){
	//kan ikke som udgangspunkt lave et forloop over en double, kun når det går op i ottendedele så det kan representeres i binary
	System.Console.WriteLine($"{x} {sfuns.erf(x)}");
	}
	return 0;
}





	}
