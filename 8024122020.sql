alter table respuesta_solicitud add constraint fk_idPedido foreign key(IdPedido) references informacion_pedido(id_pedido);

create sequence Secuencia_Respuesta_solicitud
start with 300
increment by 1;