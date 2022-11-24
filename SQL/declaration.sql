
-- CREATE DATABASE PROJETO;
-- GO

-- USE PROJETO;
-- GO

-- CREATE SCHEMA UNIV;
-- GO

CREATE TABLE Univ.Local_Trabalho(
    ID              VARCHAR(3)      NOT NULL,
    NOME            VARCHAR(256)    NOT NULL,
    ENDEREÇO        VARCHAR(256)    NOT NULL,
    PRIMARY KEY(ID),
    UNIQUE(NOME)
);
GO

CREATE TABLE UNIV.Reitoria (
    ID           VARCHAR(3)      NOT NULL,
    NOME_UNIV    VARCHAR(256)    NOT NULL,
    PRIMARY KEY(ID),
    FOREIGN KEY(ID) REFERENCES UNIV.Local_Trabalho(ID)
);
GO

CREATE TABLE UNIV.Campus (
    ID                   VARCHAR(3)         NOT NULL,
    PRIMARY KEY(ID),
    FOREIGN KEY(ID) REFERENCES UNIV.Local_Trabalho(ID),
);
GO

CREATE TABLE UNIV.Departamento (
    ID          VARCHAR(3)         NOT NULL,
    TELEFONE        CHAR(9)          NOT NULL,
    HORARIO         VARCHAR(256),
    BAR         BIT                DEFAULT 0,
    PRIMARY KEY(ID),
    FOREIGN KEY(ID) REFERENCES UNIV.Local_Trabalho(ID)
);
GO

CREATE TABLE UNIV.Pessoa (
    NOME        VARCHAR(256)       NOT NULL,
    CC          CHAR(8)            NOT NULL,
    NIF         CHAR(9)            NOT NULL,
    PRIMARY KEY(CC),
    UNIQUE(NIF),
    CHECK(CC>0),
    CHECK(NIF>0)
);
GO

CREATE TABLE UNIV.Funcionario (
    CC              CHAR(8)     NOT NULL,
    NUMERO          INT         NOT NULL,
    FUNCAO          VARCHAR(256),
    ID_TRAB         VARCHAR(3),
    PRIMARY KEY(CC),
    UNIQUE(NUMERO),
    FOREIGN KEY(ID_TRAB) REFERENCES UNIV.Local_Trabalho(ID)
);
GO

CREATE TABLE UNIV.Docente (
    CC              CHAR(8)         NOT NULL, 
    TELEFONE        CHAR(9)         NOT NULL,
    ID_DEP          VARCHAR(3)      NOT NULL,
    REF_PROJETO     VARCHAR(256),
    PRIMARY KEY(CC),
    UNIQUE(TELEFONE),
    FOREIGN KEY(CC) REFERENCES UNIV.Pessoa(CC),
    FOREIGN KEY(ID_DEP) REFERENCES UNIV.Departamento(ID)
);
GO

CREATE TABLE UNIV.Investigador (
    CC              CHAR(8)         NOT NULL,
    TELEFONE        CHAR(9)         NOT NULL,
    ID_DEP          VARCHAR(3)      NOT NULL,
    REF_PROJETO     VARCHAR(256)    NOT NULL,
    PRIMARY KEY(CC),
    UNIQUE(TELEFONE),
    FOREIGN KEY(CC) REFERENCES UNIV.Pessoa(CC),
    FOREIGN KEY(ID_DEP) REFERENCES UNIV.Departamento(ID)
);
GO

CREATE TABLE UNIV.Aluno (
    CC              CHAR(8)         NOT NULL,
    NUMERO          INT             NOT NULL,
    ANO             INT             NOT NULL,
    N_MATRICULAS    INT             NOT NULL,
    REF_PROJETO     VARCHAR(256),
    PRIMARY KEY(NUMERO),
    UNIQUE(CC),
    FOREIGN KEY(CC) REFERENCES UNIV.Pessoa(CC),
    CHECK (NUMERO >= 1),
    CHECK (N_MATRICULAS >= 1),
    CHECK (ANO >= 1)
);
GO

DROP INDEX IX_CC_Aln on Univ.Aluno;
CREATE UNIQUE INDEX IX_CC_Aln ON Univ.Aluno(CC);
GO

CREATE TABLE UNIV.Curso (
    CODIGO      INT             NOT NULL,
    CC_DIRETOR  CHAR(8)         NOT NULL,
    NOME        VARCHAR(64)     NOT NULL,
    TIPO        VARCHAR(64)     NOT NULL,
    ID_DEP      VARCHAR(3)     NOT NULL,
    PRIMARY KEY(CODIGO),
    UNIQUE(CC_DIRETOR),
    FOREIGN KEY(CC_DIRETOR) REFERENCES UNIV.Docente(CC),
    FOREIGN KEY(ID_DEP) REFERENCES UNIV.Departamento(ID),
    CHECK(CODIGO > 0),
    CHECK(TIPO ='Licenciatura' OR TIPO ='Mestrado' OR TIPO ='Mestrado Integrado' OR TIPO ='Programa Doutoral' OR TIPO ='CTESP' )
);
GO

CREATE TABLE UNIV.Pert_Curso (
    CODIGO_ALUNO    INT     NOT NULL,
    CODIGO_CURSO    INT     NOT NULL,
    DATA_INICIO     DATE,
    DATA_FIM        DATE,
    PRIMARY KEY(CODIGO_CURSO, CODIGO_ALUNO),
    FOREIGN KEY(CODIGO_CURSO) REFERENCES UNIV.Curso(CODIGO),
    FOREIGN KEY(CODIGO_ALUNO) REFERENCES UNIV.Aluno(NUMERO)
);
GO
