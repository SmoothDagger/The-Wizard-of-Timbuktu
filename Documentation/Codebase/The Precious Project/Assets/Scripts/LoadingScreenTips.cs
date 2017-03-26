using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenTips : MonoBehaviour
{
    public GameObject loadingTips;
    private string loadingtips;
    private int randomTips;
    // Use this for initialization
    void Start()
    {
        loadingTips = GameObject.Find("Loading Tips");
        loadingtips = "";//"Tips: \n";
        randomTips = Random.Range(0, 13);
        if (randomTips == 0)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "Rhinos are fun to ride until you touch their horn.";
        }
        else if (randomTips == 1)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "Crocodiles will eat you if you stay on them for too long.";
        }
        else if (randomTips == 2)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "Giraffes are the nicest animals in the wild.";
        }
        else if (randomTips == 3)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "Burning grass is deadlier than you might think.";
        }
        else if (randomTips == 4)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "Swinging axes look really nice up close, but not too close...";
        }
        else if (randomTips == 5)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "Platforms on water and lava are useful for advancing.";
        }
        else if (randomTips == 6)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "Boulders roll and will crush you if you don't avoid them.";
        }
        else if (randomTips == 7)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "Beware of spikes and falling logs!";
        }
        else if (randomTips == 8)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "If caught in a bear trap, mash the 'space bar' to escape.";
        }
        else if (randomTips == 9)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "Use the space bar to jump if on the ground or levitate if you are in air.";
        }
        else if (randomTips == 10)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "You can stop time by using 'Q'.";
        }
        else if (randomTips == 11)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "Checkpoints reset your spawn point and current time!";
        }
        else if (randomTips == 12)
        {
            loadingTips.GetComponent<Text>().text = loadingtips + "If time stop is active or can NOT be used, an hour glass will be shown on the HUD.";
        }

    }

    
   
}
