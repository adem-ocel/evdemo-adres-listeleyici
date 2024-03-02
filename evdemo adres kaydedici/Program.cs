using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
namespace evdemo_adres_kaydedici;

class Program
{
    static void Main(string[] args)
    {
        string filepatch = "/home/adem/İndirilenler/Zimmetler.pdf";
        
        string pdftext = read_pdf_full(filepatch);
        string[] adresslist = list_customer_adress(pdftext).ToArray();

        foreach (var item in adresslist)
        {
            System.Console.WriteLine(item);
        }
    }

    static string read_pdf_full(string filepatch)
    {
        PdfReader reader = new PdfReader(filepatch);
        string text = string.Empty;
        for (int page = 1; page <= reader.NumberOfPages; page++)
        {
            text += PdfTextExtractor.GetTextFromPage(reader, page);
        }
        reader.Close();
        return text;
    }
//              adresslist.Add(,splited_text[i + 1]);



    static List<string> list_customer_adress(string text)
    {
        string[] splited_text = text.Split("\n");
        List<string> adresslist = new();

        for (int i = 0; i < splited_text.Length; i++)
        {
            string line = splited_text[i];
            if (line.StartsWith("Alıcı Adı : "))
            {
                adresslist.Add(splited_text[i].Replace("Alıcı Adı : ","").Split(" -")[0]+" | "+splited_text[i + 1]);
            }
        }
        return adresslist;
    }




}