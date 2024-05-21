namespace SeedingLayer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await SeedManager.CreateUsersAsync();
                Console.WriteLine("Database seeded successfully!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}