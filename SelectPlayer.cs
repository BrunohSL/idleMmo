using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour {
    public Transform playersPanel;
    public GameObject selectPlayerPanelPrefab;
    public GameObject createPlayerPanelPrefab;
    public GameObject createCharacterForm;
    public bool playerHudLoaded = false;

    void Start() {
        createCharacterForm.SetActive(false);
    }

    void Update() {
        if (playerHudLoaded == false) {
            playerHudLoaded = true;
            loadPlayers();
        }
    }

    public void loadPlayers() {
        cleanOldPanels();
        float xValue = 256.01563f;
        int count = 0;

        for (var i = 0; i < 3; i++) {
            GameObject playerPanelObj;
            if (count > Players.playersList.Count -1) {
                playerPanelObj = Instantiate(createPlayerPanelPrefab, playersPanel);
                playerPanelObj.GetComponent<CreatePlayerPanelHud>().setupCreatePlayerPanel(createCharacterForm);
            } else {
                playerPanelObj = Instantiate(selectPlayerPanelPrefab, playersPanel);
                playerPanelObj.GetComponent<SelectPlayerPanelHud>().setupSelectPlayerPanel(Players.playersList[i], i);
            }

            playerPanelObj.transform.position = new Vector3(xValue, 337.5f, 0f);

            xValue += 380f;
            count++;
        }
    }

    public static void selectPlayer(int playerId) {
        Players.selectedPlayer = playerId;
        SceneManager.LoadScene("MainCity");
    }

    private void cleanOldPanels() {
        GameObject[] oldPanels = new GameObject[3];
        oldPanels = GameObject.FindGameObjectsWithTag("selectCreatePlayerPanel");

        foreach (GameObject panel in oldPanels) {
            Destroy(panel);
        }
    }
}
