USE [VENDAS]
GO
CREATE TABLE [dbo].[Fornecedores](
[FornecedorId][int] IDENTITY(1,1) NOT NULL,
[Nome][nvarchar](150) NOT NULL,
[Endereco][nvarchar](150) NOT NULL,
[ContatoNome][nvarchar](150) NOT NULL,
[Email][nvarchar](150) NOT NULL,
CONSTRAINT [PK_Fornecedores] PRIMARY KEY CLUSTERED
(
 [FornecedorId] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]