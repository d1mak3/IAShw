using System;

namespace LangToNums
{
	class Program
	{
		static void Main(string[] args)
		{
			LangConverter converter;
			InputChecker checker;

			string input = String.Empty;
			while (input != "stop")
			{
				Console.WriteLine("Введите число от 1 до 999");
				input = Console.ReadLine();
				checker = new InputChecker(input);
				if (checker.CheckInputForMistakes())
				{
					converter = new LangConverter(input);
					Console.WriteLine($"Число в арабском представлении {converter.ConvertToArabic()}");
					Console.WriteLine($"Число в римском представлении {converter.ConvertToRoman()}");
				}
			}
		}
	}
}
