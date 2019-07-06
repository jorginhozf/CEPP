using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCep.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppCep
{
    [Route("api/Endereco")]
    public class RestCepController : Controller
    {

        private readonly Context _context;

        public RestCepController(Context context)
        {
            _context = context;
        }

        [HttpGet("Enderecos")]
        public IEnumerable<Endereco> Listar()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();
            return enderecos;
        }

        [HttpGet("Enderecos/{cep}")]
        public IEnumerable<Endereco> ListarCEP(string cep)
        {
            var endereco = _context.Enderecos.Where(s => s.Cep == cep);
            return endereco;
        }

        [HttpGet("Enderecos/EnderecosPorEstado/{uf}")]
        public IEnumerable<Endereco> ListarEst(string uf)
        {
            List<Endereco> enderecos = _context.Enderecos.Where(s => s.Uf == uf).ToList();
            return enderecos;
        }
    }
}
