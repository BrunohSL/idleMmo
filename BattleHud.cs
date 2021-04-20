using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BattleHud : MonoBehaviour {
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;
    public Slider expSlider;

    public void setHp(int hp) {
        hpSlider.value = hp;
    }

    public void setExp(int currentExp, int maxExp) {
        expSlider.value = currentExp;
        expSlider.maxValue = maxExp;
    }
}
