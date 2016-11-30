using UnityEngine;
using UnityEngine.UI;

public class SlotPlayer
{
    public int _id;

    public MyCharacterActions _characterActions;

    public bool _isControllerAttach;

    public Text _textPlayerReady;
    public GameObject _characterSelectionObject;

    public Sprite[] _catsSprite = new Sprite[4];
    public Sprite[] _hudSprite = new Sprite[2];

    public Sprite _catsSpriteTmp;

    public RuntimeAnimatorController[] _characterAnimationController = new RuntimeAnimatorController[2];

    public bool _isPlayerOnSelection;
    public bool _isPlayerReady;
    public int _characterSelectionIndex;

    public SlotPlayer(int newId,
        Text newTextPlayerReady,
        GameObject newCharacterSelectionObject,
        Sprite[] newCatsSprite,
        Sprite[] newHudSprite,
        RuntimeAnimatorController[] newCharacterAnimationController)
    {
        _id = newId;

        _isControllerAttach = false;

        _textPlayerReady = newTextPlayerReady;
        _characterSelectionObject = newCharacterSelectionObject;
        _catsSprite = newCatsSprite;
        _hudSprite = newHudSprite;
        _characterAnimationController = newCharacterAnimationController;

        _isPlayerOnSelection = false;
        _isPlayerReady = false;
        _characterSelectionIndex = 0;

/*        _characterSelectionObject.GetComponent<Animator>().runtimeAnimatorController = _characterAnimationController[_characterSelectionIndex];
        _characterSelectionObject.GetComponent<Animator>().SetBool("Ground", true);
        _characterSelectionObject.GetComponent<Animator>().Play("KimonoCatIdle");*/
    }

    public bool openSlotPlayer()
    {
        if (_isControllerAttach && _isPlayerOnSelection == false)
        {
            if (_characterActions._jumpAction.wasPressed())
            {
                _textPlayerReady.text = "Player " + _id + " Character On Selection :";
                _isPlayerOnSelection = true;
                _characterSelectionObject.GetComponent<Image>().sprite = _catsSprite[_characterSelectionIndex];
                _characterSelectionObject.GetComponent<AudioSource>().Play();
                return (true);
            }
        }
        return (false);
    }

    public bool closeSlotPlayer()
    {
        if (_isControllerAttach)
        {
            if (_isPlayerOnSelection == true && _characterActions._dashAction.wasPressed())
            {
                _textPlayerReady.text = "Player " + _id + " Ready ?";
                _isPlayerOnSelection = false;
                _characterSelectionObject.GetComponent<Image>().sprite = _hudSprite[0];
                return (true);
            }
            else if (_isPlayerReady == true && _characterActions._dashAction.wasPressed())
            {
                _textPlayerReady.text = "Player " + _id + " Character On Selection :";
                _characterSelectionObject.GetComponent<Image>().sprite = _catsSpriteTmp;
                _isPlayerReady = false;
                _isPlayerOnSelection = true;
                return (true);
            }
        }
        return (false);
    }

    public bool setSlotPlayerReady()
    {
        if (_isControllerAttach && _isPlayerOnSelection == true)
        {
            if (_characterActions._jumpAction.wasPressed())
            {
                _textPlayerReady.text = "Player " + _id + " is Ready";
                _isPlayerReady = true;
                _isPlayerOnSelection = false;
                _catsSpriteTmp = _characterSelectionObject.GetComponent<Image>().sprite;
                _characterSelectionObject.GetComponent<Image>().sprite = _hudSprite[1];
                return (true);
            }
        }
        return (false);
    }

    public bool changeCharacterSelection()
    {
        if (_isControllerAttach && _isPlayerOnSelection)
        {
            if (_characterActions._leftAction.wasPressed())
            {
                if (_characterSelectionIndex > 0)
                    _characterSelectionIndex--;
                else
                    _characterSelectionIndex = 3;
                _characterSelectionObject.GetComponent<Image>().sprite = _catsSprite[_characterSelectionIndex];
/*               _characterSelectionObject.GetComponent<Animator>().runtimeAnimatorController = _characterAnimationController[_characterSelectionIndex];
                _characterSelectionObject.GetComponent<Animator>().SetBool("Ground", false);
                _characterSelectionObject.GetComponent<Animator>().Play("KimonoCatIdle");*/
                return (true);
            }

            if (_characterActions._rightAction.wasPressed())
            {
                if (_characterSelectionIndex < 3)
                    _characterSelectionIndex++;
                else
                    _characterSelectionIndex = 0;
                _characterSelectionObject.GetComponent<Image>().sprite = _catsSprite[_characterSelectionIndex];
/*               _characterSelectionObject.GetComponent<Animator>().runtimeAnimatorController = _characterAnimationController[_characterSelectionIndex];
                _characterSelectionObject.GetComponent<Animator>().SetBool("Ground", false);
                _characterSelectionObject.GetComponent<Animator>().Play("KimonoCatIdle");*/
                return (true);
            }
        }
        return (false);
    }
}
