class Program
{
    public static int Main(String[] args)
    {
        ProductionController productionController = new ProductionController();
        productionController.StartUp();
        Console.WriteLine("Hello world");
        return 0;
    }
}
