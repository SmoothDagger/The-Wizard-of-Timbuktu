using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SelectOnLevelEndHUD : MonoBehaviour {
    public GameObject eventObject;
    public EventSystem eventSystem;
    public GameObject selectedObject;
    private bool buttonSelected;
    // Use this for initialization
    void Start () {
        eventObject = GameObject.Find("EventSystem");
        eventSystem = eventObject.GetComponent<EventSystem>();
    }
	
	// Update is called once per frame
	void Update () {
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
