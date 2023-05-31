using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devControls : MonoBehaviour
{

    private bool canChange;

    // Update is called once per frame
    void Update()
    {
        ChangeTimeScale();

        if (Input.GetKeyDown("t"))
        {
            canChange = true;
        } else
        {
            canChange = false;
        }
    }

    public void ChangeTimeScale()
    {
        while (canChange)
        {
            Time.timeScale = 2;
            Debug.Log(Time.timeScale);
        }
    }
}
