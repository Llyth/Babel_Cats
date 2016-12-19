using UnityEngine;
using System.Collections;

public class CharacterClass
{
    private enum CharacterClassNumber { JudoBoy = 0, Ninja = 1, Wizard = 2, Punk = 3 }

    private CharacterClassNumber _currentClassCharacter;
    private int _damageWeapon;
    private float _cooldownAttack;
    private int _durabilityWeapon;
    private int _stamina;

    private int _maxDurabilityWeapon;
    private float _maxCooldownAttack;
    private int _maxStamina;

    public CharacterClass(int classNumber)
    {
        setClass(classNumber);
    }

    public CharacterClass(CharacterClass oldCharacterClass) // copy constructor
    {
        _cooldownAttack = oldCharacterClass.CooldownAttack;
        _maxCooldownAttack = oldCharacterClass.MaxCooldownAttack;

        _damageWeapon = oldCharacterClass.DamageWeapon;

        _durabilityWeapon = oldCharacterClass.DurabilityWeapon;
        _maxDurabilityWeapon = oldCharacterClass.MaxDurabilityWeapon;

        _stamina = oldCharacterClass.Stamina;
        _maxStamina = oldCharacterClass.MaxStamina;
    }

    public void setClass(int classNumber)
    {
        if (classNumber == 0)
        {
            _currentClassCharacter = CharacterClassNumber.JudoBoy;

            _cooldownAttack = 1.5f;
            _maxCooldownAttack = 1.5f;

            _damageWeapon = 1;

            _durabilityWeapon = 0;
            _maxDurabilityWeapon = 5;

            _stamina = 2;
            _maxStamina = 2;
        }

        if (classNumber == 1)
        {
            _currentClassCharacter = CharacterClassNumber.Ninja;

            _cooldownAttack = 1.5f;
            _maxCooldownAttack = 1.5f;

            _damageWeapon = 1;

            _durabilityWeapon = 0;
            _maxDurabilityWeapon = 5;

            _stamina = 2;
            _maxStamina = 2;
        }

        if (classNumber == 2)
        {
            _currentClassCharacter = CharacterClassNumber.Wizard;

            _cooldownAttack = 1.5f;
            _maxCooldownAttack = 1.5f;

            _damageWeapon = 1;

            _durabilityWeapon = 0;
            _maxDurabilityWeapon = 5;

            _stamina = 2;
            _maxStamina = 2;
        }

        if (classNumber == 3)
        {
            _currentClassCharacter = CharacterClassNumber.Punk;

            _cooldownAttack = 1.5f;
            _maxCooldownAttack = 1.5f;

            _damageWeapon = 1;

            _durabilityWeapon = 0;
            _maxDurabilityWeapon = 5;

            _stamina = 2;
            _maxStamina = 2;
        }
    }

    private CharacterClassNumber CurrentClassCharacter
    {
        get
        {
            return _currentClassCharacter;
        }

        set
        {
            _currentClassCharacter = value;
        }
    }

    public float CooldownAttack
    {
        get
        {
            return _cooldownAttack;
        }

        set
        {
            _cooldownAttack = value;
        }
    }

    public int Stamina
    {
        get
        {
            return _stamina;
        }

        set
        {
            _stamina = value;
        }
    }

    public int DamageWeapon
    {
        get
        {
            return _damageWeapon;
        }

        set
        {
            _damageWeapon = value;
        }
    }

    public int DurabilityWeapon
    {
        get
        {
            return _durabilityWeapon;
        }

        set
        {
            _durabilityWeapon = value;
        }
    }

    public int MaxDurabilityWeapon
    {
        get
        {
            return _maxDurabilityWeapon;
        }

        set
        {
            _maxDurabilityWeapon = value;
        }
    }

    public int MaxStamina
    {
        get
        {
            return _maxStamina;
        }

        set
        {
            _maxStamina = value;
        }
    }

    public float MaxCooldownAttack
    {
        get
        {
            return _maxCooldownAttack;
        }

        set
        {
            _maxCooldownAttack = value;
        }
    }
}
