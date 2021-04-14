

Project by Oancea Ionut Eugen & Dinu Marius [3A5]

# Weekly summary

## Week 1
### Oancea Ionut Eugen
| Task| Description | Completition |
| - | - | - |
| Create movement Script | Create a script that would allow the player to move smoothly on the map using keyboard inputs. Ive added animations, sound & particles, interconected. | 80% - Player hits platforms from below |
| Basic rilemap | Create a tilemap, and a default map for the player to play on. I used the sunny valley free assets, along with a script that allows me to automatically generate terrain | 100% |
| 3D model of the cat | Create a 3d model of our hero character in C4D |  50% The model has too many poligons & can't be rigged |

The current game greets you with a fx character, that can jump, run, move, dash & crouch with particle effects & sounds.
The camera shakes on impact & the player jump is influenced by the ammount of time the player keeps the spacebar pressed, by the previous state of the player (for example if the player is crouching, before jumping, it will jump higher )

### Dinu Marius Ciprian

|      ToDo          |Description                         |Progress                          |
|----------------|-------------------------------|-----------------------------|
|Minimal UI |I created 5 scenes: Start,Story,Lvl 1,Replay and End. I have implemented the transition between scenes using SceneManager. Methods are called by buttons such as Start New Game, Skip, Continue, Replay, Exit. Note: The Replay class retains the index of the scene from which it was called.            |80%           |
|Player Class         |In the player class I created the methods for heal and damage received and I added in the Die method (if the player is dead) a transition to the Replay scene.            |70%            |
|Enemy Class          |The first enemy is a frog that jumps continuously (just jumping on the spot with a delay of 4 seconds). It has implemented several triggers for collision with the playing field and the player. In frontal collision with the player will give 10 damage. |50%|
|HealthBar| I have implemented the 2 methods for HealthBar: SetMaxHealth and SetHealth which set the maximum and starting value of the slider and the current value that will change during the game.| 100%|



## Week 2
### Oancea Ionut Eugen

| ToDo | Description | Progress |
|--|--|--|
| Debugging over characters | The frog would not jump |	100% |
| Debugging over characters | Oposum would not die | 100% |
| Debugging over characters | Animation for oposum | 100%	 |
| Debugging over characters | Defining hitboxes | 100%	 |

### Dinu Marius

|      ToDo          |Description                         |Progress                          |
|----------------|-------------------------------|-----------------------------|
|Heal Obj |I created the "Heal" object with all the necessary collisions and its instantiation at the beginning of the game.            |100%           |
|Weapon Obj         |I created the "Sword" object with all the necessary collisions and its instantiation at the beginning of the game. Gives the player the option to damage enemies just by pressing the z key. Failure to press z at the time of the player's collision will result in damage.            |100%            |
|Oposum (Enemy)          | The new enemy is an opossum that has a left, right direction. Collision with the player will cause damage. In a collision with the sword it will only take damage if the player presses the z key. When colliding with other objects, the enemy changes its direction of travel. |80%|
|Tilemap(instantiate enemys)| I have implemented a script that at the beginning of the game will instantiate the enemy.| 70%|


## Week 3
### Oancea Ionut Eugen

| ToDo | Description | Progress |
|--|--|--|
| Map design | Designed a simple map, for teasting and presenting the world to the player |	100% |
| Fix tiles | Tiles would sometimes glitch, i added a padding to them |	100%% |
| Instantiated prefabs on the map | Chosen a position for each prefab on the map | 100% |
| Simplified the spawning script | The enemy spawning script now uses a public vector 3 array when chosing the position of each enemy| 100%|

### Dinu Marius

|      ToDo          |Description                         |Progress                          |
|----------------|-------------------------------|-----------------------------|
|Prefabs |I tried to create Prefab objects to make it easier to create and edit objects. (Heal obj, Player, Oposum, Frog).            |100%           |
|Checkpoint        |I implemented a checkpoint that in collision with the player will send the game to the last scene, the end scene.            |100%            |
|Tilemap(instantiate enemys)          |I reimplemented the instantiation script using Prefab objects. |50%|
|Damage| I refactorized the methods for damage (player to enemy 30 dmg, enemy to player 10 dmg).| 100%|

## Week 4
### Oancea Ionut Eugen

| ToDo | Description | Progress |
|--|--|--|
| Level adjustments | Redefined assets & tested map |	100% |
| Ui tiles | Created and added ui tiles for menu |	100% |

### Dinu Marius

| ToDo | Description | Progress |
|--|--|--|
| Enemy adjustments | Redefined enemy |	100% |
| Checkpoints adjustments| Redefined Checkpoints |	100% |

## Week 5
### Oancea Ionut Eugen

| ToDo | Description | Progress |
|--|--|--|
| Level adjustments | Redefined assets & tested map |	100% |
| Debug on enemies | Debug on the frog, & on the oposum enemies |	100%% |
| Debug for map generating script | Debug the script that updates the surrounding tiles around a certain tile | 100% |

### Dinu Marius

|      ToDo          |Description                         |Progress                          |
|----------------|-------------------------------|-----------------------------|
|New Level |New Level (but without scene transition)- Level 2 (map+spawn positions)           |80%           |
|Oposum Spawn        | Rework           |80%            |
|AutoMap       | Fail |30%|
|Save the game in json | All data related to spawn positions and checkpoint positions are saved in a json using SimpleJSON | 100%|

## Week 6
### Oancea Ionut Eugen

| ToDo | Description | Progress |
|--|--|--|
| Level adjustments | Redefined assets & tested map |	100% |
| Debug on ui tiles | Debug the positioning of the tiles |	100% |
| Debug on dark mode | Debug on the function that generates the shadow in dark places |	100% |

### Dinu Marius

|      ToDo          |Description                         |Progress                          |
|----------------|-------------------------------|-----------------------------|
|Save the game in json & static class | All data related to prefabs positions are saved in a json using SimpleJSON and the miniCheckpoint are saved in static variables           |100%           |
|Prefabs        |CheckPoint,miniCheckPoint           |100%            |
|DarkMode          |I tried to make a shadow mode but the color is too dark. |80%|
|miniCheckpoint| I implemented the miniCheckpoints that spawn you to that position after you die.| 100%|

## Week 7
### Oancea Ionut Eugen

| ToDo | Description | Progress |
|--|--|--|
| Level adjustments | Redefined assets & tested map |	100% |

### Dinu Marius

|      ToDo          |Description                         |Progress                          |
|----------------|-------------------------------|-----------------------------|
|Start Menu | I made the basis of the menu and we will both do the design. We have implemented a script for choosing skins and displaying each menu option. |100%           |
|Prefabs        |Skins for player  |100%            |
|Shop   |Soon |50%|
|FinalMenu|Soon| 100%|

## Week 8
### Oancea Ionut Eugen

| ToDo | Description | Progress |
|--|--|--|
| Level adjustments | Redefined assets & tested map |	100% |
| Level 2 map design| Map rework on lvl 2|	100% |

### Dinu Marius

| ToDo | Description | Progress |
|--|--|--|
| Prefabs adjustments | Redefined prefabs |	100% |
| Instantiate from JSON |  Redefined json |	100% |
| MiniCheckpoint and Checkpoints rework |  Redefined MiniCheckpoint and Checkpoints without bugs |	100% |
| Scene transition rework | New transitions without bugs | 100% |
| Shop | Skins |	100% |

## Week 9
### Oancea Ionut Eugen

| ToDo | Description | Progress |
|--|--|--|
| Base testing for demo | Base testing for game demo & debugging |	100% |
| Game build |* |	100% |

### Dinu Marius

| ToDo | Description | Progress |
|--|--|--|
| Base testing for demo | Base testing for game demo & debugging |	100% |
| Game build |* |	100% |
