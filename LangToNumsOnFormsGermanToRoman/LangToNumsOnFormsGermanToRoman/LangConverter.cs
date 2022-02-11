using System;
using System.Collections.Generic;
using System.Text;

namespace LangToNumsOnForms
{
	class LangConverter
	{
		static Dictionary<string, int> LangNums;
		string input;
		string[] wordsFromInput;
		int ArabicNum = 0;

		public LangConverter(string Input)
		{
			input = Input;
			input = input.ToLower();

			wordsFromInput = input.Split(' ');

			if (LangNums == null)
			{
				LangNums = new Dictionary<string, int>();

				LangNums.Add("eins", 1);
				LangNums.Add("ein", 1);
				LangNums.Add("zwei", 2);
				LangNums.Add("drei", 3);
				LangNums.Add("vier", 4);
				LangNums.Add("funf", 5);
				LangNums.Add("sechs", 6);
				LangNums.Add("sieben", 7);
				LangNums.Add("acht", 8);
				LangNums.Add("neun", 9);
				LangNums.Add("zehn", 10);
				LangNums.Add("elf", 11);
				LangNums.Add("zwolf", 12);
				LangNums.Add("dreizehn", 13);
				LangNums.Add("vierzehn", 14);
				LangNums.Add("funfzehn", 15);
				LangNums.Add("sechzehn", 16);
				LangNums.Add("siebzehn", 17);
				LangNums.Add("achtzehn", 18);
				LangNums.Add("neunzehn", 19);
				LangNums.Add("zwanzig", 20);
				LangNums.Add("dreibig", 30);
				LangNums.Add("vierzig", 40);
				LangNums.Add("funfzig", 50);
				LangNums.Add("sechzig", 60);
				LangNums.Add("siebzig", 70);
				LangNums.Add("achtzig", 80);
				LangNums.Add("neunzig", 90);
			}
		}

		public Dictionary<string, int> GetLangNums() { return LangNums; }

		public int ConvertToArabic()
		{
			ArabicNum = 0;
			string keyOfNumToAdd = wordsFromInput[0];

			if (wordsFromInput.Length > 1)
			{
				if (wordsFromInput[1] == "hundert")
				{
					ArabicNum += LangNums[keyOfNumToAdd] * 100;

					if (wordsFromInput.Length == 2)
						return ArabicNum;

					else if (wordsFromInput.Length == 3)
					{
						keyOfNumToAdd = wordsFromInput[2];
						ArabicNum += LangNums[keyOfNumToAdd];
						return ArabicNum;
					}

					else if (wordsFromInput.Length == 5)
					{
						keyOfNumToAdd = wordsFromInput[4];
						ArabicNum += LangNums[keyOfNumToAdd];
						keyOfNumToAdd = wordsFromInput[2];
						ArabicNum += LangNums[keyOfNumToAdd];
						return ArabicNum;
					}
				}
			}

			if (wordsFromInput.Length == 3)
			{
				keyOfNumToAdd = wordsFromInput[2];
				ArabicNum += LangNums[keyOfNumToAdd];
				keyOfNumToAdd = wordsFromInput[0];
				ArabicNum += LangNums[keyOfNumToAdd];
				return ArabicNum;
			}
			
			ArabicNum += LangNums[keyOfNumToAdd];
			return ArabicNum;
		}

		public string ConvertToRoman()
		{
			string roman = String.Empty;
			if (ArabicNum / 100 == 9)
			{
				roman += "CM";
				ArabicNum -= 900;
			}
			if (ArabicNum >= 500)
			{
				roman += "D";
				ArabicNum -= 500;
			}
			if (ArabicNum / 100 == 4)
			{
				roman += "CD";
				ArabicNum -= 400;
			}
			while (ArabicNum / 100 >= 1)
			{
				roman += "C";
				ArabicNum -= 100;
			}
			if (ArabicNum / 10 == 9)
			{
				roman += "XC";
				ArabicNum -= 90;
			}
			while (ArabicNum / 10 >= 5)
			{
				roman += "L";
				ArabicNum -= 50;
			}
			if (ArabicNum / 10 == 4)
			{
				roman += "XL";
				ArabicNum -= 40;
			}
			while (ArabicNum / 10 >= 1)
			{
				roman += "X";
				ArabicNum -= 10;
			}
			if (ArabicNum == 9)
			{
				roman += "IX";
				ArabicNum -= 9;
			}
			while (ArabicNum >= 5)
			{
				roman += "V";
				ArabicNum -= 5;
			}
			if (ArabicNum == 4)
			{
				roman += "IV";
				ArabicNum -= 4;
			}
			while (ArabicNum >= 1)
			{
				roman += "I";
				ArabicNum -= 1;
			}
			return roman;
		}
	}
}
