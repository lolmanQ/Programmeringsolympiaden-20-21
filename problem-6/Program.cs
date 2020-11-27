using System;
using System.Collections.Generic;

namespace problem_6
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
		bool[,] lockMatrix; //true är tom slot
		bool[,] testMatrix;
		int rows;
		int colums;
		int combinations = 1;
		int topRow = 0;

		public void Run()
		{
			Input();
			LoopV3();
			Console.WriteLine(combinations);
		}

		void Loop()
		{
			bool failed;
			
			while (topRow < rows)
			{
				failed = false;
				for (int r = 0; r < rows; r++)
				{
					ShowGrid();
					if (!testMatrix[r, 0])
					{
						MoveRow(r);
						if(r == 0)
						{
							failed = true;
						}
						r--;
					}
					else if(r == rows - 1)
					{
						combinations++;
					}
				}
				if (!failed)
				{
					MoveRow(0);
				}
				
			}
			
		}

		void LoopV2()
		{
			List<int> options = new List<int>();

			for (int r = rows - 1; r >= 1; r--)
			{
				int columAmount = 0;
				for (int c = 0; c < colums; c++)
				{
					if(lockMatrix[r, c])
					{
						columAmount++;
					}
				}
				options.Add(columAmount);
			}

			int totalVari = 1;
			foreach (int item in options)
			{
				totalVari *= item;
			}
			totalVari *= colums;
			Console.WriteLine(totalVari);
		}

		void LoopV3()
		{
			for (int layer = rows - 2; layer >= 0; layer--)
			{
				int layerPosib = LayerPosibilitys(layer);
				combinations *= layerPosib;
			}
			combinations *= colums;
		}

		void ShowGrid()
		{
			Console.WriteLine("--------");

			for (int r = 0; r < rows; r++)
			{
				string line = "";
				for (int c = 0; c < colums; c++)
				{
					if (testMatrix[r, c])
					{
						line += ".";
					}
					else
					{
						line += "#";
					}
				}
				Console.WriteLine(line);
			}
			Console.WriteLine("----");
			Console.WriteLine();
		}

		void MoveRow(int row)
		{
			if (row == 0)
			{
				topRow++;
			}
			bool storage = testMatrix[row, 0];
			for (int i = 1; i < colums; i++)
			{
				testMatrix[row, i - 1] = testMatrix[row, i];
			}
			testMatrix[row, colums-1] = storage;
		}

		int LayerPosibilitys(int layer)
		{
			int layerPosi = 0;
			List<string> usedPoses = new List<string>();
			for (int c = 0; c < colums; c++)
			{
				if(testMatrix[layer, c])
				{
					for (int c2 = 0; c2 < colums; c2++)
					{
						if (testMatrix[layer + 1, c] && !usedPoses.Contains(layer + 1 + " " + c2))
						{
							layerPosi++;
							usedPoses.Add(layer + 1 + " " + c2);
						}
						MoveRow(layer + 1);
					}
				}
			}
			return layerPosi;
		}

		void Input()
		{
			rows = int.Parse(Console.ReadLine());
			colums = int.Parse(Console.ReadLine());

			lockMatrix = new bool[rows, colums];

			for (int r = 0; r < rows; r++)
			{
				string rowString = Console.ReadLine();
				for (int c = 0; c < colums; c++)
				{
					switch (rowString[c])
					{
						case '.':
							lockMatrix[r, c] = true;
							break;
						case '#':
							lockMatrix[r, c] = false;
							break;
					}
				}
			}
			testMatrix = lockMatrix;
		}
	}
}
