using ContatosWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ContatosWebAPI.Controllers
{
    //http://localhost:25377/api/contatos

    public class TesteController : Controller
    {
        string BaseUrl = "http://localhost:25377";

        public IActionResult Index()
        {
            //criando a lista de contatos
            List<Contato> contatoLista = new List<Contato>();

            //criando uma instancia de HttpClient
            using (HttpClient cliente = new HttpClient())
            {
                //definindo o endereço base
                cliente.BaseAddress = new Uri(BaseUrl);

                //definindo o formato dos dados no request
                MediaTypeWithQualityHeaderValue contentType = new
                    MediaTypeWithQualityHeaderValue("application/json");

                cliente.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = cliente.GetAsync("/api/contatos").Result;
                if(response.IsSuccessStatusCode)
                {
                    var contatoResponse = response.Content.ReadAsStringAsync().Result;
                    contatoLista = JsonConvert.DeserializeObject<List<Contato>>(contatoResponse);
                }
                return View(contatoLista);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            //apresentar o formulario(view) dos contatos
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            Contato contatoInfo = new Contato();

            using (HttpClient cliente = new HttpClient())
            {
                //define a url Base
                cliente.BaseAddress = new Uri(BaseUrl);
                //serializa os dados do objeto Contato
                string contatoSerializado = JsonConvert.SerializeObject(contato);
                //define o formato dos dados do request
                var conteudoDados = new StringContent(contatoSerializado, System.Text.Encoding.UTF8, "application/json");
                //Envia o request para encontrar o recurso de serviço REST exposto pela Web API
                HttpResponseMessage response = cliente.PostAsync("/api/contatos", conteudoDados).Result;
                //verifica se a resposta foi obtida com sucesso
                if (response.IsSuccessStatusCode)
                {
                    //armazena os detalhes da resposta recebidos da web api
                    var contatoResponse = response.Content.ReadAsStringAsync().Result;
                    //deserializa a resposta recebida e armazena no objeto Contato
                    contatoInfo = JsonConvert.DeserializeObject<Contato>(contatoResponse);
                    //redireciona para a Action "Index"
                    return RedirectToAction(nameof(Index));
                }
                return View(contatoInfo);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Contato contato = new Contato();
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = cliente.GetAsync("/api/contatos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var contatoResposta = response.Content.ReadAsStringAsync().Result;
                    contato = JsonConvert.DeserializeObject<Contato>(contatoResposta);
                }
                return View(contato);
            }
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            Contato contato = new Contato();
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = cliente.GetAsync("/api/contatos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var contatoResposta = response.Content.ReadAsStringAsync().Result;
                    contato = JsonConvert.DeserializeObject<Contato>(contatoResposta);
                }
                return View(contato);
            }
        }


        [HttpPost]
        public IActionResult Edit(Contato contato)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(BaseUrl);
                string stringData = JsonConvert.SerializeObject(contato);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = cliente.PutAsync("/api/contatos/" + contato.Id, contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    var contatoResultado = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }
                return View(contato);
            }
        }

        public IActionResult Delete(int id)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = cliente.GetAsync("/api/contatos/" + id).Result;
                var contatoResposta = response.Content.ReadAsStringAsync().Result;
                Contato contatoDados = JsonConvert.DeserializeObject<Contato>(contatoResposta);
                return View(contatoDados);
            }
        }




        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = cliente.DeleteAsync("/api/contatos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var contatoResposta = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
        }
    }
}