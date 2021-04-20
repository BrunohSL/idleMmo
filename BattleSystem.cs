using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour {
    public BattleState state;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    private Character playerCharacter;
    private Character enemyCharacter;

    private GameObject playerObj;
    private GameObject enemyObj;

    public Text dialogueText;

    public BattleHud playerHud;
    public BattleHud enemyHud;

    void Start() {
        state = BattleState.START;

        Debug.Log("BattleSystem start");

        StartCoroutine(setupBattle());
    }

    IEnumerator setupBattle() {
        // get all characters info
        // load them on screen
        // order them by attack order
        // Start the battle

        playerObj = Instantiate(playerPrefab, playerBattleStation);
        enemyObj = Instantiate(enemyPrefab, enemyBattleStation);

        setHud();

        dialogueText.text = "A wild " + Enemies.enemiesList[Enemies.getSelectedEnemy()].characterName + " approaches!";

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        playerTurn();
    }

    void setHud() {
        enemyObj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Enemies.enemiesList[Enemies.getSelectedEnemy()].sprite);
        enemyHud.nameText.text = Enemies.enemiesList[Enemies.getSelectedEnemy()].characterName;
        enemyHud.levelText.text = "Lv " + Enemies.enemiesList[Enemies.getSelectedEnemy()].level;
        enemyHud.hpSlider.maxValue = Enemies.enemiesList[Enemies.getSelectedEnemy()].maxHp;
        enemyHud.hpSlider.value = Enemies.enemiesList[Enemies.getSelectedEnemy()].currentHp;

        playerObj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Players.playersList[Players.getSelectedPlayer()].sprite);
        playerHud.nameText.text = Players.playersList[Players.getSelectedPlayer()].characterName;
        playerHud.levelText.text = "Lv " + Players.playersList[Players.getSelectedPlayer()].level;
        playerHud.hpSlider.maxValue = Players.playersList[Players.getSelectedPlayer()].maxHp;
        playerHud.hpSlider.value = Players.playersList[Players.getSelectedPlayer()].currentHp;
        playerHud.expSlider.value = Players.playersList[Players.getSelectedPlayer()].currentXp;
        playerHud.expSlider.maxValue = Players.playersList[Players.getSelectedPlayer()].maxXp;
    }

    void playerTurn() {
        dialogueText.text = "Choose an action";
    }

    public void onAttackButton() {
        if (state != BattleState.PLAYERTURN) {
            return;
        }

        StartCoroutine(playerAttack());
    }

    IEnumerator playerAttack() {
        bool isDead = Enemies.enemiesList[Enemies.getSelectedEnemy()].takeDmg(Players.playersList[Players.getSelectedPlayer()].attack);

        enemyHud.setHp(Enemies.enemiesList[Enemies.getSelectedEnemy()].currentHp);
        dialogueText.text = "The attack gives " + Players.playersList[Players.getSelectedPlayer()].attack + " to the enemy!";

        yield return new WaitForSeconds(2f);

        if (isDead) {
            state = BattleState.WON;
            endBattle();
        } else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(enemyTurn());
        }
    }

    void endBattle() {
        if (state == BattleState.WON) {
            Debug.Log("Won the batle");
            dialogueText.text = "You won the battle";

            StartCoroutine(earnExperience());

            Currency.gold += (int) Random.Range(5.0f, 15.0f);

            foreach (DropController drop in Enemies.enemiesList[Enemies.getSelectedEnemy()].drops) {
                Debug.Log("Rolando chance do item " + drop.itemName + ".");
                if (drop.rollDropChance()) {
                    Debug.Log("Item name on battleSystem " + drop.itemName);
                    Item item = Items.getItemByName(drop.itemName);
                    item.amount = 1;
                    Players.playersList[Players.getSelectedPlayer()].inventory.addItem(item);
                }
            }

            // display exp earned text
            // verify level up to display in text
            // press any key to quit battle
            SceneManager.LoadScene("MainCity");
        }

        if (state == BattleState.LOST) {
            dialogueText.text = "You lost the battle";
            // display some lost text
            // press any key to return
        }
    }

    IEnumerator earnExperience() {
        Players.playersList[Players.getSelectedPlayer()].gainExp(Enemies.enemiesList[Enemies.getSelectedEnemy()].baseXpYield);

        playerHud.setExp(Players.playersList[Players.getSelectedPlayer()].currentXp, Players.playersList[Players.getSelectedPlayer()].maxXp);

        yield return new WaitForSeconds(2f);
    }

    IEnumerator enemyTurn() {
        dialogueText.text = Enemies.enemiesList[Enemies.getSelectedEnemy()].characterName + " has given you " + Enemies.enemiesList[Enemies.getSelectedEnemy()] .attack + " damage!";
        yield return new WaitForSeconds(1f);

        bool isDead = Players.playersList[Players.getSelectedPlayer()].takeDmg(Enemies.enemiesList[Enemies.getSelectedEnemy()].attack);
        playerHud.setHp(Players.playersList[Players.getSelectedPlayer()].currentHp);

        yield return new WaitForSeconds(2f);

        if (isDead) {
            state = BattleState.LOST;
            endBattle();
        } else {
            state = BattleState.PLAYERTURN;
            playerTurn();
        }
    }
}
