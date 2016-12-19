using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour
{
    private InputDevice [] _devices;
    private int _nbDeviceConnected;

    // slotPlayer variables
    Text _textPlayerReady;
    GameObject _characterSelectionObject;
    public Sprite[] _catsSprite = new Sprite[4];
    public Sprite[] _catsWeaponSprite = new Sprite[4];
    public Sprite[] _hudSprite = new Sprite[2];
    public RuntimeAnimatorController[] _characterAnimationController = new RuntimeAnimatorController[2];

    private SlotPlayer[] _slotPlayer;

    GameObject _gameManager;

    void Start ()
    {
        _nbDeviceConnected = InputManager.Devices.Count;
        _devices = new InputDevice[_nbDeviceConnected];
        _slotPlayer = new SlotPlayer[4];
        _gameManager = GameObject.Find("GameManager");

        for (int i = 0; i < 4; i++)
        {
            if (i < _nbDeviceConnected)
            {
                _textPlayerReady =  GameObject.Find("Player" + (i + 1) + "Status").GetComponent<Text>();

                _characterSelectionObject = GameObject.Find("Player" + (i + 1) + "CharacterSelection");
                _characterSelectionObject.GetComponent<Image>().sprite = _hudSprite[0];

                _devices[i] = InputManager.Devices[i];
                _slotPlayer[i] = new SlotPlayer(i + 1, _textPlayerReady, _characterSelectionObject, _catsSprite, _hudSprite, _characterAnimationController);
                _slotPlayer[i]._characterActions = new MyCharacterActions(_devices[i], true, i);
                _slotPlayer[i]._isControllerAttach = true;
            }
            else
            {
                _textPlayerReady = GameObject.Find("Player" + (i + 1) + "Status").GetComponent<Text>();

                _characterSelectionObject = GameObject.Find("Player" + (i + 1) + "CharacterSelection");
                _characterSelectionObject.GetComponent<Image>().sprite = _hudSprite[0];

                _slotPlayer[i] = new SlotPlayer(i + 1, _textPlayerReady, _characterSelectionObject, _catsSprite, _hudSprite, _characterAnimationController);
/*                if (i == 1)
                {
                    _slotPlayer[i]._characterActions = new MyCharacterActions(null, false);
                    _slotPlayer[i]._isControllerAttach = true;
                }
                else*/
                _slotPlayer[i]._characterActions = null;
            }
        }
    }
	
	void Update ()
    {
        for (int i = 0; i < 4; i++)
        {
            if (_slotPlayer[i].openSlotPlayer() == false)
            {
                _slotPlayer[i].setSlotPlayerReady();
            }
            _slotPlayer[i].closeSlotPlayer();
            _slotPlayer[i].changeCharacterSelection();
        }

        if (checkPlayerReady() != 0 && countOpenSlotPlayer() == 0)
            startTheGame();
    }

    public int countOpenSlotPlayer()
    {
        int nbSlotPlayer = 0;

        for (int i = 0; i < 4; i++)
        {
            if (_slotPlayer[i]._isPlayerOnSelection == true)
                nbSlotPlayer++;
        }
        return (nbSlotPlayer);
    }

    public int checkPlayerReady()
    {
        int countPlayerReady = 0;

        for (int i = 0; i < 4; i++)
        {
            if (_slotPlayer[i]._isPlayerReady == true)
                countPlayerReady++;
        }
        return (countPlayerReady);
    }

    void startTheGame()
    {
        int y = 0;

        for (int i = 0; i < 4; i++)
        {
            if (_slotPlayer[i]._isControllerAttach == true && _slotPlayer[i]._isPlayerReady == true)
            {
                _gameManager.GetComponent<GameSceneManager>()._nbPlayerAvailable++;
                _gameManager.GetComponent<GameSceneManager>()._characterActions[y] = new MyCharacterActions(_slotPlayer[i]._characterActions);
                _gameManager.GetComponent<GameSceneManager>()._characterSprite[y] = _catsSprite[_slotPlayer[i]._characterSelectionIndex];
                _gameManager.GetComponent<GameSceneManager>()._catsWeaponSprite[y] = _catsWeaponSprite[_slotPlayer[i]._characterSelectionIndex];
                _gameManager.GetComponent<GameSceneManager>()._characterAnimationController[y] = _characterAnimationController[_slotPlayer[i]._characterSelectionIndex];
                _gameManager.GetComponent<GameSceneManager>()._charactersClass[y] = new CharacterClass(_slotPlayer[i]._characterSelectionIndex);
                y++;
            }
        }
        SceneManager.LoadScene("MainScene");
    }
}
