using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SelectPlayerPanelHud : MonoBehaviour {
    public Image playerSprite;
    public Text nameText;
    public Text levelText;
    public Text hpText;
    public GameObject panel;

    public void setupSelectPlayerPanel(Player player, int playerNumber) {
        playerSprite.sprite = Resources.Load<Sprite>(player.sprite);
        nameText.text = player.characterName;
        levelText.text = "LV " + player.level;
        hpText.text = "HP: " + player.maxHp;

        panel.GetComponent<Button>().onClick.AddListener(delegate {SelectPlayer.selectPlayer(playerNumber);});
    }
}
