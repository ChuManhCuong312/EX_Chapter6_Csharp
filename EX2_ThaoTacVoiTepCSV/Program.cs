using System;
using System.Collections.Generic;
using System.IO;

// Định nghĩa lớp SinhVien
public class SinhVien
{
    public int Id { get; set; }
    public string Ten { get; set; }
    public int Tuoi { get; set; }
    public double Diem { get; set; }

    // Constructor
    public SinhVien(int id, string ten, int tuoi, double diem)
    {
        Id = id;
        Ten = ten;
        Tuoi = tuoi;
        Diem = diem;
    }

    // Phương thức để đọc từ tệp CSV và chuyển đổi thành List<SinhVien>
    public static List<SinhVien> DocTuCSV(string filePath)
    {
        List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        int id = Convert.ToInt32(parts[0].Trim());
                        string ten = parts[1].Trim();
                        int tuoi = Convert.ToInt32(parts[2].Trim());
                        double diem = Convert.ToDouble(parts[3].Trim());

                        SinhVien sv = new SinhVien(id, ten, tuoi, diem);
                        danhSachSinhVien.Add(sv);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi đọc từ tệp CSV: {ex.Message}");
        }

        return danhSachSinhVien;
    }

    // Phương thức để ghi List<SinhVien> vào tệp CSV
    public static void GhiVaoCSV(List<SinhVien> danhSachSinhVien, string filePath)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var sv in danhSachSinhVien)
                {
                    sw.WriteLine($"{sv.Id},{sv.Ten},{sv.Tuoi},{sv.Diem}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi ghi vào tệp CSV: {ex.Message}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        string fileNhap = "sinhvien.csv";
        string fileXuat = "sinhvien_xuat.csv";

        List<SinhVien> danhSachSV = new List<SinhVien>()
        {
            new SinhVien(1, "Nguyễn Văn A", 20, 8.5),
            new SinhVien(2, "Trần Thị B", 22, 7.8),
            new SinhVien(3, "Lê Văn C", 21, 9.2)
        };


        SinhVien.GhiVaoCSV(danhSachSV, fileXuat);
        Console.WriteLine($"Đã ghi danh sách sinh viên vào tệp {fileXuat}");


        List<SinhVien> sinhVienTuFile = SinhVien.DocTuCSV(fileNhap);
        Console.WriteLine("\nDanh sách sinh viên từ tệp:");
        foreach (var sv in sinhVienTuFile)
        {
            Console.WriteLine($"ID: {sv.Id}, Tên: {sv.Ten}, Tuổi: {sv.Tuoi}, Điểm: {sv.Diem}");
        }
    }
}
