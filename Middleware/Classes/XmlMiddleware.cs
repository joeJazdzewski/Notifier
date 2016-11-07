using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Middleware.Interfaces;
using System.IO;

namespace Middleware.Classes
{
    public class XmlMiddleware<T> : Middleware<T>, IMiddleware<T> where T : class
    {
        private string _path;
        private string _fileName;
        private string _rootName;

        public XmlMiddleware(string path, string fileName, string rootName)
        {
            this._path = path;
            this._fileName = fileName;
            this._rootName = rootName;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (!File.Exists(_GenerateFullPath()))
                Write(null);
        }

        public override void Write(T model)
        {
            using (var Xw = XmlWriter.Create(this._GenerateFullPath()))
            {
                try
                {
                    Xw.WriteStartElement(this._rootName);
                    XmlSerializer ser = this._GenerateSerializer();
                    ser.Serialize(Xw, model);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    Xw.Close();
                }
            }
        }

        public override T Read()
        {
            using (var Xr = XmlReader.Create(this._GenerateFullPath()))
            {
                try
                {
                    Xr.ReadStartElement(this._rootName);
                    XmlSerializer ser = this._GenerateSerializer();
                    return (T)ser.Deserialize(Xr);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    Xr.Close();
                }
            }
        }

        private XmlSerializer _GenerateSerializer()
        {
            return new XmlSerializer(typeof(T));
        }
        private string _GenerateFullPath()
        {
            return new StringBuilder(this._path).Append("/").Append(_fileName).ToString();
        }
    }
}
