using System;

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
		int combinations = 0;
		int topRow = 0;

		public void Run()
		{
			Input();
			Loop();
			Console.WriteLine(combinations);
		}

		void Loop()
		{
			bool failed;
			
			while (topRow < rows)
			{
				for (int r = 0; r < rows; r++)
				{
					if (!testMatrix[r, 0])
					{
						MoveRow(r);
						r--;
					}
					else if(r == rows - 1)
					{
						combinations++;
					}
				}
				
			}
			
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
