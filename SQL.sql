create Database Estacion Server
use Estacion Server
	Create table Region(
	id_Region int primary key,
	Nombre varchar(100) NOT NULL
	) 

	Create table Estacion
	(
	Rut varchar(11) Primary key,
	Capacidad int NOT NULL,
	Region int NOT NULL,
	Direccion varchar(150) NOT NULL,
	Hora_cierre datetime NOT NULL,
	Hora_inicio datetime NOT NULL
	Constraint fk_estacion_region foreign Key(Region)
	references Region(id_Region)
	)

	Create table Puntocarga(
	Punto_rut varchar(11) NOT NULL,
	ID int Primary key,
	Tipo int NOT NULL,
	Capacidadmaxima int NOT NULL,
	Fechavencimiento datetime NOT NULL
	Constraint fk_puntocarga_estacion foreign Key(Punto_rut)
	references Estacion(Rut)
	)