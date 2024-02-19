class main{
	public static int Main(){
	for(double x=0; x<=3;x+=1.0/8){
	System.Console.Out.WriteLine($"{x} {sfuns.gamma(x+1)} {sfuns.stirling(x)} {sfuns.lngamma(x+1)} {sfuns.lnstirling(x)}");
	}
	for(int j=0; j<=3;j++){
	System.Console.Error.WriteLine($"{j} {sfuns.factorial(j)} {sfuns.lnfactorial(j)}");
	
	}	

		return 0;
	}
}
