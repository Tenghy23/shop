using Application.Models.SampleModels;
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


        public async Task<string> MultithreadingIncrementExercise()
        {
            int[] numbers = Enumerable.Range(1, 1000000).ToArray();

            #region multithreading
            Stopwatch timer1 = new Stopwatch();
            timer1.Start();

            // init a array to hold the values, perform calculation in parallel and sum them up
            int[] partialSums = new int[4];

            var tasks = new List<Task>();
            tasks.Add(Task.Run(() => partialSums[0] = CalculatePartialSum(numbers, 0, numbers.Length / 4)));
            tasks.Add(Task.Run(() => partialSums[1] = CalculatePartialSum(numbers, numbers.Length / 4, numbers.Length / 2)));
            tasks.Add(Task.Run(() => partialSums[2] = CalculatePartialSum(numbers, numbers.Length / 2, numbers.Length * 3 / 4)));
            tasks.Add(Task.Run(() => partialSums[3] = CalculatePartialSum(numbers, numbers.Length * 3 / 4, numbers.Length)));

            await Task.WhenAll(tasks);
            int totalSum = partialSums.Sum();
            timer1.Stop();
            #endregion

            #region without multithreading
            Stopwatch timer2 = new Stopwatch();
            timer2.Start();

            // init array, perform the calculation synchronously and sum them up
            int[] partialSums1 = new int[4];

            partialSums1[0] = CalculatePartialSum(numbers, 0, numbers.Length / 4);
            partialSums1[1] = CalculatePartialSum(numbers, numbers.Length / 4, numbers.Length / 2);
            partialSums1[2] = CalculatePartialSum(numbers, numbers.Length / 2, numbers.Length * 3 / 4);
            partialSums1[3] = CalculatePartialSum(numbers, numbers.Length * 3 / 4, numbers.Length);

            int totalSum1 = partialSums1.Sum();
            timer2.Stop();
            #endregion

            return $"Total sum of squares after multithreading: {totalSum}, with time taken: {timer1.Elapsed}\n" +
                $"Total sum of squares without multithreading: {totalSum1}, with time taken: {timer2.Elapsed}";
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
        private int CalculatePartialSum(int[] numbers, int startIndex, int endIndex)
        {
            int partialSum = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                partialSum += numbers[i] * numbers[i]; // Calculate square and sum
                var test = new Sample(partialSum); // assign into a class to simulate load
            }
            return partialSum;
        }
        #endregion
    }
}
