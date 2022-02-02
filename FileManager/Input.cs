using System;

namespace FileManager {
    /// <summary>
    /// Класс для работы с пользовательским вводом
    /// </summary>
    public class Input {
        
        /// <summary>
        /// Метод для получения команды от пользователя и её дальнейшего запуска
        /// </summary>
        /// <param name="command">Объект класса Command</param>
        public static void CommandName(Command command) {
            command.Name = Console.ReadLine();
            command.Run();
        }
        
        /// <summary>
        /// Метод для ввода пользователем имени директории
        /// </summary>
        /// <returns>Имя директории, введенное</returns>
         public static string DirectoryName() {
            Console.WriteLine("Введите имя директории");
            return Console.ReadLine();
        }
         
        /// <summary>
        /// Метод для ввода пользователем имени диска
        /// </summary>
        /// <returns>Имя диска, введенное пользователем</returns>
        public static string DiskName() {
            Console.WriteLine("Введите имя диска");
            return Console.ReadLine();
        }
        
        /// <summary>
        /// Метод для ввода пользователем имени файла
        /// </summary>
        /// <returns>Имя файла, введенное пользователем</returns>
        public static string FileName() {
            Console.WriteLine("Введите имя файла");
            return Console.ReadLine();
        }

        /// <summary>
        /// Метод для ввода пользователем названия кодировки
        /// </summary>
        /// <returns>Название кодировки, введенное пользователем</returns>
        public static string Encoding() {
            Console.WriteLine("Введите название кодировки(utf8/utf32/unicode/asci)");
            return Console.ReadLine();
        }
    }
}