using System.IO;
using Save;
namespace Redactor
{
    class redactor
    {
        static void Main()
        {
            bool k = true;
            string path;
            while (k)
            {
               
                Console.WriteLine("Добро пожаловать в редактор");
                Console.WriteLine("Выбирете путь до файла \t Чтобы выйти нажмите Escape");
                ConsoleKeyInfo key = Console.ReadKey();
                 path = Console.ReadLine();
                path = ("C" + path);  // костыль.У меня почему то не передавался диск, хотя вводил я его вверно, пришлось таким способом добовлять
                Text_text text = new Text_text();
                text.text = File.ReadAllText(path);
                Info(text, path);
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Вы вышли из программы");
                    k = false;
                }
            }
        }
        static void Info(Text_text text, string path)
        {
            Console.Clear();
            Console.WriteLine("Если хотите сохранить текст, нажмите F1");
            Console.WriteLine(text.text);
            bool k = true;
            while (k)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.F1)
                {
                    k = false;
                    Saveworld.Serialized(text, path);
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    k = false;
                }
            }
        }
    }


}




