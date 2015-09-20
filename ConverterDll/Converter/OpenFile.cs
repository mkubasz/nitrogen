using System;
using System.IO;
using ConverterDll.Exception;
using Microsoft.Win32;
using Spire.Xls;
using Excel = Microsoft.Office.Interop.Excel;

namespace Converter
{
	public class OpenFile
	{
		private Excel.Application app = null;
		private Excel.Application _excel;
		private Excel.Workbook _workbook;
		private Excel.Sheets _sheets;
		private Excel.Worksheet _worksheet;
		private object _missing = System.Reflection.Missing.Value;
		private Excel.Range range;


		public bool Create(bool visible, string path,out Worksheet )
		{
			try
			{
				ExceptionConvert ex = new ExceptionConvert(EnumException.CONNECT_PROBLEM);
				//Spire.Xls.Workbook wbFromStream = new Workbook();
				//FileStream fileStream = File.OpenRead(path);
				//fileStream.Seek(0, SeekOrigin.Begin);
				//wbFromStream.LoadFromStream(fileStream);
				//wbFromStream.SaveToFile("From_stream.xls");
				//fileStream.Dispose();
				//System.Diagnostics.Process.Start("From_start.xls");

				_excel = new Excel.Application();
				_worksheet = new Excel.Worksheet();
				_workbook = _excel.Workbooks.Open(path, _missing, _missing, _missing, _missing, _missing, _missing, _missing,
					_missing, _missing, _missing, _missing, _missing, _missing, _missing);
				_worksheet.Activate();
				_worksheet = (Excel.Worksheet) _workbook.ActiveSheet;

				_sheets = _workbook.Worksheets;
				_excel.Visible = visible;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			return true;
		}

		public void Save()
		{
			if (_workbook != null)
				this._workbook.Save();
		}
	}
}