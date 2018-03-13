using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib.Primitives
{
	public abstract class Primitive:SceneObject
	{

		public abstract Intersection Intersect(Ray Ray);
	}
}
