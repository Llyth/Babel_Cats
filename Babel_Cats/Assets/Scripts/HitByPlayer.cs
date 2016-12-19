using UnityEngine;
using System.Collections;

public class HitByPlayer : MonoBehaviour
{
    public bool _isHit;
    public bool _isStunt;
    public bool _isDead;

    private float _cooldownHit;
    private float _cooldownStunt;

    private Color _defaultColor;

    public AudioClip[] _catSounds;

    void Awake()
    {
        _isHit = false;
        _isStunt = false;
        _isDead = false;

        _cooldownHit = 1;
        _cooldownStunt = 2;

        _defaultColor = gameObject.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        if (gameObject.GetComponent<CharacterHandlingController>()._isControllerAttach)
        {
            if (_isHit)
            {
                if (_cooldownHit < 0)
                {
                    _cooldownHit = 1;
                    gameObject.GetComponent<Renderer>().material.color = _defaultColor;
                    _isHit = false;
                }
                else
                    _cooldownHit -= Time.deltaTime;
            }

            if (_isStunt)
            {
                if (_cooldownStunt < 0)
                {
                    _cooldownStunt = 2;
                    gameObject.GetComponent<Renderer>().material.color = _defaultColor;
                    _isStunt = false;
                    gameObject.GetComponent<CharacterHandlingController>()._charactersClass.Stamina = gameObject.GetComponent<CharacterHandlingController>()._charactersClass.MaxStamina;
                }
                else
                    _cooldownStunt -= Time.deltaTime;
            }
        }
    }

    public bool hasBeenHit()
    {
        if (_isHit != true && gameObject.GetComponent<CharacterHandlingController>()._charactersClass.Stamina > 0) // the player is hit
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
//            gameObject.GetComponent<AudioSource>().clip = _catSounds[0];
            gameObject.GetComponent<AudioSource>().Play();
            _isHit = true;
            gameObject.GetComponent<CharacterHandlingController>()._charactersClass.Stamina--;
            return (true);
        }

        if (_isHit != true && gameObject.GetComponent<CharacterHandlingController>()._charactersClass.Stamina == 0 && !_isStunt) // the player is stunt
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            gameObject.GetComponent<AudioSource>().Play();
            _isStunt = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            return (true);
        }
        return (false);
    }
}
