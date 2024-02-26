using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace MilesCarRental_Repository
{
    /// <summary>
    /// Clase de utilidad para mapear instancias de DataTable a listas de objetos utilizando Newtonsoft.Json.
    /// </summary>
    public static class MapInstance
    {
        /// <summary>
        /// Convierte un DataTable en una lista de objetos del tipo especificado.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto al que se mapearán los datos.</typeparam>
        /// <param name="dataTable">DataTable que contiene los datos a ser mapeados.</param>
        /// <returns>Lista de objetos del tipo especificado.</returns>
        public static List<T> MapearInstanciaObjeto<T>(DataTable dataTable)
        {
            List<T> functionReturnValue = new List<T>();
            try
            {
                // Serializa el DataTable a formato JSON.
                string serializedObject = JsonConvert.SerializeObject(dataTable, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                // Deserializa el JSON a una lista de objetos del tipo especificado.
                if (serializedObject != null)
                {
                    functionReturnValue = (List<T>)JsonConvert.DeserializeObject(serializedObject, typeof(List<T>));
                }
            }
            catch (JsonSerializationException)
            {
                try
                {
                    // Si hay problemas con la serialización, intenta ajustar el formato JSON.
                    string serializedObject = JsonConvert.SerializeObject(dataTable, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    var sb = new StringBuilder(serializedObject);
                    sb[0] = string.Empty.FirstOrDefault();
                    sb[serializedObject.Length - 1] = string.Empty.FirstOrDefault();
                    serializedObject = sb.ToString();

                    // Deserializa el JSON ajustado a una lista de objetos del tipo especificado.
                    functionReturnValue = (List<T>)JsonConvert.DeserializeObject(serializedObject, typeof(List<T>));
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return functionReturnValue;
        }
    }
}
