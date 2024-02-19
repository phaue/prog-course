using static System.Console;
using System;
using static System.Math;

public class main{
	public static void Main(string[] args){
		WriteLine("Task 1: \n");
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-numbers"){
				var numbers=words[1].Split(',');
				foreach(var number in numbers){
					double x=double.Parse(number);
					WriteLine($"{x} {Sin(x)} {Cos(x)}");
				}
			}
		}

	}
}
