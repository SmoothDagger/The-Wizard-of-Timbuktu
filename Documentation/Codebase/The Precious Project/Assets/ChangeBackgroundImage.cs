using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackgroundImage : MonoBehaviour {
    GameObject background;
    Sprite sprite;

    //public Sprite World1;
    //public Sprite World2;
    //public Sprite World;


    // Use this for initialization
    void Start () {
        background = GameObject.Find("Background");
        sprite = background.GetComponent<SpriteRenderer>().sprite;
        int lastWorldPlayed = PlayerPrefs.GetInt("Last World Played");
        switch (lastWorldPlayed)
        {
            case 1:
                sprite = Resources.Load("World 1 Sprite", typeof(Sprite)) as Sprite;
                background.GetComponent<Transform>().localScale = new Vector3(10, 10, 10);
                break;
            case 2:
                sprite = Resources.Load("World 2 Sprite", typeof(Sprite)) as Sprite;
                background.GetComponent<Transform>().localScale = new Vector3(30, 30, 10);
                break;
            case 3:
                sprite = Resources.Load("World 3 Sprite", typeof(Sprite)) as Sprite;
                background.GetComponent<Transform>().localScale = new Vector3(20, 20, 10);
                break;
            default:
                break;
        }

        background.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
