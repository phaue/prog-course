class main{
static int Main(){

	double x=7;
	System.Console.Out.Write($"this goes to stdout: x={x}\n");
	//Her skriver vi strengen ud til "Out" destination som er vores output fil
	System.Console.Error.Write($"this goes to stderr: x={x}\n");
	//Her skriver vi strengen ud til "Error" destination som er vores log fil

	string line = System.Console.In.ReadLine();
	//Her siger vi at der kommer et eller andet input i form af "In" og dette input skal gemmes som en streng kaldet line
	System.Console.Error.Write($"this also goes to stderr: line={line}\n");
	//igen skriv den til Error destinationen
	x=double.Parse(line); // lav strengen om til en double
	System.Console.Out.Write($"this goes to stdout: x={x}\n");// skriv den ud til Out destinationen

return 0;
}
}
