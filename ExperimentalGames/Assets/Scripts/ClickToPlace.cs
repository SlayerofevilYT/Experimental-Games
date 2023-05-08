using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToPlace : MonoBehaviour
{
    public GameObject[] towers;

    public void Start()
    {

    }

    public void SelectTower(int selectedTower)
    {
        switch (selectedTower)
        {
            case 1:
                Instantiate(towers[0], this.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(towers[1], this.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(towers[2], this.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(towers[3], this.transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(towers[4], this.transform.position, Quaternion.identity);
                break;
        }
    }
}
