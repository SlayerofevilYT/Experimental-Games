using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerListPath: MonoBehaviour
{
    public GameObject towerListPanel;
    public Button closeButton;
    public Button[] towerButtons;

    public TowerPlacementPath placementSpot;

    public bool canPlace;

    void Start()
    {
        towerListPanel.SetActive(false);

        for (int i = 0; i < towerButtons.Length; i++)
        {
            int index = i;
            towerButtons[index].onClick.AddListener(() => { OnTowerButtonClicked(index); });
        }

        // Add a click listener to the close button
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    public void ChooseTowerSpot(TowerPlacementPath obj)
    {
        placementSpot = obj;
    }

    public void ShowTowerList(Vector3 pos)
    {
        towerListPanel.SetActive(true);
        towerListPanel.transform.position = pos;
    }

    private void OnTowerButtonClicked(int index)
    {
        Debug.Log("Chose tower #"+index);
        placementSpot.PickingTowers(index);

        towerButtons[index].GetComponent<Image>().color = Color.yellow;
    }

    private void OnCloseButtonClicked()
    {
        // Hide the tower list panel
        towerListPanel.SetActive(false);
    }
}
