using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {
    public Transform battlePanel;
    public GameObject enemyPanelPrefab;

    public GameObject heroNotificationImage;
    public GameObject squadNotificationImage;
    public GameObject bagNotificationImage;

    public Text goldText;

    public AudioSource openBag;
    public AudioSource openBattle;

    public static void onClickBattle(int enemyId) {
        Enemies.setSelectedEnemy(enemyId);
        SceneManager.LoadScene("Battle");
    }

    void Start() {
        heroNotificationImage.SetActive(false);
        squadNotificationImage.SetActive(false);
        bagNotificationImage.SetActive(false);

        openBag = this.GetComponent<AudioSource>();
    }

    void Update() {
        if (Players.playersList[Players.getSelectedPlayer()].pointsLeft > 0) {
            heroNotificationImage.SetActive(true);
        } else {
            heroNotificationImage.SetActive(false);
        }

        goldText.text = "GOLD: " + Currency.gold;
    }

    // Debug/Test only
    public void clickAddItem() {
        Players.playersList[Players.getSelectedPlayer()].inventory.addItem(
            new Item {
                itemType = Item.ItemType.equipable,
                itemName = Item.ItemName.shovel,
                amount = 1,
                sprite = "shovel",
            }
        );
        Players.playersList[Players.getSelectedPlayer()].inventory.addItem(
            new Item {
                itemType = Item.ItemType.material,
                itemName = Item.ItemName.ironOre,
                amount = 5,
                sprite = "ironOre",
            }
        );
        Players.playersList[Players.getSelectedPlayer()].inventory.addItem(
            new Item {
                itemType = Item.ItemType.material,
                itemName = Item.ItemName.jerryHairBall,
                amount = 1,
                sprite = "jerryHairBall",
            }
        );
    }

    public void playOpenBag() {
        openBag.Play();
    }

    public void saveButton() {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = new FileStream(Path.Combine(Application.persistentDataPath, "playerData.dat"), FileMode.Create);

        Debug.Log(Application.persistentDataPath);
        PlayerData data = new PlayerData();
        binaryFormatter.Serialize(file, data);
        file.Close();

        Debug.Log("Player Saved!");
    }

    // Debug/Test only
    public void emptyBag() {
        Debug.Log("Esvaziou a mochila");
        Inventory inventory = new Inventory();
        Players.playersList[Players.getSelectedPlayer()].inventory = inventory;
    }

    public void loadEnemies() {
        openBattle.Play();
        float xValue = 256.0f;

        for (var i = 0; i < Enemies.enemiesList.Count; i++) {
            GameObject enemyPanelObj = Instantiate(enemyPanelPrefab, battlePanel);
            enemyPanelObj.transform.position = new Vector3(xValue, 418f, 0.0f);
            enemyPanelObj.GetComponent<EnemyPanelHud>().setupEnemyPanel(Enemies.enemiesList[i]);

            xValue += 384f;
        }
    }
}
