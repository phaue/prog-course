using System;
using static System.Math;

public class matrix{

	private double[][]  data;
	public readonly int rowsize, colsize; //defines the size of the matrix n,m to be unchangeable

	public matrix(int n, int m){
		rowsize = n;
		colsize=m;
		data = new double[colsize][];//specifies how many columns there are
		for(int i=0;i<colsize;i++) data[i]=new double[rowsize]; //adding rows equal to the size of n
		}
      	public matrix(int n) : this(n,n) {} //creates a square matrix of size nxn this(n,n) calls the first constructor
					     //with the arguments n,n	
	public double this[int i, int j]{
		get => data[i][j];
		set => data[i][j]=value;
	}

	public vector this[int i]{
		get => data[i];
		set => data[i]=value;
	}

	public matrix(string s){
		string[] rows = s.Split(';');//rows are seperated by a semicolon
		rowsize = rows.Length; // number of rows
		char[] delimeters = {' ', ','}; //entries are seperated by , or nothing
		var options = StringSplitOptions.RemoveEmptyEntries;
		colsize = rows[0].Split(delimeters,options).Length; //number of colums is the number of entries in a given row
		data = new double[colsize][];
		for(int i=0;i<colsize;i++) data[i] = new double[rowsize];
		for(int j=0;j<rowsize;j++){
			string[] words = rows[j].Split(delimeters,options);
			for(int k=0;k<colsize;k++){
				this[j,k]=double.Parse(words[k]);
			}
		}
	}

//Operators
//matrix plus, negate matrix, sub matrix, divide by integer, times an integer(2 different), times another matrix(matrixproduct) , matrix times vector(need two?), 

	public static matrix operator+ (matrix a, matrix b){
		matrix r = new matrix(a.rowsize, a.colsize);
		for(int i=0; i<a.colsize;i++){
			for(int j=0;j<a.rowsize;j++){
				r[j,i] = a[j,i]+b[j,i];
			}
		}
		return r;
	}

	public static matrix operator- (matrix a){
		matrix r = new matrix(a.rowsize,a.colsize);
		for(int i=0;i<a.colsize;i++){
			for(int j=0;j<a.rowsize;j++) r[j,i]=-a[j,i];
		}
		return r;
	}
	
	public static matrix operator-(matrix a,matrix b){
		matrix r = new matrix(a.rowsize,a.colsize);
		for(int i=0;i<a.colsize;i++){
			for(int j=0;j<a.rowsize; j++) r[j,i] = a[j,i] - b[j,i];
		}
		return r;
	}

	public static matrix operator/(matrix a, double k){
		matrix r = new matrix(a.rowsize,a.colsize);
		for(int i=0;i<a.colsize;i++){
			for(int j=0;j<a.rowsize;j++) r[j,i]=a[j,i]/k;
		}
		return r;
	}

	public static matrix operator*(matrix a, double k){
		matrix r = new matrix(a.rowsize,a.colsize);
		for(int i=0;i<a.colsize;i++){
			for(int j=0;j<a.rowsize;j++) r[j,i]=a[j,i]*k;
		}
		return r;
	}

	public static matrix operator*(double k, matrix a){return a*k;}
	
	public static matrix operator*(matrix a, matrix b){
	matrix r = new matrix(a.rowsize,b.colsize);
	for(int i=0;i<a.rowsize;i++)
	for(int j=0;j<b.colsize;j++)
		{
		for(int k=0;k<a.colsize;k++){
			r[i,j]=a[i,k]*b[k,j];
		}
		}
	return r;
	}

	public static vector operator*(matrix a, vector v){
		vector r = new vector(a.rowsize);
		for(int i=0;i<a.colsize;i++)
		for(int j=0;j<a.rowsize;j++)
		{
			r[j]+=a[j,i]*v[i];
		}
		return r;
	}

	public static vector operator%(matrix a, vector v){
		vector r = new vector(a.colsize);
		for(int i=0;i<a.rowsize;i++)
		for(int j=0;j<a.colsize;j++)
		{
			r[j]+=a[i,j]*v[i];
		}
		return r;
	}

	public matrix(vector v) : this(v.size,v.size){
		for(int i=0;i<v.size;i++) this[i,i] = v[i];
	} //makes a square matrix from a vector
	
	public void set(int a, int b, double value){this[a,b]=value;}
	public static void set(matrix a, int i, int j, double value){ a[i,j]=value;}
	public double get(int i, int j){ return this[i,j];}
	public static double get(matrix a, int i, int j){return a[i,j];}

	//ways of take cuts of the matrix either cut off some columns or rows
	public matrix rows(int a, int b){
		matrix r = new matrix(b-a+1, colsize);
		for(int i=0;i<r.rowsize;i++){
			for(int j=0;j<r.colsize;j++) r[i,j]=this[i+a,j];
		}
		return r;
	}
	public matrix cols(int a, int b){
		matrix r = new matrix(rowsize, b-a+1);
		for(int i =0;i<rowsize;i++){
			for(int j=0;j<colsize;j++) r[i,j]=this[i, j+a];
		}
		return r;
	}

	public static matrix id(int n){
		matrix r = new matrix(n,n);
		for(int i=0;i<n;i++) r[i,i]=1;
		return r;
	}

	public void set_unity(){
		for(int i=0;i<rowsize;i++){
			this[i,i]=1;
			for(int j=i+1;j<colsize;j++){
				this[i,j]=0;
				this[j,i]=0;
			}
		}
	}
	public void set_identity(){this.set_unity();}//putting set_identity and set_unity equal
	public void setid(){this.set_unity();} //also setting setid to the same

	public void set_zero(){
		for(int i=0;i<colsize;i++){
			for(int j=0;j<rowsize;j++) this[i,j]=0;
		}
	}

	public static matrix outerproduct(vector v, vector w){
		matrix r = new matrix(v.size, w.size);
		for(int i =0;i<r.rowsize;i++)
		for(int j=0;j<r.colsize;j++)
		{
			r[i,j]=v[i]*w[j];
		}
		return r;
	}

	public void update(vector v, vector w, double s=1){
		for(int i=0;i<rowsize;i++)
		for(int j=0;j<colsize;j++)
		{
			this[i,j]+=v[i]*w[j]*s;
		}
	}
	public matrix copy(){
		matrix r = new matrix(rowsize,colsize);
		for(int i=0;i<colsize;i++)
		for(int j=0;j<rowsize;j++)
		{
			r[j,i]=this[j,i];
		}
		return r;
	}

	public matrix transpose(){
		matrix r= new matrix(colsize,rowsize);
		for(int i=0;i<colsize;i++)
		for(int j=0;j<rowsize;j++)
		{
			r[i,j] = this[j,i];
		}
		return r;
	}

	public matrix T{
		get{return this.transpose();}
		set{}
	}


	public matrix submatrix(int rowa, int rowb, int cola, int colb){
		matrix r = new matrix(rowb-rowa+1,colb-cola+1);
		for(int i=rowa;i<rowb;i++)
		for(int j=cola;j<colb;j++)
		{
			r[i-rowa, j-cola]=this[i,j];
		}
		return r;
	}

	public static void scale(matrix a, double k){
		for(int i=0;i<a.colsize;i++)
		for(int j=0;j<a.rowsize;i++)
		{
			a[j,i]*=k;
		}
	}

	public void print(string s="",string format="{0,10:g3} "){
	System.Console.WriteLine(s);
	for(int irow=0;irow<this.rowsize;irow++){
	for(int icol=0;icol<this.colsize;icol++)
		System.Console.Write(format,this[irow,icol]);
		System.Console.WriteLine();
		}
	}
	
	public static bool approx(double a, double b, double acc=1e-6, double eps=1e-6){
	if(Abs(a-b)<acc)return true;
	if(Abs(a-b)/Max(Abs(a),Abs(b)) < eps)return true;
	return false;
	}

	public bool approx(matrix a,double acc=1e-6, double eps=1e-6){
	if(this.rowsize!=a.rowsize)return false;
	if(this.colsize!=a.colsize)return false;
	for(int i=0;i<rowsize;i++)
		for(int j=0;j<colsize;j++)
			if(!approx(this[i,j],a[i,j],acc,eps))
				return false;
	return true;
	}	


}
