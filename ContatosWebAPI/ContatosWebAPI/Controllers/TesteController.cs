using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using ContatosWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContatosWebAPI.Controllers
{
    public class TesteController : Controller
    {
        //url base gerada para a minha máquina - pode ser necessário alterar
        string baseUrl = "http://localhost:57578/api/contato";
        public IActionResult Index()
        {
            //criando a lista de contato
            List<Contato> contatoLista = new List<Contato>();
            //criando uma instancia de httpClient
            using (HttpClient cliente = new HttpClient())
            {
                //definindo o endereço base
                cliente.BaseAddress = new Uri(baseUrl);
                //definindo o formato dos dados no request
                MediaTypeWithQualityHeaderValue contenttype = new MediaTypeWithQualityHeaderValue("application/json");
                cliente.DefaultRequestHeaders.Accept.Add(contenttype);
                //executando 
                HttpResponseMessage response = cliente.GetAsync("/api/contato").Result;

                if (response.IsSuccessStatusCode)
                {
                    var contatoResponse = response.Content.ReadAsStringAsync().Result;
                    contatoLista = JsonConvert.DeserializeObject<List<Contato>>(contatoResponse);
                }
            }
                return View(contatoLista);
        }
    }
}