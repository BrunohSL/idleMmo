using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class keeps the player currency, gold.
/// </summary>
public static class Currency {
    public static int gold;

    /// <summary>
    /// Add a integer value of gold to the actual player gold.
    /// </summary>
    public static void addCurrency(int amount) {
        Currency.gold += amount;
    }
}
