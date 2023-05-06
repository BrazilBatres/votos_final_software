CREATE DATABASE elecciones;

USE elecciones;

-- Tabla candidato
CREATE TABLE candidato (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL,
  apellidos VARCHAR(50) NOT NULL,
  fecha_nacimiento DATE NOT NULL,
  formacion_profesional VARCHAR(100) NOT NULL,
  sexo VARCHAR(10) NOT NULL,
  partido_politico VARCHAR(50) NOT NULL,
  informacion TEXT
);

-- Tabla voto
CREATE TABLE voto (
  id INT AUTO_INCREMENT PRIMARY KEY,
  candidato_id INT NOT NULL,
  dpi VARCHAR(13) NOT NULL,
  fecha_hora DATETIME NOT NULL,
  ip_origen VARCHAR(45) NOT NULL,
  es_fraudulento TINYINT(1) NOT NULL DEFAULT 0,
  FOREIGN KEY (candidato_id) REFERENCES candidato(id)
);

INSERT INTO candidato (nombre, apellidos, fecha_nacimiento, formacion_profesional, sexo, partido_politico, informacion)
VALUES ('Juan', 'Pérez', '1990-05-15', 'Licenciado en Economía', 'Masculino', 'Partido A', 'Candidato experimentado en asuntos económicos.');

INSERT INTO candidato (nombre, apellidos, fecha_nacimiento, formacion_profesional, sexo, partido_politico, informacion)
VALUES ('María', 'Gómez', '1985-10-20', 'Abogada', 'Femenino', 'Partido B', 'Abogada especializada en derechos humanos y justicia social.');

SELECT * FROM voto
