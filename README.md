# The Odyssey 11 – Computer Vision-based AR Narrative System

## Overview

The Odyssey 11 is an Augmented Reality system that combines Computer Vision and real-time rendering to create an interactive storytelling experience.

The system uses Vuforia’s image target detection and tracking pipeline to detect predefined visual markers and trigger corresponding 3D scenes in Unity. This allows static images to function as visual anchors for placing AR content in 3D space.

The project is deployed as both a Windows application and an Android APK.

Link Demo: https://youtu.be/4vPuH-QUpCM

---

## Core Idea (Computer Vision Focus)

This project applies computer vision techniques through Vuforia for real-time image tracking in augmented reality environments.

Each image in the storybook is registered as an Image Target, from which visual features are extracted and tracked in real time by Vuforia’s computer vision engine. Once detected, the system maps the image to a predefined AR scene, enabling dynamic scene activation.

This forms a simple but effective image-to-scene mapping pipeline.

---

## Computer Vision Pipeline

1. Image Target Detection (Vuforia)
2. Feature-based Tracking and Pose Estimation (handled by Vuforia)
3. Scene Mapping (Image Target → AR Scene)
4. Real-time 3D Rendering (Unity Engine)

---

## System Architecture

- Input: Physical book images (6 image targets)
- Vision Module: Vuforia Engine (feature-based image tracking)
- Mapping Layer: Image Target → Scene Controller
- Rendering Engine: Unity 3D runtime
- Output: Real-time AR scene overlay

---

## Narrative Context (Optional)

The story follows “The Odyssey 11”, a classified lunar mission where previous expeditions have been erased from history. Each detected image represents a fragmented memory of the mission, reconstructed in AR space.

---

## Technologies

- Unity Engine
- Vuforia Engine (Computer Vision / Image Tracking)
- C#
- Augmented Reality (AR)

---

## Deployment

- Windows Desktop Application (.exe build)
- Android APK (mobile AR experience)

Both builds use the same vision pipeline for real-time image tracking and scene activation.

---

## Project Type

- Computer Vision (Image-based Tracking - applied via Vuforia)
- Augmented Reality System
- Real-time Scene Mapping Pipeline

---

## Key Highlights

- Implemented an image-based tracking system using Vuforia Image Targets
- Designed a mapping system between Image Targets and AR scenes
- Built a real-time AR rendering pipeline using Unity
- Deployed cross-platform (Windows + Android)

---

## Author
Nguyen Minh Nhan
