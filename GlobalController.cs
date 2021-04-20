using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class GlobalController : MonoBehaviour {
    public static GlobalController control;
    private string savePath;

    public Transform saveButton;

    void Awake () {
        savePath = Path.Combine(Application.persistentDataPath, "playerData.dat");
        if (control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
        } else if (control != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        Enemies.setEnemyList();
        Heroes.setHeroesList();

        if (File.Exists(savePath)) {
            List<Player> loadedPlayers = loadPlayerList();

            Players.playersList = new List<Player>();

            foreach (Player player in loadedPlayers) {
                Players.addPlayer(player);
            }
        }

        // Debug only
        selectPlayerIfNotFromHomeScreen();
    }

    public void selectPlayerIfNotFromHomeScreen() {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        if (scene.name == "MainCity") {
            Players.selectedPlayer = 0;
        }
    }

    public void savePlayer() {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = new FileStream(savePath, FileMode.Create);

        Debug.Log(Application.persistentDataPath);
        PlayerData data = new PlayerData();
        binaryFormatter.Serialize(file, data);
        file.Close();

        Debug.Log("Player Saved!");
    }

    public List<Player> loadPlayerList() {
        if (File.Exists(savePath)) {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = new FileStream(savePath, FileMode.Open);
            PlayerData data = binaryFormatter.Deserialize(file) as PlayerData;
            file.Close();

            Currency.gold = 200;

            // Currency.gold = data.gold;

            Debug.Log("Player Loaded!");

            return data.savePlayerList;
        } else {
            return null;
        }
    }
}
