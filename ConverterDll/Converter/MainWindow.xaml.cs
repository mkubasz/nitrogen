using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Spire.Xls;
using Excel = Microsoft.Office.Interop.Excel;

namespace Converter
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

	    private void BtnOpen_OnClick(object sender, RoutedEventArgs e)
	    {
	        FileStream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();


	        openFileDialog.DefaultExt = ".xls|.xlsx";
	        openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
	        Nullable<bool> result = openFileDialog.ShowDialog();

	        if (result == true)
	        {
				Excel.Worksheet worksheet = new Excel.Worksheet();
	            string name = openFileDialog.FileName;
	            txtPath.Text = name;
                FileExcel open = new FileExcel();
	            open.OpenFile(true, name, out worksheet);
                open.SaveFile();
	        }
	    }

        private void txtPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
           
           
        }

        private void txtSave_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

		private void menuExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
		}

		private void MenuItem_OnClick(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
