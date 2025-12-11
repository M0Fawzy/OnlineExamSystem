# Online Exam System

## Project Overview

The Online Exam System is a web-based application built with ASP.NET Core MVC that allows administrators to create, manage, and administer online exams. Students can take exams and receive instant feedback on their performance.

### Key Features

- **Question Management**: Create and edit three types of questions:
  - Multiple Choice Questions (MCQ)
  - True/False Questions
  - Short Answer Questions

- **Exam Paper Creation**: Combine multiple questions into exam papers with customizable scoring

- **Exam Taking**: Students can take exams with an intuitive interface and receive immediate results

- **Score Calculation**: Automatic grading for objective questions with detailed score breakdowns

- **Responsive Design**: Clean, modern UI using Bootstrap and Bootswatch themes

## Technology Stack

- **Backend**: ASP.NET Core MVC
- **Database**: Entity Framework Core with SQL Server
- **Frontend**: HTML5, CSS3, Bootstrap 5, JavaScript
- **Architecture**: Repository Pattern with Dependency Injection

## Project Structure

```
Online_Exam_System/
├── Models/
│   ├── Exam.cs
│   ├── ExamPaper.cs
│   └── ExamPaperQuestion.cs
├── Controllers/
│   ├── ExamController.cs
│   └── ExamPaperController.cs
├── Views/
│   ├── Exam/
│   └── ExamPaper/
├── Repository/
│   ├── IRepository.cs
│   └── MainRepository.cs
└── Data/
    └── ApplicationDbContext.cs
```

## Screenshots

<img width="1918" height="907" alt="Questions View" src="https://github.com/user-attachments/assets/53fea9d2-c420-4d60-b741-4f798437555f" />

### 1. Question Management Page
The main dashboard displays all created questions with options to edit or delete them. Users can add new questions by clicking the "Add Question" button, which opens a modal form. The form supports three question types:
- **MCQ**: Displays 4 options with radio buttons for selection
- **True/False**: Shows True and False options
- **Short Answer**: Provides a text input field for written responses

The interface allows admins to view all questions at once and manage them efficiently.

<img width="1918" height="873" alt="Add Questions Modal" src="https://github.com/user-attachments/assets/cef488ea-d67b-456e-a69c-8bc9d9a883a4" />


### 2. Add Question Modal
The modal form enables users to create new questions with the following workflow:
1. Enter the question text
2. Select the question type from the dropdown
3. The form dynamically displays relevant fields based on the selected type
4. For MCQ: Enter 4 options and select the correct answer
5. For True/False: Choose True or False as the correct answer
6. For Short Answer: Enter the expected correct answer
7. Click "Save" to submit the question

The disabled field approach ensures only the relevant answer field is submitted based on the question type selected.

<img width="1915" height="912" alt="Exam View" src="https://github.com/user-attachments/assets/6e7368ed-2f21-4766-8e58-35c8f239a718" />


### 3. Exam Papers Dashboard
The Exam Papers page displays all created exam papers with their details and actions. Each exam paper card shows:
- **Exam Title**: The name of the exam (e.g., "Geography Exam", "Video Games Exam")
- **Total Score**: The cumulative score of all questions in the exam (e.g., 15, 10)
- **Action Buttons**:
  - **Take Exam**: Allows students to take the exam
  - **Remove**: Deletes the exam paper from the system

The "Create New Exam Paper" button in the header allows admins to create additional exam papers. This dashboard provides a quick overview of all available exams and makes it easy to manage them.


<img width="1918" height="905" alt="Create Exam View" src="https://github.com/user-attachments/assets/c4b1ba32-5550-4cd4-a0d6-58de00e5c550" />

### 4. Create New Exam Paper Form
The Create Exam Paper page allows admins to build custom exam papers by:
1. **Enter Exam Paper Title**: Name the exam (e.g., "Geography Exam")
2. **Select Questions**: Click "Add Question" to add questions to the exam paper
3. **Assign Scores**: Each question can be assigned individual points
4. **Review**: View the list of selected questions with their scores
5. **Submit**: Click "Create Exam Paper" to save the exam, or "Back" to cancel

The form displays a "Select Questions" section where admins can dynamically add multiple questions from the question bank and customize the scoring for each question. This flexible approach allows creating varied exams from a centralized question pool.

## Getting Started

### Prerequisites
- .NET 6.0 or higher
- SQL Server
- Visual Studio or VS Code

### Installation

1. Clone the repository
```bash
git clone https://github.com/yourusername/Online_Exam_System.git
cd Online_Exam_System
```

2. Update the database connection string in `appsettings.json`

3. Run migrations
```bash
dotnet ef database update
```

4. Start the application
```bash
dotnet run
```

## Features Implemented

✅ Create MCQ, True/False, and Short Answer questions
✅ Edit and delete questions
✅ Create exam papers with multiple questions
✅ Assign scores to individual questions
✅ Take exams with real-time feedback
✅ Auto-calculation of exam scores
✅ Responsive modal-based interface
✅ Form validation
✅ Clean and intuitive UI

## License

This project is open source and available under the MIT License.
