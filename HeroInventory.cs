using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class HeroInventory {
    public List<Hero> heroList;

    public HeroInventory() {
        heroList = new List<Hero>();
    }

    public void addHero(Hero hero) {
        heroList.Add(hero);
    }

    public List<Hero> getHeroList() {
        return Players.playersList[Players.getSelectedPlayer()].heroInventory.heroList;
    }
}
