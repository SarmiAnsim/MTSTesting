﻿/// 5.	Слон из мухи.
/// Программа выводит на экран строку «Муха», а затем продолжает выполнять остальной код. 
/// Реализуйте метод TransformToElephant так, чтобы программа выводила на экран строку «Слон», 
/// а затем продолжала выполнять остальной код, не выводя перед этим на экран строку «Муха».

using System;

class Program
{
	static void Main(string[] args)
	{
		TransformToElephant();
		Console.WriteLine("Муха");			
        //... custom application code
        Console.WriteLine("и муха.");
    }

	static void TransformToElephant() 	
    {	
        Console.WriteLine("Слон");
        Console.SetOut(new MyTextWriter());
    }
    class MyTextWriter : StringWriter
    {
        TextWriter defaultTextWriter = Console.Out;
        public override void WriteLine(string? value) => Console.SetOut(defaultTextWriter);
    }
}
