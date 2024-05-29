namespace ExceptionalHandling
{
    internal class DividedByZeroExceptionclass
    {
        static void Main(string[] args)
        {
         
            int x;
            Console.Write("Enter x value: ");
            x = Convert.ToInt32(Console.ReadLine());

            int y;
            Console.Write("Enter y value: ");
            y = Convert.ToInt32(Console.ReadLine());
            try
            {
                int z = y / x;

            }catch(DivideByZeroException)
            {
                Console.WriteLine("Cannot divided by zero");

            }


        }
    }
}
