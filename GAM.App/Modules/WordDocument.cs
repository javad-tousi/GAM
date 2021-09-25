using System.Diagnostics;
using System.Runtime.InteropServices;

public class WordDocument
{
    public static Microsoft.Office.Interop.Word.Application WordApplication = null;

    public static Microsoft.Office.Interop.Word.Document OpenWordFile(string filePath, bool showWordApp, bool newWordApp, bool readOnly)
    {
        try
        {
            //check if Word app is running
            if (newWordApp)
                WordApplication = new Microsoft.Office.Interop.Word.Application();
            else
            {
                if (Process.GetProcessesByName("WINWORD").Length > 0)
                    WordApplication = Marshal.GetActiveObject("Word.Application") as Microsoft.Office.Interop.Word.Application;   // Word 2010
                else
                    WordApplication = new Microsoft.Office.Interop.Word.Application();
            }
            WordApplication.Visible = showWordApp;
            if (System.IO.File.Exists(filePath))
            {
                Microsoft.Office.Interop.Word.Document doc = WordApplication.Documents.Open(filePath, ReadOnly: readOnly);
                doc.Activate();
                return doc;
            }
        }
        catch
        {
        }
        return null;
    }

    public static Microsoft.Office.Interop.Word.Application GetWordApp()
    {
        try
        {
            if (Process.GetProcessesByName("WINWORD").Length > 0)
                return Marshal.GetActiveObject("Word.Application") as Microsoft.Office.Interop.Word.Application;   // Word 2010
            else
                return new Microsoft.Office.Interop.Word.Application();
        }
        catch
        {
        }
        return null;
    }

}
