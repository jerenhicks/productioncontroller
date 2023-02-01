using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
        //Person p = new Person("Tyler", "Durden", 30); // create my serializable object 


        TcpClient client = new TcpClient(cup.ip, cup.port); // have my connection established with a Tcp Server 

        IFormatter formatter = new BinaryFormatter(); // the formatter that will serialize my object on my stream 

        NetworkStream strm = client.GetStream(); // the stream 
        //formatter.Serialize(strm, p); // the serialization process 

        strm.Close();
        client.Close();
        return false;
    }

}
