using System.Collections.Generic;
using aspcorechart.Models;

namespace aspcorechart.Services
{
    public class PopulacaoService
    {
        public static List<PopulacaoModel> GetPopulacaoPorEstado()
        {
            var lista = new List<PopulacaoModel>();
            lista.Add(new PopulacaoModel{ Cidade="São Paulo", Populacao2017 = 45094 , Populacao2010 = 39585 });
            lista.Add(new PopulacaoModel{ Cidade="Minas Gerais", Populacao2017 = 21119 , Populacao2010 =16715  });
            lista.Add(new PopulacaoModel{ Cidade="Rio de Janeiro", Populacao2017 = 16718 , Populacao2010 = 15464 });
            lista.Add(new PopulacaoModel{ Cidade="Bahia", Populacao2017 = 15344 , Populacao2010 = 10120 });
            lista.Add(new PopulacaoModel{ Cidade="Parana", Populacao2017 = 11320 , Populacao2010 = 8912 });
            return lista;
        }
    }
}