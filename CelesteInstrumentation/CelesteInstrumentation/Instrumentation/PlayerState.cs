using System.IO;

namespace Instrumentation
{
	public class PlayerState
	{
		public PlayerState()
		{
			this.Distances = new int[8];
			this.DetectedTypes = new int[8];
		}

		public byte[] Serialize()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					foreach (float value in Distances)
					{
						binaryWriter.Write((float)value);
					}
					foreach (float value2 in DetectedTypes)
					{
						binaryWriter.Write((float)value2);
					}
					binaryWriter.Write(this.XVelocity);
					binaryWriter.Write(this.YVelocity);
					binaryWriter.Write(this.CanDash ? 1f : 0f);
					binaryWriter.Write(this.OnGround ? 1f : 0f);
					binaryWriter.Write(this.Stamina);
					binaryWriter.Write(this.AngleToObjective);
					binaryWriter.Write(this.DistanceToObjective);
					binaryWriter.Write(this.SecondsElapsed);
					binaryWriter.Write(this.LevelDiagonalLength);
					binaryWriter.Write((float)this.FinishedLevelsNumber);
					
					// Extended signals
					binaryWriter.Write(this.PlayerXNorm);
					binaryWriter.Write(this.PlayerYNorm);
					binaryWriter.Write(this.DashesRemaining);
					binaryWriter.Write(this.OnWallLeft);
					binaryWriter.Write(this.OnWallRight);
					binaryWriter.Write(this.StateID);
					binaryWriter.Write(this.ProgressRatio);

					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		public int[] Distances;

		public int[] DetectedTypes;

		public float XVelocity;

		public float YVelocity;

		public bool CanDash;

		public bool OnGround;

		public float Stamina;

		public float AngleToObjective;

		public float DistanceToObjective;

		public float InitialDistanceToObjective;

		public float SecondsElapsed;

		public float LevelDiagonalLength;

		public int FinishedLevelsNumber;

		// Extended signals
		public float PlayerXNorm;
		public float PlayerYNorm;
		public float DashesRemaining;
		public float OnWallLeft;
		public float OnWallRight;
		public float StateID;
		public float ProgressRatio;
	}
}
