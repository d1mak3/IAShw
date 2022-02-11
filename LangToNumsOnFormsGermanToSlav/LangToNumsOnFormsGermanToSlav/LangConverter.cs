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

		public void SetOldNumber()
		{
			int number = ArabicNum;
			string OldNumber = "";
			while (number > 0)
			{
				if (number >= 500)
				{
					OldNumber += "Ф";
					number -= 500;
					continue;
				}
				if (number >= 100)
				{
					OldNumber += "Р";
					number -= 100;
					continue;
				}
				if (number >= 30)
				{
					OldNumber += "Л";
					number -= 30;
					continue;
				}
				if (number >= 8)
				{
					OldNumber += "И";
					number -= 8;
					continue;
				}
				if (number >= 2)
				{
					OldNumber += "В";
					number -= 2;
					continue;
				}
				if (number >= 1)
				{
					OldNumber += "А";
					number -= 1;
					continue;
				}
			}
			return OldNumber;
		}
	}
}
