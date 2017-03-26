using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Effects;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController), typeof(Timer))]
public class PlayerController : MonoBehaviour {


    #region Public
    public GameObject spawnPoint;
    public bool IsAlive = true;
    public bool controllable = true;
    public int mashCount;
    public float maxLevitateTime = .4f;
    public int numOfDeaths = 0;
    public AudioClip[] audioClip;
    public float timeStopLength;
    public float timeScaleTime;
    public float beenFrozenTime;
    //Ge's Update
    public GameObject sceneMangerObject;
    GameObject fireNotification;
    GameObject waterNotification;
    GameObject rhinoNotification;
    GameObject crocodileNotification;
    GameObject lavaNotification;
    GameObject fallingLavaNotification;
    GameObject swingingAxeNotification;
    GameObject grassSpikesNotification;
    GameObject fallingLogNotification;
    GameObject boulderNotification;
    GameObject bearTrapNotification;
    GameObject sawBladeNotification;
    public int timesKilledByFire;
    public bool isKilledByFire;
    public int timesKilledByWater;
    public bool isKilledByWater;
    public int timesKilledByRhino;
    public bool isKilledByRhino;
    public int timesKilledByCrocodile;
    public bool isKilledByCrocodile;
    public int timesKilledByLava;
    public bool isKilledByLava;
    public int timesKilledBySwingingAxe;
    public bool isKilledBySwingingAxe;
    public int timesKilledByGrassSpikes;
    public bool isKilledByGrassSpikes;
    public int timesKilledByFallingLog;
    public bool isKilledByFallingLog;
    public int timesKilledByBearTrap;
    public bool isKilledByBearTrap;
    public int timesKilledBySawBlade;
    public bool isKilledBySawBlade;
    //
    public Timestop timeStop;
    public bool isPlayerLevitating;
    public bool didPlayerJump;
    public bool movingLeft;
    #endregion

    #region Private
    ParticleSystem levitateParticle;
    AudioSource _audio;
    CharacterController controller;
    GameObject[] movingObjects;
    Timer timer;
    public Vector3 moveDirection = Vector3.zero;
    Vector3 prevPosition;
    Vector3 playerScale;
    bool canLevitate;
    bool canJump;
    bool isMoving;
    bool isGrounded;
    bool keepResetting;
    float deathWait = 0.3f;
    float speedOriginal;
    float speed = 12.0f;
    float speedSlow;
    float speedFast;
    float levitateTimer;
    float gravity;
    float maxJumpHeight = 6.0f;
    float minJumpHeight = 2.0f;
    float maxJumpVelocity;
    float minJumpVelocity;
    float horizontalMovement;
    float myDeltaTime;
    float localTimeScaleTime;
    int totalDeaths;
    //statistics
    int jumpTimes;
    int levitateTimes;
    #endregion

    #region Serialize
    [SerializeField]
    float timeToJumpApex = .4f;
    [SerializeField]
    float airSpeed = 1.4f;
    #endregion

    private bool canDie = true;
    public bool CanDie
    {
        get { return canDie; }
        set { canDie = value; }
    }

    private bool sliding;
    public bool Sliding
    {
        get { return sliding; }
        set { sliding = value; }
    }

    private float initZ;
    private Vector3 scale;

    public float InitZ
    {
        get { return initZ; }
        private set { initZ = value; }
    }

    void Start () {
        controller = GetComponent<CharacterController>();
        spawnPoint = GameObject.Find("SpawnPoint");
        totalDeaths = PlayerPrefs.GetInt("Player Deaths", totalDeaths);

        speedOriginal = speed;
        speedSlow = speed / 2;
        speedFast = speed * 2;
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        transform.position = spawnPoint.transform.position;

        timer = GetComponent<Timer>();
        _audio = GetComponentInChildren<AudioSource>();
        levitateParticle = GetComponentInChildren<ParticleSystem>();

        //Ge's change
        sceneMangerObject = GameObject.Find("SceneManagerObject");
        fireNotification = GameObject.Find("KilledByFire");
        fireNotification.SetActive(false);
        waterNotification = GameObject.Find("KilledByWater");
        waterNotification.SetActive(false);
        rhinoNotification = GameObject.Find("KilledByRhino");
        rhinoNotification.SetActive(false);
        crocodileNotification = GameObject.Find("KilledByCrocodile");
        crocodileNotification.SetActive(false);
        lavaNotification = GameObject.Find("KilledByLava");
        lavaNotification.SetActive(false);
        swingingAxeNotification = GameObject.Find("KilledBySwingingAxe");
        swingingAxeNotification.SetActive(false);
        grassSpikesNotification = GameObject.Find("KilledByGrassSpikes");
        grassSpikesNotification.SetActive(false);
        fallingLogNotification = GameObject.Find("KilledByFallingLog");
        fallingLogNotification.SetActive(false);
        bearTrapNotification = GameObject.Find("KilledByBearTrap");
        bearTrapNotification.SetActive(false);
        sawBladeNotification = GameObject.Find("KilledBySawBlade");
        sawBladeNotification.SetActive(false);
        isKilledByFire = false;
        isKilledByWater = false;
        isKilledByRhino = false;
        isKilledByCrocodile = false;
        isKilledByLava = false;
        isKilledBySwingingAxe = false;
        isKilledByGrassSpikes = false;
        isKilledByFallingLog = false;
        isKilledByBearTrap = false;
        isKilledBySawBlade = false;
        timesKilledByFire = PlayerPrefs.GetInt("Times Killed By Fire");
        timesKilledByWater = PlayerPrefs.GetInt("Times Killed By Water");
        timesKilledByRhino = PlayerPrefs.GetInt("Times Killed By Rhino");
        timesKilledByCrocodile = PlayerPrefs.GetInt("Times Killed By Crocodile");
        timesKilledByLava= PlayerPrefs.GetInt("Times Killed By Lava");
        timesKilledBySwingingAxe = PlayerPrefs.GetInt("Times Killed By Swinging Axe");
        timesKilledByGrassSpikes = PlayerPrefs.GetInt("Times Killed By Grass Spikes");
        timesKilledByFallingLog = PlayerPrefs.GetInt("Times Killed By Falling Log");
        timesKilledByBearTrap = PlayerPrefs.GetInt("Times Killed By Bear Trap");
        timesKilledBySawBlade = PlayerPrefs.GetInt("Times Killed By Saw Blade");
        //statistics
        jumpTimes = PlayerPrefs.GetInt("Total Times Jumped"); ;
        levitateTimes= PlayerPrefs.GetInt("Total Times Levitated");
        //
        Time.timeScale = 1.0f;

        timeStop = GetComponent<Timestop>();
        localTimeScaleTime = Time.timeScale;

        initZ = transform.position.z;
        scale = transform.localScale;
    }

    void Update () {
        if (0 == Time.timeScale)
            return;

        if (IsAlive && controllable)
        {
            transform.localRotation = Quaternion.identity;
            moveDirection.z = 0;
            moveDirection = transform.TransformDirection(moveDirection);

            if (!isMoving)
                sliding = false;

            if (!sliding)
            {
                if (CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0)
                {
                    horizontalMovement = 1;
                    isMoving = true;
                    movingLeft = false;
                }
                else if (CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0)
                {
                    horizontalMovement = -1;
                    isMoving = true;
                    movingLeft = true;
                }
                else
                {
                    horizontalMovement = 0;
                    isMoving = false;
                }
            }

            if (controller.isGrounded)
            {
                isGrounded = true;
                canJump = true;
                canLevitate = false;
                moveDirection = new Vector3(horizontalMovement, 0, 0);
                moveDirection *= speed;
                isPlayerLevitating = false;
                didPlayerJump = false;
                ResetTransform();
            }
            else if (!controller.isGrounded)
            {
                isGrounded = false;
                moveDirection.x = horizontalMovement;
                moveDirection.x *= (airSpeed * speed);
                if (canLevitate && CrossPlatformInputManager.GetButtonDown("Jump") && !canJump)
                {
                    StartCoroutine("LevitateTime");
                    moveDirection.y = 0;
                    gravity = 0;
                    //statistics
                    levitateTimes++;
                    isPlayerLevitating = true;
                    didPlayerJump = false;
                }
            }

            if (CrossPlatformInputManager.GetButtonDown("Jump") && !canLevitate && canJump)
            {
                moveDirection.y = maxJumpVelocity;
                canLevitate = true;
                PlaySound(1);
                //statistics
                jumpTimes++;
                didPlayerJump = true;
            }
            if (CrossPlatformInputManager.GetButtonUp("Jump"))
            {
                canJump = false;
                if (moveDirection.y > minJumpVelocity)
                    moveDirection.y = minJumpVelocity;
                isPlayerLevitating = false;

            }

            if (CrossPlatformInputManager.GetButtonDown("TimeStop"))
            {
                if (timeStop.CanTimeStop())
                    timeStop.StopTime();
            }

            moveDirection.y += (gravity * Time.deltaTime * (1 / Time.timeScale));
            moveDirection.z = 0;
            controller.Move(moveDirection * Time.deltaTime * (1 / Time.timeScale));
        }
        else if (!controllable && IsAlive)
        {        
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
                mashCount++;
        }

        localTimeScaleTime = Time.timeScale;
    }

    void OnDestroy()
    {
        totalDeaths += numOfDeaths;
        PlayerPrefs.SetInt("Player Deaths", totalDeaths);
        PlayerPrefs.SetInt("Times Killed By Fire", timesKilledByFire);
        PlayerPrefs.SetInt("Times Killed By Water", timesKilledByWater);
        PlayerPrefs.SetInt("Times Killed By Rhino", timesKilledByRhino);
        PlayerPrefs.SetInt("Times Killed By Crocodile", timesKilledByCrocodile);
        PlayerPrefs.SetInt("Times Killed By Lava", timesKilledByLava);
        PlayerPrefs.SetInt("Times Killed By Swinging Axe", timesKilledBySwingingAxe);
        PlayerPrefs.SetInt("Times Killed By Grass Spikes", timesKilledByGrassSpikes);
        PlayerPrefs.SetInt("Times Killed By Falling Log", timesKilledByFallingLog);
        PlayerPrefs.SetInt("Times Killed By Bear Trap", timesKilledByBearTrap);
        PlayerPrefs.SetInt("Times Killed By Saw Blade", timesKilledBySawBlade);
        PlayerPrefs.SetInt("Total Times Jumped",jumpTimes);
        PlayerPrefs.SetInt("Total Times Levitated", levitateTimes);
    }

    void Respawn()
    {
        transform.position = spawnPoint.transform.position;
        IsAlive = true;
        canDie = true;

        //Ge
        isKilledByFire = false;
        isKilledByWater = false;
        isKilledByRhino = false;
        isKilledByCrocodile = false;
        isKilledByLava = false;
        isKilledBySwingingAxe = false;
        isKilledByGrassSpikes = false;
        isKilledByFallingLog = false;
        isKilledByBearTrap = false;
        isKilledBySawBlade = false;
        //
    }

    public void Die()
    {
        if (!canDie) return;
        
        //Ge
        if (isKilledByFire == true && timesKilledByFire == 1)
        {
            Time.timeScale = 0.0000001f;
            sceneMangerObject.transform.GetChild(0).gameObject.SetActive(false);
            sceneMangerObject.GetComponent<SceneManagerScript>().canPauseOpen = false;
            fireNotification.SetActive(true);
            controllable = false;
        }
        else if (isKilledByWater == true && timesKilledByWater == 1)
        {
            Time.timeScale = 0.0000001f;
            sceneMangerObject.transform.GetChild(0).gameObject.SetActive(false);
            sceneMangerObject.GetComponent<SceneManagerScript>().canPauseOpen = false;
            waterNotification.SetActive(true);
            controllable = false;
        }
        else if (isKilledByRhino == true && timesKilledByRhino == 1)
        {
            Time.timeScale = 0.0000001f;
            sceneMangerObject.transform.GetChild(0).gameObject.SetActive(false);
            sceneMangerObject.GetComponent<SceneManagerScript>().canPauseOpen = false;
            rhinoNotification.SetActive(true);
            controllable = false;
        }
        else if (isKilledByCrocodile == true && timesKilledByCrocodile == 1)
        {
            Time.timeScale = 0.0000001f;
            sceneMangerObject.transform.GetChild(0).gameObject.SetActive(false);
            sceneMangerObject.GetComponent<SceneManagerScript>().canPauseOpen = false;
            crocodileNotification.SetActive(true);
            controllable = false;
        }
        else if (isKilledByLava == true && timesKilledByLava == 1)
        {
            Time.timeScale = 0.0000001f;
            sceneMangerObject.transform.GetChild(0).gameObject.SetActive(false);
            sceneMangerObject.GetComponent<SceneManagerScript>().canPauseOpen = false;
            lavaNotification.SetActive(true);
            controllable = false;
        }
        else if (isKilledBySwingingAxe == true && timesKilledBySwingingAxe == 1)
        {
            Time.timeScale = 0.0000001f;
            sceneMangerObject.transform.GetChild(0).gameObject.SetActive(false);
            sceneMangerObject.GetComponent<SceneManagerScript>().canPauseOpen = false;
            swingingAxeNotification.SetActive(true);
            controllable = false;
        }
        else if (isKilledByGrassSpikes == true && timesKilledByGrassSpikes == 1)
        {
            Time.timeScale = 0.0000001f;
            sceneMangerObject.transform.GetChild(0).gameObject.SetActive(false);
            sceneMangerObject.GetComponent<SceneManagerScript>().canPauseOpen = false;
            grassSpikesNotification.SetActive(true);
            controllable = false;
        }
        else if (isKilledByFallingLog == true && timesKilledByFallingLog == 1)
        {
            Time.timeScale = 0.0000001f;
            sceneMangerObject.transform.GetChild(0).gameObject.SetActive(false);
            sceneMangerObject.GetComponent<SceneManagerScript>().canPauseOpen = false;
            fallingLogNotification.SetActive(true);
            controllable = false;
        }
        else if (isKilledByBearTrap == true && timesKilledByBearTrap == 1)
        {
            Time.timeScale = 0.0000001f;
            sceneMangerObject.transform.GetChild(0).gameObject.SetActive(false);
            sceneMangerObject.GetComponent<SceneManagerScript>().canPauseOpen = false;
            bearTrapNotification.SetActive(true);
            controllable = false;
        }
        else if (isKilledBySawBlade == true && timesKilledBySawBlade == 1)
        {
            Time.timeScale = 0.0000001f;
            sceneMangerObject.transform.GetChild(0).gameObject.SetActive(false);
            sceneMangerObject.GetComponent<SceneManagerScript>().canPauseOpen = false;
            sawBladeNotification.SetActive(true);
            controllable = false;
        }
        CanDie = false;
        moveDirection = Vector3.zero;
        PlaySound(0);
        IsAlive = false;
        mashCount = 0;
        numOfDeaths++;
        Invoke("Respawn", deathWait);
        sliding = false;
        timer.ResetTime(true);
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
    }

    public void MakeMeMortal()
    {
        if (!canDie)
            canDie = true;
    }

    public void MakeMeAGod()
    {
        if (canDie)
            canDie = false;
    }

    void PlaySound(int _clip)
    {
        _audio.clip = audioClip[_clip];
        _audio.Play();
    }

    IEnumerator LevitateTime()
    {
        levitateTimer = 0.0f;
        levitateParticle.Play();
        while (levitateTimer <= maxLevitateTime)
        {
            levitateTimer += Time.deltaTime * (1 / Time.timeScale);
            yield return null;
        }
        levitateParticle.Stop();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        canLevitate = false;
    }

    public void ResetTransform()
    {
        if(!transform.parent)
        {
            if (Mathf.Abs(transform.position.z - initZ) > 0.001f)
                ResetZAxis();

            if (Vector3.SqrMagnitude(transform.localScale - scale) > 0.001f)
                ResetScale();
        }
    }

    void ResetZAxis()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, initZ);
    }

    void ResetScale()
    {
        transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
    }

    public void SpeedUp()
    {
        speed = speedFast;
    }

    public void SpeedUpIndefinetly()
    {
        speedSlow = speed;
        speed = speed * 2;
        speedOriginal = speed;
        speedFast = speed * 2;
    }

    public void SlowDown()
    {
        speed = speedSlow;
    }

    public void SameSpeed()
    {
        speed = speedOriginal;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public void Spring(float multiplier)
    {
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        moveDirection.y = maxJumpVelocity * multiplier;
        canLevitate = true;
        canJump = false;
    }

    public float GetPlayerSpeed()
    {
        return speed;
    }

    public void SetPlayerSpeed(float _newSpeed)
    {
        speed = _newSpeed;
    }

    public bool PlayerTrapped()
    {
        return (mashCount >= 6);
    }

    public float GetGravity()
    {
        return gravity;
    }

    public void SetGravity(float _gravity)
    {
        gravity = _gravity;
    }

    public bool IsPlayerGrounded()
    {
        return isGrounded;
    }

    public float localTimeScale()
    {
        return localTimeScaleTime;
    }

    public void setLocalTimeScale(float _timeScale)
    {
        Time.timeScale = _timeScale;
    }

    public void ResetMashCount()
    {
        mashCount = 0;
    }
}