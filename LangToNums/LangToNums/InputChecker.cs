using System;
using System.Collections.Generic;
using System.Text;

namespace LangToNums
{
	class InputChecker
	{
		static List<string> units = new List<string>
		{ "eins", "zwei", "drei", "vier", "funf", "sechs", "sieben", "acht", "neun", "zehn" };

		static List<string> elevenToNineteen = new List<string> 
		{ "elf", "zwolf", "dreizehn", "vierzehn", "funfzehn", "sechzehn", "siebzehn", "achtzehn", "neunzehn" };

		static List<string> tens = new List<string> 
		{ "zwanzig", "dreibig", "vierzig", "funfzig", "sechzig", "siebzig", "achtzig", "neunzig" };

		string input;
		string[] wordsFromInput;		

		public InputChecker(string Input)
		{
			input = Input;
			input = input.ToLower();

			for (int i = 1; i < input.Length; ++i) // Cut all extra spaces
			{
				if (input[i] == ' ' && input[i - 1] == ' ')
					input.Remove(i - 1, i - 1);
			}			

			wordsFromInput = input.Split(' ');			
		}		

		public bool CheckInputForMistakes()
		{
			if (!CheckInputLength(5))
			{
				Console.WriteLine("Слишком большая строка");
				return false;
			}

			if (input == String.Empty)
			{
				Console.WriteLine("Строка пуста");
				return false;
			}							
						
			if (wordsFromInput.Length == 5) // Example: vier hundert zwei und zwanzig 
			{
				if (wordsFromInput[1] != "hundert")
				{
					Console.WriteLine("Неправильный формат ввода");
					return false;
				}

				if (!CheckUnits(0) && wordsFromInput[0] != "ein")
				{
					Console.WriteLine($"Неправильные сотни {wordsFromInput[0]}");
					return false;
				}

				if (!CheckTens(3))								
					return false;				

				return true;
			}
			
			else if (wordsFromInput.Length == 2 && wordsFromInput[1] == "hundert") // Example: vier hundert
			{
				if (!CheckUnits(0) && wordsFromInput[0] != "ein")
				{
					Console.WriteLine($"Неправильные сотни {wordsFromInput[0]}");
					return false;
				}

				return true;
			}

			else if (wordsFromInput.Length == 3 && wordsFromInput[1] == "hundert") // Example: vier hundert elf || vier hundert eins
			{
				if (wordsFromInput[1] != "hundert")
				{
					Console.WriteLine("Неправильный формат ввода");
					return false;
				}

				if (!CheckUnits(2) && !CheckElevenToNineteen(2))
				{
					Console.WriteLine($"Неправильное число {wordsFromInput[2]}");
					return false;
				}

				return true;
			}
			
			else if (wordsFromInput.Length == 3 && wordsFromInput[1] == "und")
			{				
				if (CheckTens(1))
					return true;
				else	
					return false;			
			}
			
			else if (wordsFromInput.Length == 1)
			{
				if (!elevenToNineteen.Contains(wordsFromInput[0]) && !units.Contains(wordsFromInput[0]) && !tens.Contains(wordsFromInput[0]))
				{
					Console.WriteLine($"Неправильное число {wordsFromInput[0]}");
					return false;
				}
				else
					return true;
			}			

			Console.WriteLine("Неправильный формат ввода");
			return false;
		}

		bool CheckUnits(int pos) // pos - position of numeral
		{
			if (!(units.Contains(wordsFromInput[pos])))
				return false;

			return true;
		}

		bool CheckTens(int pos) // pos - position of "und" in input
		{			
			if (!CheckUnits(pos - 1) && wordsFromInput[pos - 1] != "ein")
			{
				Console.WriteLine($"Неправильные единицы {wordsFromInput[pos - 1]}");
				return false;
			}

			if (!tens.Contains(wordsFromInput[pos + 1]))
			{
				Console.WriteLine($"Неправильные десятки {wordsFromInput[pos + 1]}");
				return false;
			}

			return true;
		}

		bool CheckElevenToNineteen(int pos) // pos - position of numeral
		{
			if (!(elevenToNineteen.Contains(wordsFromInput[pos])))			
				return false;			

			return true;
		}

		bool CheckInputLength(int max) // max - max elements in the input
		{
			if (wordsFromInput.Length > max)						
				return false;

			return true;
		}		
	}
}
