using RayTracingLib;
using RayTracingLib.Cameras;
using RayTracingLib.Primitives;
using RayTracingLib.Transformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Scene scene;

		public MainWindow()
		{
			InitializeComponent();

			Sphere sphere;
			sphere = new Sphere(1);
			sphere.Transformations.Add(new Translation(0, 0, -5));

			scene = new Scene();
			scene.Camera = new PerspectiveCamera(320,200,60);
			scene.Camera.Transformations.Add(new LookAt(Vector3.Zero, new Vector3(0, 0, -5), Vector3.UnitY));
			//scene.Camera.Transformations.Add(new Translation(-1, -1, 0));
			scene.Primitives.Add(sphere);

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			DataContext = scene.Render();
		}


	}
}
