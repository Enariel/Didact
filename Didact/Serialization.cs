using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Didact;

public static class Serialization
{
    public static Task<string> SerializeToXmlDataContractAsync<TData>(TData data, CancellationToken token = default)
    {
        if (token.IsCancellationRequested)
            return null;
        if (data == null)
            return null;
        try
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(TData));
            using var stringWriter = new StringWriter();
            XmlDictionaryWriter xmlWriter = XmlDictionaryWriter.CreateDictionaryWriter(XmlWriter.Create(stringWriter, new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                NamespaceHandling = NamespaceHandling.OmitDuplicates,
                NewLineHandling = NewLineHandling.None,
                NewLineOnAttributes = true,
                OmitXmlDeclaration = false,
                WriteEndDocumentOnClose = true
            }));
            serializer.WriteObject(xmlWriter, data);
            xmlWriter.Flush();
            string xmlString = stringWriter.ToString();
            Console.Write(xmlString); // Print out the XML string
            return Task.FromResult(xmlString);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message, "An error occurred during XML serialization.");
            throw;
        }

        return null;
    }

    public static Task<TData> DeserializeFromXmlDataContractAsync<TData>(string xmlString, CancellationToken token = default)
    {
        if (token.IsCancellationRequested)
            return null;
        if (string.IsNullOrEmpty(xmlString))
            return null;
        if (xmlString.Length == 0)
            return null;
        DataContractSerializer serializer = new DataContractSerializer(typeof(TData));
        using var stringReader = new StringReader(xmlString);
        XmlDictionaryReader xmlReader = XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(stringReader, new XmlReaderSettings
        {
            CloseInput = true,
            DtdProcessing = DtdProcessing.Prohibit,
            IgnoreComments = true,
            IgnoreProcessingInstructions = false,
            IgnoreWhitespace = false,
        }));
        var data = (TData)serializer.ReadObject(xmlReader);
        xmlReader.Close();
        Console.Write(data.ToString());
        return Task.FromResult(data);
    }

    public static Task<string> SerializeToXmlAsync<TData>(TData data, CancellationToken token = default)
    {
        if (!token.IsCancellationRequested)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TData));
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, data);
                string xml = sw.ToString();
                return Task.FromResult(xml);
            }
        }

        return null;
    }

    public static Task<TData> DeserializeFromXmlAsync<TData>(string xmlString, CancellationToken token = default)
    {
        if (token.IsCancellationRequested)
            return null;
        if (string.IsNullOrEmpty(xmlString))
            return null;
        if (xmlString.Length == 0)
            return null;
        if (!token.IsCancellationRequested && !string.IsNullOrEmpty(xmlString))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TData));
            using (StringReader reader = new StringReader(xmlString))
            {
                TData obj = (TData)serializer.Deserialize(reader);
                return Task.FromResult(obj);
            }
        }

        return null;
    }
}