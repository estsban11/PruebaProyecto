CREATE PROCEDURE [dbo].[Registrar_asignatura]
	@c_asignatura varchar(50),
	@n_asignatura varchar(50),
	@n_grupo varchar(10),
	@h_laboratorio int,
	@id_docente varchar(50)
AS
	insert into Asignatura(Codigo_materia, Nombre_materia, Numero_grupo, Horas_laboratorio, id_docente)
	values(@c_asignatura,@n_asignatura,@n_grupo,@h_laboratorio,@id_docente)
RETURN 0
