using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace BusquedaSumatoria
{
    class PdfToImage
    {

        public void ConvertPdfToImages(string pdfFilePath)
        {
            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber++)
                {
                    PdfDictionary page = reader.GetPageN(pageNumber);
                    PdfDictionary resources = page.GetAsDict(PdfName.RESOURCES);
                    PdfDictionary xobjects = resources.GetAsDict(PdfName.XOBJECT);

                    if (xobjects != null)
                    {
                        foreach (PdfName name in xobjects.Keys)
                        {
                            PdfObject obj = xobjects.Get(name);
                            if (obj.IsIndirect())
                            {
                                PdfDictionary imgObject = (PdfDictionary)PdfReader.GetPdfObject(obj);

                                if (imgObject != null && imgObject.Get(PdfName.SUBTYPE).Equals(PdfName.IMAGE))
                                {
                                    int xrefIdx = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(System.Globalization.CultureInfo.InvariantCulture));
                                    PdfObject pdfObj = reader.GetPdfObject(xrefIdx);
                                    PdfStream pdfStrem = (PdfStream)pdfObj;
                                    byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);
                                    if ((bytes != null))
                                    {
                                        using (MemoryStream memStream = new MemoryStream(bytes))
                                        {
                                            System.Drawing.Image image = System.Drawing.Image.FromStream(memStream);
                                            image.Save($"pagina_{pageNumber}_imagen_{name.GetHashCode()}.png", System.Drawing.Imaging.ImageFormat.Png);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
}
