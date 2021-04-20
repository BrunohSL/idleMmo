using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GachaController : MonoBehaviour {
    public Transform fireLocation;
    public GameObject fireInUsePrefab;
    public Button summonButton;
    public GachaUiHandler gachaUiHandler;

    private Item.ItemName lastItemSelected;
    private bool flag_lastItemSelected = false;

    public void selectSummonItem(Item item) {
        if (item.amount > 0) {
            foreach (Transform child in fireLocation) {
                Item selectedItem = Players.playersList[Players.getSelectedPlayer()].inventory.getItemByName(lastItemSelected);
                selectedItem.amount++;
                Destroy(child.gameObject);
            }

            GameObject fireInUsePrefabObj = Instantiate(fireInUsePrefab, fireLocation);
            fireInUsePrefabObj.GetComponent<FireInUsePrefabUi>().setSprite(item.sprite);
            lastItemSelected = item.itemName;
            flag_lastItemSelected = true;

            item.amount--;
            gachaUiHandler.refreshGacha();
            Debug.Log("Pode inserir a chama");
        } else {
            Debug.Log("Chama insuficiente");
        }
    }

    public void summonHeroButton() {
        if (flag_lastItemSelected) {
            Hero gachaHero = new Hero();
            int randomNumber = Random.Range(0, 1001);

            gachaHero = summonHero(lastItemSelected, randomNumber);

            // Mostrar na tela o heroi que foi gerado (Com botão de OK para fechar pop ou)

            Debug.Log(gachaHero.heroName);
            Players.playersList[Players.getSelectedPlayer()].heroInventory.addHero(gachaHero);

            consumeSummonFire();
            // Consumir a chama

        }
    }

    public void consumeSummonFire() {
        Item selectedItem = Players.playersList[Players.getSelectedPlayer()].inventory.getItemByName(lastItemSelected);
        // selectedItem.amount--;

        foreach (Transform child in fireLocation) {
            Destroy(child.gameObject);
        }

        // lastItemSelected = null;
        gachaUiHandler.refreshGacha();
        flag_lastItemSelected = false;

        // if (selectedItem.amount == 0) {
        //     foreach (Transform child in fireLocation) {
        //         Destroy(child.gameObject);
        //     }
        // }
    }

    public void closeGachaButton() {
        if (flag_lastItemSelected) {
            Item selectedItem = Players.playersList[Players.getSelectedPlayer()].inventory.getItemByName(lastItemSelected);
            selectedItem.amount++;
        }

        gachaUiHandler.refreshGacha();

        foreach (Transform child in fireLocation) {
            Destroy(child.gameObject);
        }
    }

    public Hero summonHero(Item.ItemName summonItem, int randomNumber) {
        Hero gachaHero = new Hero();

        if (randomNumber >= 0 && randomNumber <= 10) {
            List<Hero> heroList = Heroes.getHeroByRank(Hero.HeroRank.nat5);
            Debug.Log("Legendary");

            gachaHero = rollHero(heroList);
        }

        if (randomNumber >= 11 && randomNumber <= 60) {
            List<Hero> heroList = Heroes.getHeroByRank(Hero.HeroRank.nat4);
            Debug.Log("Epic");

            gachaHero = rollHero(heroList);
        }

        if (randomNumber >= 61 && randomNumber <= 200) {
            List<Hero> heroList = Heroes.getHeroByRank(Hero.HeroRank.nat3);
            Debug.Log("Rare");

            gachaHero = rollHero(heroList);
        }

        if (randomNumber >= 201 && randomNumber <= 500) {
            List<Hero> heroList = Heroes.getHeroByRank(Hero.HeroRank.nat2);
            Debug.Log("Uncommon");

            gachaHero = rollHero(heroList);
        }

        if (randomNumber >= 501 && randomNumber <= 1000) {
            List<Hero> heroList = Heroes.getHeroByRank(Hero.HeroRank.nat1);
            Debug.Log("Common");

            gachaHero = rollHero(heroList);
        }

        return gachaHero;
    }

    public Hero rollHero (List<Hero> heroList) {
        return heroList[Random.Range(0, heroList.Count)];
    }
}
