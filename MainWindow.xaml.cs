using System;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace WPFHeatMap
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	///

	public partial class MainWindow : Window
	{
		int count = 0;

		Random rRand = new Random();

		// Loop variables
		int x;
		int y;
		byte intense;
		public MainWindow()
		{
			InitializeComponent();

			cbColors.SelectedIndex = 4;
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromMilliseconds(10);
			timer.Tick += timer_Tick;
			timer.Start();

		}

	private void timer_Tick(object sender, EventArgs e)
	{
			
			x = rRand.Next(100, (int)(111 - 1));
			y = rRand.Next(100, (int)(111 - 1));
			intense = (byte)rRand.Next(0, 80);
			cHeatMap.AddHeatPoint(new HeatPoint(x, y, intense));


			x = rRand.Next(110, (int)(121 - 1));
			y = rRand.Next(105, (int)(121 - 1));
			intense = (byte)rRand.Next(0, 80);
			cHeatMap.AddHeatPoint(new HeatPoint(x, y, intense));
			x = rRand.Next(115, (int)(121 - 1));
			y = rRand.Next(110, (int)(121 - 1));
			intense = (byte)rRand.Next(0, 80);
			cHeatMap.AddHeatPoint(new HeatPoint(x, y, intense));

			x = rRand.Next(130, (int)(135 - 1));
			y = rRand.Next(165, (int)(185 - 1));
			intense = (byte)rRand.Next(0, 105);
			cHeatMap.AddHeatPoint(new HeatPoint(x, y, intense));


			x = rRand.Next(135, (int)(145 - 1));
			y = rRand.Next(165, (int)(185 - 1));
			intense = (byte)rRand.Next(0, 85);
			cHeatMap.AddHeatPoint(new HeatPoint(x, y, intense));

			x = rRand.Next(100, (int)(125 - 1));
			y = rRand.Next(200, (int)(225 - 1));
			intense = (byte)rRand.Next(0, 105);
			cHeatMap.AddHeatPoint(new HeatPoint(x, y, intense));

			cHeatMap.Render();

			count++;
			if (count == 100)
			{
				cHeatMap.Clear();
				count = 0;
			}
			
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
				//cHeatMap.AddHeatPoint(new HeatPoint(x, y, intense));


				//cHeatMap.Render();


				//for (int i = 0; i < 10; i++)
				//{
				//	x = rRand.Next(0, (int)(cHeatMap.ActualWidth - 1));
				//	y = rRand.Next(0, (int)(cHeatMap.ActualHeight - 1));
				//	intense = (byte)rRand.Next(0, 255);
				//	cHeatMap.AddHeatPoint(new HeatPoint(x, y, intense));


				//	cHeatMap.Render();

				//}

			});

			

		}
}
	
}
