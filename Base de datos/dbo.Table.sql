CREATE TABLE [dbo].[Docente]
(
	[Identificacion] VARCHAR(10) NOT NULL PRIMARY KEY, 
    [PrimerNombre] VARCHAR(50) NOT NULL, 
    [SegundoNombre] VARCHAR(50) NULL, 
    [PrimerApellido] VARCHAR(50) NULL, 
    [SegundoApellido] VARCHAR(50) NULL, 
    [NombreUsuario] VARCHAR(50) NOT NULL, 
    [Contraseña] VARCHAR(50) NOT NULL
)

