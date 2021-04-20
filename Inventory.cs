using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Inventory {
    public List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();
    }

    public void addItem(Item item) {
        if (item.isStackable()) {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemName == item.itemName) {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }

            if (!itemAlreadyInInventory) {
                itemList.Add(item);
            }
        } else {
            item.amount = 0;
            itemList.Add(item);
        }
    }

    public List<Item> getItemList() {
        return Players.playersList[Players.getSelectedPlayer()].inventory.itemList;
    }

    public List<Item> getItemByType(Item.ItemType itemType) {
        List<Item> items = this.getItemList();
        List<Item> itemByType = new List<Item>();

        foreach (Item item in items) {
            if (item.itemType == itemType) {
                itemByType.Add(item);
            }
        }

        return itemByType;
    }

    public Item getItemByName(Item.ItemName itemName) {
        List<Item> items = this.getItemList();

        foreach (Item item in items) {
            if (item.itemName == itemName) {
                return item;
            }
        }

        return null;
    }

    // currency
    // lista de heroes
}
