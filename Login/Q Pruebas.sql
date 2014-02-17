EXEC dbo.Agrega_Usuario 
@nombre='Oscar Torres',
@correo='oscar.torres@iexglobal.com',
@contrasena='9688057LOLya';

EXEC dbo.Valida_Datos
@correo ='oscar.torres@iexglobal.com',
@contrasena='9688057LOLya';

EXEC dbo.Obten_Contrasena
@correo ='oscar.torres@iexglobal.com';

EXEC dbo.Cambia_Correo
@correoNuevo='otot9292@gmail.com',
@correoAntiguo='oscar.torres@iexglobal.com';

EXEC dbo.Cambia_Nombre
@correo='otot9292@gmail.com',
@nombreNuevo='Oscar Torres Treviño';

EXEC dbo.Cambia_Contrasena
@correo='otot9292@gmail.com',
@contrasenaNueva='160592ya',
@contrasenaAntigua='9688057LOLya';

select * from Usuario;

delete from Usuario;