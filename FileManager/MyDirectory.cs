using System;
using System.IO;

namespace FileManager {
    
    /// <summary>
    /// Класс для работы с директориями
    /// </summary>
    public class MyDirectory {
        private string _diskName;
        
        /// <summary>
        /// Конструктор класса FileManger
        /// </summary>
        /// <param name="path">Путь до директории</param>
        /// <param name="diskName">Имя диска</param>
        public MyDirectory(string path = null, string diskName = null) {
            Path = path;
            this._diskName = diskName;
        }

        public string Path { get; set; }

        /// <summary>
        /// Метод для спуска в директорию, выбранную пользователем
        /// </summary>
        /// <param name="dirName">Имя директории</param>
        private void MoveTo(string dirName) {
            Path = System.IO.Path.Combine(Path, dirName);
        }

        /// <summary>
        /// Метод для проверки возможности перехода в выбранную пользователем директорию
        /// </summary>
        /// <param name="dirName">Имя директории</param>
        /// <returns></returns>
        public bool MoveToIsPossible(string dirName) {
            if (Directory.Exists(System.IO.Path.Combine(Path, dirName))) {
                MoveTo(dirName);
                return true;
            }
            Console.WriteLine("Директории с таким именем не существует");
            return false;
        }

        /// <summary>
        /// Метод для возвращения в корневую директорию
        /// </summary>
        public void BackToDisk() {
            Path = _diskName;
        }

        /// <summary>
        /// Метод для вывода в консоль пути до текущей директории
        /// </summary>
        public void ViewPath() {
            Console.WriteLine(Path);
        }

        /// <summary>
        /// Метод для вывода в консоль всех имен доступных директорий 
        /// </summary>
        public void WriteAllDirectories() {
            Console.WriteLine();
            foreach (var dir in Directory.GetDirectories(Path)) {
                //Для удобства выводится только имя директории, без полного пути к ней 
                Console.WriteLine(dir.Split(System.IO.Path.DirectorySeparatorChar)[^1]);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Метод для вывода в консоль всех имен файлов директории
        /// </summary>
        public void WriteAllFiles() {
            Console.WriteLine();
            foreach (var file in Directory.GetFiles(Path)) {
                //Для удобства выводится только имя файла, без полного пути к нему
                Console.WriteLine(file.Split(System.IO.Path.DirectorySeparatorChar)[^1]);
            }
            
            Console.WriteLine();
        }
    }
}