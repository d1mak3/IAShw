using System;
using System.Collections.Generic;
using System.Text;

namespace LangToNumsOnForms
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

		public string CheckInputForMistakes()
		{
			if (!CheckInputLength(5))
			{
				return "Слишком большая строка";
			}

			if (input == String.Empty)
			{
				return "Строка пуста";
				
			}							
						
			if (wordsFromInput.Length == 5) // Example: vier hundert zwei und zwanzig 
			{
				if (wordsFromInput[1] != "hundert")
				{
					return "Неправильный формат ввода";
				}

				if (!CheckUnits(0) && wordsFromInput[0] != "ein")
				{
					return $"Неправильные сотни {wordsFromInput[0]}";
				}

				if (CheckTens(3) != "Ok")								
					return CheckTens(3);

				return "Ok";
			}
			
			else if (wordsFromInput.Length == 2 && wordsFromInput[1] == "hundert") // Example: vier hundert
			{
				if (!CheckUnits(0) && wordsFromInput[0] != "ein")
				{
					return $"Неправильные сотни {wordsFromInput[0]}";					
				}

				return "Ok";
			}

			else if (wordsFromInput.Length == 3 && wordsFromInput[1] == "hundert") // Example: vier hundert elf || vier hundert eins
			{
				if (wordsFromInput[1] != "hundert")
				{
					return "Неправильный формат ввода";
				}

				if (!CheckUnits(2) && !CheckElevenToNineteen(2))
				{
					return $"Неправильное число {wordsFromInput[2]}";					
				}

				return "Ok";
			}
			
			else if (wordsFromInput.Length == 3 && wordsFromInput[1] == "und")
			{
				return CheckTens(1);		
			}
			
			else if (wordsFromInput.Length == 1)
			{
				if (!elevenToNineteen.Contains(wordsFromInput[0]) && !units.Contains(wordsFromInput[0]) && !tens.Contains(wordsFromInput[0]))
				{
					return $"Неправильное число {wordsFromInput[0]}";					
				}
				else
					return "Ok";
			}			

			return "Неправильный формат ввода";			
		}

		bool CheckUnits(int pos) // pos - position of numeral
		{
			if (!(units.Contains(wordsFromInput[pos])))
				return false;

			return true;
		}

		string CheckTens(int pos) // pos - position of "und" in input
		{			
			if (!CheckUnits(pos - 1) && wordsFromInput[pos - 1] != "ein")
			{
				return $"Неправильные единицы {wordsFromInput[pos - 1]}";				
			}

			if (!tens.Contains(wordsFromInput[pos + 1]))
			{
				return $"Неправильные десятки {wordsFromInput[pos + 1]}";
				
			}

			return "Ok";
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
