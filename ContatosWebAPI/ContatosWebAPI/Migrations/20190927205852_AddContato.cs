using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ContatosWebAPI.Migrations
{
    public partial class AddContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO CONTATOS(ID,NOME, EMAIL, TELEFONE) VALUES(1,'Rafael Arthur','rafael.arthur@gmail.com','(18) 99659-6931')");
            migrationBuilder.Sql("INSERT INTO CONTATOS(ID,NOME, EMAIL, TELEFONE) VALUES(2,'Mariele','mariele@gmail.com','(18) 99659-6935')");
            migrationBuilder.Sql("INSERT INTO CONTATOS(ID,NOME, EMAIL, TELEFONE) VALUES(3,'Djalma Jorge','djalma.jorge@gmail.com','(18) 99659-6589')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM CONTATOS");
        }
    }
}
