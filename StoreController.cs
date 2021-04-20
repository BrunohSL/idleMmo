using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StoreController : MonoBehaviour {
    public static int commonFireCost = 10;

    public void buyFireSummonButton(Item.ItemName itemName) {
        if (Currency.gold > commonFireCost) {
            Currency.gold -= commonFireCost;
            Debug.Log("Item name on battleSystem " + itemName);
            Item item = Items.getItemByName(itemName);
            item.amount = 1;
            Players.playersList[Players.getSelectedPlayer()].inventory.addItem(item);
        } else {
            Debug.Log("Não tem gold para comprar");
        }
    }

    public static List<Item> getSummonItemList() {
        List<Item> itemList = new List<Item>();

        itemList.Add(Items.getItemByName(Item.ItemName.commonFire));
        itemList.Add(Items.getItemByName(Item.ItemName.uncommonFire));
        itemList.Add(Items.getItemByName(Item.ItemName.rareFire));
        itemList.Add(Items.getItemByName(Item.ItemName.epicFire));
        itemList.Add(Items.getItemByName(Item.ItemName.legendaryFire));

        return itemList;
    }

    public static List<Item> getSummonItemListFromInventory() {
        List<Item> itemList = new List<Item>();

        foreach (Item item in Players.playersList[Players.getSelectedPlayer()].inventory.itemList) {
            if (item.itemType == Item.ItemType.gacha) {
                itemList.Add(item);
            }
        }

        return itemList;
    }
}
