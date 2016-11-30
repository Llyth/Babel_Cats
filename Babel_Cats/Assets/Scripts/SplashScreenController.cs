using UnityEngine;
using UnityEngine.SceneManagement;
using InControl;

public class SplashScreenController : MonoBehaviour
{
    private InputDevice _device;

    void Start()
    {
        _device = InputManager.ActiveDevice;
    }

    void Update()
    {
        if (_device.AnyButton || _device.MenuWasPressed)
            SceneManager.LoadScene("SelectPlayer");
    }
}
