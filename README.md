# JankiiEngine

```
       █████   █████████   ██████   █████ █████   ████ █████ █████
      ▒▒███   ███▒▒▒▒▒███ ▒▒██████ ▒▒███ ▒▒███   ███▒ ▒▒███ ▒▒███
       ▒███  ▒███    ▒███  ▒███▒███ ▒███  ▒███  ███    ▒███  ▒███
       ▒███  ▒███████████  ▒███▒▒███▒███  ▒███████     ▒███  ▒███
       ▒███  ▒███▒▒▒▒▒███  ▒███ ▒▒██████  ▒███▒▒███    ▒███  ▒███
 ███   ▒███  ▒███    ▒███  ▒███  ▒▒█████  ▒███ ▒▒███   ▒███  ▒███
▒▒████████   █████   █████ █████  ▒▒█████ █████ ▒▒████ █████ █████
 ▒▒▒▒▒▒▒▒   ▒▒▒▒▒   ▒▒▒▒▒ ▒▒▒▒▒    ▒▒▒▒▒ ▒▒▒▒▒   ▒▒▒▒ ▒▒▒▒▒ ▒▒▒▒▒



 ██████████ ██████   █████   █████████  █████ ██████   █████ ██████████
▒▒███▒▒▒▒▒█▒▒██████ ▒▒███   ███▒▒▒▒▒███▒▒███ ▒▒██████ ▒▒███ ▒▒███▒▒▒▒▒█
 ▒███  █ ▒  ▒███▒███ ▒███  ███     ▒▒▒  ▒███  ▒███▒███ ▒███  ▒███  █ ▒
 ▒██████    ▒███▒▒███▒███ ▒███          ▒███  ▒███▒▒███▒███  ▒██████
 ▒███▒▒█    ▒███ ▒▒██████ ▒███    █████ ▒███  ▒███ ▒▒██████  ▒███▒▒█
 ▒███ ▒   █ ▒███  ▒▒█████ ▒▒███  ▒▒███  ▒███  ▒███  ▒▒█████  ▒███ ▒   █
 ██████████ █████  ▒▒█████ ▒▒█████████  █████ █████  ▒▒█████ ██████████
▒▒▒▒▒▒▒▒▒▒ ▒▒▒▒▒    ▒▒▒▒▒   ▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒ ▒▒▒▒▒    ▒▒▒▒▒ ▒▒▒▒▒▒▒▒▒▒

> Embrace the jank_
```

## Features

None right now, but soon, maybe some! ☝️🤓

## Intention

Make an ASCII game engine capable of real-time input handling and gameplay.  
Game-agnostic, barebone framework that provides object instancing, state rendering and update loops.

**Should be able to create:**

- Flappy bird
- Space invaders
- Pong
- Rogue

Without major hurdles.

**Stretch goals:**

- Integrated UI component system.
- Scenes

## Hurdles (Notes to self)

- Viewport rendering for rogue-like games
- Object lifecycle and rendering
- Reading input without deadlocking threads
- Console rendering limitations (must use cursor pos and delta-render)

## Why internal access modifier AND internal suffix?

Because the modifier only works on compiled assemblies.
Idk if this project will actually be made portable like that, but it's nice to have the possibility.  
This is also why it breaks convention by using an underscore, it is intentional friction to prevent accidental calls.
