using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GachaUiHandler : MonoBehaviour {
    private List<Item> summonItemList;
    private List<Item> summonItemListFromInventory;
    public Transform spawnPoint;
    public GameObject shopItemPrefab;
    public StoreController storeController;
    public GachaController gachaController;

    public void refreshGacha() {
        float y = 0f;
        float x = 50f;
        float itemSlotCellSize = 130f;
        this.summonItemList = StoreController.getSummonItemList();
        this.summonItemListFromInventory = Players.playersList[Players.getSelectedPlayer()].inventory.getItemByType(Item.ItemType.gacha);

        foreach (Item item in this.summonItemList) {
            GameObject shopItemPrefabGameObject = Instantiate(shopItemPrefab, spawnPoint);
            RectTransform shopItemPrefabRectTransform = shopItemPrefabGameObject.GetComponent<RectTransform>();
            shopItemPrefabRectTransform.anchoredPosition = new Vector2(x, y);

            Image image = shopItemPrefabRectTransform.Find("image").GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>(item.sprite);

            shopItemPrefabGameObject.GetComponent<ShopItemPrefab>().setButtonText("USE");

            Item inventoryItem = Players.playersList[Players.getSelectedPlayer()].inventory.getItemByName(item.itemName);

            if (inventoryItem != null) {
                shopItemPrefabGameObject.GetComponent<ShopItemPrefab>().setText("IN BAG " + inventoryItem.amount.ToString());
                shopItemPrefabGameObject.GetComponent<ShopItemPrefab>().setGachaSummonButton(gachaController, inventoryItem);
            } else {
                shopItemPrefabGameObject.GetComponent<ShopItemPrefab>().setText("IN BAG " + item.amount.ToString());
                shopItemPrefabGameObject.GetComponent<ShopItemPrefab>().setGachaSummonButton(gachaController, item);
                Debug.Log("No item found in bag! Item name: " + item.itemName);
            }

            x += itemSlotCellSize;
        }
    }
}
