//// Khai báo biến

//// Kiểu dữ kiệu - tên biến
//using System;

//int bien_a;

//// Kiểu dữ kiệu - tên biến
//int bien_b = 1;

//// Số nguyên: int, short, int32, int64
//int tuoi = 1;
//short tuoi4 = 1;

//// Số thực: float, double
//float tuoi1 = 1;
//double tuoi2 = 1;

//// Số thập phân: decimal
//decimal tuoi3 = 1;

//// Ký tự: string
//string HotTen = "abc";

//// for, foreach
//for (int i = 1; i < 10; i++)
//{
//    Console.WriteLine("Gia tri lap : " + i.ToString());
//}

//// foreach
//List<string> qua = new List<string>() { "apple", "mango" };
//foreach (var item in qua)
//{
//    Console.WriteLine(item);
//}

//// while
//int j = 1;
//while (j < 10)
//{
//    Console.WriteLine("Gia tri lap : " + j.ToString());
//    j++;
//}

//// Điều kiện if-else, switch-case
//if (bien_b == 1)
//{
//    Console.WriteLine("Gia trị bien_b : " + bien_b);
//}
//else
//{
//    Console.WriteLine("Gia trị bien_b khác 1 ");
//}

//int bien_switch = 3;
//switch (bien_switch)
//{
//    case 1:
//        Console.WriteLine("Gia trị bien_switch bằng 1 ");
//        break;
//    case 2:
//        Console.WriteLine("Gia trị bien_switch bằng 2 ");
//        break;
//    default: // case mặc định nếu không thỏa mãn các case khác
//        Console.WriteLine("Gia trị bien_switch khác 1, 2 ");
//        break;
//}

//Console.WriteLine(HotTen);


// Khai báo biến lưu Tuổi, họ tên, ngày sinh
// Tính và hiển thị tuổi đến năm 2030

// PascalCase
// camelCase
// UPPER_CASE
// https://viblo.asia/p/coding-conventions-trong-c-eW65Gg1j5DO

int tuoi = 20;
string hoTen = "ngoc";
DateTime ngaySinh = new DateTime(1999, 1, 1);

for (int i = 2023; i <= 2030; i++)
{
    //2023: 20 + 0 = 20 + (2023 - 2023)
    //2024: 20 + 1 = 20 + (2024 - 2023)
    //2025: 20 + 2 = 20 + (2025 - 2023)

    var tuoiMoi = tuoi + (i - 2023);
    Console.WriteLine("tuoi hien tai : " + tuoiMoi.ToString());
}