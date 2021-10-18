using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int life;
    protected int strength;
    protected int intelligence;
    protected int dexterity;
    protected int xTile;
    protected int zTile;

    public int Life { get => life; set => life = value; }
    public int Strength { get => strength; set => strength = value; }
    public int Intelligence { get => intelligence; set => intelligence = value; }
    public int Dexterity { get => dexterity; set => dexterity = value; }
    public int XTile { get => xTile; set => xTile = value; }
    public int ZTile { get => zTile; set => zTile = value; }

    public Monster(int life, int strength, int intelligence, int dexterity, int xTile, int zTile)
    {
        this.life = life;
        this.strength = strength;
        this.intelligence = intelligence;
        this.dexterity = dexterity;
        this.xTile = xTile;
        this.zTile = zTile;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(XTile * 2, 1, ZTile * 2);
    }
}
