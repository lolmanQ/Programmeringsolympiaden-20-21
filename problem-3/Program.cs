using System;

namespace problem_3
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
		int moneyNeeded;
		public void Run()
		{
			moneyNeeded = int.Parse(Console.ReadLine());

			int remainingMoneyNeeded = moneyNeeded;
			int removeMoneyAmount;
			int sedlAmount = 0;
			while (remainingMoneyNeeded != 0)
			{
				removeMoneyAmount = 0;
				int removePower = -1;
				while (remainingMoneyNeeded >= removeMoneyAmount)
				{
					removePower++;
					removeMoneyAmount += (int)Math.Pow(10, removePower);
				}
				removeMoneyAmount -= (int)Math.Pow(10, removePower);
				remainingMoneyNeeded -= removeMoneyAmount;
				if(removeMoneyAmount > 0)
				{
					sedlAmount++;
				}
				
			}
			Console.WriteLine(sedlAmount);
		}
	}
}
