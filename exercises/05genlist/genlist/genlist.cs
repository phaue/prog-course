using System;
public class genlist<T>{
	public T[] data;
	public int size => data.Length;
	public T this[int i] => data[i];
	public genlist(){ data = new T[0]; }
	public void add(T item){
		T[] newdata = new T[size+1];
		System.Array.Copy(data,newdata,size);
		newdata[size]=item;
		data=newdata;
	}

	public void remove(int i){
		T[] newdata = new T[size-1];
		System.Array.Copy(data,0, newdata,0,i);//kopierer data til newdata indtil index i er nået
		System.Array.Copy(data, i+1, newdata, i, size-i-1); 
		//starter med at kopiere fra index i+1 i data over til index "i" i newdata og mængden der skal kopieres har længden size-i-1
		data = newdata;

	}
	

}

