using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CreatePlayer : MonoBehaviour {
    private int pointsLeft;

    public int points;
    public int strValue;
    public int intValue;
    public int agiValue;
    public int vitValue;

    public Text pointsLeftText;
    public Text strValueText;
    public Text intValueText;
    public Text agiValueText;
    public Text vitValueText;

    public GameObject emptyNamePanel;
    public GameObject pointsLeftPanel;

    public InputField inputField;
    public GameObject newCharacterForm;
    public SelectPlayer selectPlayer;

    void Start() {
        pointsLeft = points;
        updateText();

        emptyNamePanel.SetActive(false);
        pointsLeftPanel.SetActive(false);
    }

    public void addAttribute(string attribute) {
        if (canAddPoints()) {
            pointsLeft--;
            switch (attribute) {
                case "str":
                    strValue++;
                    break;
                case "int":
                    intValue++;
                    break;
                case "agi":
                    agiValue++;
                    break;
                case "vit":
                    vitValue++;
                    break;
            }
            updateText();
        }
    }

    public void removeAttribute(string attribute) {
        if (canRemovePoints(attribute)) {
            pointsLeft++;
            switch (attribute) {
                case "str":
                    strValue--;
                    break;
                case "int":
                    intValue--;
                    break;
                case "agi":
                    agiValue--;
                    break;
                case "vit":
                    vitValue--;
                    break;
            }
            updateText();
        }
    }

    private bool canAddPoints() {
        if (pointsLeft <= 0) {
            return false;
        }

        return true;
    }

    private bool canRemovePoints(string attribute) {
        if (pointsLeft >= points) {
            return false;
        }

        switch (attribute) {
            case "str":
                if (strValue <= 5) {
                    return false;
                }
                break;
            case "int":
                if (intValue <= 5) {
                    return false;
                }
                break;
            case "agi":
                if (agiValue <= 5) {
                    return false;
                }
                break;
            case "vit":
                if (vitValue <= 5) {
                    return false;
                }
                break;
        }

        return true;
    }

    public void createPlayer() {
        if (inputField.text == "") {
            emptyNamePanel.SetActive(true);
            Debug.Log("Name can't be empty");
            return;
        }

        if (pointsLeft > 0) {
            pointsLeftPanel.SetActive(true);
            Debug.Log("Ainda não distribuiu todos os pontos");
            return;
        }

        Player player = new Player();

        player.characterName = inputField.text;
        player.level = 1;
        player.strength = strValue;
        player.intelligence = intValue;
        player.agility = agiValue;
        player.vitality = vitValue;
        player.maxXp = ExperienceController.expArray[player.level - 1];
        player.currentXp = 0;
        player.maxHp = player.getMaxHp();
        player.currentHp = player.getMaxHp();
        player.attack = player.getAttack();
        player.defense = player.getDefense();
        player.sprite = "bowJr";

        if (Players.playersList.Count >= 3) {
            Debug.Log("Não pode ter mais de 3 players");
            return;
        } else {
            Players.newPlayer(player);
            resetForm();

            newCharacterForm.SetActive(false);
            selectPlayer.playerHudLoaded = false;
        }

        // JSONNode playerJson = JsonUtility.ToJson(player);

        // StartCoroutine(webRequest.PostRequest(ApplicationModel.baseUrl + "player/store", playerJson, (callback) => {
        //     Debug.Log(callback);

            // newCharacterForm.SetActive(false);
            // selectPlayer.playerHudLoaded = false;
            // ApplicationModel.playersLoaded = false;
            // loadController.setPlayersList();
        // }));
    }

    private void resetForm() {
        pointsLeft = points;
        strValue = 5;
        intValue = 5;
        agiValue = 5;
        vitValue = 5;
        inputField.text = "";
        updateText();
    }

    private void updateText() {
        pointsLeftText.text = pointsLeft.ToString();
        strValueText.text = strValue.ToString();
        intValueText.text = intValue.ToString();
        agiValueText.text = agiValue.ToString();
        vitValueText.text = vitValue.ToString();
    }
}
