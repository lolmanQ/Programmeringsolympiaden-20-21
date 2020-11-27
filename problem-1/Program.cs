using System;

namespace problem_1
{
	class Program
	{
		static void Main()
		{
			int apples = int.Parse(Console.ReadLine());
			int perr = int.Parse(Console.ReadLine());
			int appleCost = apples * 7;
			int perrCost = perr * 13;
			if(appleCost > perrCost)
			{
				Console.WriteLine("Axel");
			}
			else if(appleCost < perrCost)
			{
				Console.WriteLine("Petra");
			}
			else
			{
				Console.WriteLine("Lika");
			}
		}
	}
}
