# API Administración de Clientes

Esta API permite administrar la información de clientes.

## Tabla de contenidos

1. [Notas de la Versión](#notas-de-la-versión)
2. [Testing](#testing)
3. [Documentación](#documentación)

## Notas de la Versión

Esta versión implementa 3 Endpoints:

1. **Método CreateClient**: Permite la creación de nuevos clientes, incluyendo validaciones de modelo en cuanto a obligatoriedad, tipo de datos y restricciones de negocio.
   
2. **Método GetClientById**: Permite la recuperación de un Cliente por su respectivo ID.
   
3. **Método UpdateClientById**: Permite actualizar un registro del cliente en base a su ID e información obligatoria.

## Testing

Para realizar pruebas de consumo de los servicios de manera local, en el directorio del proyecto se encuentra la carpeta ApiTest, que contiene un archivo con la configuración completa de una colección de Postman. Una vez clonado el repositorio, el proyecto debe ejecutarse y se debe importar la colección en Postman.

## Documentación

El proyecto incluye documentación con Swagger, la cual estará accesible una vez clonado el repositorio, compilada y ejecutada la solución.
