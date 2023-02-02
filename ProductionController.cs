using Newtonsoft.Json;
using System.Net.Sockets;

class ProductionController
{
    private readonly string cupFileLocation = @".\cuplist.json";

    public void StartUp()
    {
        List<Cup> cupList = ReadCups();
        StartServer(cupList[0]);
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

    private bool StartServer(Cup cup)
    {
        Message message = Message.CreateMessage(MessageType.QUERY);

        TcpClient client = new TcpClient(cup.ip, cup.port); // have my connection established with a Tcp Server 

        NetworkStream strm = client.GetStream(); // the stream 
        var writer = new BinaryWriter(strm);

        writer.Write(JsonConvert.SerializeObject(message)); // the serialization process 

        while (true)
        {
            //don't stop won't stop
        }

        strm.Close();
        client.Close();
        return false;
    }

}
