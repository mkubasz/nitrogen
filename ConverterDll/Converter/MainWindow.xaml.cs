using System;
using System.Collections.Generic;
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
	        OpenFileDialog openFile = new OpenFileDialog();
	        openFile.DefaultExt = ".xlsx|.xls|.xlsm";
	        openFile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
	       
	        Nullable<bool> result = openFile.ShowDialog();

	        if (result == true)
	        {
	            string name = openFile.FileName;
                txtPath.Text = name;
	           
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
            Microsoft.Win32.SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "XmlConvert";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (.xml)|*.xml";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                 string savePathname = dlg.FileName;
                 txtSave.Text = savePathname;
            }
           
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
			MessageBox.Show("Zrobione przez genialnych programistów xD Widmo");
		}
	}
}
