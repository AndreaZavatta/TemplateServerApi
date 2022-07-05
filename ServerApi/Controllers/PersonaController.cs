using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {

        public class Persona
        {
            [JsonPropertyName("Nome")]
            public string Nome { get; set; }
            [JsonPropertyName("Cognome")]
            public string Cognome { get; set; }
        }

        [HttpGet]
        [Route("GetPersone")]
        public List<Persona> GetPersone(string nome, string cognome)
        {
            List<Persona> l = new List<Persona>();
            l.Add(new Persona
            {
                Nome = "Stefano",
                Cognome = "Zavatta"
            });
            l.Add(new Persona
            {
                Nome = "Andrea",
                Cognome = "Zavatta"
            });
            l.Add(new Persona
            {
                Nome = "Marisa",
                Cognome = "Raggio"
            });
            l.Add(new Persona
            {
                Nome = "Romina",
                Cognome = "Zavatta"
            });

            if (!string.IsNullOrEmpty(nome))
                l = l.Where((q => q.Nome == nome)).ToList();
            if (!string.IsNullOrEmpty(cognome))
                l = l.Where((q => q.Cognome == cognome)).ToList();

            return l;
        }

        [HttpPost]
        [Route("SetPersona")]
        public bool SetPersona(Persona persona)
        {
            return true;
        }

    }
}
