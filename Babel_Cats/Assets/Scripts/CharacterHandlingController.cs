using UnityEngine;
using System.Collections;
using InControl;

[RequireComponent(typeof(CharacterActionControl))]
public class CharacterHandlingController : MonoBehaviour
{
    private enum ClassCharacter { JudoBoy = 0, Ninja = 1, Wizard = 2, Punk = 3}

    private ClassCharacter _currentClassCharacter;

    private bool _isPaused;
    public MyCharacterActions _characterActions;
    private CharacterActionControl _character;

    public bool _isControllerAttach;

    private HitByPlayer _hitByPlayer;

    private bool _jump;
    private bool _dash;
    public bool _attack;
    public float _cooldownAttack;

    private void Awake()
    {
        _cooldownAttack = 1.5f;
        _hitByPlayer = GetComponent<HitByPlayer>();

        _character = GetComponent<CharacterActionControl>();
        _jump = false;
        _dash = false;
        _attack = false;
        _isPaused = false;
    }

    void Update()
    {
        controllerControls();

        if (_cooldownAttack < 0)
        {
            _cooldownAttack = 1.5f;
            _attack = false;
            if (transform.GetChild(2).GetComponent<UseWeapon>()._isWeaponAttach)
                transform.GetChild(2).GetComponent<UseWeapon>().GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            if (_cooldownAttack > 0)
                _cooldownAttack -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (_isControllerAttach)
        {
            if (!_hitByPlayer._isStunt)
                _character.moveCharacter(_characterActions._moveAction.value(), _jump, _dash);
            _jump = false;
            _dash = false;
        }
    }

/*    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (_attack && _cooldownAttack > 0)
                coll.gameObject.GetComponent<HitByPlayer>().hasBeenHit();
        }
    }*/

    public void changeControl(bool isControllerMapping, InputDevice newController, MyCharacterActions newCharacterActions)
    {
        _characterActions = new MyCharacterActions(newCharacterActions);
        _isControllerAttach = true;
    }

    public void attachWeaponToCharacter()
    {
        gameObject.transform.FindChild("Weapon").gameObject.SetActive(true);
        //        gameObject.GetComponent<SpriteRenderer>().sprite = newWeapon;
    }

    private void controllerControls()
    {
        if (_isControllerAttach)
        {
            if (_characterActions._menuAction.wasPressed()) // pause the game
            {
/*                _isPaused = !_isPaused;
                Time.timeScale = _isPaused ? 0.0f : 1.0f;*/
            }

            if (_characterActions._jumpAction.wasPressed())
            {
                _jump = true;
//                Debug.Log("Jump InputHandler");
            }

            if (_characterActions._dashAction.wasPressed())
            {
                _dash = true;
  //              Debug.Log("Dash InputHandler");
            }

            if (_characterActions._attackAction.wasPressed())
            {
                _attack = true;
                if (transform.GetChild(2).GetComponent<UseWeapon>()._isWeaponAttach)
                    transform.GetChild(2).GetComponent<UseWeapon>().GetComponent<Collider2D>().enabled = true;
                //            Debug.Log("Attack InputHandler");
            }

            if (_characterActions._specialAction.wasPressed())
            {
      //          Debug.Log("Special InputHandler");
            }

            if (_characterActions._grabDropItemAction.wasPressed())
            {
        //        Debug.Log("grabDropItemControl InputHandler");
            }

            if (_characterActions._grabPlayerAction.wasPressed())
            {
          //      Debug.Log("grabPlayerControl InputHandler");
            }

            if (_characterActions._tauntAction.wasPressed())
            {
            //    Debug.Log("tauntControl InputHandler");
            }

            if (_characterActions._staminaRecoveryAction.wasPressed())
            {
              //  Debug.Log("staminaRecoveryControl InputHandler");
            }

            if (_characterActions._shieldAction.wasPressed())
            {
                //Debug.Log("shieldControl InputHandler");
            }
        }
    }
}
