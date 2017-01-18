using System;

namespace ShortCut
{
	class Program
	{
		static void Main(string[] args)
		{
			int[,] shortCuts;	// 지름길
			int D;              // 학교까지의 거리

			#region Input

			string[] input = Console.ReadLine().Split(' ');
			shortCuts = new int[int.Parse(input[0]), 3];	// 지름길의 개수만큼 할당
			D = int.Parse(input[1]);
			
			// 지름길 정보 입력
			for (int i = 0; i < shortCuts.GetLength(0); i++)
			{
				input = Console.ReadLine().Split(' ');
				shortCuts[i, 0] = int.Parse(input[0]);	// S
				shortCuts[i, 1] = int.Parse(input[1]);	// E
				shortCuts[i, 2] = int.Parse(input[2]);	// L
			}

			#endregion

			#region Processing

			int[] length = new int[D + 1];	// 실제 이동 거리
			for (int i = 1; i <= D; i++)	// 현재 이동 거리
			{
				length[i] = length[i - 1] + 1;	// 1km 이동

				// 지름길 확인
				for (int j = 0; j < shortCuts.GetLength(0); j++)
				{
					// 지름길의 도착 지점이 학교가는 거리보다 멀거나
					// 지름길의 길이가 그냥 가는 것보다 느릴 땐 무시
					if (shortCuts[j, 1] > D || shortCuts[j, 1] - shortCuts[j, 0] < shortCuts[j, 2])
					{
						continue;
					}

					// 지름길의 도착 지점이 현재 이동 거리랑 같을때
					if (shortCuts[j, 1] == i)
					{
						// 지름길과 그냥 길 중 빠른 길로 갔다고 값을 준다.
						length[i] = Math.Min(length[shortCuts[j, 0]] + shortCuts[j, 2], length[i]);
					}
				}
			}

			#endregion

			// 최단 거리 출력
			Console.WriteLine(length[D]);
		}
	}
}
