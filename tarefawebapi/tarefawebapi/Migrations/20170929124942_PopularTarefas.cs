using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace tarefawebapi.Migrations
{
    public partial class PopularTarefas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Tarefas(Nome,IsCompleta) VALUES('Terminar programa',0)");
            migrationBuilder.Sql("INSERT INTO Tarefas(Nome,IsCompleta) VALUES('Ajustar codigo de testes',1)");
            migrationBuilder.Sql("INSERT INTO Tarefas(Nome,IsCompleta) VALUES('Concluir documentação',0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.Sql("DELETE FROM Tarefas");
        }
    }
}
