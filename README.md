# Order Processing System Refactoring

## Overview

This project started as a deliberately poorly designed order processing system intended to demonstrate common Object-Oriented Programming (OOP) and SOLID principle violations.

The goal of this refactoring was **not** to rewrite the application from scratch, but to improve it incrementally while keeping the application working after each change. This mirrors how legacy systems are typically refactored in real software projects.

---

# Initial Problems

The original implementation contained several design issues:

## Domain Model

* Public fields instead of encapsulated properties.
* Mutable collections exposed directly.
* Business concepts represented as strings (`CustomerType`, `Status`).
* Anemic domain model where entities contained only data.

## OrderService

The `OrderService` handled multiple unrelated responsibilities:

* Validation
* ID generation
* Total calculation
* Discount calculation
* Status management
* File persistence
* Email notifications
* Logging

This violated the **Single Responsibility Principle (SRP)** and made the service difficult to maintain, test, and extend.

## Other Issues

* Nested `if` statements.
* Tight coupling to the file system and console.
* Static ID generation.
* No clear separation between business logic and infrastructure.

---

# Refactoring Process

The system was refactored in small steps.

## Step 1 – Refactor the Domain Model

### Changes

* Replaced public fields with properties.
* Introduced constructors.
* Replaced strings with enums:

  * `CustomerType`
  * `OrderStatus`
* Encapsulated the order item collection.
* Added `AddItem()` to control modifications.
* Added subtotal calculation inside the `Order` entity.

### Benefits

* Improved encapsulation.
* Stronger type safety.
* Richer domain model.
* Invalid object states became harder to create.

---

## Step 2 – Extract Validation

Created:

* `OrderValidator`

Responsibilities moved from `OrderService`:

* Customer validation.
* Order validation.

### Benefits

* Better separation of concerns.
* Easier to extend validation rules.
* Simpler `OrderService`.

---

## Step 3 – Extract Pricing

Created:

* `OrderPricingService`

Responsibilities moved from `OrderService`:

* Discount calculation.
* Final total calculation.

The `Order` entity now provides the subtotal while pricing policies remain inside the pricing service.

### Benefits

* Business pricing rules isolated.
* Easier future extension.
* Cleaner application workflow.

---

## Step 4 – Extract Persistence

Created:

* `IOrderRepository`
* `FileOrderRepository`

Responsibilities moved:

* File persistence.

### Benefits

The application now depends on an abstraction rather than the file system implementation.

Future implementations could include:

* SQL Server
* PostgreSQL
* MongoDB
* REST API
* Cloud Storage

without modifying `OrderService`.

---

## Step 5 – Extract Notifications

Created:

* `INotificationService`
* `EmailNotificationService`

Responsibilities moved:

* Sending order confirmations.

### Benefits

The notification mechanism can now be replaced without affecting business logic.

Examples:

* Email
* SMS
* Push Notifications

---

## Step 6 – Extract Logging

Created:

* `ILogger`
* `FileLogger`

Responsibilities moved:

* Application logging.

### Benefits

Logging implementation is isolated from the application workflow.

Future implementations could use:

* Serilog
* NLog
* Elastic Stack
* Azure Monitor

---

## Step 7 – Dependency Injection

`OrderService` no longer creates its own dependencies.

Instead, dependencies are supplied through constructor injection.

### Before

```text
OrderService
    ├── new OrderValidator()
    ├── new FileRepository()
    ├── new EmailService()
```

### After

```text
Program
      │
      ▼
OrderService
      │
      ├── OrderValidator
      ├── OrderPricingService
      ├── IOrderRepository
      ├── INotificationService
      └── ILogger
```

This reduced coupling and improved testability.

---

# Final Architecture

```text
                     Program
                        │
                        ▼
                  OrderService
                        │
 ┌──────────┬──────────┬──────────┬──────────┬──────────┐
 ▼          ▼          ▼          ▼          ▼
Validator  Pricing  Repository  Notifier   Logger
 Service    Service
```

The `OrderService` now acts as an **Application Service** responsible only for coordinating the workflow.

---

# SOLID Improvements

| Principle                       | Improvement                                                                                                |
| ------------------------------- | ---------------------------------------------------------------------------------------------------------- |
| Single Responsibility Principle | Responsibilities extracted into dedicated classes.                                                         |
| Open/Closed Principle           | Repository, notification, and logging implementations are replaceable without modifying application logic. |
| Liskov Substitution Principle   | Repository, logger, and notification implementations are interchangeable through interfaces.               |
| Interface Segregation Principle | Small, focused interfaces were introduced.                                                                 |
| Dependency Inversion Principle  | High-level modules depend on abstractions rather than concrete implementations.                            |

---

# OOP Improvements

* Improved encapsulation using private setters and private collections.
* Replaced primitive types with domain-specific enums.
* Added domain behavior to entities.
* Reduced mutable state.
* Improved abstraction by exposing behaviors instead of internal implementation details.

---

