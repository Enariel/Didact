using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Didact.Components.Data;

public class DataManager : ComponentBase
{
    public bool _isModifyingData = false;
    protected bool IsModifyingData => _isModifyingData;

    [Inject] protected IJSRuntime Js { get; set; }
    [Inject] protected ILocalStorageService LocalStorage { get; set; }
    [Inject] protected ILogger<DataManager> Logger { get; set; }

    protected virtual async Task SaveAsync<TData>(string key, TData data, CancellationToken token = default)
    {
        _isModifyingData = true;
        string dataString = await SerializeToXmlDataContractAsync(data, token);
        await LocalStorage.SetItemAsStringAsync(key, dataString, token);
        _isModifyingData = false;
    }

    protected virtual async Task<TData> GetDataAsync<TData>(string key, CancellationToken token = default)
    {
        _isModifyingData = true;
        string dataString = await LocalStorage.GetItemAsStringAsync(key, token);
        TData data = default;
        if (!string.IsNullOrEmpty(dataString))
            data = await DeserializeFromXmlDataContractAsync<TData>(dataString, token);
        _isModifyingData = false;
        return data;
    }

    protected virtual async Task ClearAllDataAsync(CancellationToken token = default)
    {
        _isModifyingData = true;
        await LocalStorage.ClearAsync(token);
        _isModifyingData = false;
    }

    protected virtual async Task ClearDataAsync(string key, CancellationToken token = default)
    {
        _isModifyingData = true;
        await LocalStorage.RemoveItemAsync(key, token);
        _isModifyingData = false;
    }

    protected virtual async Task ClearDataAsync(string[] keys, CancellationToken token = default)
    {
        _isModifyingData = true;
        await LocalStorage.RemoveItemsAsync(keys, token);
        _isModifyingData = false;
    }

    protected Task<string> SerializeToXmlDataContractAsync<TData>(TData data, CancellationToken token = default)
    {
        _isModifyingData = true;
        try
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(TData));
            using var stringWriter = new StringWriter();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(XmlWriter.Create(stringWriter, new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                NamespaceHandling = NamespaceHandling.OmitDuplicates,
                NewLineHandling = NewLineHandling.None,
                NewLineOnAttributes = true,
                OmitXmlDeclaration = false,
                WriteEndDocumentOnClose = true
            }));
            ser.WriteObject(writer, data);
            writer.Flush();
            string xmlString = stringWriter.ToString();
            Console.Write(xmlString); // Print out the XML string
            _isModifyingData = false;
            return Task.FromResult(xmlString);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An error occurred during XML serialization.");
            _isModifyingData = false;
            throw;
        }
    }

    protected Task<TData> DeserializeFromXmlDataContractAsync<TData>(string dataStream, CancellationToken token = default)
    {
        _isModifyingData = true;
        DataContractSerializer ser = new DataContractSerializer(typeof(TData));
        using var stringReader = new StringReader(dataStream);
        XmlDictionaryReader reader = XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(stringReader, new XmlReaderSettings
        {
            CloseInput = true,
            DtdProcessing = DtdProcessing.Prohibit,
            IgnoreComments = true,
            IgnoreProcessingInstructions = false,
            IgnoreWhitespace = false,
        }));
        var data = (TData)ser.ReadObject(reader);
        reader.Close();
        Console.Write(data.ToString());
        _isModifyingData = false;
        return Task.FromResult(data);
    }

    protected Task<string> SerializeToXmlAsync<TData>(TData data, CancellationToken token = default)
    {
        if (!token.IsCancellationRequested)
        {
            _isModifyingData = true;
            XmlSerializer serializer = new XmlSerializer(typeof(TData));
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, data);
                string xml = sw.ToString();
                _isModifyingData = false;
                return Task.FromResult(xml);
            }
        }

        _isModifyingData = false;
        return Task.FromResult("");
    }

    protected Task<TData> DeserializeFromXmlAsync<TData>(string xmlString, CancellationToken token = default)
    {
        if (!token.IsCancellationRequested && !string.IsNullOrEmpty(xmlString))
        {
            _isModifyingData = true;
            XmlSerializer serializer = new XmlSerializer(typeof(TData));
            using (StringReader reader = new StringReader(xmlString))
            {
                TData obj = (TData)serializer.Deserialize(reader);
                _isModifyingData = false;
                return Task.FromResult(obj);
            }
        }

        _isModifyingData = false;
        return null;
    }
}