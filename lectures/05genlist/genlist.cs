public class genlist<T>{

	public T[] data;//initialiser en tom liste til data
	//public T this [int i] => data[i];//a "getter" betyder bare at man kan hente index i værdien
	public T this[int i] {get{return data[i];}set{data[i]=value;} }//kan "sette" en værdi i listen
						
	public int size => data.Length; // whenever size is reffered return data.Length

	public genlist(){data = new T[0];}
	//definerer en tom liste
	public void add (T item){
		T[] newdata = new T[data.Length+1];
			for(int i=0;i<data.Length;i++)newdata[i]=data[i];
	// Her laver vi en ny indgang i data som vi kalder newdata - det er at tilføje et item til data af type T
	// forloopet tager alle indgangene der måtte være i newdata og sender det ind i T 
			newdata[data.Length]=item;
			data=newdata;// skal garbage collectes i c++ men gjort automatisk i c#
	// 
	//
	// dvs koden alt i alt initialiserer en liste af type T indgange som kaldes for data. Dernæst putter vi alle indgange
	// fra newdata ind i data af type T
	}

}
