using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using inCapsulam.Optimization;

namespace inCapsulam
{
    static class Program
    {
        public static Random rndm = new Random();

        public static Task TaskCurrent;
        public static List<Task> TasksList = new List<Task>();

        public static string SINGLE_REPORTS_DIRECTORY = 
            Environment.CurrentDirectory + "\\Отчёты о запусках";
        public static string STATISTICS_REPORTS_DIRECTORY = 
            Environment.CurrentDirectory + "\\Отчёты о статистических запусках";
        public static string STATISTICS_DATA_DIRECTORY = 
            Environment.CurrentDirectory + "\\Данные статистических запусков";
        public static string STATISTICS_GRAPHS_DIRECTORY = 
            Environment.CurrentDirectory + "\\Графики статистических запусков";
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!System.IO.Directory.Exists(SINGLE_REPORTS_DIRECTORY)) 
                System.IO.Directory.CreateDirectory(SINGLE_REPORTS_DIRECTORY);

            if (!System.IO.Directory.Exists(STATISTICS_REPORTS_DIRECTORY)) 
                System.IO.Directory.CreateDirectory(STATISTICS_REPORTS_DIRECTORY);

            if (!System.IO.Directory.Exists(STATISTICS_DATA_DIRECTORY)) 
                System.IO.Directory.CreateDirectory(STATISTICS_DATA_DIRECTORY);

            if (!System.IO.Directory.Exists(STATISTICS_GRAPHS_DIRECTORY)) 
                System.IO.Directory.CreateDirectory(STATISTICS_GRAPHS_DIRECTORY);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form_Main());
        }
    }
}
