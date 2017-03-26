using UnityEngine;

public class CheatManager : MonoBehaviour
{
    private static CheatManager _instance;

    public static CheatManager Instance
    {
        get { return _instance; }
    }

    private bool godMode;
    public bool GodMode
    {
        get { return godMode; }
        set { godMode = value; }
    }

    private bool stopTimer;
    public bool StopTimer
    {
        get { return stopTimer; }
        set { stopTimer = value; }
    }

    private bool timeStopNoCD;
    public bool TimeStopNoCD
    {
        get { return timeStopNoCD; }
        set { timeStopNoCD = value; }
    }

    private bool doubleSpeed;
    public bool DoubleSpeed
    {
        get { return doubleSpeed; }
        set { doubleSpeed = value; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
            
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ToggleGodMode()
    {
        GodMode = !GodMode;
    }

    public void ToggleStopTimer()
    {
        StopTimer = !StopTimer;
    }

    public void ToggleTimeStopCD()
    {
        TimeStopNoCD = !TimeStopNoCD;
    }

    public void ToggleDoubleSpeed()
    {
        DoubleSpeed = !DoubleSpeed;
    }

    public void DisableAll()
    {
        GodMode = false;
        StopTimer = false;
        TimeStopNoCD = false;
        DoubleSpeed = false;
    }

    public void EnableAll()
    {
        GodMode = true;
        StopTimer = true;
        TimeStopNoCD = true;
        DoubleSpeed = true;
    }
}
