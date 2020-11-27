using System;

namespace problem_2
{
	class Program
	{
		static void Main()
		{
			string unformatNumber = Console.ReadLine();
			string subYearString = unformatNumber[0] + "";
			subYearString += unformatNumber[1];

			int subYear = int.Parse(subYearString);

			string finalFormat = unformatNumber.Remove(6, 1);

			if(unformatNumber[6] == '-')
			{
				if (subYear > 20)
				{
					finalFormat = "19" + finalFormat;
				}
				else
				{
					finalFormat = "20" + finalFormat;
				}
			}
			else if(unformatNumber[6] == '+')
			{
				if (subYear > 20)
				{
					finalFormat = "18" + finalFormat;
				}
				else
				{
					finalFormat = "19" + finalFormat;
				}
			}

			Console.WriteLine(finalFormat);
		}
	}
}
