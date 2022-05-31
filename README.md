# DisneyApi

ALKEMY

PROYECTO Alkemy.Disney.API

CONFIGURACION PARA CORRER LA API "ALKEMY.DISNEY.API"

1- Clonar este repositorio

2- Abrir el proyecto Alkemy.Disney.Api

3- Modificar en el archivo appsetting.json la referencia al servidor de base de datos de su maquina

4- Abrir console de package NuGet y ejecutar el comando: Update-Database

5- (Opcional) Ejecutar en SQL Server el script "SciptDeDisneyDB" proporcionado en la carpeta "Documentacion" para generar casos de pruebas

6- Correr la solucion 

7- Crear un usuario en siguiente endpoint "User -> Post -> /User"

Ejemplo:
{
  "id": 0,
  "userName": "yessica",
  "password": "1234",
  "confirmaClave": "1234",
  "sal": ""
}

8- Una vez creado el usuario, autenticarse con ese usuario en el siguiente endpoint "Login -> Post -> /Login" y copiar el Token generado por ese endpoint
Ejemplo:
{
  "userName": "yessica",
  "password": "1234"
}

9- Abrir la seccion "Authorize" y colocar el token generado en el paso 8

Listo! Ahora puedes probar todos los endpoint
