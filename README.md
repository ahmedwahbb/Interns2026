# NorthWaveConsole — Week 1 Starter (Intentionally Bad Code)

This is the legacy code interns start from on Day 1 of the roadmap.
It compiles and runs fine — that's the point. The problems are all
structural, not syntactic.

## Run it

```bash
dotnet run
```

It will write `orders.txt` and `app.log` next to the executable and
print two "processed" orders — except the second one silently fails
(empty customer name) and nothing tells you why.

## Do not fix this before Day 1

Let the intern diagnose the smells themselves first (that's Day 1's
exercise). See the comments in `Services/OrderService.cs` for the full
list of what's wrong, once you're ready to reveal it.

## Where this goes

By the end of Week 1 this project should have:
- An `IDiscountStrategy` per customer type instead of the if/else chain
- Interfaces for persistence, email, and logging, injected via
  constructor (Week 1 Day 5 wires up `Microsoft.Extensions.DependencyInjection`)
- `ILogger<T>` instead of hand-rolled file logging
- Guard clauses instead of nested ifs
- No swallowed exceptions

By Week 2 it becomes a class library (`NorthWaveCore`) with generics,
async, records, and pattern matching added. By Week 3–4 it becomes the
`NorthWaveAPI` project — see the reference solution folder in this kit
for what that end state looks like.
