# Lab 01 - Construindo uma Aplicação Web com Azure PaaS

## Objetivo

Neste laboratório, você aprenderá a criar e implantar uma aplicação web utilizando os serviços de PaaS da Microsoft Azure, com foco em **App Service**, **Azure Storage** e deploy via **Kudu (zip deployment)**. O cenário simula uma galeria de fotos com backend em ASP.NET e frontend em Razor Pages.

---

## 🔧 Tecnologias Utilizadas

- **Azure App Service (Web Apps)**
- **Azure Blob Storage**
- **.NET 8**
- **Visual Studio Code**
- **Azure CLI**
- **Apache Kudu (Zip Deploy)**

---

## 🧪 Exercício 1: Backend API com Azure Storage e Web Apps

**Etapas:**

1. Criar um Storage Account e configurar um container `images`.
2. Fazer upload de um arquivo (ex: `grilledcheese.jpg`) para o Blob Storage.
3. Criar um Web App (`imgapi`) com .NET 8 e configurar a connection string como Application Setting.
4. Fazer deploy da API para o Web App utilizando `az webapp deployment source config-zip`.
5. Testar o endpoint retornando URLs das imagens do blob.

---

## 🧪 Exercício 2: Frontend Web App consumindo a API

**Etapas:**

1. Criar outro Web App (`imgweb`) com .NET 8 para o frontend.
2. Configurar Application Setting `ApiUrl` com a URL da API criada anteriormente.
3. Fazer deploy do frontend com `az webapp deployment source config-zip`.
4. Interagir com a aplicação: listar imagens da galeria e fazer upload de novas (ex: `banhmi.jpg`).

---

## 🗂 Estrutura da Aplicação

```
Lab01/
├── API/
│   └── ASP.NET Web API (imgapi)
├── Web/
│   └── Razor Pages frontend (imgweb)
├── Images/
│   ├── grilledcheese.jpg
│   └── banhmi.jpg
└── README.md
```

---

## ✅ Resultado Esperado

Ao final do laboratório, você terá:

- Um backend funcional hospedado no Azure App Service que se conecta ao Azure Storage.
- Um frontend que consome essa API e exibe uma galeria de imagens.
- Capacidade de fazer upload de novas imagens, armazenando-as no blob.

---