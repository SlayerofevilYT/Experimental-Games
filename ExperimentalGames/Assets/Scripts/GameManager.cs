using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;    // Singleton instance of the GameManager

    public Tower[] availableTowers;        // Array of all available towers in the game

    // Called when the script is first enabled
    private void Awake()
    {
        // Ensure that there is only one instance of the GameManager in the scene
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
