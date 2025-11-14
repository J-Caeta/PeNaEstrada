# Pé na Estrada 🌄

> "Entre mapas e memórias: registre sua jornada."

`Status do Projeto: 🚧 Em Desenvolvimento 🚧`

## 📖 Sobre o Projeto

O **Pé na Estrada** é um sistema web moderno para registrar e compartilhar experiências de viagem.

Originalmente um projeto front-end simples (baseado em HTML/CSS/LocalStorage), esta nova versão foi totalmente reconstruída do zero como uma aplicação **full-stack .NET** robusta, escalável e de nível profissional.

O sistema permite que os usuários mantenham um diário de viagens pessoal (`Meu Diário`) e, opcionalmente, publiquem suas aventuras em um feed público (`Feed Público`) para inspirar outros viajantes.

## ✨ Funcionalidades Principais (MVP V1.0)

* **Autenticação:** Sistema completo de Registro e Login de usuários.
* **Diário Pessoal:** Visualização privada de todas as experiências criadas pelo usuário.
* **CRUD de Experiências:** Funcionalidade completa para Criar, Ler, Editar e Excluir posts de viagem.
* **Upload de Mídia:** Upload de foto de capa e uma galeria de fotos para cada experiência.
* **Detalhamento:** Cadastro de descrição, avaliação (0-5 estrelas), data e localização da vivência.
* **Feed Público:** Uma "timeline" social onde posts marcados como "públicos" são exibidos, ordenados pelas melhores avaliações.
* **Interação Social:** Sistema de "Curtidas" e "Comentários" nos posts do feed.

## 🏛️ Arquitetura e Tecnologias

Este projeto foi desenvolvido com foco total no ecossistema .NET moderno, seguindo os princípios da **Clean Architecture (Arquitetura Limpa)** para garantir uma separação clara de conceitos (SoC), alta testabilidade e manutenibilidade.

A solução é dividida nas seguintes camadas:

* **`Domain`**: O coração do aplicativo. Contém as entidades de negócio puras (`Experiencia`, `Foto`, etc.) sem nenhuma dependência externa.
* **`Application`**: Contém a lógica de negócio (casos de uso) e as interfaces (contratos) dos repositórios e serviços.
* **`Infrastructure`**: Contém os detalhes de implementação. É responsável por "honrar" os contratos da camada de Application (Ex: `EF Core`, `Identity`, integração com APIs).
* **`Server`**: A API. Camada de apresentação do backend (`ASP.NET Core Web API`) que expõe os endpoints RESTful.
* **`Client`**: O frontend. Uma aplicação SPA (Single Page Application) construída em `Blazor WebAssembly`.

---

### 🚀 Stack Tecnológica

| Camada | Tecnologia |
| :--- | :--- |
| **Frontend** | Blazor WebAssembly (WASM) |
| **Backend (API)** | ASP.NET Core Web API (.NET 8) |
| **Linguagem** | C# 12 |
| **Banco de Dados** | SQL Server (via LocalDB) |
| **ORM** | Entity Framework Core (EF Core 8) |
| **Autenticação** | .NET Identity |
| **Testes** | xUnit |

## 🎓 Foco do Projeto e Aprendizado

Mais do que um simples CRUD, o objetivo deste projeto é servir como um portfólio de alta qualidade, demonstrando o domínio de conceitos avançados de engenharia de software no ecossistema .NET.

Os principais focos de aprendizado incluem:

* **Padrões de Projeto:** Implementação prática do **Repository Pattern** e **CQRS** (planejado, com MediatR).
* **Código Limpo (Clean Code):** Uso de **SonarLint** e **.editorconfig** para forçar a qualidade e padronização do código em tempo real.
* **Testabilidade:** Foco na criação de **Testes Unitários (xUnit)** robustos para a camada de `Application`, utilizando Mocks.
* **Injeção de Dependência (DI):** Uso extensivo do contêiner de DI nativo do ASP.NET Core para desacoplar as camadas.
* **Programação Assíncrona:** Uso correto e consciente de `async/await` em todo o fluxo I/O (chamadas de API e acesso ao banco de dados).