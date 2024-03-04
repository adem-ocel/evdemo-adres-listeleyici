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

        List<string> başiskele_adresleri = [];
        List<string> izmit_adresleri = [];
        List<string> kartepe_adresleri = [];
        List<string> derince_adresleri = [];
        List<string> gölcük_adresleri = [];
        List<string> körfez_adresleri = [];
        List<string> çayırova_adresleri = [];
        List<string> darıca_adresleri = [];
        List<string> dilovası_adresleri = [];
        List<string> gebze_adresleri = [];
        List<string> kandıra_adresleri = [];
        List<string> karamürsel_adresleri = [];
        List<string> diğer_adresler = [];

        List<string> adresslist = new();

        for (int i = 0; i < splited_text.Length; i++)
        {
            string line = splited_text[i];
            if (line.StartsWith("Alıcı Adı : "))
            {
                string adsoyad = splited_text[i].Replace("Alıcı Adı : ", "").Split(" -")[0];
                string adress = splited_text[i + 1];

                switch (adress.Split(' ')[adress.Split(' ').Length - 2].ToLower())
                {
                    case "başiskele": başiskele_adresleri.Add(adsoyad + " | " + adress); break;
                    case "izmit": izmit_adresleri.Add(adsoyad + " | " + adress); break;
                    case "kartepe": kartepe_adresleri.Add(adsoyad + " | " + adress); break;
                    case "derince": derince_adresleri.Add(adsoyad + " | " + adress); break;
                    case "gölcük": gölcük_adresleri.Add(adsoyad + " | " + adress); break;
                    case "körfez": körfez_adresleri.Add(adsoyad + " | " + adress); break;
                    case "çayırova": çayırova_adresleri.Add(adsoyad + " | " + adress); break;
                    case "darıca": darıca_adresleri.Add(adsoyad + " | " + adress); break;
                    case "dilovası": dilovası_adresleri.Add(adsoyad + " | " + adress); break;
                    case "gebze": gebze_adresleri.Add(adsoyad + " | " + adress); break;
                    case "kandıra": kandıra_adresleri.Add(adsoyad + " | " + adress); break;
                    case "karamürsel": karamürsel_adresleri.Add(adsoyad + " | " + adress); break;
                    default: diğer_adresler.Add(adsoyad + " | " + adress); break;
                }
            }
        }
        adresslist.AddRange(başiskele_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(izmit_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(kartepe_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(derince_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(gölcük_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(körfez_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(çayırova_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(darıca_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(dilovası_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(gebze_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(kandıra_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(karamürsel_adresleri);
        adresslist.Add("------------------------------------------------------------------------------------------");
        adresslist.AddRange(diğer_adresler);
        return adresslist;
    }
}