using UnityEngine;
using System.Collections;

public class GameSceneManager : MonoBehaviour {

    public int _nbPlayerAvailable;
    public MyCharacterActions[] _characterActions;
    public Sprite[] _characterSprite;
    public RuntimeAnimatorController[] _characterAnimationController;
    public string _winnerName;

    void Start ()
    {
        GameSceneManager.DontDestroyOnLoad(gameObject);
        _nbPlayerAvailable = 0;
        _characterActions = new MyCharacterActions[4];
        _characterSprite = new Sprite[4];
        _characterAnimationController = new RuntimeAnimatorController[4];
    }

    void Update()
    {
    }
}
