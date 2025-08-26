# VContainer Example Project

A comprehensive Unity project demonstrating VContainer dependency injection concepts. This project is the source code artifact from the "Gamedev Engine Room" YouTube channel, showcasing a spaceship asteroid shooter game built from scratch to demonstrate VContainer usage.

## 📋 Project Overview

This is a 2D spaceship asteroid shooter built to demonstrate VContainer's key features:
- **Dependency Injection** with interfaces and implementations
- **Lifetime Management** (Singleton, Transient, Instance)
- **Entry Points** for game loop integration
- **Keyed Registration** for multiple instances
- **Service Location** with IObjectResolver
- **Component Registration** for MonoBehaviour injection

## 🎮 Game Mechanics

- **Player Control**: Rotate spaceship with keyboard input and shoot bullets
- **Asteroid System**: Asteroids spawn randomly and despawn after time
- **Scoring**: Points awarded for hits, deducted when asteroids despawn without being hit

## 🏗️ Architecture

### Core Components

#### 1. **GameLifetimeScope** (`Assets/Code/GameLifetimeScope.cs:28`)
The main DI container configuration demonstrating:

```csharp
protected override void Configure(IContainerBuilder builder)
{
    // Service registration with interfaces
    builder.Register<IBulletsService, BulletsService>(Lifetime.Singleton);
    builder.Register<IScoreService, ScoreService>(Lifetime.Singleton);
    
    // Instance registration with keyed access
    builder.RegisterInstance(_bulletSpawnPoint).Keyed(TransformKey.BulletSpawn);
    
    // Component registration for MonoBehaviour
    builder.RegisterComponent(_playerView).As<IPlayerView>();
    
    // Entry points for game loop
    builder.UseEntryPoints(config =>
    {
        config.Add<PlayerController>();
        config.Add<TargetsService>();
    });
}
```

#### 2. **Key VContainer Concepts Demonstrated**

**🔧 Service Registration Types:**
- `Register<Interface, Implementation>()` - Standard DI registration
- `RegisterInstance()` - Register existing objects
- `RegisterComponent()` - Register MonoBehaviour components
- `Keyed()` registration for multiple instances of same type

**⏱️ Lifetime Management:**
- `Singleton` - Single instance per container (BulletsService, ScoreService)
- `Transient` - New instance per resolve (TargetController)
- `Instance` - Pre-created objects (Settings, Views)

**🚪 Entry Points:**
- `IStartable` - Called when container starts
- `ITickable` - Called every frame
- `IDisposable` - Called when container disposes

### Service Layer

#### BulletsService (`Assets/Code/Services/BulletsService.cs:18`)
Demonstrates:
- Constructor injection with multiple dependencies
- Keyed dependency resolution: `[Key(TransformKey.BulletSpawn)] Transform`
- IObjectResolver usage for runtime instantiation with DI: `_resolver.Instantiate(_bulletPrefab)`

#### TargetsService (`Assets/Code/Services/TargetsService.cs:19`)
Shows:
- IEnumerable injection for multiple registered instances
- Runtime dependency resolution with IObjectResolver

### Controller Layer

#### PlayerController (`Assets/Code/Controllers/PlayerController.cs:14`)
Implements:
- ITickable for frame-based updates
- Constructor dependency injection

### Settings Management

#### GameSettings (`Assets/Code/Settings/GameSettings.cs:7`)
ScriptableObject-based settings:
- Interface implementation
- Unity Inspector integration
- Configurable game parameters

#### UiView (`Assets/Code/Views/UiView.cs:17`)
Demonstrates:
- MonoBehaviour that's NOT registered in the container
- Method injection using `[Inject]` attribute
- Automatic dependency resolution for scene objects

## 🔍 Key Learning Points

### VContainer Features Demonstrated
- **Multiple Registration Types**: Services, instances, components, and keyed registration
- **Lifetime Management**: Singleton, transient, and instance lifetimes
- **Entry Points**: Integration with Unity's lifecycle using IStartable, ITickable, IDisposable
- **Method Injection**: Using `[Inject]` attribute for MonoBehaviours not registered in container
- **Runtime Instantiation**: Creating objects with dependency injection using IObjectResolver

## 🚀 Getting Started

### Prerequisites
- Unity 6.2 (probably works with Unity 2022.1+, but not tested on other versions)
- VContainer package (installed via OpenUPM)

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   ```

2. **Open in Unity**
   - Open Unity Hub
   - Add project from disk
   - Select the project folder

3. **Package Dependencies**
   The project uses OpenUPM registry for:
   - `jp.hadashikick.vcontainer`: 1.17.0
   - `com.cysharp.unitask`: 2.5.10

4. **Run the Game**
   - Open `Assets/Scenes/MainScene.unity`
   - Press Play

### Controls
- **A/D Keys**: Rotate spaceship
- **Spacebar**: Fire bullet

## 📁 Project Structure

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
└── GameLifetimeScope.cs  # Main DI container
```

## 📚 Tutorial Topics Covered

This project demonstrates these VContainer concepts suitable for YouTube tutorials:

1. **Basic Setup** - Installing and configuring VContainer
2. **Service Registration** - Different registration methods
3. **Lifetime Management** - Understanding object lifecycles  
4. **Interface-Based Design** - Coding to contracts
5. **Entry Points** - Integrating with Unity's lifecycle
6. **Keyed Registration** - Managing multiple instances
7. **Runtime Resolution** - IObjectResolver usage
8. **Method Injection** - Using [Inject] attribute
9. **Dynamic Instantiation** - Creating objects with DI
10. **MonoBehaviour Integration** - Non-registered components with injection

## 📺 YouTube Channel

This project was built from scratch in the "Gamedev Engine Room" YouTube channel as a VContainer tutorial.

## 📝 License

MIT License - This project is provided as an educational resource for learning VContainer and dependency injection patterns in Unity.
