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

__Should be able to create:__  
- Flappy bird
- Space invaders
- Pong
- Rogue

Without major hurdles.  

__Stretch goals:__  
- Integrated UI component system.
- Scenes

## Hurdles (Notes to self)

- Viewport rendering for rogue-like games
- Object lifecycle and rendering
- Reading input without deadlocking threads
- Console rendering limitations (must use cursor pos and delta-render)
