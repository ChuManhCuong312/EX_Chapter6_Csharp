using System;
using System.IO;

class Program
{
    // 2. Khai báo một biến chuỗi không đổi được gọi là "FilePath"
    private const string FilePath = "data.txt";

    // 3. Phương thức tạo file mới
    public static void CreateFile(string filePath)
    {
        File.Create(filePath).Close(); // Close the file to release the handle
        Console.WriteLine($"File '{filePath}' đã được tạo thành công.");
    }

    // 4. Phương thức ghi nội dung vào file
    public static void WriteToFile(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
        Console.WriteLine($"Nội dung đã được ghi vào file '{filePath}'.");
    }

    // 5. Phương thức đọc nội dung từ file
    public static void ReadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            Console.WriteLine($"Nội dung của '{filePath}':\n{content}");
        }
        else
        {
            Console.WriteLine($"File '{filePath}' không tồn tại.");
        }
    }

    // 6. Phương thức nối nội dung vào file
    public static void AppendToFile(string filePath, string content)
    {
        File.AppendAllText(filePath, content);
        Console.WriteLine($"Nội dung đã được nối vào file '{filePath}'.");
    }

    // 7. Phương thức xóa file
    public static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine($"File '{filePath}' được xóa thành công.");
        }
        else
        {
            Console.WriteLine($"File '{filePath}' không tồn tại.");
        }
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("\nChọn một chức năng:");
            Console.WriteLine("1. Tạo tệp");
            Console.WriteLine("2. Ghi vào tệp");
            Console.WriteLine("3. Đọc từ tệp");
            Console.WriteLine("4. Nối vào tệp");
            Console.WriteLine("5. Xóa tệp");
            Console.WriteLine("6. Thoát chương trình");
            Console.Write("Nhập lựa chọn của bạn: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Đầu vào không hợp lệ. Vui lòng nhập một số từ 1-6.");
                continue;
            }

            switch (choice)
            {
                case 1: // 8. Gọi phương thức CreateFile
                    CreateFile(FilePath);
                    break;
                case 2: // 9. Gọi phương thức WriteToFile
                    Console.Write("Nhập nội dung để ghi vào tệp:: ");
                    string writeContent = Console.ReadLine();
                    WriteToFile(FilePath, writeContent);
                    break;
                case 3: // 10. Gọi phương thức ReadFromFile
                    ReadFromFile(FilePath);
                    break;
                case 4: // 11. Gọi phương thức AppendToFile
                    Console.Write("Nhập nội dung để nối vào tệp:: ");
                    string appendContent = Console.ReadLine();
                    AppendToFile(FilePath, appendContent);
                    break;
                case 5: // 13. Gọi phương thức DeleteFile
                    DeleteFile(FilePath);
                    break;
                case 6: // Exit the program
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                    break;
            }
        }
    }
}
