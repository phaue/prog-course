using static System.Console;
using System;

class main{
	static int Main(){
		
		var list = new genlist<double[]>();
		char[] delimiters = {' ', '\t'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = ReadLine(); line!=null; line=ReadLine()){
			var words = line.Split(delimiters,options);
			int n = words.Length;
			var numbers = new double[n];
			for(int i=0;i<n;i++) numbers[i] = double.Parse(words[i]);
			list.add(numbers);
		}
		WriteLine("The numbers put into the list: \n");

		for(int i=0; i<list.size;i++){
			var numbers = list[i];
			foreach(var number in numbers)Write($"{number : 0.00e+00; -0.00e+00} ");
			WriteLine();
		}
		WriteLine("The same list where {42.0, 66, 369. 323232} has been added and index 7 have been removed : \n");
		
		double[] adds = new double[]{42.0, 66, 369, 323232};

		list.add(adds);
		list.remove(2);
		//list.remove(3);
		
		for(int i=0; i<list.size;i++){
                        var numbers = list[i];
                        foreach(var number in numbers)Write($"{number : 0.00e+00; -0.00e+00} ");
                        WriteLine();
		}
		

		return 0;
	}
}

