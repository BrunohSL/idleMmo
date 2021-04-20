using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HeroPanelController : MonoBehaviour {
    public Text characterNameText;
    public Text levelText;

    public Text pointsLeftValueText;
    public Text strValueText;
    public Text intValueText;
    public Text agiValueText;
    public Text vitValueText;

    public int pointsLeft;
    public int points;

    public int strValue;
    public int intValue;
    public int agiValue;
    public int vitValue;

    public int strBaseValue;
    public int intBaseValue;
    public int agiBaseValue;
    public int vitBaseValue;

    void Start() {
        getActualPlayerAttributes();
        setBaseValues();

        updateText();
        setupHeroPanel();
    }

    public void applyStatusChangeButton() {
        Players.playersList[Players.getSelectedPlayer()].pointsLeft = pointsLeft;
        Players.playersList[Players.getSelectedPlayer()].strength = strValue;
        Players.playersList[Players.getSelectedPlayer()].intelligence = intValue;
        Players.playersList[Players.getSelectedPlayer()].agility = agiValue;
        Players.playersList[Players.getSelectedPlayer()].vitality = vitValue;

        Players.playersList[Players.getSelectedPlayer()].updatePlayerAttributes();

        getActualPlayerAttributes();
        setBaseValues();
    }

    public void setupHeroPanel() {
        characterNameText.text = Players.playersList[Players.getSelectedPlayer()].characterName;
        levelText.text = "Level: " + Players.playersList[Players.getSelectedPlayer()].level.ToString();
        updateText();
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
                if (strValue <= strBaseValue) {
                    return false;
                }
                break;
            case "int":
                if (intValue <= intBaseValue) {
                    return false;
                }
                break;
            case "agi":
                if (agiValue <= agiBaseValue) {
                    return false;
                }
                break;
            case "vit":
                if (vitValue <= vitBaseValue) {
                    return false;
                }
                break;
        }

        return true;
    }

    public void getActualPlayerAttributes() {
        pointsLeft = Players.playersList[Players.getSelectedPlayer()].pointsLeft;
        strValue = Players.playersList[Players.getSelectedPlayer()].strength;
        intValue = Players.playersList[Players.getSelectedPlayer()].intelligence;
        agiValue = Players.playersList[Players.getSelectedPlayer()].agility;
        vitValue = Players.playersList[Players.getSelectedPlayer()].vitality;
    }

    public void setBaseValues() {
        points = pointsLeft;
        strBaseValue = strValue;
        intBaseValue = intValue;
        agiBaseValue = agiValue;
        vitBaseValue = vitValue;
    }

    private void updateText() {
        pointsLeftValueText.text = pointsLeft.ToString();
        strValueText.text = strValue.ToString();
        intValueText.text = intValue.ToString();
        agiValueText.text = agiValue.ToString();
        vitValueText.text = vitValue.ToString();
    }
}
