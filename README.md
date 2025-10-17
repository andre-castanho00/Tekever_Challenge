# TEKEVER - TV Shows App - Step-by-Step Setup Guide

This guide explains how to install, configure, and run the **TV Shows App**, which consists of a **.NET 8 Web API backend** with **MySQL** and a **React Vite frontend**.

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
2. **Create a database** for the app:
```sql
CREATE DATABASE tvshowsdb;
