using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemies : MonoBehaviour {
    public static List<Enemy> enemiesList = new List<Enemy>();
    public static Enemy enemyClass = new Enemy();
    public static int selectedEnemy;

    public static void setSelectedEnemy(int selectedEnemy) {
        Enemies.selectedEnemy = selectedEnemy;
    }

    public static int getSelectedEnemy() {
        return Enemies.selectedEnemy - 1;
    }

    public static void setEnemyList() {
        enemyClass.id = 1;
        enemyClass.characterName = "Cat";
        enemyClass.level = 1;
        enemyClass.attack = 4;
        enemyClass.defense = 2;
        enemyClass.maxHp = 20;
        enemyClass.currentHp = 20;
        enemyClass.sprite = "cat1";
        enemyClass.baseXpYield = 5;
        enemyClass.addDropItem(new DropController {itemName = Item.ItemName.jerryHairBall, dropChance = 70f});
        Enemies.enemiesList.Add(enemyClass);
        enemyClass = new Enemy();

        enemyClass.id = 2;
        enemyClass.characterName = "Gravekeeper";
        enemyClass.level = 3;
        enemyClass.attack = 8;
        enemyClass.defense = 5;
        enemyClass.maxHp = 50;
        enemyClass.currentHp = 50;
        enemyClass.sprite = "gravekeeper1";
        enemyClass.baseXpYield = 10;
        enemyClass.addDropItem(new DropController {itemName = Item.ItemName.ironOre, dropChance = 50f});
        enemyClass.addDropItem(new DropController {itemName = Item.ItemName.shovel, dropChance = 10f});
        Enemies.enemiesList.Add(enemyClass);
        enemyClass = new Enemy();

        enemyClass.id = 3;
        enemyClass.characterName = "General";
        enemyClass.level = 5;
        enemyClass.attack = 16;
        enemyClass.defense = 12;
        enemyClass.maxHp = 100;
        enemyClass.currentHp = 100;
        enemyClass.sprite = "governor";
        enemyClass.baseXpYield = 20;
        enemyClass.addDropItem(new DropController {itemName = Item.ItemName.skull, dropChance = 20f});
        Enemies.enemiesList.Add(enemyClass);
        enemyClass = new Enemy();
    }
}
