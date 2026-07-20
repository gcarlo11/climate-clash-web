# 🌍 Climate Clash Web

**Climate Clash Web** is a turn-based deckbuilding roguelite game centered around environmental crisis management, built with **Godot Engine 4.x**. Players combat escalating climate disasters (such as *Flood*, *Heatwave*, and *Climate Collapse*) using ecological action cards, managing energy resources, and mitigating threat meters.

---

## 🖼️ Gameplay Showcase

| Main Battle & UI | Climate Disasters |
|---|---|
| ![Battle Showcase 1](assets/placeholders/screenshots/Screenshot%202026-06-17%20130418.png) | ![Battle Showcase 2](assets/placeholders/screenshots/Screenshot%202026-06-17%20130430.png) |

| Map & Node Progression | Boss Encounter |
|---|---|
| ![Map & Events](assets/placeholders/screenshots/Screenshot%202026-06-17%20130447.png) | ![Boss Battle](assets/placeholders/screenshots/Screenshot%202026-06-17%20130506.png) |

---

## 🌟 Key Features

- **🃏 Strategic Deckbuilding**: Collect and play cards categorized by type (*Defensive*, *Offensive*, *Utility*, *Scaling*) and elemental themes (*Water*, *Thermal*, *Bio*, *Neutral*).
- **🌊 Dynamic Climate Enemies & Multi-Phase Boss**:
  - **Flood**: Delivers fast, steady damage with constant meter growth.
  - **Heatwave**: Thermal menace with attack scaling over time.
  - **Climate Collapse (Boss)**: Multi-phase boss fight entering **Phase 2** below 50% HP, dramatically boosting attack power and meter accumulation.
- **🗺️ Branching Run Map System**: Navigate through procedural node paths featuring regular **Battles**, **Event/Sanctuary** resting points, and ultimate **Boss** confrontations.
- **📊 Custom Visual HP & Threat Meter System**: Real-time *TextureProgressBar* UI synced dynamically based on disaster types and player status.
- **🎵 Centralized Audio Manager**: Integrated BGM and SFX system for hit feedback, card plays, and atmospheric audio.
- **🌐 Web & Cross-Platform Optimization**: Built with Godot's **GL Compatibility** renderer for web browser deployment (HTML5/WebAssembly).

---

## 🎮 Gameplay Mechanics

### 1. Elements & Card Roles
| Element | Primary Focus | Card Examples |
|---|---|---|
| **Water 💧** | Flood defense & flow disruption | *Flood Barrier*, *Water Pump* |
| **Thermal ☀️** | Temperature control & heat surges | *Solar Shade*, *Solar Flare* |
| **Bio 🌿** | Ecosystem restoration & healing | *Mangrove Wall*, *Reforestation*, *Green Bomb* |
| **Neutral ⚙️** | Policy management, energy manipulation & draw | *Policy Strike*, *Carbon Tax*, *EV Initiative*, *Climate Pact* |

### 2. Card Types
- **Defensive**: Grants Block (Armor) and suppresses enemy threat meter buildup.
- **Offensive**: Deals direct damage to climate entities.
- **Utility**: Reduces enemy threat meter, draws additional cards, or restores player HP.
- **Scaling**: Provides energy cost reductions or offensive damage buffs across turns.

### 3. Enemy Threat Meter
Each turn, climate disasters build up their **Threat Meter**. When the meter reaches capacity, the enemy unleashes a devastating catastrophic strike! Cards such as *Carbon Tax* or *Flood Barrier* allow players to suppress or reset meter progression.

---

## 📁 Project Structure

```text
climate-clash-web/
├── assets/
│   └── placeholders/
│       ├── cards/               # Card artwork (water_pump.png, etc.)
│       ├── characters/          # Player & enemy sprites (mc.png, enemy_flood.png)
│       ├── screenshots/         # In-game preview screenshots
│       └── ui/                  # UI themes & font files
├── scenes/
│   ├── MainMenu.tscn            # Main Menu Scene
│   ├── Map.tscn                 # Run Map Node Selection
│   ├── BattleFlood.tscn         # Flood Disaster Encounter
│   ├── BattleHeatwave.tscn      # Heatwave Disaster Encounter
│   ├── BattleBoss.tscn          # Climate Collapse Boss Encounter
│   ├── Event.tscn               # Sanctuary & Event Nodes
│   ├── Cutscene.tscn            # Story Cutscenes
│   └── Result.tscn              # Victory / Defeat Screen
├── scripts/
│   ├── core/                    # Core Game Engine Systems
│   │   ├── game_database.gd     # Card, Enemy & Node Definitions
│   │   ├── game_enums.gd        # Enums for Types, Elements & Enemies
│   │   ├── run_state.gd         # Persistent Run Progress State
│   │   ├── audio_manager.gd     # Autoload Sound Controller
│   │   └── damage_calculator.gd # Combat Math
│   ├── scenes/                  # Controller Scripts for Godot Scenes
│   └── backgrounds/             # Dynamic Shader & Background Logic
├── project.godot                # Godot 4 Project File
└── README.md                    # Project Documentation
```

---

## 🚀 Getting Started

### Prerequisites
- **Godot Engine**: Version `4.2+` (Recommended: **Godot 4.6** with *GL Compatibility* renderer).

### Running Locally
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/gcarlo11/climate-clash-web.git
   cd climate-clash-web
   ```
2. **Open Project in Godot Engine**:
   - Open **Godot Engine**.
   - Click **Import**, navigate to the `climate-clash-web` directory, and select `project.godot`.
   - Click **Import & Edit**.
3. **Play the Game**:
   - Press **F5** or click the **Play** button in the top-right corner to launch the main menu (`MainMenu.tscn`).

### Web Export (HTML5)
1. In Godot Editor, navigate to **Project > Export...**.
2. Add the **Web (HTML5)** export preset.
3. Click **Export Project** to compile to HTML5 and WebAssembly.

---

## 🎨 Asset Naming Conventions

For automatic asset loading into battle scenes and card interfaces, follow the guidelines specified in `assets/placeholders/README_ASSET_NAMING.txt`:
- **Card Art**: Saved in `res://assets/placeholders/cards/<card_id>.png` (Aspect ratio 2:3, e.g. `water_pump.png`).
- **Character Sprites**: Saved in `res://assets/placeholders/characters/` (`mc.png`, `enemy_flood.png`, `enemy_heatwave.png`, `enemy_boss.png`).

---

## 🛠️ Built With

- **Engine**: [Godot Engine 4.6](https://godotengine.org/)
- **Language**: GDScript
- **Rendering Driver**: Direct3D 12 / OpenGL Compatibility (Web ready)
- **Physics Engine**: Jolt Physics (3D)

---

## 📜 License & Credits

Developed for the **Climate Clash** environmental awareness game initiative. All visual assets, audio, and source code belong to the project maintainers.
