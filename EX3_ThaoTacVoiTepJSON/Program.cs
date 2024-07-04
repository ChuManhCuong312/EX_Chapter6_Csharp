using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Định nghĩa lớp Product
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }

    // Constructor mặc định
    public Product() { }

    // Constructor có tham số
    public Product(int id, string name, double price, string category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }

    // Phương thức để đọc từ tệp JSON và chuyển đổi thành List<Product>
    public static List<Product> DocTuJSON(string filePath)
    {
        List<Product> danhSachSanPham = new List<Product>();

        try
        {
            string jsonData = File.ReadAllText(filePath);
            danhSachSanPham = JsonSerializer.Deserialize<List<Product>>(jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi đọc từ tệp JSON: {ex.Message}");
        }

        return danhSachSanPham;
    }

    // Phương thức để ghi danh sách sản phẩm vào tệp JSON
    public static void GhiVaoJSON(List<Product> danhSachSanPham, string filePath)
    {
        try
        {
            string jsonData = JsonSerializer.Serialize(danhSachSanPham, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi ghi vào tệp JSON: {ex.Message}");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        string fileNhap = "products.json";
        string fileXuat = "products_out.json";


        List<Product> danhSachSanPham = new List<Product>()
        {
            new Product(1, "Laptop Dell XPS 13", 2500, "Laptop"),
            new Product(2, "Smartphone iPhone 12", 1200, "Điện thoại"),
            new Product(3, "Smart TV Samsung 4K", 1500, "TV"),
        };


        Product.GhiVaoJSON(danhSachSanPham, fileXuat);
        Console.WriteLine($"Đã ghi danh sách sản phẩm vào tệp {fileXuat}");


        List<Product> sanPhamTuFile = Product.DocTuJSON(fileNhap);
        Console.WriteLine("\nDanh sách sản phẩm từ tệp:");
        foreach (var sp in sanPhamTuFile)
        {
            Console.WriteLine($"ID: {sp.Id}, Tên: {sp.Name}, Giá: {sp.Price}, Danh mục: {sp.Category}");
        }
    }
}
