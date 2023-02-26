// See https://aka.ms/new-console-template for more information

using ADOnet;


var dbService = new StudentsVisitationService();
//dbService.CreateTable();
Console.WriteLine("Здесь вы можете создать таблицу студентов и их посещений\n");

dbService.CreateTableStudents();
dbService.CreateTableVisitations();

Console.WriteLine("Чтобы добавить студента или посещения, следуйте инструкции: \n");

while (true)
{
    Console.Clear();
    Console.WriteLine("Чтобы добавить студента нажмите 1\n" +
                      "Чтобы добавить студента в таблицу посещений 2\n" +
                      "Чтобы выйти, нажмите 0");
    var answer = Console.ReadLine();
    if (answer == "0")
        break;

    string name = String.Empty;

    switch (answer)
    {
        case "1":
            Console.WriteLine("Введите имя: ");
            while (true)
            {
                name = Console.ReadLine();
                if (name == null)
                    Console.WriteLine("Поле обязательное для ввода");
                else break;
            }

            Console.WriteLine("Введите год: ");
            while (true)
            {
                DateOnly date;
                if (DateOnly.TryParseExact(Console.ReadLine(), "dd.mm.yyyy", out date))
                {
                    break;
                }
                else Console.WriteLine("Неверный формат");
            }

            break;

        case "2":
            Console.WriteLine("Введите имя: ");
            while (true)
            {
                name = Console.ReadLine();
                if (name == null)
                    Console.WriteLine("Поле обязательное для ввода");
                else break;
            }

            Console.WriteLine("Введите год: ");
            while (true)
            {
                DateOnly date;
                if (DateOnly.TryParseExact(Console.ReadLine(), "dd.mm.yyyy", out date))
                {
                    break;
                }
                else Console.WriteLine("Неверный формат");
            }

            break;
    }
}