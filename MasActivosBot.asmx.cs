using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MasActivosBot
{
    /// <summary>
    /// Descripción breve de MasActivosBot
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class MasActivosBot : System.Web.Services.WebService
    {

        [WebMethod]
        public string DeleteDeudores(Boolean borrado_masivo, String entidad)
        {
            return deleteHelperDeudores(borrado_masivo, entidad);
        }      

        private string deleteHelperDeudores(Boolean borrado_masivo, String entidad)
        {
            //var client = new RestSharp.RestClient(ConfigurationManager.AppSettings["urlDeudores"]+"?entidad="+entidad);
            var client = new RestSharp.RestClient(ConfigurationManager.AppSettings["urlDeudores"] + "?entidad=" + entidad);
            var request = new RestSharp.RestRequest(RestSharp.Method.DELETE);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", ConfigurationManager.AppSettings["tokenDeudores"]);
       
            request.AddJsonBody(
                new
                {
                    borrado_masivo = borrado_masivo,
                }); ; ;

            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Content;

        }

        [WebMethod]
        public string GetDeudores(string idInterno)
        {
            return getHelperDeudores(idInterno);
        }

        private string getHelperDeudores(string idInterno)
        {
            var client = new RestSharp.RestClient(ConfigurationManager.AppSettings["urlDeudores"]);

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", ConfigurationManager.AppSettings["tokenDeudores"]);

            request.AddParameter("id", idInterno);

            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Content;
        }

        [WebMethod]
        //public string PostDeudores(string idinterno, string nombre, string documento, string deuda_total, string deuda_parcial, string nromedidor, string domicilio, string grupoyorden)
        public string PostDeudores(string jsonString)
        {
            //return postHelperDeudores(idinterno, nombre, documento, deuda_total, deuda_parcial, nromedidor, domicilio, grupoyorden);
            return postHelperDeudores(jsonString);
        }

        //private string postHelperDeudores(string idinterno, string nombre, string documento, string deuda_total, string deuda_parcial, string nromedidor, string domicilio, string grupoyorden)
        private string postHelperDeudores(string jsonString)
        {
            var client = new RestSharp.RestClient(ConfigurationManager.AppSettings["urlDeudores"]);

            var request = new RestSharp.RestRequest(RestSharp.Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", ConfigurationManager.AppSettings["tokenDeudores"]);
           
            //La estrategia es modelar un objeto(DataJson) y luego el array que contiene muchos(RoobObject), 
            //en el body se devuelve el array de esta clase que tiene el nombre "elems"
            
            RootObject datalist = JsonConvert.DeserializeObject<RootObject>(jsonString);
           
            //Estrategia para 1 solo objeto

            //elems elemento = new elems(idinterno, nombre, documento, deuda_total, deuda_parcial, nromedidor, domicilio, grupoyorden);
            //List<elems> list = new List<elems>();
            //list.Add(elemento);
            //elems[] arrayElems = list.ToArray();

            request.AddJsonBody(
                new
                {
                    //Caso de 1 solo elem
                    //elems = arrayElems,
                    datalist.elems,
                }); ;

            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Content;

        }

        [WebMethod]
        public string GetResoluciones(DateTime date)
        {
            return getHelperResoluciones(date);
        }

        private string getHelperResoluciones(DateTime date)
        {
            
            var client = new RestSharp.RestClient(ConfigurationManager.AppSettings["urlResoluciones"]);

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", ConfigurationManager.AppSettings["tokenResoluciones"]);

            request.AddParameter("date", date.ToString("yyyy-MM-dd"));

            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Content;                        
        }

        [WebMethod]
        public string DeleteResoluciones(Boolean borrado_masivo)
        {
            return deleteHelperResoluciones(borrado_masivo);
        }

        private string deleteHelperResoluciones(Boolean borrado_masivo)
        {
            var client = new RestSharp.RestClient(ConfigurationManager.AppSettings["urlResoluciones"]);

            var request = new RestSharp.RestRequest(RestSharp.Method.DELETE);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", ConfigurationManager.AppSettings["tokenResoluciones"]);

            request.AddJsonBody(
                new
                {
                    borrado_masivo = borrado_masivo,
                }); ; ;

            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Content;

        }


        [WebMethod]
        public string GetAvisos(DateTime date)
        {
            return getHelperAvisos(date);
        }

        private string getHelperAvisos(DateTime date)
        {

            var client = new RestSharp.RestClient(ConfigurationManager.AppSettings["urlAvisos"]);

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", ConfigurationManager.AppSettings["tokenAvisos"]);

            request.AddParameter("date", date.ToString("yyyy-MM-dd"));

            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Content;
        }

        [WebMethod]
        public string DeleteAvisos(Boolean borrado_masivo)
        {
            return deleteHelperAvisos(borrado_masivo);
        }

        private string deleteHelperAvisos(Boolean borrado_masivo)
        {
            var client = new RestSharp.RestClient(ConfigurationManager.AppSettings["urlAvisos"]);

            var request = new RestSharp.RestRequest(RestSharp.Method.DELETE);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", ConfigurationManager.AppSettings["tokenAvisos"]);

            request.AddJsonBody(
                new
                {
                    borrado_masivo = borrado_masivo,
                }); ; ;

            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Content;

        }
    }

}
