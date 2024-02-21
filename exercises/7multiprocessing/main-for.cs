class main{
	static int Main(string[] args){
	long nterms = (long)1e8;
	foreach(string arg in args){
		var words= arg.Split(':');
		if(words[0]=="-nterms")nterms=(long)double.Parse(words[1]);
	}
	double sum=0;
	System.Threading.Tasks.Parallel.For( 1, nterms+1, (long i) => sum+=1.0/i );
	System.Console.Write($"harm sum = {sum}\n");

// It does not return the correct result, and it is ridicilously slower than the other call
// something something - this being a function call that has to be processed each time unlike the other one that just loops without considering the content


	return 0;

	
	}
}
