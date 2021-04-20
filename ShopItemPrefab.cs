using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShopItemPrefab : MonoBehaviour {
    public Image itemSprite;
    public Text itemText;
    public Button button;
    public Text buttonText;

    public void setText(string text) {
        // Debug.Log("Passou aqui: " + price.ToString());
        this.itemText.text = text;
    }

    public void setBuyButton(StoreController storeController, Item.ItemName itemName) {
        button.onClick.AddListener(delegate {
            storeController.buyFireSummonButton(itemName);
        });
    }

    public void setGachaSummonButton(GachaController gachaController, Item item) {
        button.onClick.AddListener(delegate {
            gachaController.selectSummonItem(item);
        });
    }

    public void setUseButton(StoreController storeController, Item.ItemName itemName) {
        button.onClick.AddListener(delegate {
            storeController.buyFireSummonButton(itemName);
        });
    }

    public void setButtonText(string text) {
        buttonText.text = text;
    }
}
