int chieudai = 6; 
for (int i = 1; i <= chieudai; i++)
{
       
    for (int j = 1; j <= chieudai - i; j++)
    {
        Console.Write("0 ");
    }

    for (int k = 1; k <= 2 * i - 1; k++)
    {
        Console.Write("* ");
    }

    for (int j = chieudai * 2 - 1; j >= chieudai; j--)
    {
        if (j - chieudai >= i)
            Console.Write("0 ");
    }
 
    Console.WriteLine();
}


Console.WriteLine("=====================================================");

for (int i = 1; i <= chieudai; i++)
{

    for (int k = 1; k <= (chieudai * 2 - 1); k++)
    {
        if (k >= i && k <= (chieudai * 2 - i))
            Console.Write("* ");
        else
            Console.Write("0 ");
    }

    Console.WriteLine();
}