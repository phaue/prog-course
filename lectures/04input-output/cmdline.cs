using System;
using static System.Console;
using static System.Math;
class main{
static int Main(string[] args){ // specificerer at vores funktion Main kan tage et input array af strings som vi kalder 4 args
	string infile=null,outfile=null; // vi initialiserer vores inputfil og outputfil vha. null
	foreach(var arg in args){
		System.Console.Error.WriteLine(arg); // denne linje skriver til vores #2 output nemlig log filen
		string[] words = arg.Split(':'); // her splitter vi strengen ved kolon
		if(words[0]=="-input")infile=words[1]; //hvis det der står først i strengen starter med input er filen vi inou//tter efterfulgt af kolonnet hvilket vil sige at det er anden entry i strengen fordi vi har splittet den.
// dette gøres for både en input fil og en output fil. De er specificeret ligesom i Makefilen						 
		if(words[0]=="-output")outfile=words[1];
		if(words[0]=="-numbers"){
			string[] numbers=words[1].Split(',');
			foreach(var number in numbers){
				double x=double.Parse(number);// .Parse laver "number" som er en streng om til en double som
							      // x også er
				System.Console.Error.WriteLine($"x={x}"); // skriver det ud til vores log fil
				}
			}
		}
	if(infile==null || outfile==null){ 
		System.Console.Error.WriteLine("wrong argument");
		return 1;
		}// ved at returne 1 siger vi at der er sket en fejl, kan også gøres med -1 der derimod siger at 
		 // det er gået helt galt
	var instream  = new System.IO.StreamReader(infile);//nu åbner vi en stream af filen, dvs vi åbner filen
	var outstream = new System.IO.StreamWriter(outfile,append:false);// vi åbner således outfilen
	
	for(string line = instream.ReadLine();line!=null;line=instream.ReadLine()){
		double x=double.Parse(line);
		outstream.WriteLine($"x={x} Sin({x})={System.Math.Sin(x)}");
		}
	//Her så tager vi hver linje i vores infile og læser den ud så længe af filen ik returner "null" dvs en tom linje
	//denne linje er læst som en string og omsættes derefter til en double
	//så skriver vi vores double ud i vores outfil
	//
	instream.Close();
	outstream.Close();
	//vores infile og outfile lukkes inden vi terminerer programmet således at der ikke sker funky ting
return 0;
}//Main
}//main
