# TEKEVER - TV Shows App - Step-by-Step Setup Guide

This guide explains how to install, configure, and run the **TV Shows App**, which consists of a **.NET 8 Web API backend** with **MySQL** and a **React Vite frontend**.

---

📁 Project Overview

This project consists of:
- **Backend**: ASP.NET Core Web API (.NET 8.0)
- **Backend**: MySQL
- **Frontend**: React with Vite

---

## 1 Prerequisites

Before starting, make sure the following are installed:

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download/dotnet/8.0)  
- [MySQL Server 8.0+](https://dev.mysql.com/downloads/mysql/)  
- [Node.js 18+](https://nodejs.org/) (LTS recommended)  
- npm or [Yarn](https://yarnpkg.com/)  

---

## 2️ Database Setup

1. **Start MySQL Server** and log in to your MySQL client.  
2. Run TekeverChallengeDB.sql in Tekever_Challenge/Tekever_Challenge/Utils (utils in the same folder as Program.cs)

## 3 Backend Setup

1. Open project solution on Visual Studio Community
2. Go to appsettings.json and update the connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=tvshowsdb;user=root;password=yourpassword"
}
```
3. Run application

## 4 Frontend Setup

1. Open Tekever_Challenge/frontend in VS Code
2. Install dependencies
```bash
npm install
```
3. Create file .env in same directory as .env.example with:
```bash
VITE_BACKEND_URL=https://localhost:7151
```
4. Run development server:
```bash
npm run dev
```

## 5 Login Credentials

1. If using TekeverChallengeDB, for a demo user with favorites and data use:
- email: andre@example.com
- password: Andre@123
2. If you want a fresh user, register.