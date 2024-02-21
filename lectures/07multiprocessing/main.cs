class main{

public class harmdata{ public int a,b; public double sum;}
//takes argument a and b and returns the sum


public static void harm(object obj){
	harmdata d = (harmdata)obj;
	//vi siger her at vi nu definere en varibel d som er af klassen harmdata, og d initialiseres vha objectet
	d.sum=0;
	System.Console.Write($"harm: a= {d.a} b={d.b}\n");
	for(int i=d.a;i<=d.b;i++)d.sum+=1.0/i;
	System.Console.Write($"harm: sum={d.sum}\n");
	//en funktion der udregner den harmoniske sum fra a til b
}




	public static int Main(string[] args){
	//harmdata datum = new harmdata();
	//csharp laver constructere for en, ikke ligesom c++, dvs at den sandsynligvis returnere a=0 og b=0 selvom dette ikke var specificeret
	int nterms=(int)1e7,nthreads=1;
	foreach(string arg in args){
		var words = arg.Split(':');
		if(words[0]=="-nterms")nterms=(int)double.Parse(words[1]);
		if(words[0]=="-nthreads")nthreads=(int)double.Parse(words[1]);

	}	
	//gør at vores program kan modtage keywordene nterms og nthreads så vi kan bestemme antallet fra kaldet af programmet
	System.Console.Write($"Main: nterms={nterms} nthreads={nthreads}\n");
	harmdata[] data = new harmdata[nthreads];
	//initialiserer data sættene til at være et array der har lige så mange indgange som threads
	int chunk = nterms/nthreads; 
	//opdeler mængden af data som hver thread skal køre så for 2 threads kører hver thread halvdelen af dataene
	for(int i=0;i<nthreads;i++){
		data[i] = new harmdata();
		data[i].a=i*chunk+1;
		data[i].b=data[i].a+chunk;
	}
	data[nthreads-1].b=nterms;
	//her udregnes de forskellige chunks af data hver for sig, og der vil være ligeså mange datasæt som der er threads hvilket er derfor vi kører forloopet op til nthreads


	var threads = new System.Threading.Thread[nthreads];
	//initialiserer threads og angiver antallet af threads vi initialiserer
	System.Console.Write($"Main: starting threads...\n");

	for(int i=0;i<nthreads;i++){
		threads[i] = new System.Threading.Thread(harm);
		//prepare a thread and every thread will run harm
		//and each thread will run with a given data[i]
		threads[i].Start(data[i]);
	}
	System.Console.Write($"Main: waiting for threads to finish...\n");
	foreach(var thread in threads)thread.Join();
	double total=0;
	foreach(harmdata datum in data)total+=datum.sum;
	//summer alle resultater i data
	System.Console.Write($"Main: total sum= {total}\n");
// kalder main.exe efter make med mono og så -nterms:somenumber og -nthreads:somenumberofthreads


	return 0;
	}
}	
