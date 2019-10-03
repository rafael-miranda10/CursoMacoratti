USE [Vendas]
GO
CREATE PROCEDURE [dbo].[AdicionarFornecedor]
	@nome nvarchar(150),
	@endereco nvarchar(150),
	@contatoNome nvarchar(150),
	@email nvarchar(150)
AS
BEGIN
	INSERT INTO dbo.Fornecedores values (@nome, @endereco, @contatoNome, @email)
END

---------------------------------------------------------------------
USE [Vendas]
GO
CREATE PROCEDURE [dbo].[AtualizaFornecedor]
	@fornecedorId INT,
	@nome nvarchar(50),
	@endereco nvarchar(max),
	@contatoNome nvarchar(50),
	@email nvarchar(150)
AS
BEGIN
	UPDATE Fornecedores SET nome=@nome, endereco=@endereco, contatoNome=@contatoNome, email = @email WHERE fornecedorId = @fornecedorId
END
------------------------------------------------------------------------
USE [Vendas]
GO
CREATE PROCEDURE [dbo].[DeletaFornecedor]
(@id INT)
AS
BEGIN
	DELETE FROM Fornecedores WHERE FornecedorId = @id
END
------------------------------------------------------------------------------
USE [Vendas]
GO
CREATE PROCEDURE [dbo].[GetFornecedores]
AS
BEGIN
	SELECT * FROM Fornecedores
END
--------------------------------------------------------------------------