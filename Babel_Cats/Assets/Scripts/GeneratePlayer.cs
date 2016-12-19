using UnityEngine;
using System.Collections;
using InControl;

public class GeneratePlayer : MonoBehaviour
{
    private CharacterHandlingController[] _players;

    private float _gapBetween;

    private int _nbDeviceConnected;

    public GameObject[] _characterPrefabs = new GameObject[4];
    public GameObject _gameManager;

    public MyCharacterActions[] _characterActions;
    public CharacterClass[] _characterClass;

    void Start ()
    {
        _gameManager = GameObject.Find("GameManager");
        _nbDeviceConnected = _gameManager.GetComponent<GameSceneManager>()._nbPlayerAvailable;
        _players = new CharacterHandlingController[_nbDeviceConnected];
        if (_nbDeviceConnected != 0)
            _gapBetween = 18f / (_nbDeviceConnected - 1);
        else
            _gapBetween = 0;
        Debug.Log("NbDevice : " + _nbDeviceConnected);

        _characterActions = new MyCharacterActions[_nbDeviceConnected];
        _characterClass = new CharacterClass[_nbDeviceConnected];
        createCharacters();
    }
	
	void Update ()
    {
	}

    public void createCharacters()
    {
        GameObject[] go = new GameObject[4];

        for (int i = 0; i < _nbDeviceConnected; i++)
        {
            go[i] = Instantiate(_characterPrefabs[i]) as GameObject;

            _players[i] = go[i].GetComponent<CharacterHandlingController>();

            _players[i].GetComponent<SpriteRenderer>().sprite = _gameManager.GetComponent<GameSceneManager>()._characterSprite[i];
            _players[i].gameObject.transform.FindChild("Weapon").GetComponent<SpriteRenderer>().sprite = _gameManager.GetComponent<GameSceneManager>()._catsWeaponSprite[i];

            _characterClass[i] = new CharacterClass(_gameManager.GetComponent<GameSceneManager>()._charactersClass[i]);
            _players[i]._charactersClass = new CharacterClass(_characterClass[i]);

            if (i != 0)
                _players[i].transform.position = new Vector3(_players[i - 1].transform.position.x + _gapBetween,
                    _players[i - 1].transform.position.y,
                    _players[i - 1].transform.position.z);
            _characterActions[i] = new MyCharacterActions(_gameManager.GetComponent<GameSceneManager>()._characterActions[i]);
            _players[i]._characterActions = new MyCharacterActions(_characterActions[i]);
            _players[i]._isControllerAttach = true;
            //            RuntimeAnimatorController animController = Resources.Load("Animation/KimonoCat/KimonoCatController") as RuntimeAnimatorController;
            //            _players[i].GetComponent<Animator>().runtimeAnimatorController = animController;
            _players[i].GetComponent<Animator>().runtimeAnimatorController = _gameManager.GetComponent<GameSceneManager>()._characterAnimationController[i];
        }
    }
}
