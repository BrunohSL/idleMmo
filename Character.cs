using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class keeps all the basic attributes for a character
/// </summary>
/// <remarks>
/// A character can be the player, a heroe or an enemy
/// </remarks>
[System.Serializable]
public class Character {
    public int id;
    public string characterName = "";
    public int level = 1;
    public int attack = 0;
    // public int magicAttack = 0;
    public int defense = 0;
    // public int magicDefense = 0;
    public int maxHp = 0;
    public int currentHp = 0;
    public string sprite = "";

    /// <summary>
    /// This function deal damage to a character
    /// </summary>
    /// <remarks>
    /// A character can be the player, a heroe or an enemy
    /// </remarks>
    /// <returns>
    /// true if the character died or false if its alive
    /// </returns>
    public bool takeDmg(int dmg) {
        currentHp -= dmg;

        if (currentHp <= 0) {
            return true;
        }

        return false;
    }
}
