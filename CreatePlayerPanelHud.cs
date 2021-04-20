using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CreatePlayerPanelHud : MonoBehaviour {
    public void setupCreatePlayerPanel(GameObject createCharacterForm) {
        this.GetComponent<Button>().onClick.AddListener(delegate {
            createCharacterForm.SetActive(true);
        });
    }
}
