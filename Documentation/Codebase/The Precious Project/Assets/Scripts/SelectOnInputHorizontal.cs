using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectOnInputHorizontal : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;
    bool buttonSelected;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
    }


    private void OnDisable()
    {
        buttonSelected = false;
    }
}