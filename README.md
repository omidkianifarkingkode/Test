# 🛍️ ShopLite – Coding Test

Welcome to **ShopLite**, a small demo e-commerce API designed as a technical exercise.  
Your task is to extend and complete this minimal project so it behaves like a simple online shop.

---

## 🧩 Goal

Implement a few missing pieces and improve code quality where noted.  
Focus on **correctness, clarity, and testability** rather than completeness or fancy UI.

You have about **1–2 hours**.  
Deliver what you can confidently explain — partial but well-structured work is preferred over rushed completeness.

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
Look for TODO: comments and missing logic.

1. Complete Domain Validation
  - Implement or fix validation in:
  - Customer – name and email validation
  - Product – price, stock validation
  - Product.DecreaseStock() – throw when insufficient stock

2. Implement OrderService.PlaceOrderAsync
  - Steps are listed as comments in the method:
  - Validate Customer & Product existence
  - Decrease stock
  - Compute total amount
  - Save order & update product

3. Implement ReportingService.GetTopCustomersAsync
  - For each customer, sum their total order amount
  - Filter where total ≥ minimumTotal
  - Return ordered list as TopCustomerDto

4. (Optional Bonus Ideas) If time allows:
  - Add basic unit tests for OrderService and Product.DecreaseStock
  - Handle concurrent stock updates (optimistic concurrency or transaction)
  - Add input validation (FluentValidation or manual)
  - Add pagination/filtering for /api/products

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

---

## 📝 Deliverable
Send back:

Your updated code (or a link to your repo / zip)

Optional short notes on what you improved or left for later

Good luck & have fun building! 🎯
