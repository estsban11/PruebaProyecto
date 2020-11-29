select * from Informacion_pedido;
delete from Informacion_pedido;
select * from Materiales_pedido;
alter table Materiales_pedido add constraint fk_id_pedido foreign key(id_pedido) references informacion_pedido(id_pedido);
                        