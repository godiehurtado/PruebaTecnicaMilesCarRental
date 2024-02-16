using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace MilesCarRental_Repository
{
    public static class MapInstance
    {
        public static List<T> MapearInstanciaObjeto<T>(DataTable dataTable)
        {
            List<T> functionReturnValue = new List<T>();
            try
            {
                string serializedObject = JsonConvert.SerializeObject(dataTable, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                if (serializedObject != null)
                {
                    functionReturnValue = (List<T>)JsonConvert.DeserializeObject(serializedObject, typeof(List<T>));
                }
            }
            catch (JsonSerializationException)
            {
                try
                {
                    string serializedObject = JsonConvert.SerializeObject(dataTable, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    var sb = new StringBuilder(serializedObject);
                    sb[0] = string.Empty.FirstOrDefault();
                    sb[serializedObject.Length - 1] = string.Empty.FirstOrDefault();
                    serializedObject = sb.ToString();
                    functionReturnValue = (List<T>)JsonConvert.DeserializeObject(serializedObject, typeof(List<T>));
                }
                catch (Exception exc)
                { throw exc; }
            }
            catch (Exception ex)
            { throw ex; }
            return functionReturnValue;
        }
    }
}
