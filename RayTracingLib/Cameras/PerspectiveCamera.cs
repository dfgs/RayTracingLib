using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib.Cameras
{
	public class PerspectiveCamera : Camera
	{
		public int FOV
		{
			get;
			set;
		}

		public PerspectiveCamera()
		{
			FOV=60;
		}

		public PerspectiveCamera(int Width, int Height, int FOV, int NearPlaneDistance = 1, int FarPlaneDistance = 100)
			: base(Width, Height, NearPlaneDistance, FarPlaneDistance)
		{
			this.FOV = FOV;
		}

		public override Matrix4x4 GetProjectionMatrix()
		{
			return Matrix4x4.CreatePerspectiveFieldOfView(FOV*(float)Math.PI/180.0f , (float)Width/(float)Height ,NearPlaneDistance, FarPlaneDistance) ;
		}


	}
}
