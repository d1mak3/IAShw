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
			wordsFromInput = input.Split(' ');
		}	

		int SearchIndexInWords( string word)
		{
			for (int i = 0; i < wordsFromInput.Length; ++i)
				if (wordsFromInput[i] == word)
					return i;

			return -1;
		}

		public string CheckInputForMistakes()
		{
			if (input == String.Empty)
				return "Строка пуста";

			for (int i = 0; i < wordsFromInput.Length; ++i)
				if (!units.Contains(wordsFromInput[i]) && wordsFromInput[i] != "ein" && !tens.Contains(wordsFromInput[i])
					&& !elevenToNineteen.Contains(wordsFromInput[i]) && wordsFromInput[i] != "hundert" && wordsFromInput[i] != "und")
					return $"Неправильное слово: {wordsFromInput[i]}";

			if (wordsFromInput[0] == "hundert" || wordsFromInput[0] == "und")
				return $"Перед {wordsFromInput[0]} должно стоять число единичного разряда";

			for (int i = 0; i < wordsFromInput.Length - 1; ++i)
			{
				if ((wordsFromInput[i] == "hundert" || wordsFromInput[i] == "und") && wordsFromInput[i] == wordsFromInput[i + 1])
					return $"Повторение слова: {wordsFromInput[i]}";

				if (tens.Contains(wordsFromInput[i]) && (wordsFromInput[i + 1] == "und" || wordsFromInput[i + 1] == "hundert"))
					return $"После числа десятичного формата не должно стоять {wordsFromInput[i + 1]}";

				if ((units.Contains(wordsFromInput[i]) || wordsFromInput[i] == "ein") && (units.Contains(wordsFromInput[i + 1]) || wordsFromInput[i + 1] == "ein") && SearchIndexInWords("hundert") == -1)
					return $"Между двумя числами единичного разряда: {wordsFromInput[i]} и {wordsFromInput[i + 1]} ожидалось hundert";

				if (units.Contains(wordsFromInput[i]) && elevenToNineteen.Contains(wordsFromInput[i + 1]))
					return $"Между единичным разрядом: {wordsFromInput[i]} и разрядом от 11 до 19: {wordsFromInput[i + 1]} ожидалось hundert";

				if ((units.Contains(wordsFromInput[i]) || wordsFromInput[i] == "ein") && tens.Contains(wordsFromInput[i + 1]))
					return $"Между единичным разрядом: {wordsFromInput[i]} и десятичным разрядом: {wordsFromInput[i + 1]} ожидалось und";

				if (wordsFromInput[i] == "und" && !tens.Contains(wordsFromInput[i + 1]))
					return "После und должно стоять число десятичного разряда";

				if (wordsFromInput[i + 1] == "und" && !units.Contains(wordsFromInput[i]) && wordsFromInput[i] != "ein")
					return "Перед und должно стоять число единичного разряда";				

				if (wordsFromInput[i + 1] == "hundert" && !units.Contains(wordsFromInput[i]) && wordsFromInput[i] != "ein")
					return "Перед hundert должно стоять число единичного разряда";

				if (wordsFromInput[i] == "hundert" && !units.Contains(wordsFromInput[i + 1]) && !elevenToNineteen.Contains(wordsFromInput[i + 1]) && wordsFromInput[i + 1] != "ein")
					return "После hundert должно стоять число единичного разряда или число разряда от 11 до 19";

				if ((units.Contains(wordsFromInput[i]) || wordsFromInput[i] == "ein") && wordsFromInput[i] == wordsFromInput[i + 1])
					return $"Повторение единиц: {wordsFromInput[i]} {wordsFromInput[i + 1]}";				

				if (elevenToNineteen.Contains(wordsFromInput[i]) && wordsFromInput[i] == wordsFromInput[i + 1])
					return $"Повторение разряда от 11 до 19: {wordsFromInput[i]} {wordsFromInput[i + 1]}";

				if (tens.Contains(wordsFromInput[i]) && wordsFromInput[i] == wordsFromInput[i + 1])
					return $"Повторение десятков: {wordsFromInput[i]} {wordsFromInput[i + 1]}";						
			}

			return "Ok";
		}
	}
}
