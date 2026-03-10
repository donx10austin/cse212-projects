# My SQLite App

## Overview
My SQLite App is a C# application that demonstrates how to use SQLite for data storage and management. This project includes a simple implementation of a database helper class, a model representing the data structure, and an entry point for running the application.

## Project Structure
```
my-sqlite-app
├── Data
│   └── DatabaseHelper.cs       # Contains methods for database operations
├── Models
│   └── ExampleModel.cs         # Defines the data structure for the application
├── my-sqlite-app.csproj        # Project file with configuration settings
├── Program.cs                  # Entry point of the application
└── README.md                   # Documentation for the project
```

## Setup Instructions
1. **Clone the repository**:
   ```
   git clone https://github.com/donx10austin/my-sqlite-app.git
   cd my-sqlite-app
   ```

2. **Install dependencies**:
   Ensure you have the necessary .NET SDK installed. You can install the SQLite NuGet package by running:
   ```
   dotnet add package Microsoft.Data.Sqlite
   ```

3. **Build the project**:
   ```
   dotnet build
   ```

4. **Run the application**:
   ```
   dotnet run
   ```

## Usage
- The `DatabaseHelper` class provides methods to connect to the SQLite database, execute queries, and manage transactions.
- The `ExampleModel` class represents the data structure used in the application, mapping to the fields in the database.
- Modify `Program.cs` to implement your application logic and interact with the database as needed.

## Contributing
Contributions are welcome! Please feel free to submit a pull request or open an issue for any suggestions or improvements.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.