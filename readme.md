# Wake Word Detection for Unity

This project implements wake word detection in Unity using Picovoice's Porcupine engine. It can detect the wake word "Hey Digi" and works on both Windows and Android platforms.

## Prerequisites

- Unity 2020.3 or newer
- Picovoice Account and Access Key
- For Android: Android SDK and NDK

## Setup

1. Clone this repository
2. Open the project in Unity
3. Sign up at [Picovoice Console](https://console.picovoice.ai/)
4. Get your access key
5. Replace `YOUR_PICOVOICE_ACCESS_KEY` in `WakeWordDetector.cs` with your key
6. Import the Porcupine Unity package from Picovoice

## Project Structure

```
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── WakeWordManager.cs       # Singleton manager for wake word detection
│   │   ├── WakeWordDetector.cs      # Main detection implementation
│   │   └── AudioPermissionManager.cs # Handles microphone permissions
│   ├── UI/
│   │   └── PermissionDialog.cs      # UI for permission requests
│   └── Demo/
│       └── DemoManager.cs           # Demo scene implementation
├── Scenes/
│   └── Demo.unity                   # Demo scene
└── Plugins/
    └── Porcupine/                   # Porcupine plugin files
```

## Features

- Wake word detection using "Hey Digi"
- Cross-platform support (Windows & Android)
- Proper permission handling
- Debug mode for development
- Simple demo scene
- Singleton pattern for easy access
- Event-based architecture

## Building

### For Windows
1. Open Build Settings
2. Select PC, Mac & Linux Standalone
3. Switch platform to Windows
4. Build

### For Android
1. Open Build Settings
2. Select Android
3. Switch platform to Android
4. Set minimum API level to 21
5. Build

## Usage

1. Add the WakeWordManager prefab to your scene
2. Subscribe to the onWakeWordDetected event
3. Implement your response logic

Example:
```csharp
WakeWordManager.Instance.onWakeWordDetected.AddListener(() => {
    Debug.Log("Wake word detected!");
    // Your code here
});
```