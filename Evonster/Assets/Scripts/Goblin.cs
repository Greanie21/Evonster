using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster
{
    public Goblin(int life, int strength, int intelligence, int dexterity, int xTile, int zTile) : base(life, strength, intelligence, dexterity, xTile, zTile)
    {
        this.life = life;
        this.strength = strength;
        this.intelligence = intelligence;
        this.dexterity = dexterity;
        this.xTile = xTile;
        this.zTile = zTile;
    }
}
