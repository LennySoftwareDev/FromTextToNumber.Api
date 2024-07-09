# From Text To Number Api

## Api creada con arquitectura orientada al dominio (Domain-Driven Design, DDD)

- Librerías utilizadas
     - WebApi
         - Microsoft.EntityFrameworkCore.Design
         - Microsoft.AspnetCore.Authentication.Jwtbearer
     - Application.Core
         - AutoMapper
         - Humanizer
         - MediatR
         - MediatR.Extensions.Microsoft.DependencyInjectionFixed
     - Application.Dto
         - MediatR
     - Domain
         - Microsoft.EntityFrameworkCore
     - Infrastructure
         - Microsoft.EntityFrameworkCore
         - Microsoft.EntityFrameworkCore.Tools
           
### Controladores creados
- FromNumberToTextController
    - EndPoints
         - CreateTextOfNumber
         - GetNumbers
- UserController
    - EndPoints
         - AuthorizationLogin

### Imágenes de lo desarrollado
___
- Base de datos
    - Contiene las tablas User y Number

![DataBase](https://github.com/LennySoftwareDev/FromTextToNumber.Api/assets/133023801/a9faf097-6725-4da6-ac9c-8d22ac0b2e67)

- Tabla usuario
    - El usuario es de prueba, se crea al hacer la migración a la base de datos

![User](https://github.com/LennySoftwareDev/FromTextToNumber.Api/assets/133023801/4bf9c440-3b2e-480d-88fc-27009cf86693)

- Tabla Número
    - En esta tabla se registran todos los números de los cuales se desea saber cuál es su pronunciación
      
![Number](https://github.com/LennySoftwareDev/FromTextToNumber.Api/assets/133023801/a7459f82-5f6f-4728-b2cf-269e1da06aad)

- Controladores

![image](https://github.com/LennySoftwareDev/FromTextToNumber.Api/assets/133023801/70131879-3a33-4777-b5c6-2409b93dca9f)

- Pruebas en los endpoints sin autenticarse
    - CreateTextOfNumber

![image](https://github.com/LennySoftwareDev/FromTextToNumber.Api/assets/133023801/3b7cccb9-0404-4406-9306-32eb9ab9e109)
    
  - GetNumbers

![image](https://github.com/LennySoftwareDev/FromTextToNumber.Api/assets/133023801/e57910d6-fa6d-4d62-999a-08544616db08)

- Pruebas en los endpoints autenticado
    - AuthorizationLogin

![image](https://github.com/LennySoftwareDev/FromTextToNumber.Api/assets/133023801/ef58d69f-20de-4634-963d-09135c4d0803)

  - CreateTextOfNumber

![image](https://github.com/LennySoftwareDev/FromTextToNumber.Api/assets/133023801/3c0a5733-9895-488a-bc74-4206e781e474)

![image](https://github.com/LennySoftwareDev/FromTextToNumber.Api/assets/133023801/f5931e08-fed2-454f-8f7e-b0b080bc4a6e)

  - GetNumbers

![image](https://github.com/LennySoftwareDev/FromTextToNumber.Api/assets/133023801/bbc93b5e-e097-44dd-95d8-7c9bb1453862)

![image](https://github.com/LennySoftwareDev/FromTextToNumber.Api/assets/133023801/deee8e5a-74e1-4736-be72-e7a4b22de4ad)









