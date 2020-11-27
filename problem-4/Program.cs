using System;
using System.Collections.Generic;

namespace problem_4
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
		long islandAmount;
		long rowDuri;
		long witchDist;
		List<long> islandDists = new List<long>();
		long requierdRows = 0;
		public void Run()
		{
			Input();
			for (int i = islandDists.Count - 1; i >= 0; i--)
			{
				requierdRows = RowsNeededFor(islandDists[i], requierdRows);
			}
			Console.WriteLine(requierdRows);
		}

		void Input()
		{
			islandAmount = long.Parse(Console.ReadLine());
			rowDuri = long.Parse(Console.ReadLine());
			witchDist = long.Parse(Console.ReadLine());
			for (int i = 0; i < islandAmount - 1; i++)
			{
				islandDists.Add(long.Parse(Console.ReadLine()) * witchDist);
			}
		}

		long RowsNeededFor(long dist, long restPadels)
		{
			long maxDistCur = restPadels * (rowDuri - 1);
			if(maxDistCur >= dist)
			{
				return restPadels;
			}
			long remainingDist = dist - maxDistCur;
			long additinalPadsNeeded = (long)Math.Ceiling(remainingDist / (decimal)rowDuri);
			return restPadels + additinalPadsNeeded;
		}
	}
}
