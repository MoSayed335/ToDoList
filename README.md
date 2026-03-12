📦 ToDoListProject
 ┣ 📂 src
 ┃ ┣ 📂 ToDoList.Domain         # Core Entities, Interfaces & Domain Logic
 ┃ ┃ ┣ 📂 Entities              # Task, Category, User
 ┃ ┃ ┗ 📂 Interfaces            # Repository Interfaces
 ┃ ┣ 📂 ToDoList.Application    # Business Logic & Use Cases
 ┃ ┃ ┣ 📂 DTOs                  # Data Transfer Objects (TaskDTO, CreateTaskDTO)
 ┃ ┃ ┣ 📂 Services              # TaskService, AuthService
 ┃ ┃ ┗ 📂 Mappings              # AutoMapper Profiles
 ┃ ┣ 📂 ToDoList.Infrastructure # Data Access & External Services
 ┃ ┃ ┣ 📂 Data                  # DbContext, Migrations
 ┃ ┃ ┣ 📂 Repositories          # Implementation of Domain Interfaces
 ┃ ┃ ┗ 📂 Identity              # User Management & JWT Logic
 ┃ ┗ 📂 ToDoList.API            # Presentation Layer (Controllers & Middlewares)
 ┃   ┣ 📂 Controllers           # TasksController, AuthController
 ┃   ┗ 📜 Program.cs            # Dependency Injection & Middleware Pipeline
 ┣ 📂 tests
 ┃ ┗ 📂 ToDoList.UnitTests      # Unit Testing for Services & Logic
 ┣ 📜 .gitignore                # Ignoring bin/obj and sensitive files
 ┣ 📜 ToDoList.sln              # Solution File
 ┗ 📜 README.md                 # Project Documentation
