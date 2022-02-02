using System;
using System.IO;

namespace FileManager {
    /// <summary>
    /// Класс для работы с командами, введенных пользователем
    /// </summary>
    public class Command {
        public string Name { get; set; }
        private MyDirectory _currentDirectory;

        /// <summary>
        /// Конструктор класса Command
        /// </summary>
        /// <param name="userCommand">Имя команды</param>
        /// <param name="directory">Объект класса MyDirectory</param>
        public Command(string userCommand, MyDirectory directory) {
            Name = userCommand;
            _currentDirectory = directory;
        }
        
        /// <summary>
        /// Метод для запуска команды, введенной пользователем
        /// </summary>
        public void Run() {
            try {
                switch (Name) {
                    case "help":
                        Program.Help();
                        return;
                    case "vdisk":
                        Disk.ViewDisks();
                        return;
                    case "sdisk":
                        Disk.SetDisk(ref _currentDirectory, Input.DiskName());
                        return;
                    case "vfile":
                        _currentDirectory.WriteAllFiles();
                        return;
                    case "vdir":
                        _currentDirectory.WriteAllDirectories();
                        return;
                    case "mtdir":
                        _currentDirectory.MoveToIsPossible(Input.DirectoryName());
                        return;
                    case "cd":
                        _currentDirectory.BackToDisk();
                        return;
                    case "pwd":
                        _currentDirectory.ViewPath();
                        return;
                    case "cwf":
                        MyFile.WriteText(Path.Combine(_currentDirectory.Path, Input.FileName()));
                        return;
                    case "cwfe":
                        MyFile.WriteText(Path.Combine(_currentDirectory.Path, Input.FileName()), Input.Encoding());
                        return;
                    case "copyf":
                        MyFile.CreateCopy(_currentDirectory.Path, Input.FileName());
                        return;
                    case "fmtdir":
                        MyFile.MoveTo(_currentDirectory.Path, Input.DirectoryName(), Input.FileName());
                        return;
                    case "delf":
                        MyFile.Delete(Path.Combine(_currentDirectory.Path, Input.FileName()));
                        return;
                    case "crf":
                        MyFile.CreateFile(Path.Combine(_currentDirectory.Path, Input.FileName()) + ".txt");
                        return;
                    case "crfe":
                        MyFile.CreateFile(Path.Combine(_currentDirectory.Path, Input.FileName()) + ".txt", Input.Encoding());
                        return;
                    case "ctf":
                        MyFile.ConcadTwoFiles(Input.FileName(), Input.FileName(), _currentDirectory.Path);
                        return;
                    case "ctfe":
                        MyFile.ConcadTwoFiles(Input.FileName(), Input.FileName(), _currentDirectory.Path,
                            Input.Encoding(), Input.Encoding(), Input.Encoding());
                        return;
                    case "wtfe":
                        MyFile.WriteTextTo(Path.Combine(_currentDirectory.Path, Input.FileName()), Input.Encoding());
                        return;
                    case "stop":
                        Program.RunFlag = false;
                        return;
                    default:
                        Console.WriteLine("Команды с таким именем не существует");
                        Input.CommandName(this);
                        return;
                }
            } catch (ArgumentNullException) {
                Console.WriteLine("Диск не выбран");
            } catch (FileNotFoundException) {
                Console.WriteLine("Файла с таким именем не существует");
            } catch (IOException) {
                Console.WriteLine("Файл с таким именем уже существует");
            } catch (Exception exception) {
                Console.WriteLine($"Упс, что-то пошло не так:\n{exception}");
            }
        }
    }
}