using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingLib
{
	public static class MatrixExtensions
	{
		public static Vector3 AxisX(this Matrix4x4 Matrix)
		{
			return new Vector3(Matrix.M11, Matrix.M12, Matrix.M13);
		}
		public static Vector3 AxisY(this Matrix4x4 Matrix)
		{
			return new Vector3(Matrix.M21, Matrix.M22, Matrix.M23);
		}
		public static Vector3 AxisZ(this Matrix4x4 Matrix)
		{
			return new Vector3(Matrix.M31, Matrix.M32, Matrix.M33);
		}

	}
}
