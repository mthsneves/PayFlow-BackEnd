# Estudos de Arquitetura de Software — .NET & C#

Repositório dedicado ao estudo e aprimoramento de arquitetura de software, com foco prático em **C# e .NET**. O objetivo aqui não é só teoria: cada conceito estudado é implementado, testado e documentado em código real, através da construção de um sistema de pagamento com microsserviços.

## Objetivo do repositório

Este espaço serve para consolidar aprendizado sobre:

- **Clean Architecture** — separação de responsabilidades em camadas independentes
- **Microsserviços** — comunicação entre serviços, desacoplamento, filas de mensagens
- **C# / .NET** — boas práticas, tipagem forte, testes, frameworks (ASP.NET Core)
- **Performance e concorrência em .NET** — `async/await`, `Task`, `Channels`, `Span<T>`
- **Design de sistemas** — trade-offs entre abordagens (monolito vs. microsserviços, síncrono vs. assíncrono)

A ideia é que cada branch, pasta ou commit relevante documente não só o código, mas o raciocínio por trás das decisões técnicas.

## Projeto principal: Sistema de Pagamento

Como estudo de caso central, o repositório constrói um sistema de pagamento simulado usando arquitetura de microsserviços.

| Serviço | Linguagem / Stack | Responsabilidade |
|---|---|---|
| API Gateway | YARP / Traefik | Roteia requisições para os serviços internos |
| Payment Service | C# (ASP.NET Core Web API) | Recebe, valida e orquestra pagamentos |
| Ledger Service | C# (.NET Minimal API) | Registra transações de forma imutável e auditável, com foco em performance |
| Notification Service | C# (.NET Worker Service) | Notifica cliente/lojista sobre o status do pagamento |

Cada serviço segue os princípios de Clean Architecture:

```
Service/
├── Domain/            # Regras de negócio puras, sem dependência externa
├── Application/        # Casos de uso, orquestram as entidades
├── Infrastructure/     # Frameworks, banco de dados, mensageria
├── Api/                # Camada de apresentação (Controllers ou Minimal API)
└── Tests/
```

**Regra de ouro** seguida em todo o repositório: as camadas de dentro (`Domain`, `Application`) nunca dependem das camadas de fora (`Infrastructure`, `Api`).

## Stack utilizada

- **.NET 8+ (LTS)** — plataforma base de todos os serviços
- **ASP.NET Core** — Web API (Controllers e Minimal APIs)
- **Entity Framework Core** — ORM e persistência
- **xUnit** + **FluentAssertions** + **Moq** — testes unitários e de integração
- **MediatR** — implementação de casos de uso / CQRS
- **PostgreSQL** — persistência
- **RabbitMQ** (via **MassTransit**) — comunicação assíncrona entre serviços
- **Docker / Docker Compose** — orquestração local
- **Visual Studio / Rider / VS Code** — ambiente de desenvolvimento

## Estrutura do repositório

```
.
├── PaymentService/        # C# — Clean Architecture aplicada
├── LedgerService/         # C# — Clean Architecture aplicada, foco em performance
├── NotificationService/   # C# — Worker Service
├── docs/                  # Anotações de estudo, diagramas, decisões técnicas
├── docker-compose.yml
└── README.md
```

## Como rodar localmente

```bash
# clone o repositório
git clone <url-do-repo>
cd <nome-do-repo>

# suba todos os serviços
docker compose up --build

# ou rode um serviço isoladamente (exemplo: PaymentService)
cd PaymentService
dotnet restore
dotnet run --project Api
```

## Roadmap de estudo

- [ ] Setup do ambiente (.NET SDK, Docker)
- [ ] Payment Service com Clean Architecture (C#)
- [ ] Ledger Service em C# com foco em performance
- [ ] Comunicação síncrona entre serviços (HTTP)
- [ ] Comunicação assíncrona via fila de mensagens (RabbitMQ/MassTransit)
- [ ] API Gateway (YARP)
- [ ] Testes automatizados (unitários e de integração)
- [ ] Documentação de decisões arquiteturais (ADRs)
- [ ] Observabilidade básica (logs estruturados, métricas com OpenTelemetry)

## Anotações e decisões técnicas

Decisões de arquitetura relevantes são documentadas na pasta `docs/`, incluindo:

- Por que separar Payment Service e Ledger Service como serviços distintos, mesmo utilizando a mesma stack (.NET)
- Controllers vs. Minimal APIs: quando usar cada abordagem
- Trade-offs entre monorepo e polyrepo neste projeto
- Motivos para adotar Clean Architecture em vez de uma estrutura mais simples (MVC puro, por exemplo)

O objetivo é que qualquer pessoa lendo o repositório entenda não só o que foi construído, mas por que cada escolha técnica foi feita.

## Observação

Este é um projeto de estudo e portfólio — não deve ser usado em produção sem revisão completa de segurança, especialmente em relação a dados de pagamento (PCI-DSS, criptografia, tratamento de dados sensíveis).

## Status

Em desenvolvimento ativo — repositório atualizado conforme o aprendizado avança.
