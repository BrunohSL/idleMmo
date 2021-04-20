using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item {
    public ItemName itemName;
    public ItemType itemType;
    public int amount;
    public string sprite;
    public int price = 0;

    public enum ItemType {
        consumable,
        material,
        equipable,
        gacha,
    }

    public enum ItemName {
        jerryHairBall,
        ironOre,
        shovel,
        skull,
        commonFire,
        uncommonFire,
        rareFire,
        epicFire,
        legendaryFire,
    }

    public bool isStackable () {
        switch (itemType) {
            default:
            case ItemType.consumable:
            case ItemType.material:
                return true;
            case ItemType.equipable:
                return false;
        }
    }
}
