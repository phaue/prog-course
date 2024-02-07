using System;
// vi bruger namespacet System som gør at kommandoer som starter på System.etellerandet ikke behøver at blive kaldt med System. men man kan nøjes med etellerandet

using static System.Console;
//Hvis funktionerne er statiske skal de kaldes som static, men denne error bliver kaldt når vi prøver at compile programmet hvis den ikke er tilfreds, det samme er tilfældet nedenunder.

using static System.Math;
static class main{ 
	//nu definerer vi en statisk klasse som betyder at det som klassen returnere er statisk, det er ikke en function
	static double x=1.0;
       	// som konsekvens skal alle variablerne defineret inde i programmet være givet som statiske
	
	static string hello = $"hello, x={x}\n";
	// dollar tegnet bruges ligesom f-function foran strings i python - det er hvor at hvis vi tilføjger curly brackets så henviser vi til variablen inde i den og ikke selve strengen inde i de brackets
	
	static double Sin(double x){ return 0; }
       	// dette er en funktion som vi definere som Sin, dette betyder at den overshadower den senere brugte funktion Sin som er inde i namespacet System.Math, måske kan dette fikses ved at gå ud a namespacet?
	
	static double times2(double y){
		//standard funktions definition hvor funktion kaldes for times2 og den er defineret til at være både statisk og en double og parentesen specificerer hvad den afhænger af - i dette tilfælde doublen y
		double x=7;
		WriteLine(x);
		return y*2;
		// variabler og funktioner som erdefineret inde i en funktion altså i et mindre scope bliver slettet når funktionen er kørt igennem, dette betyder at det samme variabel navn godt kan blive brugt, hvoraf det vil være variablen defineret i det lille scope der vi blive brugt og så slettet bagefter, ligesom x her hvor vi havde defineret x før i det store scope. man kan også definere funktioner eller variabler i "boxes" disse boxes definere kun variablerne inde i boksen og bagefter bliver de slettet ligesom med funktion, boxes kan bare også bruges inde i en funktion.
		}
	
	static int Main(){
		Write($"{hello} x={x} Sin(x)={Sin(x)}\n");
		//igen behøver vi ikke system.console fordi vi er i namespacet
		double prod=1;
		for(int x=1;x<10;x+=1){
			Write($"fgamma({x})={sfuns.fgamma(x)} {x-1}! ={prod}\n");
			//Her henter vi en funktion der hedder fgamma fra vores bibliotek sfuns som er en fil som har en funktion kaldet fgamma. Derved kan vi definere funktioner i andre filer og kalde dem i vores hoved fil således at koden bliver skrevet mere kompakt og alle definitions funktionerne ikke fylder i hoveddokumentet.
			prod*=x;
			}
	return 0;
	}
}
