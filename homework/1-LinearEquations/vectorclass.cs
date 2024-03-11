using static System.Math;
using static System.Console;
using System;
using System.IO;

public class vector{
	
	private double[] data;//Her lavet vi et tomt array som kaldes data. Dette er måden at nemt hente et tomt array senere

	public int size => data.Length; // vi definerer "size" til at være givet som længden af data

	public double this[int i]{
		get => data[i]; // laver en funktion hvor vi kan hente en værdi af data i indekset i "getter"
		set => data[i]=value; // laver en funktion hvor vi kan tilskrive et bestemt indeks i data en værdi "setter"
	}



	//Constructors
	public vector(int n){data=new double[n];} //definere her et nyt vector objekt som defines ved .vector(n) som laver
						  // en ny vector som indeholder "data" som er et array a doubles 
						  // og har størrelsen n data er det array som bruges til at holde værdierne
	
	public vector(params double[] list){data=list;}//Her laver vi en vector ved at give den en liste som argument og den
						       // liste bliver så til vores vector objekt.

	public vector(string s){
	char[] seperators={',',' '}; // vi definere en liste af "seperators"
	var options =StringSplitOptions.RemoveEmptyEntries; // vi definere "options" som at fjerne alle tomme entries
	string[] words = s.Split(seperators, options); //laver en liste af strings som vi kalder words og den liste er lig med
						       //vores streng "s" som er splittet vha. seperators og options og lavet
						       //om til en normal liste uden de symboler
	int n= words.Length; // definere en længde n
	data = new double[n];// laver et nyt data array som er n langt
	for(int i=0;i<size;i++){
		this[i]=double.Parse(words[i]);
		}
	}	//laver hver indgang i words om til en double og ik længere string
	



	//Implicit konverting mellem double[] og vector	
	public static implicit operator vector(double[] a){
		return new vector(a);
		}// operatoren definere en implicit konvertering fra et double array til et vector objekt.
		 // den returnere et nyt vector objekt som er lavet ved at bruge vector(doubl[] list) constructoren
		 // den kopiere elementerne fra double arrayet til det nye vector objekt.
	public static implicit operator double[] (vector a){
		return a.data;
		}//laver operationen den anden vej hvor vi konvertere vores vector objekt til et double array 
		//disse to funktioner gør at man kan skrive et double array til at være lig med et vector objekt og omvendt
		//således at konvertingen sker implicit fra double[] til vector og omvendt.




	//Print statements
	public void print(string s="", string format="{0,10:g3}",TextWriter file=null){
		//print statement af vector objektet. Her printes s med den givne formatering og filen kan specificeres
		//ellers bruges standard værdierne der er sat foroven
		if(file==null)file=System.Console.Out; //hvis file==null så er standard output system.console.out
		file.Write(s); //skriv strengen s ud i file(eller default output)
		for(int i=0;i<size;i++){
			file.Write(format,this[i]);// printer itererativt igennem for at skrive hvert element til outputtet 
		}
		file.Write("\n");
	}

	public void fprint(TextWriter file, string s="", string format="{0,10:g3}"){
		file.Write(s);
		for(int i=0;i<size;i++){
			file.Write(format, this[i]);
		}
		file.Write("\n");
	}// gør meget det samme som den før men nu skal man specificere hvilken fil man skal printe ud til
	 // fprint står nok for filerprint så siden man gerne vil have det specificeret



	//Operators
	

	public static vector operator+(vector v, vector w){
	vector r = new vector(v.size); //ny vector som har samme størrelse som v
	for(int i=0; i<v.size;i++){
		r[i]=v[i]+w[i];
		}		
	return r;
	}

	public static vector operator-(vector v){
		vector r = new vector(v.size);
		for(int i=0;i<v.size;i++)r[i]=-v[i];
		return r;
	}

	public static vector operator-(vector v, vector w){
		vector r=new vector(v.size);
		for(int i=0;i<v.size;i++)r[i]=v[i]-w[i];
		return r;
	}

	public static vector operator*(vector v, double a){
		vector r = new vector(v.size);
		for(int i=0;i<v.size;i++)r[i]=a*v[i];
		return r;
	}
	public static vector operator*(double a, vector v){
		return v*a;
	}


	public static vector operator/(vector v, double a){
		vector r = new vector(v.size);
		for(int i=0;i<v.size;i++)r[i]=v[i]/a;
		return r;
	}
	public static vector operator/(vector v, vector w){
		vector r= new vector(v.size);
		for(int i=0;i<v.size;i++)r[i]=v[i]/w[i];
		return r;
	}

	public double dot(vector v){
		double sum=0;
		for(int i=0; i<v.size;i++)sum+=this[i]*v[i];
		return sum;
	}
	public static double operator%(vector v, vector w){
		return v.dot(w);
	}

public static vector map(vector v, System.Func<double,double>f){
	vector r = new vector(v.size);
	for(int i=0;i<v.size;i++)r[i]=f(v[i]);
	return r;
}//tager og "mapper" vores vector over i en function som tager double som input og spytter en double ud.
 //dvs at vi for hvert element af vores vector kører functionen f på den for hver indgang og returnerer den nye vector
 


// maxabs max min norm copy 
	public double maxabs(){
		double r = Abs(this[0]);
		for(int i=0;i<size;i++)if(Abs(this[i])>r)r=Abs(this[i]);
		return r;
	}
	public double max(){
		double r=this[0];
		for(int i=0;i<size;i++)if(this[i]>r)r=this[i];
		return r;
	}
	public double min(){
		double r=this[0];
		for(int i=0;i<size;i++)if(this[i]<r)r=this[i];
		return r;
	}
	public double norm(){
		double meanabs = 0;
		for(int i=0;i<size;i++)meanabs+=Abs(this[i]);
		if(meanabs==0)meanabs=1;
		meanabs/=size;
		double sum=0;
		for(int i=0;i<size;i++){
			sum+=(this[i]/meanabs)*(this[i]/meanabs);
		}
		return meanabs*Sqrt(sum);
	}
	
	public vector copy(){
		vector r = new vector(this.size);
		for(int i=0;i<this.size;i++)r[i]=this[i];
		return r;
	}

	public static bool approx(double a, double b, double acc=1e-9, double epsi=1e-9){
		if(Abs(a-b)<acc)return true;
		if(Abs(a-b)/Max(Abs(a),Abs(b))<epsi)return true;
		else return false;

	
	}

	public static bool approx(vector v, vector w, double acc=1e-9, double epsi=1e-9){
		if(v.size != w.size) return false;
		for(int i=0;i<v.size;i++){
			if(!approx(v[i],w[i],acc,epsi)) return false;//refererer til approx funktionen ovenfor
								     //hvis ikke de er lig hinanden så ...
		}
		return true;

	}
	public bool approx(vector v){
		for(int i=0;i<size;i++){
			if(!approx(this[i],v[i])) return false;//igen funktionen 2 gange ovenfor der biver brugt
		}
		return true;
	
	}

}//vector class

