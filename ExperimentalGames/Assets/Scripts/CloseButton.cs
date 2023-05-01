using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    public GameObject panelToClose;     // Reference to the panel to be closed

    // Called when the button is clicked
    public void ClosePanel()
    {
        panelToClose.SetActive(false);  // Deactivate the panel to close it
    }
}
