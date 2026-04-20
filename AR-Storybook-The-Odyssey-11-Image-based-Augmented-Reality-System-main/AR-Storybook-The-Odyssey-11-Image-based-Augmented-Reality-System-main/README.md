# The Odyssey 11 – Computer Vision-based AR Narrative System

## Overview

The Odyssey 11 is an Augmented Reality system that combines Computer Vision and real-time rendering to create an interactive storytelling experience.

The system uses Vuforia’s image recognition pipeline to detect predefined visual markers and trigger corresponding 3D scenes in Unity. This allows static images to function as real-time visual anchors for a structured narrative system.

The project is deployed as both a Windows application and an Android APK.

---

## Core Idea (Computer Vision Focus)

This project focuses on **image-based visual recognition and tracking in augmented reality environments**.

Each image in the storybook acts as a visual feature descriptor that is tracked in real-time using Vuforia’s computer vision engine. Once detected, the system maps the image to a predefined AR scene, enabling dynamic scene activation.

This forms a simple but effective **image-to-scene recognition pipeline**.

---

## Computer Vision Pipeline

1. Image Target Detection (Vuforia Feature Tracking)
2. Feature Matching and Pose Estimation
3. Scene Mapping (Image ID → AR Scene)
4. Real-time 3D Rendering (Unity Engine)

---

## System Architecture

- Input: Physical book images (6 image targets)
- Vision Module: Vuforia Engine (feature-based image tracking)
- Mapping Layer: Image ID → Scene Controller
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
- Augmented Reality (AR Core Concept)

---

## Deployment

- Windows Desktop Application (.exe build)
- Android APK (mobile AR experience)

Both builds use the same vision pipeline for real-time image tracking and scene activation.

---

## Project Type

- Computer Vision (Image-based Tracking)
- Augmented Reality System
- Real-time Scene Recognition Pipeline

---

## Key Highlights

- Implemented image-based tracking pipeline using Vuforia
- Designed mapping system between visual features and AR scenes
- Built real-time AR rendering system using Unity
- Cross-platform deployment (Windows + Android)

## Author
Nguyen Minh Nhan
