namespace ProgToTranslate
{
	class Program
	{
		static void Main(string[] args)
		{
			Menu.LoadDataFromFile();
			Menu.Execute();
			Menu.SaveDataInFile();
		}
	}
}
