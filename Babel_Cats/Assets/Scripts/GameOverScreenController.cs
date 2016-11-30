using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using InControl;

public class GameOverScreenController : MonoBehaviour
{
    private float _cooldownGameOverMenu;

    private InputDevice _device;
    private GameObject _inputControlObject;
    private GameObject _gameManagerObject;
    private GameObject _backgroundMusicObject;

    void Start()
    {
        _cooldownGameOverMenu = 3;

        _device = InputManager.ActiveDevice;
        _inputControlObject = GameObject.Find("InControl");
        _gameManagerObject = GameObject.Find("GameManager");
        _backgroundMusicObject = GameObject.Find("BackgroundMusic");
        _inputControlObject.GetComponent<InControlManager>().dontDestroyOnLoad = false;
        gameObject.transform.GetChild(1).GetComponent<Text>().text = GameObject.Find("GameManager").GetComponent<GameSceneManager>()._winnerName;
    }

    void Update()
    {
        if (_cooldownGameOverMenu < 0)
        {
            if (_device.AnyButton || _device.MenuWasPressed)
            {
                Destroy(_inputControlObject);
                Destroy(_gameManagerObject);
                Destroy(_backgroundMusicObject);
                SceneManager.LoadScene("SplashScene");
            }
        }
        else
        {
            if (_cooldownGameOverMenu > 0)
                _cooldownGameOverMenu -= Time.deltaTime;
        }
    }
}
