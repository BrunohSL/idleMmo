using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShopUiHandler : MonoBehaviour {
    private List<Item> summonItemList;
    public Transform spawnPoint;
    public GameObject shopItemPrefab;
    public StoreController storeController;

    void Awake() {
        this.summonItemList = StoreController.getSummonItemList();

        Debug.Log(this.summonItemList.Count);

        refreshStore();
    }

    public void refreshStore() {
        float x = 50f;
        float y = 0f;
        float itemSlotCellSize = 130f;

        foreach (Item item in this.summonItemList) {
            GameObject shopItemPrefabGameObject = Instantiate(shopItemPrefab, spawnPoint);
            RectTransform shopItemPrefabRectTransform = shopItemPrefabGameObject.GetComponent<RectTransform>();
            shopItemPrefabRectTransform.anchoredPosition = new Vector2(x, y);

            Image image = shopItemPrefabRectTransform.Find("image").GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>(item.sprite);

            shopItemPrefabGameObject.GetComponent<ShopItemPrefab>().setText("PRICE " + item.price.ToString());
            shopItemPrefabGameObject.GetComponent<ShopItemPrefab>().setBuyButton(storeController, item.itemName);
            shopItemPrefabGameObject.GetComponent<ShopItemPrefab>().setButtonText("BUY");

            x += itemSlotCellSize;
        }
    }
}
