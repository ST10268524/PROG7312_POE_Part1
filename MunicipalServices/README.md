# MunicipalServicesApp (ASP.NET MVC)

## Requirements
- Visual Studio 2019/2022
- .NET Framework 4.7.2 or 4.8

## How to run
1. Open MunicipalServicesApp.sln in Visual Studio.
2. Build (Ctrl+Shift+B).
3. Run (F5). The app will open in your browser.
4. On the home page, click "Report Issues" to use the form.

## Uploads
Attachments saved to the /Uploads folder in project root.

## Notes
- Data is stored in memory (List<Issue>) and resets when the app recycles.
- To persist data, replace IssueRepository with a database (EF or other).

## Demo video
- Use Windows Game Bar (Win+G) or OBS Studio to record a demo:
  - Show the app launch, open Report Issues, fill fields, attach file, submit, and view Confirmation + Reports list.
