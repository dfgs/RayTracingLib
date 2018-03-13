using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib
{
	public struct Ray
	{
		public Vector3 Position
		{
			get;
			set;
		}
		public Vector3 Direction
		{
			get;
			set;
		}

		public Ray(Vector3 Position,Vector3 Direction)
		{
			this.Position = Position;this.Direction = Direction;
		}

	}
}
