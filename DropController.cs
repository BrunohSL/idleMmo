using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DropController {
    public Item.ItemName itemName;
    public float dropChance;

    public bool rollDropChance () {
        if (Random.Range(0f, 1f) <= dropChance / 100) {
            Debug.Log("Dropou o item " + itemName);
            Players.playersList[Players.getSelectedPlayer()].inventory.addItem(Items.getItemByName(itemName));

            return true;
        }

        return false;
    }
}
