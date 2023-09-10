using server.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Linq;

namespace server.DAL
{
    public class TreeDataContext
    {
        private List<Node> _nodes;
        public List<Node> Nodes
        {
            get
            {
                return _nodes;
            }
            set
            {
                _nodes = value;
            }
        }

        private string? _dataPath;
        public string? DataPath
        {
            get
            {
                return _dataPath;
            }
            set
            {
                if (File.Exists(value))
                    _dataPath = value;
                else
                    throw new ArgumentException("Файл не найден");
            }
        }

        public async Task<List<Node>?> GetDataAsync()
        {
            List<Node>? nodes;


            using (FileStream fs = new(DataPath, FileMode.OpenOrCreate))
            {
                nodes = await JsonSerializer.DeserializeAsync<List<Node>>(
                    fs,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }

            return nodes;
        }

        public TreeDataContext(string dataPath)
        {
            DataPath = dataPath;
            Nodes = GetDataAsync().Result;
        }
    }
}
