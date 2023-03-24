using System;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;
using static PDFLIBMatika.CLogger;
using System.Linq;

namespace PDFToJPG
{
    /*
     *  Autor: Geovanny García
     *  Ghostscript.NET
     *  https://ghostscript.com/releases/
     *  
     */
    public class PdfRasterizer
    {
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string NativeGhostscriptDll { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "bin", Environment.Is64BitProcess ? "gsdll64.dll" : "gsdll32.dll");



        public PdfExportResult Export(string pdfPath, PdfExportOptions options)
        {
            var logger = new Logger();

            string binPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            log.Info("binPath " + binPath);
            logger.Log("binPath " + binPath);
            logger.Log("Environment.Is64BitProcess " + Environment.Is64BitProcess);

            Console.WriteLine("binPath " + binPath);
      

            try
            {
                if (!File.Exists(pdfPath))
                    throw new FileNotFoundException("El archivo Pdf de entrada no existe.");

                using (var rasterizer = new GhostscriptRasterizer())
                {
                    var buffer = File.ReadAllBytes(pdfPath);
                    var ms = new MemoryStream(buffer);

                    var gvi = new GhostscriptVersionInfo(NativeGhostscriptDll);

                    rasterizer.Open(ms, gvi, true);

                    for (int pageNumber = 1; pageNumber <= rasterizer.PageCount; pageNumber++)
                    {
                        if (!options.ExcludePages.Contains(pageNumber))
                        {
                            var imageFormat = ImageFormat.Jpeg;
                            var filename = Path.Combine(options.OutputFolder, string.Format(options.FilenameFormat, pageNumber));

                            if (!filename.ToLower().EndsWith(".png") &&
                                !filename.ToLower().EndsWith(".jpg") &&
                                !filename.ToLower().EndsWith(".jpeg"))
                            {
                                filename += ".jpg";
                            }
                            else
                            {
                                if (filename.ToLower().EndsWith(".png"))
                                    imageFormat = ImageFormat.Png;
                            }

                            var image = rasterizer.GetPage(options.Dpi, pageNumber);

                            image.Save(filename, imageFormat);

                            logger.Log("filename " + filename);

                            
                            //imageObj.comprimeImagen(filename);
                        }
                    }

                    return new PdfExportResult
                    {
                        Success = true,
                        Message = "File processed successfully."
                    };
                }
                //prueba();
            }
            catch (Exception ex)
            {
                return new PdfExportResult
                {
                    Success = false,
                    Message = ex.ToString()
                };
            }
        }
        
        public static void prueba()
        {
            var logger = new Logger();

            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "PublicTempStorage" + Path.DirectorySeparatorChar + "TempPdfToImage";

            Console.WriteLine("prueba pathFile " + pathFile);

            logger.Log("prueba pathFile " + pathFile);

            try
            {
                string[] filePaths = Directory.GetFiles(pathFile, "*.*", SearchOption.AllDirectories);
                
                logger.Log("prueba filePaths " + filePaths);

                //imageObj.comprimeImagen(filename);
            }
            catch (Exception ex)
            {

                String Message = ex.ToString();
                logger.Log("Message " + Message);

            }
        }
    }
}