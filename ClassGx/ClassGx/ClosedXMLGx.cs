using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ClosedXML.Excel;


namespace ClassGx
{


    //https://github.com/ClosedXML/ClosedXML
    public class ClosedXMLGx
    {

        protected static String pathFile;        
        protected static FileStream sw;
        protected static XLWorkbook workbook;
        protected static IXLWorksheet ws;

        public void PostClosedXML(string nombreArchivo)
        {
            Console.WriteLine("hola");

            
        }

        public void OpenExcel(string nombreArchivo)
        {
            pathFile = AppDomain.CurrentDomain.BaseDirectory + "PublicTempStorage" + Path.DirectorySeparatorChar + nombreArchivo + ".xlsx";
            workbook = new XLWorkbook();
        } // Open
        /*
        public CustomCell celda(int inrow, int incolumn)
        {
            //IXLCell celda = ws.Cell(inrow, incolumn);
            return new CustomCell(ws.Cell(inrow, incolumn));
        } */

        public void ExcelTexto(string texto, int inrow, int incolumn)
        {
            ws.Cell(inrow, incolumn).Value = texto;
            ws.Column(incolumn).AdjustToContents();
        }

        public void ExcelNumero(Decimal texto, int inrow, int incolumn, string formato)
        {
            ws.Cell(inrow, incolumn).Value = texto;
            ws.Cell(inrow, incolumn).Style.NumberFormat.Format = formato; //"#,##0";


            ws.Column(incolumn).AdjustToContents();

        }

        public void CentrarTexto(int inrow, int incolumn)
        {

            ws.Cell(inrow, incolumn).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell(inrow, incolumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


        }

        public void AjustarTextoColumnas(int incol, int fincolumn)
        {
            ws.Columns(incol, fincolumn).AdjustToContents();

        }

        public void ExcelFecha(string texto, int inrow, int incolumn)
        {
            ws.Cell(inrow, incolumn).Value = texto;
            ws.Cell(inrow, incolumn).Style.NumberFormat.Format = "dd/mm/yyyy";

            ws.Column(incolumn).AdjustToContents();

        }

        public void ExcelFormula(string formula, int inrow, int incolumn)
        {
            var cellWithFormulaA1 = ws.Cell(inrow, incolumn);
            cellWithFormulaA1.FormulaA1 = formula;
            ws.Cell(inrow, incolumn).Style.NumberFormat.Format = "#,##0";

            ws.Column(incolumn).AdjustToContents();

        }

        public void SelectSheet(string nombreHoja)
        {
            ws = workbook.Worksheets.Add(nombreHoja);

        } 

        public void BackgroundColor(int inrow, int incolumn, int rojo, int verde, int azul)
        {
            ws.Cell(inrow, incolumn).Style.Fill.BackgroundColor = XLColor.FromArgb(rojo, verde, azul);
        }

        public void Bold(bool isBold, int inrow, int incolumn)
        {
            ws.Cell(inrow, incolumn).Style.Font.Bold = isBold;
        }

        public void UnderlineDoble(int inrow, int incolumn)
        {
            ws.Cell(inrow, incolumn).Style.Font.Underline = XLFontUnderlineValues.Double;
        }

        public void UnderlineSencillo( int inrow, int incolumn)
        {
            ws.Cell(inrow, incolumn).Style.Font.Underline = XLFontUnderlineValues.Single;
        }

        public void FontColor(int inrow, int incolumn, int rojo, int verde, int azul)
        {

            ws.Cell(inrow, incolumn).Style.Font.FontColor = XLColor.FromArgb(rojo,verde, azul) ;
        }

        public void FontSize(int inrow, int incolumn, int tamaño)
        {

            ws.Cell(inrow, incolumn).Style.Font.FontSize = tamaño;
            

        }

        public void MergedRowCenter(string rango)
        {
           
            int indice = rango.IndexOf(":");
            if(indice > 0)
            {
                string inrango = rango.Substring(0, indice);

                ws.Cell(inrango).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(inrango).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Range(rango).Row(1).Merge();
            }
        }


        public void MergedRowLef(string rango)
        {

            int indice = rango.IndexOf(":");
            if (indice > 0)
            {
                string inrango = rango.Substring(0, indice);

                ws.Cell(inrango).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                ws.Cell(inrango).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Range(rango).Row(1).Merge();
            }
        }

        public void CloseExcel()
        {
            workbook.SaveAs(pathFile);

        }

        public void CrearArchivo(string cadena)
        {
            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "Log.txt";
            Console.WriteLine("Devuelve " + pathFile);

            FileStream fs = new FileStream(pathFile, FileMode.Create);
            fs.Write(ASCIIEncoding.ASCII.GetBytes(cadena), 0, cadena.Length);
            fs.Close();



        }

        
    }
}
