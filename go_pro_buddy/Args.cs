using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;

namespace GoProFileOrganizer
{
    public class Args
    {
        //todo add method to print nicely prerun arguments

        public string destination;
        public string sourcePath;
        public int iterations;
        public List<FileEntry> files;
        public bool dryrun;
        public string exceptionInformation;
        public StringBuilder logText;

        public Args()
        {
            destination = "";
            sourcePath = "";
            iterations = 0;
            files = new List<FileEntry>();
            dryrun = true;
            exceptionInformation = "";
            logText = new StringBuilder();
        }

        public string Status()
        {
            return "Processing " + iterations.ToString() + " of " + files.Count.ToString();
        }


        //public FileManager fileManager = new FileManager();
        //public int progress = 1;
        //public string status { get; set; }
        // public List<string> files = new List<string>();
        //public List<string> fails = new List<string>();
        //public int pass = 0;
        //public int fail = 0;
        // this is the real deal failure system.... I hope
        //public List<Failure> failures = new List<Failure>();
        //public List<string> errorLogs = new List<string>();
        // keep me!!!
        //public FailureManager failManager = new FailureManager();
        //public int invalidFileName = 0;
        
        //public Metrics[] mets = new[]{
        //    new Metrics("video"),
        //    new Metrics("photo"),
        //    new Metrics("photoGroup")
        //    };
        //public int[,] metrics = new int[2, 2];
        //public Dictionary<string, int[]> metrics = new Dictionary<string, int[]>();
    }
}
