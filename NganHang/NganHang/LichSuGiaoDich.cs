using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NganHang
{
    internal class LichSuGiaoDich
    {
        #region Fields
        private DateTime _date;
        private LoaiGiaoDich _loaiGiaoDich;
        private string _message;
        #endregion

        #region Properties
        public DateTime Date { get => _date; private set => _date = value; }
        public LoaiGiaoDich LoaiGiaoDich { get => _loaiGiaoDich; private set => _loaiGiaoDich = value;  }
        public string Message { get => _message; private set => _message = value;  }

        #endregion

        #region Constructors
        public LichSuGiaoDich (DateTime date, LoaiGiaoDich loaiGiaoDich, string message)
        {
            Date = date;
            LoaiGiaoDich = loaiGiaoDich;
            Message = message;
        }

        public LichSuGiaoDich (LoaiGiaoDich loaiGiaoDich, string message)
        {
            Date = new DateTime();
            LoaiGiaoDich = loaiGiaoDich;
            Message = message;
        }
        #endregion

        #region Override Methods
        public override string ToString()
        {
            string loaiGiaoDichStr = LoaiGiaoDich == LoaiGiaoDich.NAP_TIEN ? "Nap tien" :
                LoaiGiaoDich == LoaiGiaoDich.RUT_TIEN ? "Rut tien" : 
                LoaiGiaoDich == LoaiGiaoDich.CHUYEN_TIEN ? "Chuyen tien" :
                LoaiGiaoDich == LoaiGiaoDich.THANH_TOAN ? "Thanh toan" : "";
            return "[" + Date.ToString("dd/mm/yyyy") + "] [" + loaiGiaoDichStr + "] : " + Message;
        }
        #endregion



    }
}
