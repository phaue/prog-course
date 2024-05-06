using static System.Math;
using static System.Console;

class main{
	static int Main(){
	//initializing of two vectors v and u using the defined class
	vec v = new vec(1.0, 2.0, 3.0);
	vec u = new vec(4.0, 5.0, 6.0);
	vec w = new vec(0.5, 1, 1.5);
	Write("Vectors v, u and w respectively: \n");
	Write("v=");
	v.print();
	Write("u=");
	u.print();
	Write("w=");
	w.print();
	//using the defined operators for multiplikation addition and subtraction.
	vec vscaled = v*2.0;
	vec uscaled = u*3.0;
	vec wscaled= w*2.0;
	vec vaddu = v + u;
	vec vminusu = v - u;
	vec vneg = -v;

	double dot1 = v.dot(u);
	double dot2 = vec.dot(v,u);
	
	
	bool aprox1 = vec.approx(v, wscaled);
	bool aprox2 = v.approx(wscaled);
			

	vscaled.print("vector v times 2 = ");
	uscaled.print("vector u times 3 = ");
	vaddu.print("vector v + u = ");
	vminusu.print("vector v minus u = ");
	vneg.print("vector v negated = ");
	Write($"The vec other method of calculating the dot product gives: {dot1}\n");
	Write($"The dot vec1,vec2 method of calculating the dot product gies: {dot2}\n");
	Write($"The two approx methods are chronologically given as {aprox1} and {aprox2}\n");




	return 0;	



	}
}
