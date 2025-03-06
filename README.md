### Week 7 Assignment: Object Factories and Adding Rooms

---

# Exam Preparation Guide

## Overview

Welcome to Week 7! This week, there will be no new assignments. Instead, you should focus on reviewing the Week 7 code and preparing for the upcoming in-class midterm exam. The exam will be heavily based on the concepts and code from Week 7 which is a culmination of the assignments that have come before. In the exam you will be asked to modify and extend the existing codebase.

## What to *Potentially* Expect in the Exam

During the in-class midterm exam, you will be asked to add new functionality to the existing codebase. Here are **some examples of the types of modifications you might be asked to make**:

### 1. Add a New Room
You may be asked to add a new type of room to the game. This will involve:
- Defining a new room type in the `RoomFactory`.
- Implementing the new room's properties and behaviors and adding it to the existing world map, making sure it can be visited by the player.

### 2. Add a New Monster
You might be required to introduce a new monster to the game. This will involve:
- Creating a new monster class that inherits from an existing abstract class or implements an interface for behavior.
- Adding the new monster to the game's logic and adding it to a room, making sure it is visible when the player visits the room.

### 3. Enhance Attack Functionality
You could be asked to improve the attack functionality. This might include:
- Adding new attack types or special abilities.
- Modifying the existing attack logic to include new features such as reducing hit points based on damage, or allowing for multiple hits.

### 4. Update Equipment List After Combat
You may need to update the equipment list after combat. This will involve:
- Modifying the combat logic to include equipment drops.
- Updating the player's inventory with new items.

### 5. Improve the Menu
You might be asked to enhance the game's menu. This could include:
- Adding new menu options.
- Improving the user interface and navigation.

## How to Prepare

To prepare for the exam, you should thoroughly review the Week 7 code. Focus on understanding the following concepts:

### Data Context
- Understand how the existing data context is reading in the `input.json` and adding characters (player, ghost, goblin) to the game.

### Factory Methods
- Understand how factory methods are used to create objects.
- Review the `RoomFactory` implementation and how it creates different types of rooms.

### Abstract Classes and Interfaces
- Review how abstract classes and interfaces are used to define common behaviors and properties.
- Understand how to implement new classes that inherit from abstract classes or implement interfaces.

### SOLID Principles
- Understand how the SOLID Principles are applied in the codebase.
- For example, review how high-level modules depend on abstractions rather than concrete implementations.

### Code Modularity and Extensibility
- Understand how the code is structured to promote modularity and extensibility.
- Review how new functionality can be added without modifying existing code.

## Tips for Success

- **Practice:** Implement your own modifications to the Week 7 code to get comfortable with adding new functionality in preparation for the midterm.
- **Understand the Concepts:** Make sure you understand the key concepts of factory methods, abstract classes, interfaces, etc, as mentioned above.
- **Ask Questions:** If you have any questions or need clarification, don't hesitate to reach out for help.

## Further Reading

To reinforce your understanding, you can refer to the following resources, or any of the resources that have been previously supplied.

- [Factory Method Pattern - Refactoring.Guru](https://refactoring.guru/design-patterns/factory-method)
- [Factory Method Pattern in C# - DotNetTricks](https://www.dotnettricks.com/learn/designpatterns/factory-method-design-pattern-dotnet)
- [Creational Design Patterns - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/standard/design-patterns/creational-design-patterns)

## Next Steps

Good luck with your preparation, and see you in class for the midterm exam!