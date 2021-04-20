using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Items : MonoBehaviour {
    public static Item itemClass;

    public static Item getItemByName(Item.ItemName itemName) {
        itemClass = new Item();

        switch (itemName) {
            default: return null;
            case Item.ItemName.shovel:
                itemClass.itemName = Item.ItemName.shovel;
                itemClass.itemType = Item.ItemType.equipable;
                itemClass.amount = 0;
                itemClass.sprite = "shovel";
                itemClass.price = 0;
            return itemClass;

            case Item.ItemName.jerryHairBall:
                itemClass.itemName = Item.ItemName.jerryHairBall;
                itemClass.itemType = Item.ItemType.material;
                itemClass.amount = 0;
                itemClass.sprite = "jerryHairBall";
                itemClass.price = 0;
            return itemClass;

            case Item.ItemName.ironOre:
                itemClass.itemName = Item.ItemName.ironOre;
                itemClass.itemType = Item.ItemType.material;
                itemClass.amount = 0;
                itemClass.sprite = "ironOre";
                itemClass.price = 0;
            return itemClass;

            case Item.ItemName.skull:
                itemClass.itemName = Item.ItemName.skull;
                itemClass.itemType = Item.ItemType.material;
                itemClass.amount = 0;
                itemClass.sprite = "skull";
                itemClass.price = 0;
            return itemClass;

            case Item.ItemName.commonFire:
                itemClass.itemName = Item.ItemName.commonFire;
                itemClass.itemType = Item.ItemType.gacha;
                itemClass.amount = 0;
                itemClass.sprite = "commonFire";
                itemClass.price = 10;
            return itemClass;

            case Item.ItemName.uncommonFire:
                itemClass.itemName = Item.ItemName.uncommonFire;
                itemClass.itemType = Item.ItemType.gacha;
                itemClass.amount = 0;
                itemClass.sprite = "uncommonFire";
                itemClass.price = 25;
            return itemClass;

            case Item.ItemName.rareFire:
                itemClass.itemName = Item.ItemName.rareFire;
                itemClass.itemType = Item.ItemType.gacha;
                itemClass.amount = 0;
                itemClass.sprite = "rareFire";
                itemClass.price = 100;
            return itemClass;

            case Item.ItemName.epicFire:
                itemClass.itemName = Item.ItemName.epicFire;
                itemClass.itemType = Item.ItemType.gacha;
                itemClass.amount = 0;
                itemClass.sprite = "epicFire";
                itemClass.price = 500;
            return itemClass;

            case Item.ItemName.legendaryFire:
                itemClass.itemName = Item.ItemName.legendaryFire;
                itemClass.itemType = Item.ItemType.gacha;
                itemClass.amount = 0;
                itemClass.sprite = "legendaryFire";
                itemClass.price = 1000;
            return itemClass;
        }
    }
}
