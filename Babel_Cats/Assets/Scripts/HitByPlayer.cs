using UnityEngine;
using System.Collections;

public class HitByPlayer : MonoBehaviour
{
    public int _stamina;

    public bool _isHit;
    public bool _isStunt;
    public bool _isDead;

    private float _cooldownHit;
    private float _cooldownStunt;

    private Color _defaultColor;

    void Awake()
    {
        _stamina = 2;

        _isHit = false;
        _isStunt = false;
        _isDead = false;

        _cooldownHit = 1;
        _cooldownStunt = 2;

        _defaultColor = gameObject.GetComponent<Renderer>().material.color;
    }

    void Update()
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
                _stamina = 2;
            }
            else
                _cooldownStunt -= Time.deltaTime;
        }
    }

    public bool hasBeenHit()
    {
        if (_isHit != true && _stamina > 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            gameObject.GetComponent<AudioSource>().Play();
            _isHit = true;
            _stamina--;
            return (true);
        }
        if (_isHit != true && _stamina == 0 && !_isStunt)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            gameObject.GetComponent<AudioSource>().Play();
            _isStunt = true;
//            GameObject.GetComponent<Rigidbody2D>().velocity.y = 0;
            return (true);
        }
        return (false);
    }
}
