﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CrudAngularDapper.DAL;
using CrudAngularDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAngularDapper.Controllers
{
    [Produces("application/json")]
    [Route("api/Fornecedor")]
    public class FornecedorController : Controller
    {
        private IFornecedorDAL fornecedorDAL;

        public FornecedorController(IFornecedorDAL _fornecDAL)
        {
            this.fornecedorDAL = _fornecDAL;
        }

        // GET: api/fornecedor
        [HttpGet]
        public async Task<IEnumerable<Fornecedor>> Get()
        {
            return await this.fornecedorDAL.GetFornecedores();
        }

        // GET: api/fornecedor/5
        [HttpGet("{id}")]
        public async Task<Fornecedor> Get(int id)
        {
            return await this.fornecedorDAL.GetFornecedor(id);
        }

        // POST: api/fornecedor
        [HttpPost]
        public async Task Post([FromBody]Fornecedor oFornecedor)
        {
            await this.fornecedorDAL.AdicionarFornecedor(oFornecedor);
        }

        // PUT: api/fornecedor/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Fornecedor oFornecedor)
        {
            await this.fornecedorDAL.AtualizarrFornecedor(oFornecedor);
        }

        // DELETE: api/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.fornecedorDAL.DeletarFornecedor(id);
        }
    }
}
