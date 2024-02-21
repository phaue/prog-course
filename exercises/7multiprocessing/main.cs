class main{

public class data { public int a,b; public double sum;}
	
public static void harm(object obj){
		var arg = (data)obj;
		arg.sum=0;
		//System.Console.Write($"harm: a= {arg.a} b={arg.b}\n");
		for(int i=arg.a;i<arg.b;i++)arg.sum+=1.0/i;
		//System.Console.Write($"harm: sum={arg.sum}\n");
}


public static int Main(string[] args){
	
	int nthreads = 1, nterms = (int)1e8; /* default values */
	foreach(var arg in args) {
   		var words = arg.Split(':');
   		if(words[0]=="-threads") nthreads=int.Parse(words[1]);
   		if(words[0]=="-terms"  ) nterms  =(int)float.Parse(words[1]);
   	}	
	System.Console.Write($"Number of threads to be used: {nthreads}\n");

	data[] dat = new data[nthreads];
	//initializing a data array that holds nthreads entries
	int chunk = nterms/nthreads;
	for(int i=0;i<nthreads;i++) {
   		dat[i] = new data();
   		dat[i].a = 1 + chunk*i;
   		dat[i].b = 1 + chunk*(i+1);
   	}// a forloop that calculates the sum for each entry in the dataset which means for each thread

	dat[dat.Length-1].b=nterms; /* the enpoint might need adjustment */

	var threads = new System.Threading.Thread[nthreads];
	for(int i=0;i<nthreads;i++) {
   		threads[i] = new System.Threading.Thread(harm); /* create a thread */
   		threads[i].Start(dat[i]); /* run it with params[i] as argument to "harm" */
   	}
	
	foreach(var thread in threads) thread.Join();

	double total=0;
       	foreach(var d in dat)total+=d.sum;
	System.Console.Write($"Main: total sum= {total}\n");





		return 0;
	}
}

