select * from Informacion_pedido_monitor;
select * from Materiales_monitor;
select * from Informacion_pedido_monitor i full join Materiales_monitor m on
i.Id_pedido = m.id_pedido;