using FlagLearner.Database;
using FlagLearner.Database.Entities;
using FlagLearner.Database.Repository;

namespace FlagLearner
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
        }
    }
}