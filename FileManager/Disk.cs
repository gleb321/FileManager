using System;
using System.IO;

namespace FileManager {
    /// <summary>
    /// Класс для работы с дисками
    /// </summary>
    public class Disk {
        /// <summary>
        /// Метод для вывода списка дисков компьютера
        /// </summary>
        public static void ViewDisks() {
            Console.WriteLine();
            foreach (var drive in DriveInfo.GetDrives()) {
                Console.WriteLine(drive.Name);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Метода для установки пользователем диска
        /// </summary>
        /// <param name="directory">Объекта класса MyDirectory</param>
        /// <param name="diskName">Имя диска</param>
        public static void SetDisk(ref MyDirectory directory, string diskName) {
            if (Directory.Exists(diskName)) {
                directory = new(diskName, diskName);
            } else {
                Console.WriteLine("Диска с таким именем не существует");
            }
        }
    }
}