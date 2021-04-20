using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Players : MonoBehaviour {
    public static List<Player> playersList = new List<Player>();
    public static Player playerClass = new Player();
    public static int selectedPlayer;

    public static void setSelectedPlayer(int selectedPlayer) {
        Players.selectedPlayer = selectedPlayer;
    }

    public static int getSelectedPlayer() {
        return Players.selectedPlayer;
    }

    public static void newPlayer(Player player) {
        playerClass.id = player.id;
        playerClass.characterName = player.characterName;
        playerClass.level = player.level;
        playerClass.attack = player.attack;
        playerClass.defense = player.defense;
        playerClass.maxHp = player.maxHp;
        playerClass.currentHp = player.currentHp;
        playerClass.sprite = player.sprite;
        playerClass.maxXp = player.maxXp;
        playerClass.currentXp = player.currentXp;
        playerClass.strength = player.strength;
        playerClass.agility = player.agility;
        playerClass.intelligence = player.intelligence;
        playerClass.vitality = player.vitality;
        playerClass.inventory = new Inventory();
        playerClass.heroInventory = new HeroInventory();
        Players.playersList.Add(playerClass);
        playerClass = new Player();
    }

    public static void addPlayer(Player player) {
        playerClass.id = player.id;
        playerClass.characterName = player.characterName;
        playerClass.level = player.level;
        playerClass.attack = player.attack;
        playerClass.defense = player.defense;
        playerClass.maxHp = player.maxHp;
        playerClass.currentHp = player.currentHp;
        playerClass.sprite = player.sprite;
        playerClass.maxXp = player.maxXp;
        playerClass.currentXp = player.currentXp;
        playerClass.strength = player.strength;
        playerClass.agility = player.agility;
        playerClass.intelligence = player.intelligence;
        playerClass.vitality = player.vitality;
        playerClass.inventory = player.inventory;
        playerClass.heroInventory = player.heroInventory;
        Players.playersList.Add(playerClass);
        playerClass = new Player();
    }

    static public void printPlayer(Player player) {
        Debug.Log(
            "characterName: " + player.characterName +
            "\nlevel: " + player.level +
            "\nattack: " + player.attack +
            "\ndefense: " + player.defense +
            "\nmaxHp: " + player.maxHp +
            "\ncurrentHp: " + player.currentHp +
            "\nsprite: " + player.sprite +
            "\nmaxXp: " + player.maxXp +
            "\ncurrentXp: " + player.currentXp +
            "\nstrength: " + player.strength +
            "\nintelligence: " + player.intelligence +
            "\nagility: " + player.agility +
            "\nvitality: " + player.vitality +
            "\npointsLeft: " + player.pointsLeft
        );
    }
}
