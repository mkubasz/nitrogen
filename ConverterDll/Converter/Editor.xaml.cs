using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Converter
{
	/// <summary>
	/// Interaction logic for Editor.xaml
	/// </summary>
	public partial class Editor : Window
	{
		private MainWindow _windows;
		public Editor(MainWindow mainWin)
		{
			InitializeComponent();
			_windows = mainWin;
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			_windows.Show();
		}

		private void btnOpen_Click(object sender, RoutedEventArgs e)
		{
			dataGrid.
		}
	}
}
