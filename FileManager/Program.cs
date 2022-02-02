using System;
using System.IO;

namespace FileManager {
    class Program {
        public static bool RunFlag = true;
        
        /// <summary>
        /// Метод для вывода в консоль справки по доступным командам
        /// </summary>
        public static void Help() {
            string path = @"help.txt";
            if (File.Exists(path)) {
                var reader = new StreamReader(path);
                string input;
                while ((input = reader.ReadLine()) != null) {
                    Console.WriteLine(input);
                }
            } else {
                Console.WriteLine("Упс...файл помощник пропал, поищи в папке проекта файл help.txt");
            }
        }
        
        static void Main(string[] args) {
            Console.WriteLine("Добро пожаловать в файловый менеджер, " +
                              "перед использованием настоятельно рекомендую заглянуть в Readme.");
            Console.WriteLine("Доступные команды:");
            Help();
            MyDirectory currentDirectory = new MyDirectory();
            Command command = new Command("help", currentDirectory);
            do {
                command.Name = Console.ReadLine();
                command.Run();
            } while (RunFlag);
        }
    }
}