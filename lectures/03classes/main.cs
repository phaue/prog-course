using System;
using static System.Console;
class main{
static int Main(string[] args){
	/*ovenfor i mainfunktionen er der specificeret input i Main som er den funktion som styrer hele koden. dette input kan gives i command linen når make kaldes. Dette gør at argumentet der gives bliver proppet ind i Main funktionen og får navnet
args som er givet som en array af strings.
	 */

	double x=2,y=1;
	if(x>y){
	       	Console.Write("x>y\n");
       	}
       	else {
	       	Write("y<=x\n");
       	}
	/* standard if else statement ligesom i python, vi skal dog have specificeret vores if-statement i en parentes, og så bruges blok-parenteser ligeledes som i python ¨for at få det på flere linjer eller vores statement indeholder flere statements
	 if statements kan også nestes med flere elseif statements, er lidt i tvivl om man kan have flere if statements og så en else til slut ligesom i python
	 */

	/*
	int i;
	for(i=1;i<10;++i)Write($"i={i}\n");
	i=0;

	do {Write($"i={i}\n");i++;} while(i<10);
	i=0;

	while(i<10) {Write($"i={i}\n");i++;};

	forskellige former for forloops hvor at det første loop er præcis ligesom det sædvanlige for-loop i python,
	linjen betyder at "for i der starter som 1 og så længe i er mindre end 10 så skal vi køre i=i+1 dvs hæve værdien af i med 1 hver iteration. For hver iteration af loopet så skriver vi værdien af i. Ligesom med if og else så kan forloops også godt skrives i bloks som gør at vi kan skrive flere statements og på flere linjer.

	do while loops er det samme som i python og er bare en alternativ måde at køre et loops på. det kan neten skrives med do først hvoraf at først gøres der noget og derefter tjekkes while betingelsen. Hvorimod at hvis det er while do loops så først tjekkes betingelsen før der køres en iteration.
	dvs do while loops kører 1 gang uanset hvad, while do loops kører ikke nødvendigis en gang

	*/



	int n=5;
	double[] a = new double[n]; 
	//ovenfor er der en initialisering af en array hvor vi siger at arrayen er en double og den double indeholder 5 indgange
	//
	//
	for(int i=0;i<n;i++)a[i]=i+1;
	// giver værdier til de forskellige indgange i arrayen a

	for(int i=0;i<n;i++)Write($"a[{i}]={a[i]} ");
	//skriver værdierne for de forskellige indgange i arrayen a
	
	foreach(var ai in a)Write($"ai={ai} ");
	//skriver ligeledes de forskellige indgange i arrayen a men bare med et andet forloop der er foreach som gør at for hver indgang ai i a skal vi gøre et eller andet.
	

	Write("\n");
	
	foreach(var arg in args)Write($"arg={arg} ");
	Write("\n");
return 0;
}//Main
}//class main
