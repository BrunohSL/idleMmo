using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Player : Character {
    public int maxXp = 0;
    public int currentXp = 0;
    public int strength = 0;
    public int intelligence = 0;
    public int agility = 0;
    public int vitality = 0;
    public int pointsLeft = 0;

    public Inventory inventory;
    public HeroInventory heroInventory;

    void Start() {
        Debug.Log("Player start");
    }

    public void updatePlayerAttributes() {
        this.maxHp = getMaxHp();
        this.attack = getAttack();
        this.defense = getDefense();
    }

    public int getMaxHp() {
        var baseHp = 20 + this.level * 5;
        var bonusHp = 5 * this.vitality;
        var maxHp = baseHp + bonusHp;

        return maxHp;
    }

    public int getAttack() {
        var baseAtk = 5 + this.level * 2;
        var bonusAtk = 2 * this.strength;
        var totalAtk = baseAtk + bonusAtk;

        return totalAtk;
    }

    public int getDefense() {
        var baseDef = 5 + this.level * 2;
        var bonusDef = 2 * this.vitality;
        var totalDef = baseDef + bonusDef;

        return totalDef;
    }

    public void gainExp(int exp) {
        this.currentXp += exp;

        if (this.currentXp >= this.maxXp) {
            Debug.Log("Level up");
            int expDifference = this.currentXp - this.maxXp;
            this.level++;
            this.currentXp = 0;
            this.maxXp = ExperienceController.expArray[this.level - 1];
            this.currentXp += expDifference;

            this.maxHp = this.getMaxHp();
            this.attack = this.getAttack();
            this.defense = this.getDefense();

            this.currentHp = this.maxHp;

            this.pointsLeft += 4;
        }
    }
}
