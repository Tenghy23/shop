using Application.Models.SampleModels;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Application.Services
{
    public class CSharpTopicsService : ICSharpTopicsService
    {
        public async Task<string> StreamWriteIntoTxtFile()
        {
            // Create a string array with the lines of text
            string[] lines = { "First line", "Second line", "Third line" };

            // Set a variable to MyDocuments unless outputPath exist
            string outputPath = @"C:\Users\Tengh\repo\ECommerce8\outputFiles";
            if (!Directory.Exists(outputPath))
            {
                outputPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            // Delete the file if it exists.
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(outputPath, "WriteLines.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }

            return "file successfully created";
        }

        public async Task<string> StreamReadFromTxtFile()
        {
            // Set a variable to MyDocuments unless outputPath exist
            string outputPath = @"C:\Users\Tengh\repo\ECommerce8\outputFiles";
            if (!Directory.Exists(outputPath))
            {
                outputPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader(Path.Combine(outputPath, "WriteLines.txt")))
            {
                // Read the stream as a string, and write the string to the console.
                Console.WriteLine(sr.ReadToEnd());
            }

            return "file successfully read";
        }

        /* 
            https://learn.microsoft.com/en-us/office/open-xml/getting-started
            note: installation of DocumentFormat.OpenXml is required
        */
        public async Task<string> StreamWriteIntoExcelFile()
        {
            // Create a string array with the lines of text
            string[] header = { "First Header", "Second Header", "Third Header" };
            string[] values = { "First line", "Second line", "Third line" };

            // Set a variable to MyDocuments unless outputPath exist
            string outputPath = @"C:\Users\Tengh\repo\ECommerce8\outputFiles";
            if (!Directory.Exists(outputPath))
            {
                outputPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            // Delete the file if it exists.
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(
                Path.Combine(outputPath, "WriteLines.xlsx"), SpreadsheetDocumentType.Workbook))
            {
                // Add a WorkbookPart to the document.
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart.
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                // Add Sheets to the Workbook.
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                // Append a new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "mySheet" };
                sheets.Append(sheet);

                // Insert header (assuming it's the first row)
                InsertRow(worksheetPart, header);

                // Insert values (assuming they start from the second row)
                for (int i = 0; i < values.Length; i++)
                {
                    InsertRow(worksheetPart, new string[] { values[i] });
                }

                workbookPart.Workbook.Save();
            }

            return "file successfully created";
        }

        public async Task<string> StreamReadFromExcelFile()
        {
            // Set a variable to MyDocuments unless outputPath exist
            string outputPath = @"C:\Users\Tengh\repo\ECommerce8\outputFiles";
            if (!Directory.Exists(outputPath))
            {
                outputPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(
                Path.Combine(outputPath, "WriteLines.xlsx"), false))
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();

                // Get the sheet data
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                int rowCount = 0;
                foreach (Row row in sheetData.Elements<Row>())
                {
                    // Read cell values (you can handle different cell types here)
                    foreach (Cell cell in row.Elements<Cell>())
                    {
                        string cellValue = GetCellValue(workbookPart, cell);
                        Console.Write(cellValue + "\t"); // Print cell value (tab-separated)
                    }
                    Console.WriteLine(); // Move to the next line

                    rowCount++;
                    // Stop reading if there are no more rows
                    if (rowCount >= 100) // Adjust the condition as needed
                        break;
                }
            }

            return "file successfully read";
        }

        //  multithreading
        public async Task<string> AsyncParallelVsSynchronous()
        {
            int[] numbers = Enumerable.Range(1, 1000000).ToArray();

            #region multithreading
            Stopwatch timer1 = new Stopwatch();
            timer1.Start();

            // init collection to hold the values, perform calculation in async
            var partialSums = new List<string>();

            var tasks = new List<Task>();
            tasks.Add(Task.Run(() => partialSums.Add(CalculatePartialSum(numbers, 0, numbers.Length / 4, partialSums))));
            tasks.Add(Task.Run(() => partialSums.Add(CalculatePartialSum(numbers, numbers.Length / 4, numbers.Length / 2, partialSums))));
            tasks.Add(Task.Run(() => partialSums.Add(CalculatePartialSum(numbers, numbers.Length / 2, numbers.Length * 3 / 4, partialSums))));
            tasks.Add(Task.Run(() => partialSums.Add(CalculatePartialSum(numbers, numbers.Length * 3 / 4, numbers.Length, partialSums))));
            await Task.WhenAll(tasks);

            timer1.Stop();
            #endregion

            #region without multithreading
            Stopwatch timer2 = new Stopwatch();
            timer2.Start();

            // init collection, perform the calculation synchronously
            var partialSums1 = new List<string>();

            CalculatePartialSum(numbers, 0, numbers.Length / 4, partialSums1);
            CalculatePartialSum(numbers, numbers.Length / 4, numbers.Length / 2, partialSums1);
            CalculatePartialSum(numbers, numbers.Length / 2, numbers.Length * 3 / 4, partialSums1);
            CalculatePartialSum(numbers, numbers.Length * 3 / 4, numbers.Length, partialSums1);

            timer2.Stop();
            #endregion

            return $"List after multithreading: {partialSums.Aggregate((x,y) => x + " " + y)}, with time taken: {timer1.Elapsed}\n" +
                $"List after without multithreading: {partialSums1.Aggregate((x, y) => x + " " + y)}, with time taken: {timer2.Elapsed}";
        }

        public async Task<string> MultithreadingSharedListMutate()
        {
            int[] numbers = Enumerable.Range(1, 100000).ToArray();

            #region multithreading
            var partialSums = new List<string>();
            Stopwatch timer1 = new Stopwatch();
            timer1.Start();

            // init collection that will mutate asynchronously, perform calculation in parallel, return list
            var tasks = new List<Task>();
            tasks.Add(Task.Run(() => CalculatePartialSum(numbers, 0, numbers.Length / 4, partialSums)));
            tasks.Add(Task.Run(() => CalculatePartialSum(numbers, numbers.Length / 4, numbers.Length / 2, partialSums)));
            tasks.Add(Task.Run(() => CalculatePartialSum(numbers, numbers.Length / 2, numbers.Length * 3 / 4, partialSums)));
            tasks.Add(Task.Run(() => CalculatePartialSum(numbers, numbers.Length * 3 / 4, numbers.Length, partialSums)));
            await Task.WhenAll(tasks);

            timer1.Stop();
            #endregion

            #region without multithreading
            Stopwatch timer2 = new Stopwatch();
            timer2.Start();

            // pass in a list that will mutate synchronously, perform calculation & return list
            var partialSums2 = new List<string>();

            CalculatePartialSum(numbers, 0, numbers.Length / 4, partialSums2);
            CalculatePartialSum(numbers, numbers.Length / 4, numbers.Length / 2, partialSums2);
            CalculatePartialSum(numbers, numbers.Length / 2, numbers.Length * 3 / 4, partialSums2);
            CalculatePartialSum(numbers, numbers.Length * 3 / 4, numbers.Length, partialSums2);

            timer2.Stop();
            #endregion

            return $"partialSums after multithreading: [{string.Join(", ", partialSums)}], with time taken: {timer1.Elapsed}\n" +
                $"partialSums2 without multithreading: [{string.Join(", ", partialSums2)}], with time taken: {timer2.Elapsed}";
        }

        #region helper method for excel
        static void InsertRow(WorksheetPart worksheetPart, string[] rowData)
        {
            SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
            Row row = new Row();

            foreach (string value in rowData)
            {
                Cell cell = new Cell
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(value)
                };
                row.Append(cell);
            }

            sheetData.Append(row);
        }

        // Helper method to get cell value
        static string GetCellValue(WorkbookPart workbookPart, Cell cell)
        {
            if (cell.DataType == null)
                return cell.InnerText;

            string value = cell.InnerText;
            if (cell.DataType.Value == CellValues.SharedString)
            {
                int sharedStringIndex = int.Parse(value);
                SharedStringItem sharedStringItem = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(sharedStringIndex);
                value = sharedStringItem.Text.Text;
            }
            return value;
        }
        #endregion

        #region helper method for multithreading exercises
        private string CalculatePartialSum(int[] numbers, int startIndex, int endIndex, List<string> list)
        {
            int partialSum = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                partialSum += numbers[i] * 5; // Calculate multiplication of 5 and sum
                var test = new Sample(partialSum); // assign into a class to simulate load
                if (list.Count() < 1000)
                {
                    lock (list)
                    {
                        list.Add(partialSum.ToString());
                    }
                }
            }
            return partialSum.ToString();
        }
        #endregion
    }
}
