# Apocclipse

A fast-paced post-apocalyptic 2D side-scrolling runner game. Players take on the role of Brontë, an experienced adventurer who has arrived on a war-torn planet to save it from destruction. We designed this game as a prototype for an in-coming game we are developing to test out some of the game assets and skeleton character animation.

---

![Game Preview](https://github.com/GelzoneXUnsas/Apocclipse/blob/main/Assets/Sprites/Apocclipse_2.png)

* [Play Online](https://gelzonexunsas.itch.io/apocclipse)

---
### Gameplay
To collect items and gain points, Brontë must navigate through dangerous terrain and avoid a variety of obstacles as she progresses through the game. The game's core mechanic revolves around collecting items, while also avoid hazards.

### Game Design
#### Background
The game takes place in a distant galaxy, where a group of vigilantes is on a mission to save their dying home planet. They come across the war-torn planet that Brontë now finds herself on along the way. The plot of the game revolves around the group's efforts to save the planet from destruction, as well as Brontë’s role as their leader and savior.

#### Character
The character of Brontë is one of the distinguishing features. Brontë is a girl who was born deaf and uses a hearing aid to interact with the world around her. She, on the other hand, frequently pretends not to hear people and instead focuses on her love of drums.


### Technical Details
#### Character Movement
Brontë's actions involve animation, which are controlled by **animation states**.

#### Dialogue System
One other feature about the game is the dialogue system. I implemented this feature not only to support character development, but also for future game testing purposes. The dialogue is triggered in the beginning of the game, and also when the player hits the 1 minute playtime mark. 

To polish the design, I added auto-type lines and voice overlay to the system.

#### Sound
Sound is implemented both in terms of background music and SFXs.

- BGM: The in game background music is my [guitar arrangement](https://gelzonexunsas.github.io/posts/weight-of-the-world/) from the Nier’s OST.
- SFX: The SFXs are being activated when the character collides with coins and obstacles. The sound effects are not copyrighted.
