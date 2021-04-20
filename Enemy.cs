using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Enemy : Character {
    public int baseXpYield = 0;

    public List<DropController> drops = new List<DropController>();

    public int giveXp(int level) {
        int xp = this.baseXpYield * level;

        return xp;
    }

    public void addDropItem(DropController dropItem) {
        drops.Add(dropItem);
    }
}
