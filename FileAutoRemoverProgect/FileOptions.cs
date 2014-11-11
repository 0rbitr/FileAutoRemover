using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAutoRemoverProgect
{
    class FileOptions
    {
        public enum EndOfFilesLifeOption
        {
            Nothing, Delete, Backup, Ask
        }
        #region private_declarations
        
        private DateTime _creationDate;
        #endregion

        #region public_declarations
        public DateTime CreationDate { get {return _creationDate;}  }
        public string Path { get; set; }
        public EndOfFilesLifeOption EndOfLifeOption { get; set; }
        public DateTime KillingTime { get; set; }
       
        #endregion
       
        public FileOptions(string path, EndOfFilesLifeOption endOfLife, DateTime killingTime)
        {
            EndOfLifeOption = endOfLife;
            Path = path;
            _creationDate = DateTime.Now;
            KillingTime = killingTime;

        }
        public FileOptions(string path, EndOfFilesLifeOption endOfLife, TimeSpan killingTimeSpan)
            :this(path,endOfLife,DateTime.Now + killingTimeSpan)
        {
           
        }

    }
}
