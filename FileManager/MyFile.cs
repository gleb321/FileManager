using System;
using System.IO;
using System.Text;

namespace FileManager {
    /// <summary>
    /// Класс для работы с файлами
    /// </summary>
    public class MyFile {
        
        /// <summary>
        /// Метод для определния типа кодировки, введённой пользователем
        /// </summary>
        /// <param name="encoding">Название кодировки, введённой пользователем</param>
        /// <returns>Объект класса Encoding</returns>
        public static Encoding EncodingType(string encoding) {
            switch (encoding) {
                case "utf32":
                    return Encoding.UTF32;
                case "utf8":
                    return Encoding.UTF8;
                case "unicode":
                    return Encoding.Unicode;
                case "asci":
                    return Encoding.ASCII;
                default:
                    Console.WriteLine("Кодировки с таким именем не существует");
                    return null;
            }
        }
        
        /// <summary>
        /// Метод для вывода текста из файла в консоль в кодировке UTF-8
        /// </summary>
        /// <param name="path">Путь до файла</param>
         public static void WriteText(string path) {
            Console.OutputEncoding = Encoding.UTF8;
            var reader = new StreamReader(path, Encoding.UTF8);
            string input;
            while ((input = reader.ReadLine()) != null) {
                Console.WriteLine(input);
            }
            reader.Close();
        }
        
        /// <summary>
        ///  Метод для вывода текста из файла в консоль в выбранной пользователем кодировке
        /// </summary>
        /// <param name="path">Путь до файла</param>
        /// <param name="encoding">Название кодировки</param>
        public static void WriteText(string path, string encoding) {
            if (EncodingType(encoding) != null) {
                Console.OutputEncoding = EncodingType(encoding);
                var reader = new StreamReader(path, EncodingType(encoding));
                string input;
                while ((input = reader.ReadLine()) != null) {
                    Console.WriteLine(input);
                }
                reader.Close();
            }
            Console.OutputEncoding = Encoding.UTF8;
        }
        
        /// <summary>
        /// Метод для записи текста из файла input.txt в выбранный пользователем файл, в выбранной пользователем кодировке
        /// </summary>
        /// <param name="path">Путь до файла</param>
        /// <param name="encoding">Название кодировки</param>
        public static void WriteTextTo(string path, string encoding) {
            if (EncodingType(encoding) != null) {
                var reader = new StreamReader(@"input.txt", Encoding.UTF8);
                var writer = new StreamWriter(path, false, EncodingType(encoding));
                string input;
                while ((input = reader.ReadLine()) != null) {
                    writer.WriteLine(input);
                }
                
                reader.Close();
                writer.Close();
            }
        }
        
        /// <summary>
        /// Метод для создания текстового файла в кодировке UTF-8
        /// </summary>
        /// <param name="path">Путь до файла</param>
        public static void CreateFile(string path) {
            File.Create(path).Close();
            var writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.WriteLine("");
            writer.Close();
        }
        
        /// <summary>
        /// Метод для создания текстового файла в кодировке, выбранной пользователем
        /// </summary>
        /// <param name="path">Путь до файла</param>
        /// <param name="encoding">Название кодировки</param>
        public static void CreateFile(string path, string encoding) {
            File.Create(path).Close();
            if (EncodingType(encoding) != null) {
                var writer = new StreamWriter(path, false, EncodingType(encoding));
                writer.WriteLine("");
                writer.Close();
                return;
            }

            File.Delete(path);
        }
        
        /// <summary>
        /// Метод для объединения двух текстовых файлов в кодировке UTF-8 в третий файл в кодировке UTF-8
        /// </summary>
        /// <param name="firstFileName">Имя первого файла</param>
        /// <param name="secondFileName">Имя второго файла</param>
        /// <param name="dirPath">Путь до директории, где находятся файлы</param>
        public static void ConcadTwoFiles(string firstFileName, string secondFileName, string dirPath) {
            string firstFilePath = Path.Combine(dirPath, firstFileName);
            string secondFilePath = Path.Combine(dirPath, secondFileName);
            /* Имя 3-го файла строится по следующему принципу: у имен двух файлов отбрасываются расширения,
            после этого они объединяются через _ и в конце добавляется .txt */
            string outputFilePath = Path.Combine(dirPath, firstFileName.Split('.')[0] + "_" + secondFileName.Split('.')[0] + ".txt");
            File.Create(outputFilePath).Close();
            var reader = new StreamReader(firstFilePath, Encoding.UTF8);
            var writer = new StreamWriter(outputFilePath, true, Encoding.UTF8);
            string input;
            while ((input = reader.ReadLine()) != null) {
                writer.WriteLine(input);
            }

            reader.Close();
            reader = new StreamReader(secondFilePath, Encoding.UTF8);
            while ((input = reader.ReadLine()) != null) {
                writer.WriteLine(input);
            }

            reader.Close();
            writer.Close();
        }

        /// <summary>
        /// Метод для объединения двух текстовых файлов в произвольной кодировке в третий файл в кодировке, выбранной пользователем
        /// </summary>
        /// <param name="firstFileName">Имя первого файла</param>
        /// <param name="secondFileName">Имя второго файла</param>
        /// <param name="dirPath">Путь до директории, где находятся файлы</param>
        /// <param name="enc1">Название кодировки первого файла</param>
        /// <param name="enc2">Название кодировки второго файла</param>
        /// <param name="enc3">Название кодировки, выбранной пользователем</param>
        public static void ConcadTwoFiles(string firstFileName, string secondFileName, string dirPath, string enc1, string enc2, string enc3) {
            if (EncodingType(enc1) != null && EncodingType(enc2) != null && EncodingType(enc3) != null) {
                string firstFilePath = Path.Combine(dirPath, firstFileName);
                string secondFilePath = Path.Combine(dirPath, secondFileName);
                /* Имя 3-го файла строится по следующему принципу: у имен двух файлов отбрасываются расширения,
                после этого они объединяются через _ и в конце добавляется .txt */
                string outputFilePath = Path.Combine(dirPath, firstFileName.Split('.')[0] + "_" + secondFileName.Split('.')[0] + ".txt");
                File.Create(outputFilePath).Close();
                var reader = new StreamReader(firstFilePath, EncodingType(enc1));
                var writer = new StreamWriter(outputFilePath, true, EncodingType(enc3));
                string input;
                while ((input = reader.ReadLine()) != null) {
                    writer.WriteLine(input);
                }

                reader.Close();
                reader = new StreamReader(secondFilePath, EncodingType(enc2));
                while ((input = reader.ReadLine()) != null) {
                    writer.WriteLine(input);
                }

                reader.Close();
                writer.Close();
            }
        }

        /// <summary>
        /// Метод для создания копии файла, выбранного пользователем
        /// </summary>
        /// <param name="dirPath">Путь до директории, где находится файл</param>
        /// <param name="fileName">Имя файла</param>
        public static void CreateCopy(string dirPath, string fileName) {
            string filePath = Path.Combine(dirPath, fileName);
            // Имя копии файла строится по следующему принципу: к названию файла без расширения добавляется -copy
            string copyPath = Path.Combine(dirPath, fileName.Split('.')[0] + "-copy" + "." + fileName.Split('.')[1]);
            File.Copy(filePath, copyPath);
        }
        
        /// <summary>
        /// Метод для перемещения выбранного пользователем файла в выбранную пользователем директорию
        /// </summary>
        /// <param name="currentPath">Путь до директории файла</param>
        /// <param name="newPath">Путь до выбранной пользователем директории</param>
        /// <param name="fileName">Имя файла</param>
        public static void MoveTo(string currentPath, string newPath, string fileName) {
            if (Directory.Exists(newPath)) {
                File.Move(Path.Combine(currentPath, fileName), Path.Combine(newPath, fileName));
            } else {
                Console.WriteLine("Директории с таким именем не существует");
            }
        }

        /// <summary>
        /// Метод для удаления файла, выбранного пользователем
        /// </summary>
        /// <param name="path">Путь до файла</param>
        public static void Delete(string path) {
            File.Delete(path);
        }
    }
}