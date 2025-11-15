Task 1 – Complete Domain Validation: 1 / 5
Customer validation only checks for empty strings and a bare @ in the email, leaving whitespace and basic format issues unhandled, while the constructor bypasses validation entirely.
Product validation allows zero pricing, tolerates whitespace names, and DecreaseStock manipulates the local quantity argument instead of the product’s Stock, so inventory never changes and insufficient stock is never detected.

Task 2 – Implement OrderService.PlaceOrderAsync: 1 / 5
The service verifies entity existence but never checks quantity, never calls DecreaseStock, never ensures available inventory, and simply rewrites the existing product without updating stock or persisting a total derived from validated domain rules.

Task 3 – Implement ReportingService.GetTopCustomersAsync: 3 / 5
The method produces totals and ordering, but it synchronously materializes data and runs a new sum query for every customer, which is inefficient and ignores the async EF APIs the rest of the project is built around.

Task 4 – Optional Bonus Ideas: 1 / 5
No extra safeguards such as concurrency handling were added to order placement, and there are no test projects or files alongside the main source folders to cover the requested scenarios.