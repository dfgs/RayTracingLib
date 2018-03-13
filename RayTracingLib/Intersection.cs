using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib
{
	public class Intersection
	{
		public float Time
		{
			get;
			set;
		}
		public Vector3 Position
		{
			get;
			set;
		}
		public Vector3 Normal
		{
			get;
			set;
		}
		
		public Intersection()
		{

		}
		public Intersection(float Time,Vector3 Position,Vector3 Normal)
		{
			this.Time = Time;this.Position = Position;this.Normal = Normal;
		}

	}
}
