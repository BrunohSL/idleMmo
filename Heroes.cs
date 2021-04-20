using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class keeps all heroes information and make some "SELECTS" on the heroes list
/// </summary>
public class Heroes : MonoBehaviour {
    public static List<Hero> heroesList = new List<Hero>();
    public static Hero heroClass = new Hero();

    /// <summary>
    /// Search for all the heroes with specific rank on the static list Heroes.heroesList
    /// </summary>
    /// <returns>
    /// A list of Hero class
    /// </returns>
    public static List<Hero> getHeroByRank(Hero.HeroRank heroRank) {
        List<Hero> heroList = new List<Hero>();

        foreach (Hero hero in Heroes.heroesList) {
            if (hero.heroRank == heroRank) {
                heroList.Add(hero);
            }
        }

        return heroList;
    }

    /// <summary>
    /// Search a hero on the static list Heroes.heroesList
    /// </summary>
    /// <remarks>
    /// Search for one hero by its name
    /// </remarks>
    /// <returns>
    /// One instance of Hero class
    /// </returns>
    public static Hero getHeroByName(Hero.HeroName heroName) {
        heroClass = new Hero();

        foreach (Hero hero in Heroes.heroesList) {
            if (hero.heroName == heroName) {
                heroClass = hero;
            }
        }

        return heroClass;
    }

    /// <summary>
    /// Save all heroes into the static variable Heroes.heroesList.
    /// </summary>
    /// <remarks>
    /// This is the heroes sumary. Check README for more info
    /// </remarks>
    public static void setHeroesList() {
        // Ghost
        heroClass.id = 1;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.ghost;
        heroClass.heroRank = Hero.HeroRank.nat5;
        heroClass.heroType = Hero.HeroType.support;
        heroClass.sprite = "ghost";
        heroClass.attack = 6;
        heroClass.defense = 5;
        heroClass.maxHp = 30;
        heroClass.currentHp = 30;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Golem
        heroClass.id = 2;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.golem;
        heroClass.heroRank = Hero.HeroRank.nat3;
        heroClass.heroType = Hero.HeroType.tank;
        heroClass.sprite = "golem";
        heroClass.attack = 4;
        heroClass.defense = 20;
        heroClass.maxHp = 50;
        heroClass.currentHp = 50;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Spider
        heroClass.id = 3;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.spider;
        heroClass.heroRank = Hero.HeroRank.nat2;
        heroClass.heroType = Hero.HeroType.damage;
        heroClass.sprite = "spider";
        heroClass.attack = 20;
        heroClass.defense = 5;
        heroClass.maxHp = 15;
        heroClass.currentHp = 15;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Water Elemental
        heroClass.id = 4;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.waterElemental;
        heroClass.heroRank = Hero.HeroRank.nat4;
        heroClass.heroType = Hero.HeroType.support;
        heroClass.sprite = "waterElemental";
        heroClass.attack = 8;
        heroClass.defense = 7;
        heroClass.maxHp = 40;
        heroClass.currentHp = 40;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Wind Elemental
        heroClass.id = 5;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.windElemental;
        heroClass.heroRank = Hero.HeroRank.nat4;
        heroClass.heroType = Hero.HeroType.support;
        heroClass.sprite = "windElemental";
        heroClass.attack = 8;
        heroClass.defense = 7;
        heroClass.maxHp = 40;
        heroClass.currentHp = 40;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Fire Elemental
        heroClass.id = 6;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.fireElemental;
        heroClass.heroRank = Hero.HeroRank.nat4;
        heroClass.heroType = Hero.HeroType.damage;
        heroClass.sprite = "fireElemental";
        heroClass.attack = 14;
        heroClass.defense = 8;
        heroClass.maxHp = 20;
        heroClass.currentHp = 20;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Bat
        heroClass.id = 7;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.bat;
        heroClass.heroRank = Hero.HeroRank.nat1;
        heroClass.heroType = Hero.HeroType.damage;
        heroClass.sprite = "bat";
        heroClass.attack = 5;
        heroClass.defense = 4;
        heroClass.maxHp = 10;
        heroClass.currentHp = 10;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Dragon
        heroClass.id = 8;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.dragon;
        heroClass.heroRank = Hero.HeroRank.nat5;
        heroClass.heroType = Hero.HeroType.tank;
        heroClass.sprite = "dragon";
        heroClass.attack = 5;
        heroClass.defense = 4;
        heroClass.maxHp = 10;
        heroClass.currentHp = 10;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Goblin
        heroClass.id = 9;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.goblin;
        heroClass.heroRank = Hero.HeroRank.nat2;
        heroClass.heroType = Hero.HeroType.damage;
        heroClass.sprite = "goblin";
        heroClass.attack = 5;
        heroClass.defense = 4;
        heroClass.maxHp = 10;
        heroClass.currentHp = 10;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Husky
        heroClass.id = 9;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.husky;
        heroClass.heroRank = Hero.HeroRank.nat3;
        heroClass.heroType = Hero.HeroType.support;
        heroClass.sprite = "husky";
        heroClass.attack = 5;
        heroClass.defense = 4;
        heroClass.maxHp = 10;
        heroClass.currentHp = 10;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Skeleton
        heroClass.id = 10;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.skeleton;
        heroClass.heroRank = Hero.HeroRank.nat1;
        heroClass.heroType = Hero.HeroType.damage;
        heroClass.sprite = "skeleton";
        heroClass.attack = 5;
        heroClass.defense = 4;
        heroClass.maxHp = 10;
        heroClass.currentHp = 10;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Zombie
        heroClass.id = 11;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.zombie;
        heroClass.heroRank = Hero.HeroRank.nat2;
        heroClass.heroType = Hero.HeroType.tank;
        heroClass.sprite = "zombie";
        heroClass.attack = 5;
        heroClass.defense = 4;
        heroClass.maxHp = 10;
        heroClass.currentHp = 10;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();

        // Zombie Cat
        heroClass.id = 12;
        heroClass.level = 1;
        heroClass.heroName = Hero.HeroName.zombieCat;
        heroClass.heroRank = Hero.HeroRank.nat3;
        heroClass.heroType = Hero.HeroType.damage;
        heroClass.sprite = "zombieCat";
        heroClass.attack = 5;
        heroClass.defense = 4;
        heroClass.maxHp = 10;
        heroClass.currentHp = 10;
        heroClass.maxXp = ExperienceController.expArray[heroClass.level - 1];
        heroClass.currentXp = 0;
        Heroes.heroesList.Add(heroClass);
        heroClass = new Hero();
    }
}
