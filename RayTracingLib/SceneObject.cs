using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using RayTracingLib.Transformations;

namespace RayTracingLib
{
	public class SceneObject
	{
		public List<Transformation> Transformations
		{
			get;
			set;
		}
		public SceneObject()
		{
			Transformations = new List<Transformation>();
		}

		public Matrix4x4 GetTransformationMatrix()
		{
			Matrix4x4 matrix;

			matrix = Matrix4x4.Identity;
			foreach(Transformation transformation in Transformations)
			{
				matrix *= transformation.GetTransformationMatrix();
			}

			return matrix;
		}


	}
}
