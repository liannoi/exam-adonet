# Address Plan

[//]: # (Badges)

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/57265e99afa048e89f4a990cc2b779fa)](https://www.codacy.com/manual/liannoi/exam-adonet?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=liannoi/exam-adonet&amp;utm_campaign=Badge_Grade)
[![CodeFactor](https://www.codefactor.io/repository/github/liannoi/exam-adonet/badge)](https://www.codefactor.io/repository/github/liannoi/exam-adonet)
[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://github.com/liannoi/exam-adonet/blob/master/LICENSE)

[//]: # (Snapshot of the program)

![](https://github.com/liannoi/exam-adonet/blob/master/snapshot.png)

[//]: # (Short description)

Examination project performed by me at the STEP Computer Academy.

This project is a kind of address accounting application. The main idea is to
perform CRUD operations on the database through a graphical application. For
more convenient data retrieval from the database, it was necessary to describe
the procedure in SQL (T-SQL).

Graphics written in WinForms (Windows Forms) using the MVP architectural
pattern.

The second part of the examination task is writing LINQ queries to a set of
addresses.

**I got 10/12 for work. Teacher: Vasilenko Igor Grigorevich**

[//]: # (Paragraphs)

## System requirements

| Visual Studio    | .NET Framework         | C#  |
|------------------|------------------------|-----|
| 2017 (or higher) | 4.8 (is recommended)   | 7.3 |

## Build and Run

- Сlone the repository
- Launch SQL Server Management Studio (SSMS)
- Connect to an instance of SQL Server
- **(optional)** *If the database has already been created, delete it yourself*
- Run the [script to create the database](https://github.com/liannoi/exam-adonet/blob/master/db/script-to-create.sql)
- Run the [script to create the procedure](https://github.com/liannoi/exam-adonet/blob/master/db/procedure.sql)
- Run [AddressPlan.sln](https://github.com/liannoi/exam-adonet/blob/master/src/AddressPlan.sln) file in Visual Studio.

## License

The repository is licensed by [Apache-2.0](https://github.com/liannoi/exam-adonet/blob/master/LICENSE).
