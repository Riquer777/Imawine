# Imawine

Imawine is a simple launcher for running Windows applications on Linux using Wine.

The focus is lightweight design, easy use, and clean organization.

---

## Features

* Run Windows games and apps using Wine
* Save and manage a list of games/apps
* Add and remove entries from the library
* Automatic folder creation:

  ```
  ~/WINGAMES
  ```
* Each game uses its own isolated Wine prefix
* Keyboard-based navigation

---

## Controls

* W / S → move up and down
* A / D → move left and right
* Enter → select
* Back / Esc → go back

---

## Storage structure

All games and configurations are stored in:

```
~/WINGAMES
```

Each entry has its own folder and Wine prefix.

---

## Wine

Wine is provided through the official release package of the project.

It is not included directly in this repository.

The version may change depending on the release.

---

## Lightweight design

Imawine is designed to stay lightweight:

* no heavy system dependencies
* no complex installation steps
* runs as a simple AppImage
* fast and simple workflow

---

## License

GPLv3

---

## Project name

Imawine

Author: Riquer777

---

## Planned features

* HELP menu inside the application
* Improved and cleaner UI
* Better Wine prefix management

---

## Note

Wine AppImage is distributed separately in official project releases.
