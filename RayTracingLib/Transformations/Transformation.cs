using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib.Transformations
{
	public abstract class Transformation
	{

		public abstract Matrix4x4 GetTransformationMatrix();

	}

}
