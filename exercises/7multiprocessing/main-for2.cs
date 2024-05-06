using System.Linq;

class main{
	static int Main(string[] args){
	long nterms = (long)1e8;
	foreach(string arg in args){
		var words= arg.Split(':');
		if(words[0]=="-nterms")nterms=(long)double.Parse(words[1]);
	}
	var sum = new System.Threading.ThreadLocal<double>( ()=>0, trackAllValues:true);
	System.Threading.Tasks.Parallel.For( 1, nterms+1, (long i)=>sum.Value+=1.0/i );
	double totalsum=sum.Values.Sum();
	System.Console.Write($"harm sum = {totalsum}\n");
	System.Console.WriteLine("Again it is way slower, again we have to do a function call within the iteration which is a lot slower.");
//This however produces the right result but it is still slower than the original method.


	return 0;

	
	}
}
