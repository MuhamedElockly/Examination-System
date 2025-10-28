## Examination System (WPF, .NET 8)

A simple examination system built with WPF and .NET 8 that reads exam data from JSON, renders different question types, and collects student answers using the MVVM architectural pattern. The solution consists of a WPF UI project (`AppDesign`) and a reusable domain library (`Examination System`).

### Features
- **Load exams from JSON**: Exam, questions, and answers are deserialized from `Json/Exam.json`.
- **Multiple question types**: True/False, single-choice, and multiple-select (choose-all) questions.
- **Answer collection**: Captures and validates user selections.
- **Question navigation**: Move between questions with visual flags/markers.
- **Separation of concerns (MVVM)**: ViewModels drive UI logic; Models encapsulate exam domain.
- **Extensible domain library**: Core exam logic lives in the `Examination System` project for reuse and testing.

### Tech Stack
- **Framework**: .NET 8
- **UI**: WPF (Windows Presentation Foundation)
- **Language**: C#
- **Serialization**: JSON-based exam definitions

### Solution Structure
```
Examination System.sln
├─ AppDesign/                         # WPF UI (Startup project)
│  ├─ App.xaml / App.xaml.cs          # WPF application entry
│  ├─ MainWindow.xaml(.cs)            # Main shell / navigation
│  ├─ ExaminationWindow.xaml(.cs)     # Exam screen
│  ├─ ExamViewModel.cs                # Exam-level state and actions
│  ├─ QuestionViewModel.cs            # Per-question bindings
│  ├─ QuestionTemplateSelector.cs     # Chooses DataTemplate per question type
│  ├─ QuestionWrapper.cs              # Bridges model ↔ view state
│  ├─ WrappedAnswer.cs                # Answer binding helpers
│  └─ assets (flag.png, etc.)         # UI imagery for flags/markers
│
└─ Examination System/                # Domain library (Models + JSON IO)
   ├─ Exam/                           # Exams (Final/Practical)
   ├─ Question/                       # Question types + contracts
   ├─ Answer/                         # Answer models/collections
   ├─ Json/                           # DTOs + JSON handler
   │  └─ Exam.json                    # Sample exam data
   └─ Program.cs                      # (Library entry/testing, if used)
```

### MVVM Architecture
This project follows MVVM to keep UI clean and testable.

- **Model (M)**: Pure C# domain types for exams, questions, and answers.
  - Located in `Examination System/Exam`, `Question`, and `Answer`.
  - No UI dependencies; responsible for validation rules and core logic.

- **View (V)**: XAML pages/windows and their visual states.
  - Located in `AppDesign` as `MainWindow.xaml`, `ExaminationWindow.xaml`, and DataTemplates.
  - Uses bindings, styles, and a `QuestionTemplateSelector` to render different question types.

- **ViewModel (VM)**: Bridges View and Model; exposes properties/commands for bindings.
  - `ExamViewModel` manages overall exam lifecycle, navigation, remaining time (if any), and submission state.
  - `QuestionViewModel` exposes the current question, available answers, and selection state.
  - ViewModels do not directly reference view types; they are unit-test friendly.

Data Flow (high level):
1) JSON → DTOs (`JsonRootModel`, `JsonExam`, `JsonQuestion`, etc.) via `JsonHandler`.
2) DTOs → Domain Models (Exam, Question, Answer).
3) Models → ViewModels (`ExamViewModel`, `QuestionViewModel`).
4) View binds to ViewModels; user actions update ViewModels, which update Models.

### How It Works
- On startup, the UI loads exam data from `Json/Exam.json`.
- The `ExamViewModel` prepares a list of `QuestionViewModel`s.
- `QuestionTemplateSelector` picks the appropriate DataTemplate (True/False, Single Choice, Choose All) for each item based on its type.
- User selections are tracked and can be validated/serialized for review or scoring logic.

### Getting Started
1) Prerequisites
   - Windows 10/11
   - .NET SDK 8.0+
   - Visual Studio 2022 (or newer) with “.NET desktop development” workload

2) Open and Run
   - Open `Examination System.sln` in Visual Studio.
   - Set `AppDesign` as the Startup Project.
   - Build the solution (Debug/Any CPU or x64).
   - Run (F5). The app should launch and load the sample exam.

3) Edit Exam Content
   - Update `Examination System/Json/Exam.json` (and the copy under `AppDesign/bin/.../Json/Exam.json` at runtime if needed).
   - Add/modify questions and answers following the existing JSON structure.

### Customization Tips
- Add new question types by:
  - Creating a new Model in `Question/` and extending the domain logic.
  - Extending `QuestionViewModel` or adding a specialized VM if needed.
  - Adding a DataTemplate and updating `QuestionTemplateSelector` to map the new type.

### Troubleshooting
- If the UI shows no questions, verify the JSON path and that `Exam.json` is copied to the output directory.
- Ensure `AppDesign` targets `net8.0-windows` and builds without errors.

### License
This project has no explicit license. If you intend to use or distribute it, consider adding a license (e.g., MIT) to this repository.

### Acknowledgements
- Built with WPF and .NET 8.
- MVVM structure inspired by common WPF best practices.