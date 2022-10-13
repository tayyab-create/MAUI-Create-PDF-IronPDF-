using IronPdf;
using IronPdf.Rendering;

namespace MAUI_PDF;

public partial class MainPage : ContentPage
{

    ChromePdfRenderer renderer = new ChromePdfRenderer();

        
    string url = string.Empty;
	public MainPage()
	{
		InitializeComponent();
    }

    private void HtmlToPdf(object sender, EventArgs e)
	{   
        var doc = renderer.RenderHtmlAsPdf("<h1>Hello IronPDF!</h1> <p>I'm using IronPDF MAUI!</p>");   
        File.WriteAllBytes(@"C:\IronPDF HTML string.pdf", doc.Stream.ToArray());
        //Saves the memory stream as file.
        SaveService saveService = new();
        saveService.SaveAndView("IronPDF HTML string.pdf", "application/pdf", doc.Stream);
    }

    private void HtmlFileToPdf(object sender, EventArgs e)
    {
        
        var doc = renderer.RenderHtmlFileAsPdf(@"C:\Website\NET Free. Cross-platform.html");
        renderer.RenderingOptions.PaperSize = PdfPaperSize.A2;
        File.WriteAllBytes(@"C:\IronPDF Html File.pdf", doc.Stream.ToArray());
        
        SaveService saveService = new();
        saveService.SaveAndView("IronPDF Html File.pdf", "application/pdf", doc.Stream);
    }

    void OnEntryTextChanged(object sender, EventArgs e)
    {
        url = ((Entry)sender).Text;
    }

    private void UrlToPdf(object sender, EventArgs e)
    {
        
        var doc = renderer.RenderUrlAsPdf(url);
        renderer.RenderingOptions.PaperSize = PdfPaperSize.A2;
        File.WriteAllBytes(@"C:\IronPDF Url.pdf", doc.Stream.ToArray());
        //Saves the memory stream as file.
        SaveService saveService = new();
        saveService.SaveAndView("IronPDF Url.pdf", "application/pdf", doc.Stream);
    }

}

