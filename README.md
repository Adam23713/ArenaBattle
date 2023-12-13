# ArenaBattle

In the arena, N heroes are battling, who can be archers, knights, and swordsmen. Each hero has an identifier and health, and they can attack and defend according to the rules below.
Archer attacks 
•	Knight: 40% chance the knight dies, 60% chance it is avoided 
•	Swordsman: the swordsman dies  
•	Archer: defending archer dies
Swordsman attacks
•	Knight: nothing happens 
•	Swordsman: defending swordsman dies
•	 Archer: archer dies

Knight attacks   
•	Knight: defending knight dies 
•	Swordsman: knight dies 
•	Archer: archer dies

The battle is divided into rounds, and in each round, an attacker and a defender are randomly selected.
The skipped heroes rest, and their health increases by 10, but it cannot exceed the maximum. The health of the participating heroes is halved, and if it is less than a quarter of the initial health, they die.

Initial health values are:
•	archer:  100
•	knight: 150
•	swordsman: 120.

Before starting the battle, N random heroes must be generated, which will be received as a parameter. The battle continues until only one hero remains alive. At the end of each round, it is necessary to log who attacked whom and how their health changed.
