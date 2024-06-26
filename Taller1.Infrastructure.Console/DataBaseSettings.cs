namespace Taller1.Infrastructure.Console
{
    public interface IDataBaseSettings
    {
        public string MySql { get; set; }
    }

    public class DataBaseSettings : IDataBaseSettings
    {
        public string MySql { get; set; }
    }
}