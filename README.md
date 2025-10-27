<div id="top">

<!-- HEADER STYLE: CLASSIC -->
<div align="center">


# MEDILOGIX

<em>Transforming Healthcare Data Into Actionable Insights</em>

<!-- BADGES -->
<img src="https://img.shields.io/github/last-commit/J-Radu/MediLogix?style=flat&logo=git&logoColor=white&color=0080ff" alt="last-commit">
<img src="https://img.shields.io/github/languages/top/J-Radu/MediLogix?style=flat&color=0080ff" alt="repo-top-language">
<img src="https://img.shields.io/github/languages/count/J-Radu/MediLogix?style=flat&color=0080ff" alt="repo-language-count">

<em>Built with the tools and technologies:</em>

<img src="https://img.shields.io/badge/JSON-000000.svg?style=flat&logo=JSON&logoColor=white" alt="JSON">
<img src="https://img.shields.io/badge/Docker-2496ED.svg?style=flat&logo=Docker&logoColor=white" alt="Docker">
<img src="https://img.shields.io/badge/NuGet-004880.svg?style=flat&logo=NuGet&logoColor=white" alt="NuGet">
<img src="https://img.shields.io/badge/YAML-CB171E.svg?style=flat&logo=YAML&logoColor=white" alt="YAML">

</div>
<br>

---

## Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
    - [Usage](#usage)
    - [Testing](#testing)
- [Features](#features)
- [Project Structure](#project-structure)

---

## Overview

MediLogix is a comprehensive healthcare data management platform designed for scalability, security, and maintainability. Built with a modular architecture, it integrates core components like web APIs, domain logic, infrastructure, and application services to streamline development and deployment. The system emphasizes security through JWT authentication, HTTPS, and environment-specific configurations, ensuring data protection across all layers. Its robust testing setup—including unit, integration, and architectural validation—supports reliable, high-quality code. Containerized with Docker Compose and Dockerfile, MediLogix simplifies deployment across environments. With extensive use of Entity Framework Core, MediatR, and clear data mappings, it offers a solid foundation for managing medical devices, warranties, failures, and operational data—empowering developers to build scalable, secure healthcare solutions efficiently.

---

## Features

|      | Component       | Details                                                                                     |
| :--- | :-------------- | :------------------------------------------------------------------------------------------ |
| ⚙️  | **Architecture**  | <ul><li>Layered architecture: API, Application, Infrastructure, Domain</li><li>Uses Clean Architecture principles</li><li>Separation of concerns between Web API, Business Logic, Data Access</li></ul> |
| 🔩 | **Code Quality**  | <ul><li>Uses C# with modern features (nullable reference types, async/await)</li><li>Projects structured with clear boundaries</li><li>Includes architectural and unit tests</li></ul> |
| 📄 | **Documentation** | <ul><li>Dockerfile documented in `MediLogix/src/WebApi/Dockerfile`</li><li>Configuration via `appsettings.json` and environment-specific files</li><li>HTTP API documentation via `webapi.http`</li></ul> |
| 🔌 | **Integrations**  | <ul><li>Containerized with Docker</li><li>Uses NuGet for package management</li><li>CI/CD tools include Docker, NuGet, and Compose (`compose.yaml`)</li></ul> |
| 🧩 | **Modularity**    | <ul><li>Projects divided into separate layers: WebApi, Application, Infrastructure, Domain</li><li>Test projects for each layer</li></ul> |
| 🧪 | **Testing**       | <ul><li>Unit tests in `WebApi.UnitTests`, `Application.UnitTests`, `Infrastructure.UnitTests`</li><li>Integration tests for WebApi</li><li>Architectural tests to enforce design constraints</li></ul> |
| ⚡️  | **Performance**   | <ul><li>Potential use of async programming for scalability</li><li>Dockerized environment supports consistent performance testing</li></ul> |
| 🛡️ | **Security**      | <ul><li>Configuration managed via `appsettings.json` with environment separation</li><li>Potential for secure secrets management (not explicitly shown)</li></ul> |
| 📦 | **Dependencies**  | <ul><li>Managed via NuGet packages</li><li>Includes core libraries and testing frameworks</li></ul> |

---

## Project Structure

```sh
└── MediLogix/
    └── MediLogix
        ├── .config
        ├── .dockerignore
        ├── .gitignore
        ├── .idea
        ├── MediLogix.sln
        ├── Tests
        ├── appsettings.json
        ├── compose.yaml
        └── src
```

---

## Getting Started

### Prerequisites

This project requires the following dependencies:

- **Programming Language:** CSharp
- **Package Manager:** Nuget
- **Container Runtime:** Docker

### Installation

Build MediLogix from the source and install dependencies:

1. **Clone the repository:**

    ```sh
    ❯ git clone https://github.com/J-Radu/MediLogix
    ```

2. **Navigate to the project directory:**

    ```sh
    ❯ cd MediLogix
    ```

3. **Install the dependencies:**

**Using [docker](https://www.docker.com/):**

```sh
❯ docker build -t J-Radu/MediLogix .
```
**Using [nuget](https://docs.microsoft.com/en-us/dotnet/csharp/):**

```sh
❯ dotnet restore
```

### Usage

Run the project with:

**Using [docker](https://www.docker.com/):**

```sh
docker run -it {image_name}
```
**Using [nuget](https://docs.microsoft.com/en-us/dotnet/csharp/):**

```sh
dotnet run
```

### Testing

Medilogix uses the {__test_framework__} test framework. Run the test suite with:

**Using [docker](https://www.docker.com/):**

```sh
echo 'INSERT-TEST-COMMAND-HERE'
```
**Using [nuget](https://docs.microsoft.com/en-us/dotnet/csharp/):**

```sh
dotnet test
```

---

<div align="left"><a href="#top">⬆ Return</a></div>

---
