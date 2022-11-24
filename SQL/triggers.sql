

-- DELETE PESSOAS

IF OBJECT_ID(N'UNIV.Delete_Func', N'TR') IS NOT NULL  
    DROP TRIGGER UNIV.Delete_Func
GO
CREATE Trigger Delete_Func ON UNIV.Funcionario
AFTER DELETE
AS
    DECLARE @CC CHAR(9)
	SELECT @CC = CC FROM deleted

    DELETE FROM UNIV.Pessoa WHERE CC=@CC
GO

IF OBJECT_ID(N'UNIV.Delete_Doc', N'TR') IS NOT NULL  
    DROP TRIGGER UNIV.Delete_Doc
GO
CREATE Trigger Delete_Doc ON UNIV.Docente
INSTEAD OF DELETE
AS
    DECLARE @CC CHAR(9)
	SELECT @CC = CC FROM deleted

    DELETE FROM UNIV.Docente WHERE CC=@CC
    DELETE FROM UNIV.Pessoa WHERE CC=@CC
GO

IF OBJECT_ID(N'UNIV.Delete_Inv', N'TR') IS NOT NULL  
    DROP TRIGGER UNIV.Delete_Inv
GO
CREATE Trigger Delete_Inv ON UNIV.Investigador
AFTER DELETE
AS
    DECLARE @CC CHAR(9)
	SELECT @CC = CC FROM deleted

    DELETE FROM UNIV.Pessoa WHERE CC=@CC
GO

IF OBJECT_ID(N'UNIV.Delete_Aln', N'TR') IS NOT NULL  
    DROP TRIGGER UNIV.Delete_Aln
GO
CREATE Trigger Delete_Aln ON UNIV.Aluno
INSTEAD OF DELETE
AS    
    DECLARE @CC CHAR(9)
	SELECT @CC = CC FROM deleted

    DECLARE @NUMERO INTEGER 
    SELECT @NUMERO=NUMERO FROM deleted

    DELETE FROM UNIV.Pert_Curso WHERE CODIGO_ALUNO=@NUMERO

    DELETE FROM UNIV.Aluno WHERE CC=@CC
    DELETE FROM UNIV.Pessoa WHERE CC=@CC
GO



-- DELETE LUGARES

IF OBJECT_ID(N'UNIV.Delete_Reit', N'TR') IS NOT NULL  
    DROP TRIGGER UNIV.Delete_Reit
GO
CREATE Trigger Delete_Reit ON UNIV.Reitoria
AFTER DELETE
AS
    DECLARE @ID VARCHAR(3)
	SELECT @ID = ID FROM deleted

    DELETE FROM UNIV.Local_Trabalho WHERE ID=@ID
GO

IF OBJECT_ID(N'UNIV.Delete_Campus', N'TR') IS NOT NULL  
    DROP TRIGGER UNIV.Delete_Campus
GO
CREATE Trigger Delete_Campus ON UNIV.Campus
AFTER DELETE
AS
    DECLARE @ID VARCHAR(3)
	SELECT @ID = ID FROM deleted

    DELETE FROM UNIV.Local_Trabalho WHERE ID=@ID
GO

IF OBJECT_ID(N'UNIV.Delete_Dep', N'TR') IS NOT NULL  
    DROP TRIGGER UNIV.Delete_Dep
GO
CREATE Trigger Delete_Dep ON UNIV.Departamento
AFTER DELETE
AS
    DECLARE @ID VARCHAR(3)
	SELECT @ID = ID FROM deleted

    DELETE FROM UNIV.Local_Trabalho WHERE ID=@ID
GO

-- DELETE CURSOS

IF OBJECT_ID(N'UNIV.Delete_Curso', N'TR') IS NOT NULL  
    DROP TRIGGER UNIV.Delete_Curso
GO
CREATE Trigger Delete_Curso ON UNIV.Curso
INSTEAD OF DELETE
AS
    DECLARE @CODIGO INT
	SELECT @CODIGO = CODIGO FROM deleted

    UPDATE Univ.Pert_Curso SET DATA_FIM=GETDATE() 
    WHERE CODIGO_CURSO=@CODIGO
    DELETE FROM UNIV.Curso WHERE CODIGO=@CODIGO
GO

