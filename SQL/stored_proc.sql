
-- INSERIR PESSOAS
DROP PROC UNIV.Insert_Func
GO
CREATE PROC UNIV.Insert_Func @CC char(8), @NIF char(9), 
@NOME varchar(256), @NUMERO INT, @FUNCAO VARCHAR(256) = null,
@ID_TRAB VARCHAR(3) = null
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN
            INSERT INTO UNIV.Pessoa VALUES (@NOME, @CC, @NIF)
            SET @rcount += @@rowcount

            INSERT INTO UNIV.Funcionario VALUES (@CC, @NUMERO, @FUNCAO, @ID_TRAB)
            SET @rcount += @@rowcount
            
            IF @rcount < 2
                ROLLBACK TRAN 
            ELSE
                COMMIT TRAN
GO

DROP PROC UNIV.Insert_Doc
GO
CREATE PROC UNIV.Insert_Doc @CC char(8), @NIF char(9), 
@NOME varchar(256), @TELEFONE CHAR(9), @ID_DEP VARCHAR(3),
@REF_PROJETO VARCHAR(256) = null, @COD_CURSO INT = 0
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN 
        INSERT INTO UNIV.Pessoa VALUES (@NOME, @CC, @NIF)
        SET @rcount += @@rowcount

        INSERT INTO UNIV.Docente VALUES (@CC, @TELEFONE, @ID_DEP, @REF_PROJETO)
        SET @rcount += @@rowcount

        IF @COD_CURSO <> 0
            UPDATE UNIV.Curso SET CC_DIRETOR=@CC WHERE CODIGO=@COD_CURSO
        
        IF @rcount < 2
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

DROP PROC UNIV.Insert_Inv
GO
CREATE PROC UNIV.Insert_Inv @CC char(8), @NIF char(9), 
@NOME varchar(256), @TELEFONE CHAR(9), @ID_DEP VARCHAR(3),
@REF_PROJETO VARCHAR(256)
AS
    DECLARE @rcount INT
    SET @rcount=0
    
    BEGIN TRAN    
        INSERT INTO UNIV.Pessoa VALUES (@NOME, @CC, @NIF)
        SET @rcount += @@rowcount

        INSERT INTO UNIV.Investigador VALUES (@CC, @TELEFONE, @ID_DEP, @REF_PROJETO)
        SET @rcount += @@rowcount
        
        IF @rcount < 2
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

DROP PROC UNIV.Insert_Aln 
GO
CREATE PROC UNIV.Insert_Aln @CC char(8), @NIF char(9), 
@NOME varchar(256), @NUMERO INT, @ANO INT, @N_MAT INT,  
@REF_PROJETO VARCHAR(256) = null, @COD_CURSO INTEGER,
@DATA_INIC DATE, @DATA_FIM DATE=null
AS  
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN
        INSERT INTO UNIV.Pessoa VALUES (@NOME, @CC, @NIF)
        SET @rcount += @@rowcount

        INSERT INTO UNIV.Aluno VALUES (@CC, @NUMERO, @ANO, @N_MAT, @REF_PROJETO)
        SET @rcount += @@rowcount

        IF @DATA_FIM IS NULL
            INSERT INTO UNIV.Pert_Curso (CODIGO_ALUNO, CODIGO_CURSO, DATA_INICIO) VALUES (@NUMERO, @COD_CURSO, @DATA_INIC)
        ELSE
            INSERT INTO UNIV.Pert_Curso (CODIGO_ALUNO, CODIGO_CURSO, DATA_INICIO, DATA_FIM) VALUES (@NUMERO, @COD_CURSO, @DATA_INIC, @DATA_FIM)
        SET @rcount += @@rowcount

        IF @rcount < 3
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

DROP PROC UNIV.Insert_Aln_Curso
GO
CREATE PROC UNIV.Insert_Aln_Curso @NUMERO INTEGER,
@COD_CURSO INTEGER, @DATA_INIC DATE, @DATA_FIM DATE=null
AS  
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN
        INSERT INTO UNIV.Pert_Curso (CODIGO_ALUNO, CODIGO_CURSO, DATA_INICIO) VALUES (@NUMERO, @COD_CURSO, @DATA_INIC)
        SET @rcount += @@rowcount

        IF @DATA_FIM IS NOT NULL
            UPDATE UNIV.Pert_Curso SET DATA_FIM=@DATA_FIM WHERE CODIGO_ALUNO=@NUMERO AND CODIGO_CURSO=@COD_CURSO

        IF @rcount < 1
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

-- UPDATE PESSOAS
DROP PROC UNIV.Update_Func
GO
CREATE PROC UNIV.Update_Func @CC char(8), @NIF char(9), 
@NOME varchar(256), @NUMERO INT, @FUNCAO VARCHAR(256) = null,
@ID_TRAB VARCHAR(3) = null
AS
    DECLARE @rcount INT
    SET @rcount=0
    
    BEGIN TRAN    
        UPDATE UNIV.Pessoa SET NOME=@NOME WHERE CC=@CC
        SET @rcount += @@rowcount

        UPDATE UNIV.Funcionario SET NUMERO=@NUMERO, FUNCAO=@FUNCAO, ID_TRAB=@ID_TRAB WHERE CC=@CC
        SET @rcount += @@rowcount

        IF @rcount < 2
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

DROP PROC UNIV.Update_Doc
GO
CREATE PROC UNIV.Update_Doc @CC char(8), @NIF char(9), 
@NOME varchar(256), @TELEFONE CHAR(9), @ID_DEP VARCHAR(3),
@REF_PROJETO VARCHAR(256) = null, @COD_CURSO INT = 0
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN    
        UPDATE UNIV.Pessoa SET NOME=@NOME WHERE CC=@CC
        SET @rcount += @@rowcount

        UPDATE UNIV.Docente SET TELEFONE=@TELEFONE, 
        ID_DEP=@ID_DEP, REF_PROJETO=@REF_PROJETO WHERE CC=@CC
        SET @rcount += @@rowcount

        IF @COD_CURSO <> 0
            UPDATE UNIV.Curso SET CC_DIRETOR=@CC WHERE CODIGO=@COD_CURSO

        IF @rcount < 2
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

DROP PROC UNIV.Update_Inv
GO
CREATE PROC UNIV.Update_Inv @CC char(8), @NIF char(9), 
@NOME varchar(256), @TELEFONE CHAR(9), @ID_DEP VARCHAR(3),
@REF_PROJETO VARCHAR(256)
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN
        UPDATE UNIV.Pessoa SET NOME=@NOME WHERE CC=@CC
        SET @rcount += @@rowcount

        UPDATE UNIV.Investigador SET TELEFONE=@TELEFONE, 
        ID_DEP=@ID_DEP, REF_PROJETO=@REF_PROJETO WHERE CC=@CC
        SET @rcount += @@rowcount
        
        IF @rcount < 2
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

DROP PROC UNIV.Update_Aln
GO
CREATE PROC UNIV.Update_Aln @CC char(8), @NIF char(9), 
@NOME varchar(256), @NUMERO INT, @ANO INT, @N_MAT INT,  
@REF_PROJETO VARCHAR(256)
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN
        UPDATE UNIV.Pessoa SET NOME=@NOME WHERE CC=@CC
        SET @rcount += @@rowcount

        UPDATE UNIV.Aluno SET NUMERO=@NUMERO, ANO=@ANO, 
        N_MATRICULAS=@N_MAT, REF_PROJETO=@REF_PROJETO WHERE CC=@CC
        SET @rcount += @@rowcount
        
        IF @rcount < 2
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

DROP PROC UNIV.Update_Aln_Curso
GO
CREATE PROC UNIV.Update_Aln_Curso @NUMERO INTEGER,
@COD_CURSO INTEGER, @DATA_INIC DATE, @DATA_FIM DATE=null
AS  
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN
        UPDATE UNIV.Pert_Curso SET DATA_INICIO=@DATA_INIC WHERE CODIGO_ALUNO=@NUMERO AND CODIGO_CURSO=@COD_CURSO
        SET @rcount += @@rowcount

        IF @DATA_FIM IS NOT NULL
            UPDATE UNIV.Pert_Curso SET DATA_FIM=@DATA_FIM WHERE CODIGO_ALUNO=@NUMERO AND CODIGO_CURSO=@COD_CURSO

        IF @rcount < 1
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

---------------------------------------------------------------------------------------


-- INSERIR LUGARES

DROP PROC UNIV.Insert_Reit
GO
CREATE PROC UNIV.Insert_Reit @ID varchar(3), @ENDEREÇO VARCHAR(256), 
@NOME varchar(256), @NOME_UNIV VARCHAR(256)
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN    
        INSERT INTO UNIV.Local_Trabalho VALUES (@ID, @NOME, @ENDEREÇO)
        SET @rcount += @@rowcount

        INSERT INTO UNIV.Reitoria VALUES (@ID, @NOME_UNIV)
        SET @rcount += @@rowcount
        
        IF @rcount < 2
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

DROP PROC UNIV.Insert_Campus
GO
CREATE PROC UNIV.Insert_Campus @ID varchar(3), @ENDEREÇO VARCHAR(256), 
@NOME varchar(256)
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN
        INSERT INTO UNIV.Local_Trabalho VALUES (@ID, @NOME, @ENDEREÇO)
        SET @rcount += @@rowcount

        INSERT INTO UNIV.Campus VALUES (@ID)
        SET @rcount += @@rowcount
        
        IF @rcount < 2
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

DROP PROC UNIV.Insert_Dep
GO
CREATE PROC UNIV.Insert_Dep @ID varchar(3), @ENDEREÇO VARCHAR(256), 
@NOME varchar(256), @TELEFONE CHAR(9), @HORARIO varchar(256) = null,
@BAR BIT = 0
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN
        INSERT INTO UNIV.Local_Trabalho VALUES (@ID, @NOME, @ENDEREÇO)
        SET @rcount += @@rowcount

        INSERT INTO UNIV.Departamento VALUES (@ID, @TELEFONE, @HORARIO, @BAR)
        SET @rcount += @@rowcount
        
        IF @rcount < 2
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

-- UPDATE LUGARES

DROP PROC UNIV.Update_Reit
GO
CREATE PROC UNIV.Update_Reit @ID varchar(3), @ENDEREÇO VARCHAR(256), 
@NOME varchar(256), @NOME_UNIV VARCHAR(256)
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN
        UPDATE UNIV.Local_Trabalho SET NOME=@NOME, ENDEREÇO=@ENDEREÇO WHERE ID=@ID
        SET @rcount += @@rowcount

        UPDATE UNIV.Reitoria SET NOME_UNIV=@NOME_UNIV WHERE ID=@ID
        SET @rcount += @@rowcount
        
        IF @rcount < 2
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN 
GO

DROP PROC UNIV.Update_Campus
GO
CREATE PROC UNIV.Update_Campus @ID varchar(3), @ENDEREÇO VARCHAR(256), 
@NOME varchar(256)
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN
        UPDATE UNIV.Local_Trabalho SET NOME=@NOME, ENDEREÇO=@ENDEREÇO WHERE ID=@ID
        SET @rcount += @@rowcount
                
        IF @rcount < 1
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

DROP PROC UNIV.Update_Dep
GO
CREATE PROC UNIV.Update_Dep @ID varchar(3), @ENDEREÇO VARCHAR(256), 
@NOME varchar(256), @TELEFONE CHAR(9), @HORARIO varchar(256) = null,
@BAR BIT = 0
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN
        UPDATE UNIV.Local_Trabalho SET NOME=@NOME, ENDEREÇO=@ENDEREÇO WHERE ID=@ID
        SET @rcount += @@rowcount

        UPDATE UNIV.Departamento SET TELEFONE=@TELEFONE, HORARIO=@HORARIO, BAR=@BAR 
        WHERE ID=@ID
        SET @rcount += @@rowcount
        
        IF @rcount < 2
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO


---------------------------------------------------------------------------------------


-- INSERIR CURSOS

DROP PROC UNIV.Insert_Curso
GO
CREATE PROC UNIV.Insert_Curso @CODIGO int, @CC_DIRETOR CHAR(8), 
@NOME varchar(64), @TIPO VARCHAR(64), @ID_DEP VARCHAR(3)
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN    
        INSERT INTO UNIV.Curso VALUES (@CODIGO, @CC_DIRETOR, @NOME, @TIPO, @ID_DEP)
        SET @rcount += @@rowcount
        
        IF @rcount < 1
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

-- UPDATE CURSOS

DROP PROC UNIV.Update_Curso
GO
CREATE PROC UNIV.Update_Curso @CODIGO int, @CC_DIRETOR CHAR(8), 
@NOME varchar(64), @TIPO VARCHAR(64), @ID_DEP VARCHAR(3)
AS
    DECLARE @rcount INT
    SET @rcount=0

    BEGIN TRAN    
        UPDATE UNIV.Curso SET CC_DIRETOR=@CC_DIRETOR, NOME=@NOME, TIPO=@TIPO, ID_DEP=@ID_DEP WHERE CODIGO=@CODIGO
        SET @rcount += @@rowcount
        
        IF @rcount < 1
            ROLLBACK TRAN 
        ELSE
            COMMIT TRAN
GO

