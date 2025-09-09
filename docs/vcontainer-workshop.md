# VContainer Workshop

**Video**: [Building a Game with VContainer](https://youtu.be/G3dzcKoo62U)  
**Branch**: `workshops/00-vcontainer`

## Overview

This workshop demonstrates building a 2D spaceship asteroid shooter from scratch using VContainer dependency injection in Unity. The project showcases real-world usage of VContainer's key features through practical game development.

## What Was Built

A complete 2D asteroid shooter game featuring:
- Player-controlled spaceship with rotation and shooting mechanics
- Dynamic asteroid spawning system
- Score tracking with hit/miss penalties
- Full dependency injection architecture

## Key Concepts Covered

### VContainer Features
- **Service Registration**: Different methods for registering services, instances, and components
- **Lifetime Management**: Singleton, Transient, and Instance lifetimes
- **Entry Points**: Integration with Unity's lifecycle (IStartable, ITickable, IDisposable)
- **Keyed Registration**: Managing multiple instances of the same type
- **Runtime Resolution**: Using IObjectResolver for dynamic instantiation
- **Method Injection**: [Inject] attribute for non-registered MonoBehaviours

### Architecture Patterns
- Interface-based design for testability
- Service layer for business logic
- Controller layer for game logic
- Settings management with ScriptableObjects
- View layer for UI components

## Project Structure

```
Assets/Code/
├── Behaviors/          # MonoBehaviour utilities
├── Controllers/        # Game logic controllers  
├── Handlers/          # Input handling
├── Interfaces/        # Abstraction contracts
├── Services/          # Business logic services
├── Settings/          # ScriptableObject configurations
├── Utils/             # Utility classes and enums
├── Views/             # Presentation layer components
└── GameLifetimeScope.cs  # Main DI container configuration
```

## Game Controls
- **A/D Keys**: Rotate spaceship
- **Spacebar**: Fire bullet

## Technical Requirements
- Unity 6.2 (probably works with Unity 2022.1+)