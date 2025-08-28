# 📚 Library Management System

A simple and interactive Console-based Library Management System built using **C#**. This application allows users to add, borrow, and return books while tracking member activity.

---

## 🚀 Features

- 📖 Add new books with details like title, author, ISBN, and available copies.
- 📚 Borrow and return books with proper validations.
- 👤 View member information and the list of borrowed books.
- 📋 Display all books in the library.
- 🧾 Console-based UI for quick interaction.

---

## 🛠️ Tech Stack

- **Language:** C#  
- **Platform:** .NET Console Application  
- **Core Concepts Used:** OOPs (Classes, Objects, Lists, Encapsulation)

---

## 🧩 How It Works

Upon running the application, the user is greeted with a simple menu:

1. Add Book  
2. Borrow Book  
3. Return Book  
4. Show All Books  
5. Show Member Info  
6. Exit

Each option provides the corresponding functionality, and updates are reflected in real-time.

---

## 📂 Classes Used

### `Book`
Represents a book in the library.

- Fields: `Title`, `Author`, `ISBN`, `CopiesAvailable`
- Methods: `setTitle()`, `getTitle()`, `isBorrowed()`, `isReturned()` etc.

### `Member`
Represents a library member.

- Fields: `Name`, `MemberID`, `bookBorrowed`
- Methods: `Borrowed()`, `Returned()`, `HasBorrowed()`, `MemberInfo()`

---

## 🧠 Learning Objectives

This project helped reinforce:

- Object-Oriented Programming in C#
- List data structure and object manipulation
- Console I/O interaction
- Class design & encapsulation
