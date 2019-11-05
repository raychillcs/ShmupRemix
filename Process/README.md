# Shmup Remix Process

## 09.30.19: Brainstorming and Final Idea
To brainstorm different directions that my shmup could go, I listed off the primary characteristics of typical shoot-em-ups and Fullerton’s Formal Elements to see what I could change mechanically and thematically about them. My favorite shmup idea was a combination of a few from the top five that I brainstormed during my ideation journal.

**Shmup Idea:** A cooperative shoot-em-up where multiple players aim to heal a large ally together to keep it alive against enemy fire and obstacles

**Basic Rules:**
Players must work together and aim to shoot healing projectiles at a large robot ally to keep it alive as it endures enemy fire and other obstacles. The player’s role and projectile must match the area they are healing, or it will not repair the ally. If the ally runs out of health and dies, the game is over.

**Formal Elements:**
* Players: cooperative (multiple players work together with different roles)
* Objective: defend/heal (repairing and protecting an ally)
* Rules: hit box size (made smaller to put focus on precision)
* Conflict: opponents (different healing types, different enemy types; must shoot correct projectile at matching area/enemy)

**Puzzles/Challenges:**
* Each player has a different role or projectile that corresponds to specific area(s) and is only able to heal/repair those areas or damage certain enemies (color matching)
* Hit box sizes on large ally are relatively small, like doing surgery (precision)

## 10.21.19: Iteration 1 and Playtesting
These are the features that I got done for my first iteration of my shmup:
* Created second hero
* Created second type of projectile: healing
* New locations for hero controls (to accommodate second set of movement controls, healing vs. damage controls)
* Hero 1: Movement is AWSD, damage is left command, healing is left alt
* Hero 2: Movement is JIKL, damage is right command, healing is right alt
* Decided both players should play both roles (damage and healer)
* Created ally
* Ally loses health from enemies
* Decided damage projectiles should also hurt ally (to encourage player to focus on aim)
* Ally gains health from healing projectiles
* Higher spawn rate of enemies
* Game over happens when either of heroes dies, or if ally runs out of health

During my playtesting, I took note that I should:
* Have a scrolling background to show movement
* Make a different (larger) model for the ally for visual difference
* Make a visual to represent the ally's health (health bar, etc.)
* Make the ally move
* Have the heroes be different colors/shapes
* Make the enemies have different movement and models
* Add sound to shooting/death
* Add start screen or game over screen
* Maybe only have the game end when both heroes die or ally dies
* Balance health/damage more

## 10.28.19: Final iteration
Here are the features I finished for the final iteration of my shmup:
* Scrolling background
* Created new ally model and size
* Added movement to ally (in the form of a sin wave)
* Made the heroes (players) different colors (blue for first/left player, red for second/right player)
* Made the enemies a new color (darker, visual difference from ally)

In the future, these are the features I would still like to implement:
* Adding a start screen and game over screen
