CREATE DATABASE PruebaTecnicaDb;
GO
USE PruebaTecnicaDb;
GO

CREATE TABLE Usuarios (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash  NVARCHAR(256) NOT NULL,
    Activo        BIT           NOT NULL DEFAULT 1,
    FechaCreacion DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE Clientes (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Nombre        NVARCHAR(100) NOT NULL,
    Apellido      NVARCHAR(100) NOT NULL,
    Email         NVARCHAR(150) NOT NULL,
    Telefono      NVARCHAR(20)  NULL,
    Direccion     NVARCHAR(250) NULL,
    FechaCreacion DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

-- No se usa FK de clientes porque así se evita problema al eliminar un cliente
CREATE TABLE Bitacora (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Accion        NVARCHAR(20)  NOT NULL,
    ClienteId     INT           NOT NULL,
    FechaHora     DATETIME      NOT NULL DEFAULT GETDATE(),
    UsuarioId     INT           NOT NULL,
    NombreUsuario NVARCHAR(50)  NOT NULL,
    Detalle       NVARCHAR(500) NULL,
    CONSTRAINT FK_Bitacora_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    CONSTRAINT CK_Bitacora_Accion CHECK (Accion IN ('Agregar','Editar','Eliminar'))
);
GO


USE PruebaTecnicaDb
CREATE UNIQUE INDEX UX_Clientes_Email ON Clientes(Email);

-- Usuario base para administrador
-- Nombre: admin
-- Password: PruebaTecnica (en la db se almacena con hash pero en el login se debe poner la contraseña correcta)
INSERT INTO Usuarios (NombreUsuario, PasswordHash)
VALUES ('admin', '100000.kIDyGGWJ8K2+yUB/DrtCmg==.eCFgL72rLCu5BGh6612nCxTWKZSv4p9ABg+mfYKMJmQ=');
