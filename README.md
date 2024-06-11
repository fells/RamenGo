Estrutura do Projeto
A estrutura de pastas e arquivos do projeto é a seguinte:

```bash
Ramengo
├── . Properties
│   ├── launchSettings.json
├── wwwroot
│   ├── index.html
│   ├── app.js
│   └── styles.css
├── Controllers
│   ├── BrothController.cs
│   ├── ProteinController.cs
│   └── OrderController.cs
├── Data
│   └── DataContext.cs
├── Dto
│   ├── BrothDto.cs
│   ├── OrderRequestDto.cs
│   ├── OrderResponseDto.cs
│   └── ProteinDto.cs
├── Helper
│   ├── MappingProfiles.cs
│   └── OrderIdService.cs
├── Interfaces
│   ├── IBrothRepository.cs
│   ├── IProteinRepository.cs
│   └── IOrderRepository.cs
├── Models
│   ├── Broth.cs
│   ├── Protein.cs
│   └── Order.cs
├── Repository
│   ├── BrothRepository.cs
│   ├── ProteinRepository.cs
│   └── OrderRepository.cs
├── appsettings.json
└── Program.cs
```

Descrição dos Arquivos

- index.html
O arquivo HTML principal da aplicação, responsável pela estrutura da página e pela chamada dos arquivos JavaScript e CSS.

- app.js
O arquivo JavaScript que contém a lógica de interação com o usuário, como carregar opções de caldos e proteínas, fazer um pedido e manipular eventos na interface.

- styles.css
O arquivo CSS que define o estilo visual da aplicação, incluindo layout, cores e estilos de elementos.

Controllers

Os controladores (Controllers) são responsáveis por receber as requisições HTTP, processá-las e retornar as respostas adequadas. Eles incluem:

- BrothController.cs: Controlador para operações relacionadas aos caldos (broths).
- ProteinController.cs: Controlador para operações relacionadas às proteínas.
- OrderController.cs: Controlador para operações relacionadas aos pedidos.

Data

A pasta Data contém o arquivo DataContext.cs, que representa o contexto de dados da aplicação, utilizando uma fonte de dados em memória.

Dto

A pasta Dto contém classes de transferência de dados (DTOs) que são usadas para transferir dados entre as camadas da aplicação.

Helper

A pasta Helper contém arquivos utilitários, como perfis de mapeamento para AutoMapper e serviços de geração de IDs de pedido.

Interfaces

A pasta Interfaces contém interfaces que definem os contratos para os repositórios de dados.

Models

A pasta Models contém as classes de modelo que representam as entidades principais da aplicação, como caldos, proteínas e pedidos.

Repository

A pasta Repository contém os repositórios que implementam a lógica de acesso aos dados das entidades.

appsettings.json

O arquivo de configuração da aplicação, onde são definidas configurações gerais, como a conexão com banco de dados (no caso, em memória).

Program.cs

O arquivo Program.cs contém a configuração e inicialização da aplicação, incluindo a configuração dos serviços, middleware e roteamento.

Configuração e Funcionamento da Aplicação

A aplicação utiliza ASP.NET Core para o backend e JavaScript/HTML/CSS para o frontend. Ela segue a arquitetura MVC (Model-View-Controller) para a organização do código.

Configuração dos Serviços

No arquivo Program.cs, são configurados os serviços da aplicação, como controladores, AutoMapper, repositórios, serviços de geração de IDs e outros serviços necessários.

Middleware e Roteamento

O pipeline de requisição HTTP é configurado no arquivo Program.cs para incluir middleware de redirecionamento HTTPS, roteamento, autorização, suporte a CORS (Cross-Origin Resource Sharing), Swagger/OpenAPI para documentação da API e servir arquivos estáticos.



Como Executar
Para executar a aplicação, siga os passos abaixo:


Certifique-se de ter o .NET SDK instalado na sua máquina.
Clone o repositório para sua máquina local.
Abra o projeto no Visual Studio ou em um editor de código.
Execute o projeto para iniciar a aplicação.
Contribuindo
Sinta-se à vontade para contribuir com melhorias, correções de bugs ou novas funcionalidades. Abra uma issue ou envie um pull request para discutir e colaborar.

Licença
Este projeto está licenciado sob a MIT License.