using WinFormsApp1.CV;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string dir = Environment.CurrentDirectory;
            dir = Directory.GetParent(dir).Parent.Parent.FullName;
            dir = dir + "\\data";
            string[] files = Directory.GetFiles(dir);

            
            Applicant[] applicants = JsonReader.GetApplicants(files);
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }

        
    }
}