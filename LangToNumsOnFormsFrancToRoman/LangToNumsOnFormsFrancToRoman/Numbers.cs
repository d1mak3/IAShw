using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first
{
    class Numbers
    {
        static public Dictionary<string, int> SingleDigits;
        static public Dictionary<string, int> TensDigits;
        static public Dictionary<string, int> DoubleDigits;

        static public int Number;
        static public string OldNumber;

        static public void SetDictionary()
        {
            SingleDigits = new Dictionary<string, int>();
            SingleDigits.Add("un", 1);
            SingleDigits.Add("deux", 2);
            SingleDigits.Add("trois", 3);
            SingleDigits.Add("quatre", 4);
            SingleDigits.Add("cinq", 5);
            SingleDigits.Add("six", 6);
            SingleDigits.Add("sept", 7);
            SingleDigits.Add("huit", 8);
            SingleDigits.Add("neuf", 9);

            TensDigits = new Dictionary<string, int>();
            TensDigits.Add("onze", 11);
            TensDigits.Add("douze", 12);
            TensDigits.Add("treize", 13);
            TensDigits.Add("quatorze", 14);
            TensDigits.Add("quinze", 15);
            TensDigits.Add("seize", 16);

            DoubleDigits = new Dictionary<string, int>();
            DoubleDigits.Add("dix", 10);
            DoubleDigits.Add("vingt", 20);
            DoubleDigits.Add("trente", 30);
            DoubleDigits.Add("quarante", 40);
            DoubleDigits.Add("cinquante", 50);
            DoubleDigits.Add("soixante", 60);
        }
        static private void SetNull()
        {
            Number = 0;
            OldNumber = "";
        }
        static public string GetNumber(string text)
        {
            SetNull();

            bool cent = false; // проверка на конец
            bool un = false; // для cent и cents, его там нельзя
            bool soixante = false; // делаем после проверку на 10
            bool dix = false; // для 17-19
            bool quatre = false; // для quatre_vingt и quatre_vingts
            bool quatre_vingt = false; // 80, 90
            bool quatre_vingts = false; // конечное

            bool et = false; // перед 1 и 11 кроме 1-19, 80, 90
            bool cents = false; // конечное

            bool _single = false;
            bool _tens = false;
            bool _double = false;
            bool _triple = false;

            string[] numberNames = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var numberName in numberNames)
            {
                if (numberName == "et")
                {
                    if (dix == true)
                        return "Слово et не употребляется после слова dix";
                    if (quatre_vingt == true)
                        return "Слово et не употребляется при наличии слова quatre vingt";
                    if (quatre_vingts == true)
                        return "После слова quatre vingts не может быть слов";
                    if (et == true)
                        return "Второй раз слово et";
                    if (cents == true)
                        return "После слова cents не может быть слов";
                    if (_single == true || _double == false)
                        return "Слово et употребляется только после десятков перед un или onze";

                    et = true;
                    cent = false;
                }
                else if (numberName == "vingts")
                {
                    if (quatre == false)
                        return "Слово vingts употребляется только после слова quatre";
                    if (quatre_vingts == true)
                        return "Второй раз слово vingts";
                    if (et == true)
                        return "После слова et ожидались слова un или onze";
                    if (cents == true)
                        return "После слова cents не может быть слов";
                    if (_double == true)
                        return "Cлово vingts не может быть после разряда десятков";
                    if (_tens == true)
                        return "Cлово vingts не может быть после разряда 11-16";

                    Number -= 4;
                    Number += 80;
                    quatre_vingts = true;
                    quatre = false;
                    cent = false;
                }
                else if (numberName == "cents")
                {
                    if (un == true)
                        return "Перед словом cents - un не употребляется";
                    if (_single == false)
                        return "Слово cents ожидалось после слов единичного разряда";
                    if (_tens == true)
                        return "Слово cents ожидалось до разряда 11-16";
                    if (_double == true)
                        return "Слово cents ожидалось до разряда десятков";
                    if (_triple == true)
                        return "Уже есть разряд сотен";
                    if (cents == true)
                        return "Второй раз слово cents";

                    cents = true;
                    _single = false;
                    Number *= 100;
                    cent = false;
                }
                else if (SingleDigits.ContainsKey(numberName))
                {
                    if (numberName == "un")
                        un = true;
                    if (dix == true)
                        if (numberName != "sept" && numberName != "huit" && numberName != "neuf")
                            return "После слова dix ожидалось слово sept, huit или neuf";
                    if (numberName == "quatre")
                        quatre = true;
                    if (quatre_vingt == true)
                        quatre = false;
                    if (quatre_vingts == true)
                        return "После слова quatre vingts не может быть слов";
                    if (et == true)
                        if (numberName != "un")
                            return "После слова et ожидалось слово un";
                    if (numberName == "un" && et == false && _double == true && (dix == false || quatre_vingt == false))
                        return "Ожидалось слово et перед un";
                    if (cents == true)
                        return "После слова cents не должно быть слов";
                    if (_single == true)
                        return "Второй раз единичный разряд";
                    if (_tens == true)
                        return "Разряд единиц не употребляется с 11-16";

                    et = false;
                    _single = true;
                    cent = false;
                    Number += SingleDigits[numberName];
                }
                else if (TensDigits.ContainsKey(numberName))
                {
                    if (numberName == "onze" && et == false && _double == true && (dix == false || quatre_vingt == false))
                        return "Ожидалось слово et перед onze";
                    if (quatre_vingts == true)
                        return "После слова vingts не должно быть слов";
                    if (et == true)
                        if (numberName != "onze")
                            return "После слова et ожидалось слово onze";
                    if (cents == true)
                        return "После слова cents не должно быть слов";
                    if (_single == true)
                        return "Разряд 11-16 не употребляется с единицами";
                    if (_tens == true)
                        return "Второй раз разряд 11-16";
                    if (_double == true)
                        if (soixante == false && quatre_vingt == false)
                            return "Разряд 11-16 не может употребляться с десятками кроме soixante или quatre";

                    et = false;
                    _tens = true;
                    cent = false;
                    Number += TensDigits[numberName];
                }
                else if (DoubleDigits.ContainsKey(numberName))
                {
                    if (numberName == "soixante")
                        soixante = true;
                    if (dix == true)
                        return "Второй раз слово dix";
                    if (numberName == "dix")
                        dix = true;
                    if (quatre == true && numberName == "vingt")
                    {
                        Number -= 4;
                        Number += 60;
                        _single = false;
                        quatre_vingt = true;
                        quatre = false;
                    }
                    if (quatre_vingts == true)
                        return "После слова vingts не должно быть слов";
                    if (et == true)
                        return "После слова et ожидалось слово un или onze";
                    if (cents == true)
                        return "После слова cents не должно быть слов";
                    if (_single == true)
                        return "Разряд десятков не употребляется после единиц";
                    if (_tens == true)
                        return "Разряд десятков не употребляется с 11-16";
                    if (_double == true && numberName != "dix")
                        return "Второй раз десятичный разряд";

                    _double = true;
                    cent = false;
                    Number += DoubleDigits[numberName];
                }
                else if (numberName == "cent")
                {
                    if (un == true)
                        return "Перед словом cent - un не употребляется";
                    if (quatre_vingts == true)
                        return "После слова vingts не должно быть слов";
                    if (et == true)
                        return "После слова et ожидалось слово un или onze";
                    if (cents == true)
                        return "После слова cents не должно быть слов";
                    if (_single == false)
                        Number = 1;
                    if (_tens == true)
                        return "Разряд сотен не употребляется после разряда 11-16";
                    if (_double == true)
                        return "Разряд сотен не употребляется после десятичного разряда";
                    if (_triple == true)
                        return "Второй раз разряд сотен";

                    _triple = true;
                    _single = false;
                    quatre = false;
                    cent = true;
                    Number *= 100;
                }
                else
                    return "Неизвестное число \"" + numberName + "\"";
            }
            if (quatre_vingt == true)
                return "После слова vingt ожидался единичный разряд";
            if (et == true)
                return "После слова et ожидались слова un или onze";
            if (cent == true)
                return "После cent ожидались другие разряды";
            SetRoman();
            return "";
        }

        static private void SetRoman()
        {
            int ArabicNum = Number;           
            if (ArabicNum / 100 == 9)
            {
                OldNumber += "CM";
                ArabicNum -= 900;
            }
            if (ArabicNum >= 500)
            {
                OldNumber += "D";
                ArabicNum -= 500;
            }
            if (ArabicNum / 100 == 4)
            {
                OldNumber += "CD";
                ArabicNum -= 400;
            }
            while (ArabicNum / 100 >= 1)
            {
                OldNumber += "C";
                ArabicNum -= 100;
            }
            if (ArabicNum / 10 == 9)
            {
                OldNumber += "XC";
                ArabicNum -= 90;
            }
            while (ArabicNum / 10 >= 5)
            {
                OldNumber += "L";
                ArabicNum -= 50;
            }
            if (ArabicNum / 10 == 4)
            {
                OldNumber += "XL";
                ArabicNum -= 40;
            }
            while (ArabicNum / 10 >= 1)
            {
                OldNumber += "X";
                ArabicNum -= 10;
            }
            if (ArabicNum == 9)
            {
                OldNumber += "IX";
                ArabicNum -= 9;
            }
            while (ArabicNum >= 5)
            {
                OldNumber += "V";
                ArabicNum -= 5;
            }
            if (ArabicNum == 4)
            {
                OldNumber += "IV";
                ArabicNum -= 4;
            }
            while (ArabicNum >= 1)
            {
                OldNumber += "I";
                ArabicNum -= 1;
            }            
        }   
    }
}
