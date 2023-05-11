//// See https://aka.ms/new-console-template for more information


using System;

namespace TwitterTowers 
{
    internal class Program
    {
        //A function that prints the menu to the user
        public static void print_menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Rectangular tower");
            Console.WriteLine("2. Triangle tower");
            Console.WriteLine("3. Exit");
            string selected = Console.ReadLine();
            play_menu(selected);

        }

        //A function that operates according to the user's choice
        public static void play_menu(string selected)
        {
            switch (selected)
            {
                case "1":
                    rectangle();
                    print_menu();
                    break;
                case "2":
                    triangle();
                    print_menu();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Oops try again");
                    print_menu();
                    break;
            }
        }

        //Rectangle
        public static void rectangle()
        {
            
            int height=get_height();
            int width=get_width();
            if (height == width || (height - width) > 5 || (width - height) > 5)
            {
                Console.WriteLine("The area of the rectangle is: " + height * width);
            }
            else
            {
                Console.WriteLine("The perimeter of the rectangle is:" + 2 * (height + width));
            }
        }

        //Triangle
        public static void triangle()
        {
            int height = get_height();
            int width = get_width();

            bool proper = false;
            int choose;
            do
            {
                Console.WriteLine("1. perimeter of the triangle ");
                Console.WriteLine("2. Print the triangle"); string input = Console.ReadLine();
                proper = int.TryParse(input, out choose);
                if (!proper || choose > 2 || choose < 1)
                {
                    Console.WriteLine("Oops!!! Enter again...");
                }
            } while (!proper || choose > 2 || choose < 1);
            if (choose == 1)
            {
                double perimeter = width + Math.Sqrt(2 * Math.Pow(height, 2) + Math.Pow(width, 2));
                Console.WriteLine("The perimeter of the triangle is:" + perimeter.ToString("N2"));
            }
            else
            {
                if (width % 2 == 0 || width > 2 * height)
                {
                    Console.WriteLine("The triangle cannot be printed");
                }
                else
                {
                    //Checking how many odd numbers there are between the width and 1
                    int num_Odd = 0;
                    for (int i = width - 1; i > 1; i--)
                    {
                        if (i % 2 != 0)
                        {
                            num_Odd++;
                        }
                    }
                    //Checking how many rows of each number
                    int line_Odd = (height - 2) / num_Odd;
                    int remainder = (height - 2) % num_Odd;//the rest
                    int temp_line_Odd = line_Odd;
                    int padding = (width - 1) / 2;
                    Console.WriteLine(new string(' ', padding) + "*" + new string(' ', padding));
                    for (int i = 1, Odd = 3; i < height && Odd < width; i++)
                    {
                        padding = (width - Odd) / 2;
                        temp_line_Odd = line_Odd;
                        if (Odd == 3)
                        {
                            temp_line_Odd += remainder;
                        }
                        while (temp_line_Odd > 0)
                        {
                            Console.WriteLine(new string(' ', padding) + new string('*', Odd) + new string(' ', padding));
                            temp_line_Odd--;
                        }
                        Odd += 2;
                    }
                    //Printing the last line
                    Console.WriteLine(new string('*', width));
                }
            }
        }

        public static int get_height()
        {
            bool proper = false;
            int height;
            do
            {
                Console.WriteLine("Enter the height of the  tower");
                string input = Console.ReadLine();
                proper = int.TryParse(input, out height);
                if (!proper)
                {
                    Console.WriteLine("Oops!!! Enter again...");
                }
            } while (!proper);
            return height;
        }

        public static int get_width()
        {
            bool proper = false;
            int width;
            do
            {
                Console.WriteLine("Enter the width of the  tower");
                string input = Console.ReadLine();
                proper = int.TryParse(input, out width);
                if (!proper || width < 2)
                {
                    Console.WriteLine("Oops!!! Enter again...");
                }
            } while (!proper || width < 2);
            return width;
        }



        static void Main(string[] args)
        {
            print_menu();
        }
    }
}
