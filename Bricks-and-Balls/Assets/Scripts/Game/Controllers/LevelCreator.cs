using System.IO;
using Newtonsoft.Json;


public class LevelLoader
{
    private Level level;

    public Level Level
    {
        get => level;
        set => level = value;
    }
    
    public void LoadLevel(string fileName)
    {
        StreamReader reader = new StreamReader(fileName);
        string json = reader.ReadToEnd();
        level = JsonConvert.DeserializeObject<Level>(json);
    }
}