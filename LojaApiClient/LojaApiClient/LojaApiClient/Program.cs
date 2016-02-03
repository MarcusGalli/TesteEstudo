using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LojaApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:18584/api/carrinho/1/produto/3467");
            request.Method = "DELETE";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusCode);
            
            Console.Read();
        }

        static void TestaGet()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:18584/api/carrinho/1");
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaGetXml()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:18584/api/carrinho/1");
            request.Method = "GET";
            request.Accept = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaGetJson()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:18584/api/carrinho/1");
            request.Method = "GET";
            request.Accept = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaPostJson()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:18584/api/carrinho/");
            request.Method = "POST";
            request.Accept = "application/json";

            //Adicione nessa string o Json sem quebras de linha
            string json = "{'Produtos':[{'Id':6237,'Preco':5000.0,'Nome':'PS 4','Quantidade':1},{'Id':3467,'Preco':3000.0,'Nome':'Xbox','Quantidade':2}],'Endereco':'Rua teste 3185, 8 andar, São Paulo','Id':1}";
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);

            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaPostXml()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:18584/api/carrinho/");
            request.Method = "POST";
            request.Accept = "application/json";

            //Adicione nessa string o Xml sem quebras de linha
            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/LojaApi.Models'><Endereco>Rua Vergueiro 3185, 8 andar, São Paulo</Endereco><Id>1</Id><Produtos><Produto><Id>6237</Id><Nome>Videogame 4</Nome><Preco>4000</Preco><Quantidade>1</Quantidade></Produto><Produto><Id>3467</Id><Nome>Jogo de esporte</Nome><Preco>60</Preco><Quantidade>2</Quantidade></Produto></Produtos></Carrinho>";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);

            request.ContentType = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaPost2()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:18584/api/carrinho/");
            request.Method = "POST";
            request.Accept = "application/json";

            //Adicione nessa string o Xml sem quebras de linha
            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/LojaApi.Models'><Endereco>Rua Vergueiro 3185, 8 andar, São Paulo</Endereco><Id>1</Id><Produtos><Produto><Id>6237</Id><Nome>Videogame 4</Nome><Preco>4000</Preco><Quantidade>1</Quantidade></Produto><Produto><Id>3467</Id><Nome>Jogo de esporte</Nome><Preco>60</Preco><Quantidade>2</Quantidade></Produto></Produtos></Carrinho>";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);

            request.ContentType = "application/xml";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers["Location"]);

            Console.Read();
        }
    }
}
