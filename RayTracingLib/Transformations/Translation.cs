using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib.Transformations
{
	public class Translation : Transformation
	{
		public Vector3 Position
		{
			get;
			set;
		}
		public Translation()
		{

		}

		public Translation(Vector3 Position)
		{
			this.Position = Position;
		}
		public Translation(float X,float Y,float Z)
		{
			this.Position = new Vector3(X, Y, Z);
		}
		public override Matrix4x4 GetTransformationMatrix()
		{
			return Matrix4x4.CreateTranslation(Position);
		}
	}
}
