using Newtonsoft.Json;

class ProductionController
{
    private readonly string cupFileLocation = @".\cuplist.json";

    public void StartUp()
    {
        List<Cup> cupList = ReadCups();
    }

    public List<Cup> ReadCups()
    {
        string jsonFile = File.ReadAllText(cupFileLocation);
        Cup[] cups = null;
        if (jsonFile != null)
        {
            cups = JsonConvert.DeserializeObject<Cup[]>(jsonFile);
        }
        else
        {
            //let's be brutal, just kill things
            throw new Exception("Could not find the json file");
        }
        return cups.ToList();
    }

}
