using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData {
    // Object que será salvo?
    // Lista de players
    // Lista de inimigos

        // em um futuro próximo
        // inventário (itens)
        // inventário (herois)
        // currencys
            // achievement values
            // quantos pulls foram feitos
            // total de gold obtido
            // maximo de gold guardado (antes de gastar)
            // Total de herois liberados

    public List<Player> savePlayerList = new List<Player>();
    public int gold;

    public PlayerData() {
        if (Players.playersList.Count > 0) {
            for (int i = 0; i < Players.playersList.Count; i++) {
                savePlayerList.Add(Players.playersList[i]);
            }
        }

        gold = Currency.gold;
    }
}
