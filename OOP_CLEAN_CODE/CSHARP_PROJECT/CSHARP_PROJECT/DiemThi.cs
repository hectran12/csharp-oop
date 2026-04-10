using System;
using System.Collections.Generic;
using System.Text;

namespace CSHARP_PROJECT
{
    internal class DiemThi
    {
        private decimal _diemToan;
        private decimal _diemLy;
        private decimal _diemHoa;

        public decimal DiemToan
        {
            get { return _diemToan; }
            private set
            {
                ValidateScore(value, "Toan");
                _diemToan = value;
            }
        }

        public decimal DiemLy
        {
            get { return _diemLy; }
            private set
            {
                ValidateScore(value, "Ly");
                _diemLy = value;
            }
        }

        public decimal DiemHoa
        {
            get { return _diemHoa; }
            private set
            {
                ValidateScore(value, "Hoa");
                _diemHoa = value;
            }
        }

        public DiemThi ()
        {
            DiemToan = 0;
            DiemLy = 0;
            DiemHoa = 0;
        }

        public DiemThi (decimal diemToan, decimal diemLy, decimal diemHoa)
        {
            DiemToan = diemToan;
            DiemLy = diemLy;
            DiemHoa = diemHoa;
        }



        private void ValidateScore (decimal value, string subjectName)
        {
            if (value < 0 || value > 10) throw new ArgumentException($"Diem {subjectName} khong hop le (chi tu: 0-10)");
        }

        private decimal NhapDiemMon (string subjectName)
        {
            decimal subjectScore;
            while (true)
            {
                try
                {
                    Console.Write($"Nhap diem mon {subjectName}: ");
                    subjectScore = decimal.Parse(Console.ReadLine());
                    ValidateScore(subjectScore, subjectName);
                    break;
                } catch
                {
                    Console.WriteLine("Diem khong hop le, vui long nhap lai!");

                }

                
            }
            return subjectScore;
        }

        public void NhapDiem ()
        {
            decimal diemToan, diemLy, diemHoa;

            diemToan = NhapDiemMon("Toan");
            diemLy = NhapDiemMon("Ly");
            diemHoa = NhapDiemMon("Hoa");

            DiemToan = diemToan;
            DiemLy = diemLy;
            DiemHoa = diemHoa;
        }

        public decimal TinhDiemTrungBinh ()
        {
            return (DiemToan + DiemLy + DiemHoa) / 3m;
        }

       
    }
}
