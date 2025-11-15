# 🛍️ ShopLite – Coding Test

Welcome to **ShopLite**, a small demo e-commerce API designed as a technical exercise.  
Your task is to extend and complete this minimal project so it behaves like a simple online shop.

---

## 🧩 Goal

Implement a few missing pieces and improve code quality where noted.  
Focus on **correctness, clarity, and testability** rather than completeness or fancy UI.

You have about **2 hours** for this exercise.
You are NOT expected to finish every task. Focus on correctness,
code quality, and reasoning. Partial but solid work is perfectly fine.

---

## 🧰 Tech Stack

- **.NET 9 / C#**
- **Entity Framework Core (InMemory)**
- **ASP.NET Core Web API**
- Dependency Injection + Clean Architecture style layers:
  - `Domain` – entities & rules
  - `Application` – interfaces & DTOs
  - `Infrastructure` – repositories & services
  - `Presentation` – API controllers

Run it directly:

```bash
dotnet run --project ShopLite.Presentation
```
Swagger UI will open at http://localhost:5000.

---

## 🧪 What’s Already Implemented
Basic entities: Product, Customer, Order

EF Core repositories

Controllers for Products, Orders, and Reports

Simple data seeding

Registration via AddInfrastructure()

Swagger setup

---

### 🧭 Your Tasks
Follow the step-by-step instructions already written in TODO comments:

1. Complete Domain Validation
  -- Implement or fix validation in:
  - Customer – name and email validation
  - Product – price, stock validation
  - Product.DecreaseStock() – throw when insufficient stock

2. Implement OrderService.PlaceOrderAsync
  - Validate Customer & Product existence
  - Decrease stock
  - Compute total amount
  - Save order & update product
  * Hint: IQueue is resolved inside the method; see Task 5

3. Implement ReportingService.GetTopCustomersAsync
  - Implement this using EF Core LINQ query (do not use raw SQL here)
  - For each customer, sum their total order amount
  - Filter where total ≥ minimumTotal
  - Return ordered list as TopCustomerDto
  
4. Implement ReportingService.GetProductSalesRawAsync
  - Write a raw SQL query that joins Products and Orders
  - Group by product and calculate TotalQuantity and TotalAmount
  - Map results to ProductSalesDto and return ordered list
  * Note: the current project uses the EF Core InMemory provider, which does not support raw SQL at runtime. This task will be verified by **code review only**, not by executing the query.

5. Implement the IQueue<T> and Register It
  -- A generic FIFO queue interface exists under Application:
  - Find existing implementation "InMemoryQueue" in Infrastructure
  - Implement it using your own FIFO logic (do not use built-in Queue<T> or similar ready-made queue types)
  - Register it in DI (IQueue<> → InMemoryQueue<>)
  - Resolve it inside OrderService.PlaceOrderAsync using IServiceProvider
  - Enqueue the created order.Id

6. Add Global Exception Handling Middleware
  -- A middleware file already exists with an implemented HandleExceptionAsync:
  - Implement InvokeAsync as described in the TODO comments
  - Enable the middleware in Program.cs (look for the TODO comment)
  
🌿 Branching Instructions

Before making any changes:

Create a new branch using your full name:
```bash
git checkout -b your-name
```
Commit your work normally to this branch.

Do not merge your branch into main — just push it or send it as-is for review.

---

## ✅ Completion Criteria
We’ll review:

Correctness – logic and validation work as expected

Clean Code – readable, maintainable structure

Domain Reasoning – proper use of business rules

Tests – if included, they run and make sense

No need to over-engineer; good naming and solid reasoning matter most.

---

## 🚀 Running & Testing
Ensure .NET 9 SDK is installed.

Run API:

bash
Copy code
dotnet run --project ShopLite.Presentation
Open Swagger UI and try:

GET /api/products

POST /api/orders

GET /api/reports/top-customers

and the other APIs

---

## 📝 Deliverable
Send back:

Your updated code (or a link to your repo / zip)

Optional short notes on what you improved or left for later

Good luck & have fun building! 🎯
