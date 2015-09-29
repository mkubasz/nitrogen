using System;
using System.IO;
using Microsoft.Win32;
using Spire.Xls;
using Excel = Microsoft.Office.Interop.Excel;

namespace Converter
{
	public class FileExcel
	{
		private Excel.Application _app = null;
		private Excel.Application _excel;
		private Excel.Workbook _workbook;
		private Excel.Sheets _sheets;
		private Excel.Worksheet _worksheet;
		private object _missing = System.Reflection.Missing.Value;
		private Excel.Range range;

		public bool OpenFile(bool visible, string path, out Excel.Worksheet worksheet)
		{
			try
			{
				_excel = new Excel.Application();
				worksheet = _worksheet = new Excel.Worksheet();
				_workbook = _excel.Workbooks.Open(path, _missing, _missing, _missing, _missing, _missing, _missing, _missing,
					_missing, _missing, _missing, _missing, _missing, _missing, _missing);
				_worksheet.Activate();
				_worksheet = (Excel.Worksheet) _workbook.ActiveSheet;

				_sheets = _workbook.Worksheets;
				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			return true;
		}

		public void SaveFile()
		{
			if (_workbook != null)
				this._workbook.Save();
		}
	}
}