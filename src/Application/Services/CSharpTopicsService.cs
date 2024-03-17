using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

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

                workbookPart.Workbook.Save();
            }

            return "file successfully created";
        }

    }
}
