using System;
using System.Collections.Generic;
using System.IO;
namespace FileAutoRemoverProgect
{
    [Serializable]
    class FileOptions
    {
        public enum EndOfFilesLifeOption
        {
            Nothing, Delete, Archive, Ask
        }
        public enum FileState
        {
            Alive, Deleted, Archivated
        }
        #region private_declarations
        
        private DateTime _creationDate;
        private FileState _state;
        #endregion

        #region public_declarations
        public DateTime CreationDate { get {return _creationDate;}  }
        public List<string> PathList { get; set; }
        public EndOfFilesLifeOption EndOfLifeOption { get; set; }
        public DateTime KillingTime { get; set; }
        public FileState State { get; }
        #endregion

        #region Constructors

        public FileOptions(List<string> pathList, 
            EndOfFilesLifeOption endOfLife, DateTime killingTime)
        {
            EndOfLifeOption = endOfLife;
            PathList = new List<string>();
            PathList.AddRange(pathList);
            _creationDate = DateTime.Now;
            KillingTime = killingTime;
            _state = FileState.Alive;
        }
        public FileOptions(string path, EndOfFilesLifeOption endOfLife, DateTime killingTime)
            : this(new List<string>(), endOfLife, killingTime)
        {
            PathList.Add(path);
        }

        public FileOptions(string path, EndOfFilesLifeOption endOfLife, TimeSpan killingTimeSpan)
            : this(path, endOfLife, DateTime.Now + killingTimeSpan)
        {

        }
        public FileOptions(List<string> pathList, 
            EndOfFilesLifeOption endOfLife, TimeSpan killingTimeSpan)
            : this(pathList, endOfLife, DateTime.Now + killingTimeSpan)
        {

        } 
        #endregion
        public void ExecuteDeletations()
        {
            switch (EndOfLifeOption)
            {
                case EndOfFilesLifeOption.Nothing:
                    
                    break;
                case EndOfFilesLifeOption.Delete:
                    Delete();
                    break;
                case EndOfFilesLifeOption.Archive:
                    ToArchive();
                    break;
                case EndOfFilesLifeOption.Ask:
                    //TODO вызов окна диалога выбора действия над файлами
                    break;
            }
            if (EndOfLifeOption != EndOfFilesLifeOption.Nothing)
            {
                //TODO Вывод оповещения
            }
        }
        private void ToArchive()
        {
            //TODO Архивация файлов
            Delete();
        }
        private void Delete()
        {
            foreach (var item in PathList)
            {
                File.Delete(item);
            }
        }
    }
}
