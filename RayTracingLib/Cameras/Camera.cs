using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib.Cameras
{
	public abstract class Camera:SceneObject
	{
		public int Width
		{
			get;
			set;
		}
		public int Height
		{
			get;
			set;
		}

		public int NearPlaneDistance
		{
			get;
			set;
		}

		public int FarPlaneDistance
		{
			get;
			set;
		}

		public Camera()
		{
			Width = 640;Height=480;NearPlaneDistance = 1;FarPlaneDistance=100;
		}

		public Camera(int Width, int Height, int NearPlaneDistance=1, int FarPlaneDistance=100)
		{
			this.Width = Width; this.Height = Height; this.NearPlaneDistance = NearPlaneDistance; this.FarPlaneDistance = FarPlaneDistance;
		}


		public abstract Matrix4x4 GetProjectionMatrix();

		


	}
}
