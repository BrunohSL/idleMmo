using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryUiHandler : MonoBehaviour {
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    void Awake() {
        this.inventory = Players.playersList[Players.selectedPlayer].inventory;

        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");

        refreshInventoryItems();
    }

    public void refreshInventoryItems() {
        foreach (Transform child in itemSlotContainer) {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        float x = -280f;
        float y = 190f;
        float itemSlotCellSize = 140f;

        foreach (Item item in inventory.getItemList()) {
            if (y < -230f) {
                Debug.Log("Limite do inventário atingido");
                return;
            }

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x, y);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>(item.sprite);
            Text amountText = itemSlotRectTransform.Find("amountText").GetComponent<Text>();

            if (item.amount == 0) {
                amountText.text = "";
            } else {
                amountText.text = item.amount.ToString();
            }

            x += itemSlotCellSize;

            if (x > 280) {
                x = -280;
                y -= itemSlotCellSize;
            }
        }
    }
}
