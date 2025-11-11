**ShopLite Coding Task (DDD-Lite)**

**Goal:**  
Implement basic domain validations and the order placement logic in Infrastructure.

**Steps for the candidate:**
1. Complete the TODOs in `Product`, `Customer`, and `Order` (basic validation).
2. Implement `OrderService.PlaceOrderAsync`:
   - Load `Customer` and `Product`; throw if not found.
   - Call `product.DecreaseStock(quantity)` (domain logic).
   - Calculate `amount = product.Price * quantity`.
   - Create and save the `Order`.
   - Update the product’s stock.
3. Run the API (`dotnet run -p src/ShopLite.Presentation`) and test via Swagger.
4. Run architecture tests:  
   `dotnet test tests/ShopLite.ArchTests`

**Acceptance criteria:**
- Architecture tests pass.  
- POST `/api/orders` returns 201 when valid.  
- Product stock decreases after placing an order.

**DDD hint:**  
Business rules belong in Domain; Application/Infrastructure coordinate persistence and flow.

──────────────────────────────
CLI Quickstart
──────────────────────────────
dotnet restore  
dotnet build  
dotnet run -p src/ShopLite.Presentation  
dotnet test
