using FlagLearner.Database.Entities;
using System.Runtime.CompilerServices;

namespace FlagLearner.Database.Converters
{
    
    public static class LineConverter
    {
        public static string ToDomain(this Line line)
        {
            return line.ToString();
        }
    }
}
