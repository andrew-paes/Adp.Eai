# Adp.Eai

##TASKS
OK - Create a simple Web API (.NET Core) application that 
OK - makes an HTTP GET request to https://interview.adpeai.com/api/v1/get-task
OK - and then, using the ID and properties returned, dynamically perform the calculation as instructed.
OK - Once you have your ID and result, make an HTTP POST request to https://interview.adpeai.com/api/v1/submit-task
OK - with a JSON POST body including the properties id and result.
NK - Your code should be able to respond appropriately to these HTTP status codes (at your discretion).

##EVALUATION CRITERIA
OK - A reviewer should be able to clone this repository (e.g. from Github, Bitbucket)
OK - A reviewer should be able to open, build and debug solution
OK - A reviewer should be able to see that calls are successful or not
OK - A reviewer should be able to test the application (Postman, Swagger, SoapUI)
OK - Use of industry best practices
OK - Use of SOLID principles3
OK - Use of Microsoft C# coding conventions
OK - LTS - Use of latest language and framework versions (not in preview)
NK - Application works correctly for all operations
NK - Code is commented where appropriate

##EVALUATION BONUS
OK - Unit tests (tests should be visible to Test Explorer in Visual Studio)
NK - Log errors and main operations inputs
NK - Use in memory database - store operation and result
NK - Implement HTTP call retries in case of failure
NK - Benchmark code and provide results
OK - While application is running, it gets and submits tasks continuously (without being a DoS attack)
OK - Report any bugs or issues you find (there shouldn't be any, but who knows) - Well I dindn't find as a good practice to send JSON and receive HTML header

##TODO
Criar uma biblioteca de para filtro de exceções de integração
Refatorar o objeto de retorno
Comentar o código nas partes principais
HATEOAS
Cache
EF Core In-Memory Database Provider