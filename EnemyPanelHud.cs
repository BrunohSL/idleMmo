using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyPanelHud : MonoBehaviour {
    public Image enemySprite;
    public Text nameText;
    public Text levelText;
    public Text hpText;
    public Button battleButton;

    public void setupEnemyPanel(Enemy enemy) {
        enemySprite.sprite = Resources.Load<Sprite>(enemy.sprite);
        nameText.text = enemy.characterName;
        levelText.text = "LV " + enemy.level;
        hpText.text = "HP: " + enemy.maxHp;
        battleButton.onClick.AddListener(delegate {GameController.onClickBattle(enemy.id);});
    }
}
