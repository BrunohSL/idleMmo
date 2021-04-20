using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HeroInventoryUiHandler : MonoBehaviour {
    private HeroInventory heroInventory;
    private Transform heroSlotContainer;
    private Transform heroSlotTemplate;

    void Awake() {
        this.heroInventory = Players.playersList[Players.selectedPlayer].heroInventory;

        heroSlotContainer = transform.Find("heroSlotContainer");
        heroSlotTemplate = heroSlotContainer.Find("heroSlotTemplate");

        refreshHeroInventory();
    }

    public void refreshHeroInventory() {
        foreach (Transform child in heroSlotContainer) {
            if (child == heroSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        float x = -280f;
        float y = 190f;
        float itemSlotCellSize = 140f;

        foreach (Hero hero in heroInventory.getHeroList()) {
            if (y < -230f) {
                Debug.Log("Limite do inventário atingido");
                return;
            }

            RectTransform heroSlotRectTransform = Instantiate(heroSlotTemplate, heroSlotContainer).GetComponent<RectTransform>();
            heroSlotRectTransform.gameObject.SetActive(true);

            heroSlotRectTransform.anchoredPosition = new Vector2(x, y);
            Image image = heroSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>(hero.sprite);
            Text nameText = heroSlotRectTransform.Find("nameText").GetComponent<Text>();
            nameText.text = hero.heroName.ToString();

            x += itemSlotCellSize;

            if (x > 280) {
                x = -280;
                y -= itemSlotCellSize;
            }
        }
    }
}
