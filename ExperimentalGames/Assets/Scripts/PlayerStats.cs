using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int Lives = 20;      // The number of lives the player has
    public static int Money = 100;     // The amount of money the player has

    public TMP_Text livesText;             // The UI text element that displays the player's lives
    public TMP_Text moneyText;             // The UI text element that displays the player's money

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + Lives.ToString();
        moneyText.text = "$" + Money.ToString();
    }
}
