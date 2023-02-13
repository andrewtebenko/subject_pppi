new ConsoleApp().Run();

class ConsoleApp
{
    private string selectMenu;

    private void GetUserData()
    {
        Console.WriteLine("Please, select any menu item");

        Console.WriteLine("1: Write some words of the text 'Lorem ipsum'");

        Console.WriteLine("2: Calculate a mathematical operation");

        selectMenu = Console.ReadLine();
    }

    private void CollectDataFromInput()
    {
        switch (selectMenu)
        {
            case "1":
                {
                    Console.WriteLine(ReadData());
                }
                break;
            case "2":
                {
                    Console.WriteLine(MultiplyData());
                }
                break;
            default:
                {
                    Console.WriteLine("You do something wrong!");
                }
                break;
        }
    }

    private string ReadData()
    {
        Console.WriteLine("Enter number of words");

        int numberOfWords = Int32.Parse(Console.ReadLine());

        StreamReader streamReader =
            new StreamReader("C:\\Users\\Acer\\source\\repos\\ConsoleApp1\\ConsoleApp1\\data.txt");
        
        string[] words = streamReader.ReadLine().Split(" ");
        
        return string.Join(" ", words.Take(numberOfWords));
    }

    private int MultiplyData()
    {
        return 10 * 3;
    }

    public void Run()
    {
        GetUserData();
        CollectDataFromInput();
    }
}