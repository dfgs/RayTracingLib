using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib.Lights
{
	public class DirectionalLight:Light
	{
		public Vector3 Direction
		{
			get;
			set;
		}

		public DirectionalLight()
		{
			this.Direction = new Vector3(0, 0, -1);
		}
		public DirectionalLight(Vector3 Direction)
		{
			this.Direction = Direction;
		}
		public DirectionalLight(float x,float y,float z)
		{
			this.Direction = new Vector3(x,y,z);
		}

	}
}
