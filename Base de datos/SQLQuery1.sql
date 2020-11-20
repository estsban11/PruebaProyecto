Alter table dbo.Asignatura 
Add constraint fk_id_docente Foreign key(id_docente)
references dbo.Docente(Identificacion);