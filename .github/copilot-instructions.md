# CSE 212 Data Structures - AI Coding Agent Guidelines

## Project Overview
This is a C# educational codebase for CSE 212 (Data Structures) at BYU-Idaho. It contains weekly project modules (Week 1-6) covering fundamental data structures and algorithms. Each week has **code**, **teach**, and sometimes **learn**/**analyze** projects organized as separate .NET projects within a single solution.

## Architecture

### Project Structure Pattern
- **`weekNN/code/`** - Main assignment projects with TODO problems and corresponding unit tests (MSTest)
- **`weekNN/teach/`** - Teaching examples with solution files (e.g., `CustomerService.cs` + `CustomerServiceSolution.cs`)
- **`weekNN/learn/`** - Learning modules with solution pairs
- **`weekNN/analyze/`** - Performance analysis and algorithm comparison projects
- **`sandbox/`** - Scratch workspace for testing ideas

### Data Structures by Week
- **Week 1**: Arrays (rotation, multiples, selection)
- **Week 2**: Queues (simple, priority, taking turns)
- **Week 3**: Sets and Maps (dictionaries, hashing)
- **Week 4**: Linked Lists (doubly-linked with Node, Head, Tail pointers)
- **Week 5**: Recursion (memoization, backtracking, maze solving)
- **Week 6**: Binary Search Trees

## Critical Development Patterns

### Problem Structure: TODO & PLAN Comments
Every assignment problem follows this exact pattern:
```csharp
/// <summary>
/// Problem N: Descriptive Title
/// </summary>
public static ReturnType MethodName(params)
{
    // TODO Problem N Start
    // PLAN:
    // 1. First step
    // 2. Second step
    // 3. Third step
    // TODO Problem N End
    
    // Implementation goes here
}
```
**Action**: When working on problems, read the PLAN section first - it's provided by instructors and contains the algorithm strategy. Fill implementation between TODO markers.

### Testing Requirements
- Tests use **MSTest** (Microsoft.VisualStudio.TestTools.UnitTesting)
- Test files are named `{ClassName}_Tests.cs` and **must NOT be modified**
- Tests use `CollectionAssert` for arrays/lists and `Assert.AreEqual` for values
- Run tests via `dotnet test` on the specific project (see Build section)
- Example: `Arrays_Tests.cs` tests methods in `Arrays.cs`

### Recursive Functions Pattern
Recursion implementations often use:
- **Base cases**: Check for termination conditions first (`if (n <= 0)`, `if (index == -1)`)
- **Memoization**: Pass `Dictionary<T, Result>` as optional parameter to cache results
- **Backtracking**: Use boolean arrays or visited tracking for path-finding problems (e.g., maze solving)
- Example from `Recursion.cs`:
  - `CountWaysToClimb` uses memoization with `remember` dictionary
  - `PermutationsChoose` uses backtracking with boolean `used` array
  - `SolveMaze` tracks `currPath` as List of coordinates

### Null-Coalescing for Optional Parameters
```csharp
public static void SomeMethod(Dictionary<int, string>? cache = null)
{
    if (cache == null) cache = new Dictionary<int, string>();
}
```
This pattern avoids unnecessary instance creation on recursive calls.

### Doubly-Linked List Implementation (Week 4)
LinkedList implements `IEnumerable<int>` and maintains both `_head` and `_tail` pointers. The `Node` class has both `Next` and `Prev` references. When inserting/removing:
- Update both direction pointers (Next AND Prev)
- Handle boundary cases (empty list, single node, head vs tail)

## Build & Test Commands

### Build Single Project
```powershell
dotnet build week05/code/code.csproj
```

### Run Tests for Specific Week
```powershell
dotnet test week05/code/code.csproj --verbosity=normal
```

### All Tests
```powershell
dotnet build cse212-projects.sln
dotnet test cse212-projects.sln
```

### Using VS Code Tasks
Pre-configured tasks available via "Terminal > Run Task":
- `build-week05-code` - Build Week 5 projects
- Use pattern `build-weekNN-{teach,analyze,code,learn}` for other modules

## Code Quality Conventions

### Naming
- **Public methods**: PascalCase (e.g., `InsertHead`, `RotateListRight`)
- **Private fields**: camelCase with underscore (e.g., `_head`, `_queue`, `_results`)
- **Parameters**: camelCase (e.g., `letters`, `amount`, `priority`)

### Comments & Documentation
- XML doc comments for public methods (e.g., `/// <summary>`)
- PLAN comments explain algorithm approach (provided in stubs)
- Don't over-comment; code structure should be self-evident

### Edge Cases to Always Handle
- Empty collections (null checks, empty lists)
- Single-element cases
- Boundary values (index 0, count-1)
- For queues/stacks: operations on empty structures should throw `InvalidOperationException`

## Common Mistakes to Avoid

1. **Modifying test files** - `_Tests.cs` files are read-only
2. **Forgetting to remove TODO markers** - Leave structure intact, just add implementation
3. **Not handling null references** - C# 8.0+ nullability is disabled in projects (`<Nullable>disable</Nullable>`), but validate anyway
4. **Off-by-one errors in recursion** - Base cases and recursive parameter decrements are critical
5. **Not updating both pointers in linked lists** - Next AND Prev must stay synchronized
6. **Not maintaining FIFO for equal priorities** - Use `>` not `>=` in priority comparisons (Week 2 pattern)

## Performance Considerations

- **Arrays**: O(1) access, O(n) insertion/deletion
- **Linked Lists**: O(n) access, O(1) insertion/deletion if you have the node reference
- **Hash-based collections** (Sets/Dicts): O(1) average case operations
- **Recursion**: Watch for exponential complexity without memoization
- Week 3's analyze projects test these tradeoffs

## Integration Points & Data Flows

- **LinkedList** → implements `IEnumerable<int>` for LINQ compatibility
- **Queue implementations** → share `Person` and `PersonQueue` data models
- **Maze solving** → uses `Maze` class (Week 5) loaded from `.txt` or `.csv` files
- **CSV parsing** → Week 3 teach uses `basketball.csv` for set/map operations

## Troubleshooting

- **Build errors**: Check `.csproj` files reference correct .NET SDK version (net8.0)
- **Test failures**: Run single test file to isolate issues: `dotnet test week05/code/code.csproj --filter TestClassName`
- **Null reference exceptions**: Review boundary conditions in recursive base cases
- **Stack overflow in recursion**: Likely infinite recursion or missing base case

---

**Last Updated**: February 2026  
**Framework**: .NET 8.0 with C# 12  
**Testing**: MSTest  
**Key Pattern**: Problem stubs with PLAN comments + separate test files + solution examples
