# Cybersecurity Awareness Bot - Part 2

## CAA - Cybersecurity Awareness Assistant

A WPF-based desktop application that educates users about online safety through an intelligent chatbot. The bot recognises cybersecurity keywords, detects user sentiment, remembers personal information, and provides random responses to keep conversations engaging.

---

## Author

**Buyelo Tevin Mashele**  
Module: PROG6221 - Programming 2A  
Institution: IIE Rosebank

---

## Video Presentation

[Click here to watch the video presentation](https://youtu.be/21Ya0szE1Mc)

---

## Features Implemented

| Feature | Description |
|---------|-------------|
| Voice Greeting | Plays a welcome message when the application starts |
| GUI Interface | Clean WPF interface with dark theme and professional layout |
| Keyword Recognition | Recognises passwords, phishing, privacy, scams, and malware |
| Random Responses | Multiple responses per topic, selected randomly |
| Sentiment Detection | Detects worried, curious, frustrated, and happy sentiments |
| Memory Storage | Remembers user's name and favourite cybersecurity topic |
| Follow-up Handling | Responds to "tell me more", "explain more", "another tip" |
| Input Validation | Handles empty inputs and unknown queries gracefully |
| CI/CD Pipeline | GitHub Actions automatically builds and tests the project |

---

## Technologies Used

- **Language:** C# (.NET 8.0)
- **Framework:** WPF (Windows Presentation Foundation)
- **Audio:** System.Media.SoundPlayer
- **Version Control:** Git and GitHub
- **CI/CD:** GitHub Actions (windows-latest runner)

---

## How to Run

### Prerequisites

- Windows operating system
- .NET 8.0 SDK
- Visual Studio 2022

### Steps

1. Clone the repository

```bash
git clone https://github.com/tevinmashele/CybersecurityChatbot
