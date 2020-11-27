using System;
using System.Collections.Generic;

namespace problem_5
{
	class Program
	{
		static void Main()
		{
			App app = new App();
			app.Run();
		}
	}

	class App
	{
		static int[] pT = new int[] {6,2,5,5,4,5,6,3,7,6};

		int posibilitys = 0;
		int totalPower;
		int totalCurrentPower;
		List<int> powerDrawList = new List<int>();

		public void Run()
		{
			Input();
			Loop();
			Console.WriteLine(posibilitys);
		}

		void Loop()
		{

			for (int h1 = 0; h1 <= 2; h1++)//first digit hour
			{
				for (int h2 = 0; h2 <= 9; h2++)
				{
					if(h1 == 2 && h2 == 4)
					{
						break;
					}
					for (int m1 = 0; m1 <= 5; m1++)
					{
						for (int m2 = 0; m2 <= 9; m2++)
						{
							for (int s1 = 0; s1 <= 5; s1++)
							{
								for (int s2 = 0; s2 <= 9; s2++)
								{
									int currentPower = pT[h1] + pT[h2] + pT[m1] + pT[m2] + pT[s1] + pT[s2];
									CheckTime(currentPower);
								}
							}
						}
					}
				}
			}

		}

		void Input()
		{
			totalPower = int.Parse(Console.ReadLine());
		}

		void CheckTime(int curTimePower)
		{
			if(curTimePower < totalPower)
			{
				powerDrawList.Add(curTimePower);
				totalCurrentPower += curTimePower;

				while (totalCurrentPower > totalPower)
				{
					totalCurrentPower -= powerDrawList[0];
					powerDrawList.RemoveAt(0);
				}
				if(totalCurrentPower == totalPower)
				{
					posibilitys++;
				}
			}
			else if(curTimePower == totalPower)
			{
				posibilitys++;
			}
		}
	}
}
