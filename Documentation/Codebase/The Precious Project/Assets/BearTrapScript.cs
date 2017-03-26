using UnityEngine;

public class BearTrapScript : MonoBehaviour
{

    public bool Activated;
    public bool IsTrapped;
    PlayerController _player;
    float _timer;
    [SerializeField]
    float _delay = 3.0f;

    MeshRenderer _textMeshRenderer;
    Color _textColor;
    TextMesh _textMesh;
    bool _showText = true;
    float _textBlinkTimer;

    AudioSource collidedSound;
    AudioSource escapedSound;
    
	// Use this for initialization
	void Start ()
	{
	    _timer = _delay;
	    Activated = true;
	    IsTrapped = false;
        GameObject textObject = transform.FindChild("Text").gameObject;
	    _textMeshRenderer = textObject.GetComponent<MeshRenderer>();
	    _textMesh = textObject.GetComponent<TextMesh>();
        _textColor = _textMesh.color;
        //GetComponent<MeshRenderer>().enabled = false;

        collidedSound = GameObject.Find("CollidedSoundSource").GetComponent<AudioSource>();
        escapedSound = GameObject.Find("EscapedSoundSource").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (!IsTrapped) return;

	    TimerForTrap();

	    if (!_player.PlayerTrapped()) return;
        escapedSound.Play();
        Activated = false;
	    IsTrapped = false;
	    _player.controllable = true;
	    _textMeshRenderer.enabled = false;
	    transform.GetComponent<Renderer>().material.color = Color.white;
        _player.ResetMashCount();
        //GetComponent<MeshRenderer>().enabled = false;
        if (!Activated)
	    {
	        transform.GetComponent<Renderer>().enabled = false;
            transform.FindChild("Left").rotation = Quaternion.Euler(180f, 90f, 0f);
            transform.FindChild("Right").rotation = Quaternion.Euler(180f, -90f, 0f);
            
        }
	    _timer = _delay;
	}

    void LateUpdate()
    {
        if (_player && !_player.IsAlive && !Activated)
        {
            Activated = true;
            transform.GetComponent<Renderer>().enabled = true;
            transform.FindChild("Left").rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.FindChild("Right").rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.GetComponent<Renderer>().material.color = Color.white;
        }
        
    }

    void TimerForTrap()
    {
        if (_timer > 0.0f)
        {
           _timer -= Time.deltaTime;
            ToggleTextVisibility();
        }

        else
        {
            _player.isKilledByBearTrap = true;
            _player.timesKilledByBearTrap++;
            _player.Die();
            _player.controllable = true;
            IsTrapped = false;
            _textMeshRenderer.enabled = false;
            _timer = _delay;
            Activated = false;
            transform.GetComponent<Renderer>().material.color = Color.white;
            GameObject global = GameObject.FindWithTag("Global");
            
            if (global)
                global.GetComponent<GetObjectsPosition>().Reset();
            //GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (Activated)
        {
            collidedSound.Play();
        }
        
        if (!Activated || !other.CompareTag("Player")) return;

        _player = other.GetComponent<PlayerController>();
        _player.controllable = false;

        IsTrapped = true;
        _textMeshRenderer.enabled = true;

        transform.FindChild("Left").rotation = Quaternion.Euler(0f, 0f, -50f);
        transform.FindChild("Right").rotation = Quaternion.Euler(0f, 0f, 50f);

        transform.GetComponent<Renderer>().material.color = Color.red;
    }

    void ToggleTextVisibility()
    {
        if (!_textMeshRenderer.enabled) return;

        if (_textBlinkTimer < 0.3f)
            _textBlinkTimer += Time.deltaTime;
        else
        {
            _textColor.a = _showText ? 255 : 0;
            _showText = !_showText;
            _textMesh.color = _textColor;
            _textBlinkTimer = 0;
        }
    }

}
