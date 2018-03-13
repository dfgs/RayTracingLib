using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib.Primitives
{
	public class Sphere:Primitive
	{
		public float Radius
		{
			get;
			set;
		}

		public Sphere()
		{

		}
		public Sphere(float Radius)
		{
			this.Radius = Radius;
		}


		public override float? Intersect(Ray Ray)
		{
			float t0, t1; // solutions for t if the ray intersects
			Matrix4x4 transform;
			float radius2;


			transform = GetTransformationMatrix();

			radius2 = Radius * Radius;

			// geometric solution
			Vector3 L = transform.Translation - Ray.Position;
			float tca = Vector3.Dot(L,Vector3.Normalize(Ray.Direction));
			// if (tca < 0) return false;
			float d2 = L.LengthSquared() - tca * tca;
			if (d2 > radius2) return null;
			float thc = (float)Math.Sqrt(radius2 - d2);
			t0 = tca - thc;
			t1 = tca + thc;

			if (t0 < t1) return t0;
			else return t1;
		}

	}
}
