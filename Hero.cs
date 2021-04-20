using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Hero : Character {
    public enum HeroType {
        tank,
        support,
        damage,
        food,
    }

    public enum HeroRank {
        nat1,
        nat2,
        nat3,
        nat4,
        nat5,
        food,
    }

    public enum HeroName {
        ghost,
        golem,
        spider,
        waterElemental,
        windElemental,
        fireElemental,
        bat,
        dragon,
        goblin,
        husky,
        skeleton,
        zombie,
        zombieCat,
    }

    public int maxXp = 0;
    public int currentXp = 0;
    public HeroType heroType;
    public HeroRank heroRank;
    public HeroName heroName;

    public string getHeroIconType () {
        switch (heroType) {
            default:
                return "";
            case HeroType.tank:
                return "tankIcon";
            case HeroType.support:
                return "healerIcon";
            case HeroType.damage:
                return "damageIcon";
        }
    }
}
