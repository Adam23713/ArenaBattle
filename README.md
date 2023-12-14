# Hero Battle Arena

In the arena, N heroes are battling, who can be archers, knights, and swordsmen. Each hero has an identifier and health, and they can attack and defend according to the rules below.

- **Archer attacks:**
  
  ![archman300](https://github.com/Adam23713/ArenaBattle/assets/12465316/a4efb20f-c160-4de7-abc4-79ea0c6df338)
  - Knight: 40% chance the knight dies, 60% chance it is avoided
  - Swordsman: the swordsman dies
  - Archer: defending archer dies


- **Swordsman attacks:**
 
 ![swordsman_300](https://github.com/Adam23713/ArenaBattle/assets/12465316/576c2cc3-91a7-43b8-8d63-f1e306612d25)
  - Knight: nothing happens
  - Swordsman: defending swordsman dies
  - Archer: archer dies


- **Knight attacks:**
  
 ![knight_300](https://github.com/Adam23713/ArenaBattle/assets/12465316/b5825460-d136-44e6-b4e0-697b1bb0afec)
  - Knight: defending knight dies
  - Swordsman: knight dies
  - Archer: archer dies

The battle is divided into rounds, and in each round, an attacker and a defender are randomly selected. The skipped heroes rest, and their health increases by 10, but it cannot exceed the maximum.

The health of the participating heroes is halved, and if it is less than a quarter of the initial health, they die. Initial health values are archer: 100, knight: 150, swordsman: 120.

Before starting the battle, N random heroes must be generated, which will be received as a parameter. The battle continues until only one hero remains alive.

At the end of each round, it is necessary to log who attacked whom and how their health changed.
