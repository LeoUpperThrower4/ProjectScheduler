using HelperFunctions;
using PSObjects;
using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // infinite loop so the console never leaves
        while (true)
        {
            // initializes a MainProject instace
            var mp = new MainProject();

            // asks wheter the user wants to open a saved project file or not...
            Console.Write("Hey there! Do you want to open a saved project? (Y/N) ");


            // if he wants... 
            if (Console.ReadLine().ToLower() == "y")
            {
                // open file given the ID
                mp = Helper.OpenFile(AskID());

                // if the file was not found, end the program...
                if (mp.ID != "404")
                {
                    // otherwise, show each project saved on the MainProject
                    for (int i = 0; i < mp.ProjectList.Count; i++)
                    {
                        Console.WriteLine("****************************");
                        Console.WriteLine(mp.ProjectList[i].ToString());
                    }
                }
            }
            // if he doesn't...
            else
            {
                // var to stores user's intention of adding or not another project
                var repeat = true;

                // ... starts the process of creating one
                while (repeat)
                {

                    // ask user answers to fill the project properties
                    var result = AskFillForm();

                    // creates the project and adds it to the projects list of the MainProject instance mp
                    mp.CreateProject(result.Item1, result.Item2, result.Item3, result.Item4);

                    // asks if user want to add another project
                    Console.Write("Would you like to add another project? (Y/N) ");

                    // if he wants, the loop restarts...
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        repeat = true;
                    }
                    // otherwise, it ends
                    else
                    {
                        repeat = false;

                        // asks the user for it's ID
                        mp.ID = AskID();

                        // save MainProject mp as file
                        Helper.SaveFile(mp);
                    }

                }
            }

            // just an indication that the program ended
            Console.WriteLine("****************************\n\n");

        }
    }

    /// <summary>
    /// Asks the user for the ID
    /// </summary>
    /// <returns>string containing the typed ID</returns>
    public static string AskID()
    {
        Console.Write("What's your ID? ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Responsable for asking the user the needed information to fill the project's form
    /// </summary>
    /// <returns>A tuple containing, respectively, the project's name (string), limit date (DateTimeOffset), materia (string) and description (string)</returns>
    public static (string, DateTimeOffset, string, string) AskFillForm()
    {
        // fills the form...
        Console.Write("What's the name of the project? ");
        var projectName = Console.ReadLine();

        // fills the form...
        Console.Write("What's the materia? ");
        var materia = Console.ReadLine();

        // fills the form...
        Console.Write($"What's the limit date? {CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern} ");
        DateTimeOffset limitDate;

        // loops while the parse fails - fails if parsed string is not a DateTimeOffset
        while (!(DateTimeOffset.TryParse(Console.ReadLine(), out limitDate)))
        {
            Console.Write($"Not a valible format." +
                $" Please try again. {CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern} ");
        }

        // fills the form...
        Console.Write("What's the project description? ");
        var projectDescription = Console.ReadLine();

        return (projectName, limitDate, materia, projectDescription);
    }
}
