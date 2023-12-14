# Hero Battle Arena

In the arena, N heroes are battling, who can be archers, knights, and swordsmen. Each hero has an identifier and health, and they can attack and defend according to the rules below.

- **Archer attacks:**
  ![archman](https://github.com/Adam23713/ArenaBattle/assets/12465316/1fdcbb4f-1886-4aab-84f1-8b8ac0d0e2c1)
  - Knight: 40% chance the knight dies, 60% chance it is avoided
  - Swordsman: the swordsman dies
  - Archer: defending archer dies

- **Swordsman attacks:**
 ![hourseman](https://github.com/Adam23713/ArenaBattle/assets/12465316/28ed8e7c-ef18-428b-ad7a-ed63d07869b2)
  - Knight: nothing happens
  - Swordsman: defending swordsman dies
  - Archer: archer dies

- **Knight attacks:**
 ![knight](https://github.com/Adam23713/ArenaBattle/assets/12465316/2e2d1f9d-5034-4677-b46c-a6767eef94ad)
  - Knight: defending knight dies
  - Swordsman: knight dies
  - Archer: archer dies

The battle is divided into rounds, and in each round, an attacker and a defender are randomly selected. The skipped heroes rest, and their health increases by 10, but it cannot exceed the maximum.

The health of the participating heroes is halved, and if it is less than a quarter of the initial health, they die. Initial health values are archer: 100, knight: 150, swordsman: 120.

Before starting the battle, N random heroes must be generated, which will be received as a parameter. The battle continues until only one hero remains alive.

At the end of each round, it is necessary to log who attacked whom and how their health changed.
