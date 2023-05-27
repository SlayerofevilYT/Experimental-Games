using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerListUI : MonoBehaviour
{
    public GameObject towerListPanel;   // The panel that displays the tower list
    public Button closeButton;         // The button that closes the tower list panel
    public Button[] towerButtons;       // The buttons representing each tower in the list

    private Tower selectedTower;        // The currently selected tower
    public TowerPlacement[] placingTowers;

    public TowerPlacement placementSpot;

    // Called when the script is first enabled
    private void Start()
    {
        // Hide the tower list panel by default
        towerListPanel.SetActive(false);

        // Add click listeners to the tower buttons
        for (int i = 0; i < towerButtons.Length; i++)
        {
            int index = i;
            towerButtons[index].onClick.AddListener(() => { OnTowerButtonClicked(index); });
        }

        // Add a click listener to the close button
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    /*void Update()
    {
        if (towerListPanel.activeSelf)
        {

            // Set the position of the towerListPanel to the current tile position
            //towerListPanel.transform.position = currentTilePosition;

            // Get the size of the towerListPanel
            Vector2 panelSize = towerListPanel.GetComponent<RectTransform>().rect.size;

            // Calculate the maximum x and y position of the panel based on the screen dimensions
            float maxX = Screen.width - panelSize.x / 2f;
            float maxY = Screen.height - panelSize.y / 2f;

            // Clamp the position of the towerListPanel to stay within the screen bounds
            float clampedX = Mathf.Clamp(towerListPanel.transform.position.x, panelSize.x / 2f, maxX);
            float clampedY = Mathf.Clamp(towerListPanel.transform.position.y, panelSize.y / 2f, maxY);

            towerListPanel.transform.position = new Vector3(clampedX, clampedY, 0f);
        }
    }*/

    public void ChooseTowerSpot(TowerPlacement obj)
    {
        placementSpot = obj;
    }

    // Called when a tower button is clicked
    private void OnTowerButtonClicked(int index)
    {
        // Deselect any currently selected tower
        DeselectTower();

        // Get the tower associated with the clicked button
        selectedTower = GameManager.instance.availableTowers[index];
        Debug.Log("Getting tower no."+index);

        // Highlight the selected button
        towerButtons[index].GetComponent<Image>().color = Color.yellow;

        towerListPanel.SetActive(false);
        //placingTowers[index].StartTowerPlacement();
    }

    // Called when the close button is clicked
    private void OnCloseButtonClicked()
    {
        // Hide the tower list panel
        towerListPanel.SetActive(false);

        // Deselect any selected tower
        DeselectTower();
    }

    // Deselects the currently selected tower, if any
    private void DeselectTower()
    {
        if (selectedTower != null)
        {
            // Unhighlight the selected button
            int index = System.Array.IndexOf(GameManager.instance.availableTowers, selectedTower);

            selectedTower = null;
        }
    }

    // Gets the currently selected tower, if any
    public Tower GetSelectedTower(Vector3 position)
    {
        selectedTower.transform.position = position;
        return selectedTower;
    }

    public void ShowTowerList(Vector3 position)
    {
        towerListPanel.SetActive(true);    // Enable the tower list panel
        towerListPanel.transform.position = position;    // Set the position of the panel to the clicked tile position
    }

}
