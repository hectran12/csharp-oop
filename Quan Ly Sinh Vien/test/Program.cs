using System;
using System.Text;

namespace test
{
    class Program 
    {
        static Student sinhvien = new Student();
        static void Main (string[] args)
        {
            while (true)
            {
                Console.Clear();
                Menu();
            }
        }

        static void Menu()
        {
            string menu;
            menu = "[1] Them sinh vien\n";
            menu += "[2] Quan ly sinh vien\n";
            Console.Write(menu);
            choose();
        }

        static void choose()
        {
            Console.Write("Nhap chuc nang: ");
            int chucnang = Convert.ToInt32 (Console.ReadLine());
            switch (chucnang)
            {
                case 1:
                    addStudent();
                    break;
                case 2:
                    ViewStudent();
                    break;
                default:
                    Console.Write("Nhap sai roi, nhap lai di");
                    Thread.Sleep(1000);
                    break;
            }
        }

        private static void ViewStudent()
        {
            while (true)
            {
                Console.Clear();
                sinhvien.AllStudent();
                int z = MenuView();
                if(z == 1)
                {
                    break;
                }
            }

        }

        static int MenuView()
        {
            string menuview;
            menuview = "[1] Sort\n";
            menuview += "[2] Find student\n";
            menuview += "[3] Find University\n";
            menuview += "[4] Find Age\n";
            menuview += "[5] Find Name\n";
            menuview += "[6] Remove students\n";
            menuview += "[7] Edit Students\n";
            menuview += "[8] Exit\n";
            Console.Write(menuview);
            Console.Write("Nhap chuc nang: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            int exit = 0;
            switch (ch)
            {
                case 1:
                    Sort();
                    break;
                case 2:
                    findstu();
                    break;
                case 3:
                    finduvs();
                    break;
                case 4:
                    findage();
                    break;
                case 5:
                    findname();
                    break;
                case 6:
                    rmstu();
                    break;
                case 7:
                    edit();
                    break;
                case 8:
                    exit = 1;
                    break;
                default:
                    Console.Write("Khong co chuc nang nay trong menu!");
                    break;
            }
            return exit;
        }

        private static void edit()
        {
            Console.Write("Nhap ma hoc sinh: ");
            int ma = Convert.ToInt32(Console.ReadLine());
            sinhvien.edit(ma);
            Console.Write("Enter de back ve menu!");
            Console.ReadLine();
        }

        private static void rmstu()
        {
            Console.Write("Nhap ma muon xoa: ");
            int ma = Convert.ToInt32(Console.ReadLine());
            sinhvien.rm(ma);
            Console.Write("Enter de back ve menu!");
            Console.ReadLine();

        }

        private static void findname()
        {
            Console.Write("Nhap ten muon tim: ");
            string name = Convert.ToString(Console.ReadLine());
            sinhvien.findname(name);
            Console.Write("Enter de back ve menu!");
            Console.ReadLine();
        }

        private static void findage()
        {
            Console.Write("Nhap so tuoi: ");
            int age = Convert.ToInt32(Console.ReadLine());
            sinhvien.findage(age);
            Console.Write("Enter de back ve menu!");
            Console.ReadLine();
        }

        private static void finduvs()
        {
            Console.Write("Nhap truong hoc can tim: ");
            string uni = Convert.ToString(Console.ReadLine()).Trim();
            sinhvien.finduni(uni);
            Console.Write("Enter de back ve menu!");
            Console.ReadLine();
        }

        private static void findstu()
        {
            Console.Write("Nhap ma sinh vien can tim: ");
            int ma = Convert.ToInt32(Console.ReadLine());
            sinhvien.findstu(ma);
            Console.Write("Enter de back ve menu!");
            Console.ReadLine();
        }

        private static void Sort()
        {
            Console.WriteLine("[1] Small -> large\n[2] Large -> small");
            Console.Write("Nhap so: ");
            int sort = Convert.ToInt32((Console.ReadLine()));
            switch (sort)
            {
                case 1:
                    sinhvien.sortlm(1);
                    break;
                case 2:
                    sinhvien.sortlm(0);
                    break;
                default:
                    Console.Write("Khong co chuc nang cu the!");
                    Thread.Sleep(1000);
                    break;
            }
            Console.Write("Enter de tiep tuc!");
            Console.ReadLine();
        }

        private static void addStudent()
        {
            Console.Write("Nhap ten sinh vien: ");
            string tenstudent = Convert.ToString(Console.ReadLine()).ToLower();
            Console.Write("Nhap so tuoi cua ban: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap truong dai hoc: ");
            string university = Convert.ToString(Console.ReadLine()).ToLower();
            Console.Write("Nhap cong viec hien tai: ");
            string job = Convert.ToString(Console.ReadLine()).ToLower();
            sinhvien.name = tenstudent;
            sinhvien.age = age;
            sinhvien.university = university;
            sinhvien.job = job;
            Console.WriteLine(sinhvien.NewStudent());
            Console.WriteLine(sinhvien.GenID());
            Console.Write("Enter de back menu");
            Console.ReadLine();
        }
    }
}