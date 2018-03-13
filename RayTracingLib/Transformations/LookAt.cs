using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib.Transformations
{
	public class LookAt : Transformation
	{
		public Vector3 Position
		{
			get;
			set;
		}
		public Vector3 Target
		{
			get;
			set;
		}
		public Vector3 Up
		{
			get;
			set;
		}

		public LookAt(Vector3 Position,Vector3 Target,Vector3 Up)
		{
			this.Position = Position;this.Target = Target;this.Up = Up;
		}

		public override Matrix4x4 GetTransformationMatrix()
		{
			return Matrix4x4.CreateLookAt(Position, Target, Up);
		}
	}
}
