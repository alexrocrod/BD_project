-- Inserts com os SPs...


EXEC UNIV.Insert_Reit '25','Reitoria 1','Reitoria 1 Gloria, Aveiro','UAveiro'
GO

EXEC UNIV.Insert_Campus 'C1','Campus 1 Gloria, Aveiro','Campus de Santiago'
GO

EXEC UNIV.Insert_Dep '13','Dfis Gloria, Aveiro','Dfis','234567213'
GO

EXEC UNIV.Insert_Dep '11','Dmat Gloria, Aveiro','Dmat','234987123','2a à 6a das 10h às 15h',1
GO


EXEC Univ.Insert_Func '12345678','123456789','Carlos Duarte',25,'Limpeza','13'
GO

EXEC Univ.Insert_Doc '87654321','987654321','Duarte Costa','915161718','13'
GO

EXEC Univ.Insert_Inv '98765432','876543210','Joaquim Duarte','915161718','13','refProj1'
GO

EXEC Univ.Insert_Aln '23456789','012345678','Duarte Pereira','23456789',91234,2,3,'refProj1'
GO


EXEC Univ.Insert_Curso 8303,'87654321','Eng. Computacional','Licenciatura','13'
GO

EXEC Univ.Insert_Aln_Curso 91234,8303,'2018-09-01'
GO



