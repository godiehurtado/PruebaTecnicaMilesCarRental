# PruebaTecnicaMilesCarRental
Prueba Técnica Browser Travel Solutions

MilesCarRental_Api: Contiene toda la solución de la aplicación prueba con los siguientes proyectos:

 - MilesCarRental_Entities: Capa de entidades.
 - MilesCarRental_Repository: Capa repositorio (Patrón de Diseño Repository: El patrón Repository se utiliza para encapsular la lógica de acceso a datos y proporcionar una interfaz común para trabajar con datos. Los repositorios generalmente ofrecen operaciones CRUD (Create, Read, Update, Delete) y actúan como una capa de abstracción entre la aplicación y la fuente de datos.)
 - MilesCarRental_UoW: Capa de persistencia (Patrón de diseño Unit Of Work: Este patrón se utiliza comúnmente en el contexto de la programación orientada a objetos y la persistencia de datos para agrupar múltiples operaciones de base de datos en una única transacción.) 
 - MilesCarRental_Services: Capa de negocio (Patrón de Inyección de dependencias)
 - MilesCarRental_API_WEB: API WEB con micro servicios REST. Pueden ser consumidos por cualquier FRONT.
 - MilesCarRental_Api: Aplicación de consola que funciona como FRONT para probar la lógica de negocio y el consumo de los API REST. Tiene arquitectura MVC.
