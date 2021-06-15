using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesShouldBeSmall
{
    public class RowColumnPagePrinter
    {
        private readonly int _rowsPerPage;
        private readonly int _columnsPerPage;
        private readonly int _numbersPerPage;
        private readonly String _pageHeader;
        private  StreamWriter _printStream;
        private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "WriteFile.txt");
        public RowColumnPagePrinter(int rowsPerPage, int columnsPerPage, string pageHeader)
        {
            _rowsPerPage = rowsPerPage;
            _columnsPerPage = columnsPerPage;
            _pageHeader = pageHeader;
            _numbersPerPage = rowsPerPage * columnsPerPage;
            _printStream = new StreamWriter(_filePath);
        }

        public void Print(int[] data)
        {
            int pageNumber = 1;
            for(int firstIndexOnPage =0; firstIndexOnPage < data.Length; firstIndexOnPage += _numbersPerPage)
            {
                int lastIndexOnPage = Math.Min(firstIndexOnPage + _numbersPerPage - 1, data.Length - 1);
                PrintPageHeader(_pageHeader, _numbersPerPage);
                PrintPage(firstIndexOnPage, lastIndexOnPage, data);
                _printStream.WriteLine("\f");
                pageNumber++;
            }
            _printStream.Close();
        }

        private void PrintPage(int firstIndexOnPage , int lastIndexOnPage, int[] data)
        {
            int firstIndexOfLastRowOnPage = firstIndexOnPage + _rowsPerPage - 1;
            for(int firstIndexInRow = firstIndexOnPage; firstIndexInRow <= firstIndexOfLastRowOnPage; firstIndexInRow++)
            {
                PrintRow(firstIndexInRow, lastIndexOnPage, data);
                _printStream.WriteLine();
            }
        }

        private void PrintRow(int firstIndexRow, int lastIndexOnPage, int[] data)
        {
            for(int column = 0; column< _columnsPerPage; column++)
            {
                int index = firstIndexRow + column * _rowsPerPage;
                if (index <= lastIndexOnPage)
                    _printStream.WriteLine($"{data[index]}");
            }
        }

        private void PrintPageHeader(string pageHeader, int pageNumber)
        {
            _printStream.WriteLine($"{pageHeader} --- Page {pageNumber}");
            _printStream.WriteLine();
        }

        public void SetOutput (StreamWriter printStream)
        {
            this._printStream = printStream;
        }
    }
}
