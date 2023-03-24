using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace ClassGx
{
    public class CustomCell
    {
        private IXLCell _cell;

        /*public IXLCell cell
        {
            get { return _cell; }
            set { _cell = value; }
        }*/


        public string texto
        {
            get { return _cell.Value.ToString(); }
            set { _cell.Value = value; }
        }

        //public string color
        //{
        //    set {
        //        _cell.Style.Fill.BackgroundColor = value;
        //    }
        //}

        public CustomCell(IXLCell cell)
        {
            this._cell = cell;
        }

        /*public IXLCell getCell()
        {
            return this._cell;
        }*/
    }
}
