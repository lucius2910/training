        int chieudai = 6; 
        for (int i = 1; i <= chieudai; i++)
        {
       
            for (int j = 1; j <= chieudai - i; j++)
            {
                Console.Write(" ");
            }

            for (int k = 1; k <= 2 * i - 1; k++)
            {
                Console.Write("*");
            }

          
            Console.WriteLine();
        }
    
