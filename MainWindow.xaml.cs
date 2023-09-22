using System;
using System.Threading;
using System.Timers;
using System.Windows;

namespace WPFHeatMap
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	///

	public partial class MainWindow : Window
	{
		
		Random rRand = new Random();

		// Loop variables
		int x;
		int y;
		byte intense;
		public MainWindow()
		{
			InitializeComponent();

			cbColors.SelectedIndex = 4;

			
		}

	

	private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			await Dispatcher.Invoke(async () => { RenderContent(); });
			
		}

		private async void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			await Dispatcher.Invoke(async () => { RenderContent(); });
		}

		/// <summary>
		/// Renders random heat map
		/// </summary>
		private async void RenderContent()
		{
			await Dispatcher.Invoke(async () => {

				cHeatMap.Clear();



				// Lets loop few times and create a random point each iteration

				// Pick random locations and intensity
				//x = rRand.Next(0, (int)(cHeatMap.ActualWidth - 1));
				//y = rRand.Next(0, (int)(cHeatMap.ActualHeight - 1));
				//intense = (byte)rRand.Next(0, 255);

				x = 100;
				y = 100;
				intense = (byte)255;

				// Add heat point to heat points list
				cHeatMap.AddHeatPoint(new HeatPoint(x, y, intense));


				cHeatMap.Render();


				for (int i = 0; i < 10; i++)
				{
					x = rRand.Next(0, (int)(cHeatMap.ActualWidth - 1));
					y = rRand.Next(0, (int)(cHeatMap.ActualHeight - 1));
					intense = (byte)rRand.Next(0, 255);
					cHeatMap.AddHeatPoint(new HeatPoint(x, y, intense));


					cHeatMap.Render();

				}

			});

			

		}
}
	
}
