## Introducción
Realizar requerimiento del documento Examen Desarrollador FullStack.pdf

1 Instalar SDK Net Core 8
https://dotnet.microsoft.com/es-es/download/dotnet/8.0
2 - Publicar base de datos de la carpeta DataBase o correr los scripts en motor sql server
3 - URL Configurada de la API https://localhost:7215/api/controller 
Cambiar cadena de conexion en appsettings.json del proyecto Primary.API
4 - Client BLAZOR https://localhost:7088/
el mismo esta configurado para que el componente que levante primero invoque al get de la api,aqui no hay que configurar nada,
ya el mismo apunta a la API desarrollada

Contenido
##
Carpeta Client se encuentra el front hecho con Blazor

##
Carpeta DataBase dentro de Api
Se encuentra un proyecto para publicar en un motor de base de datos Sql Server o bien
se puede correr el Script que tiene datos incluidos

##
Carpeta Api
Se encuentra la API que brinda los datos 

## Funcionalidad requerida
Se tienen varias monedas. Las cuales tienen un nombre y símbolo.
● Cada moneda tiene un tipo de cambio comprador y vendedor diario. 
	--Esto esta plasmado en el front al momento de Seleccionar una Cotizacion
● Una moneda puede tener varios tipos de cambios dependiendo el origen. Por ejemplo: Oficial, Contado con Liquidación, dólar MEP, dólar Soja, etc.
	--Junto al Item anterior
● Registro de compra y venta
	1. Se debe registrar la transacción de compra y venta con el monto operado
		--Evidencia en el Word del alta de una Transaccion tanto en Swagger como en el Front
	2. Se deberá controlar que dentro del mes no supere los 200USD de compra o su equivalente en pesos al tipo de cambio oficial.
		--Evidencia en el Word del alta de una Transaccion tanto en Swagger como en el Front
	3. No se permite realizar compra y venta de moneda los fines de semana.
		--Evidencia en el Word del alta de una Transaccion tanto en Swagger como en el Front
	4. Consultar todos los movimientos de un cliente en particular
		--Evidencia en el Word del alta de una Transaccion tanto en Swagger como en el Front
