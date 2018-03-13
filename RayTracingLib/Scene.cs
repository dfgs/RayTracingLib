using RayTracingLib.Cameras;
using RayTracingLib.Lights;
using RayTracingLib.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RayTracingLib
{
	public class Scene
	{
		public Camera Camera
		{
			get;
			set;
		}

		public List<Primitive> Primitives
		{
			get;
			set;
		}

		public List<Light> Lights
		{
			get;
			set;
		}

		public Scene()
		{
			Primitives = new List<Primitive>();
			Lights = new List<Light>();
		}

		

		public BitmapSource Render()
		{
			Ray ray;
			Color color;
			Vector3 rayDirection;
			byte[] data=new byte[4];

			Vector3 ndcPosition,viewPosition,worldPosition;
			Matrix4x4 viewportMatrix,invertedViewportMatrix;
			Matrix4x4 viewMatrix,invertedProjectionMatrix;


			if (Camera == null) throw (new InvalidProgramException("No camera defined"));

			viewMatrix = Camera.GetTransformationMatrix();

			if (!Matrix4x4.Invert(Camera.GetProjectionMatrix(),out invertedProjectionMatrix))
			{
				throw (new InvalidProgramException("Failed to invert projection matrix"));
			}

			viewportMatrix = Matrix4x4.Identity * Matrix4x4.CreateScale(Camera.Width / 2.0f, Camera.Height / 2.0f, 1) * Matrix4x4.CreateTranslation(Camera.Width / 2.0f, Camera.Height / 2.0f, 0.0f);
			if (!Matrix4x4.Invert( viewportMatrix,out invertedViewportMatrix))
			{
				throw (new InvalidProgramException("Failed to invert viewport matrix"));
			}


			var renderBitmap = new WriteableBitmap(Camera.Width, Camera.Height, 96, 96, PixelFormats.Bgra32,null);
			renderBitmap.Lock();

			for (int y = 0; y < Camera.Height; y++)
			{
				for (int x = 0; x < Camera.Width; x++)
				{
					ndcPosition=Vector3.Transform(new Vector3(x, y, 0), invertedViewportMatrix);

					viewPosition = Vector3.Transform(ndcPosition, invertedProjectionMatrix);
					worldPosition = Vector3.Transform(viewPosition, viewMatrix); 
					
					rayDirection = Vector3.Normalize(worldPosition - viewMatrix.Translation);

					
					ray = new Ray(viewMatrix.Translation, rayDirection);
					color = RayCast(ray);
					data[0] = color.B;
					data[1] = color.G;
					data[2] = color.R;
					data[3] = color.A;
					renderBitmap.WritePixels(new System.Windows.Int32Rect(x, y, 1, 1), data, 4, 0);
				}

			}
			renderBitmap.Unlock();
			return renderBitmap;




		}

		private Intersection GetIntersection(Ray Ray)
		{
			Intersection intersection, minIntersection;

			minIntersection = null;
			foreach (Primitive primitive in Primitives)
			{
				intersection = primitive.Intersect(Ray);
				if ((intersection == null) || (intersection.Time<0)) continue;
				if ((minIntersection == null) || (minIntersection.Time > intersection.Time)) minIntersection = intersection;
			}
			return minIntersection;
		}

		private Color RayCast(Ray Ray)
		{
			Intersection intersection;
			Vector3 reflectedRay;
			float l,val;

			intersection = GetIntersection(Ray);
			if (intersection == null) return Colors.Black;

			reflectedRay=Vector3.Reflect(Ray.Direction, intersection.Normal);

			l = 0;
			foreach(DirectionalLight light in Lights)
			{
				val=0.5f*( 1-Vector3.Dot(reflectedRay, light.Direction));
				if (val > 0) l += val;
			}
			l = Math.Min(l, 1);
			return Color.FromArgb(255, (byte)(l * 255), (byte)(l * 255), (byte)(l * 255));
		}



	}


}
