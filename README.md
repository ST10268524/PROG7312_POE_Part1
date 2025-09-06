# MunicipalServices

MunicipalServices is an ASP.NET Core MVC web application built in C#.  
It is designed to help municipalities streamline citizen engagement by allowing residents to **report issues and service requests**.  

The application is user-friendly and serves as the first step in a broader municipal service platform.  

---

## 📌 Features

- **Report Issues** (implemented)  
  - Citizens can submit issues by providing details such as location and category.  
  - Attachments supported: `.jpg`, `.jpeg`, `.png`, `.pdf`, `.doc`, `.docx` (max 5MB).  
  - Optional notifications via email or SMS.  
  - Automatic reference number generation.  

- **Planned Features** (future development):  
  - Local Events & Announcements  
  - Service Request Status  

Currently, only **Report Issues** is enabled; the other two modules are disabled.

---

## 🛠️ Requirements

- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or later)  
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) (LTS)  
- SQL Server LocalDB (installed with Visual Studio)  
- Web browser (Chrome, Edge, or Firefox recommended)

---

## ⚙️ Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/ST10268524/PROG7312_POE_Part1.git
   cd MunicipalServices
   ```
2. **Open in Visual Studio**
   - Launch Visual Studio.
   - Slect **File** > **Open** > **Project/Solution**.
   - Open the *MunicipalServices.sln* file.
3. **Build the Project**
   - From Visual Studio's toolbar, click **Build** > **Build Solution**.
   - Ensure there are no compilation errors.
4. Run the Application
   - Press **F5** (Debug) or **Ctrl+F5** (Run without Debugging).

---

## 🚀 Using the Application

1. On startup, you will see three options:
   - **Report Issues** (enabled)
   - **Local Events and Announcements** (disabled)
   - **Service Request Status** (disabled)
   - **Community Engagement** (disabled)
2. Click Report Issues to file a new issue:
   - Select a category (e.g., Roads, Sanitation, Electricity).
   - Enter a description and location details.
   - Optionally attach a file (image or document).
   - Select notification preferences (Email or SMS).
3. Submit the form:
   - The issue is saved in the system.
   - A **reference number** is generated and shown on the confirmation page.
4. You can view details of submitted issues via the Details page.

---

<p align="center"> Made with ❤️ by <strong>Derik Korf</strong> </p> 



















