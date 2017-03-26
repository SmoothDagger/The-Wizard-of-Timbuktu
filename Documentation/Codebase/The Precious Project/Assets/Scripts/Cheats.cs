using UnityEngine;

public class Cheats : MonoBehaviour
{
    PlayerController _playerController;
    Timestop _timeStop;
    Transform _playerTransform;
    Timer _timer;

    void Start()
    {
        if (!CheatManager.Instance) return;

        GameObject player = GameObject.FindWithTag("Player");
        _playerController = player.GetComponent<PlayerController>();
        _playerTransform = player.transform;
        _timeStop = player.GetComponent<Timestop>();
        _timer = player.GetComponent<Timer>();

        ActivateCheats();
    }

    void Update()
    {
        if (!CheatManager.Instance) return;
        if (CheatManager.Instance.GodMode && PlayerOutOfBounds())
        {
            _playerController.MakeMeMortal();
           _playerController.Die();
            _playerController.MakeMeAGod();
        }

        if (CheatManager.Instance.TimeStopNoCD)
            _timeStop.Reset();
    }

    void ActivateCheats()
    {
        if (CheatManager.Instance.GodMode)
            _playerController.MakeMeAGod();
        _timer.Paused = CheatManager.Instance.StopTimer;

        if (CheatManager.Instance.DoubleSpeed)
            _playerController.SpeedUpIndefinetly();
    }

    bool PlayerOutOfBounds()
    {
        return _playerTransform.position.y <= -6;
    }
}
