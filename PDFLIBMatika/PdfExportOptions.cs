using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PDFToJPG
{
    public class PdfExportOptions
    {
        
        public string OutputFolder { get; set; }
        public string FilenameFormat { get; set; }
        public Collection<int> ExcludePages { get; set; } = new Collection<int>();
        public int Dpi { get; set; } = 96;
    }
}
