# Gaze Data Collection System

This program consists of two parts:

## 1. GazeDataServer (Python)

This component is written in Python and serves as the backend server for logging gaze data. 

### Installation

Before running the server, you need to install Flask. You can do this by running:

```bash
pip install Flask
```

### Running the Server

Once Flask is installed, you can start the server by executing:

```bash
python server.py
```

The log data will be displayed in the console window.

## 2. GazeDataCollector (Unity)

GazeDataCollector is a Unity project based on MRTK2.8's sample scene. 

### Deployment

This project is designed to be deployed on HoloLens 2. When the user looks at a panel in the scene, the system will send log information to the server.
