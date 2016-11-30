using UnityEngine;
using System.Collections;
using InControl;

public class PlayerAction
{
    bool _controllerMapping;
    InputControl _controllerAction;
    string _buttonKeyboardName;


    public PlayerAction(InputControl newControllerAction, bool newControllerMapping)
    {
        _controllerMapping = newControllerMapping;
        _controllerAction = newControllerAction;
        _buttonKeyboardName = "";
    }

    public PlayerAction(string newButtonKeyboardName, bool newControllerMapping)
    {
        _controllerMapping = newControllerMapping;
        _controllerAction = null;
        _buttonKeyboardName = newButtonKeyboardName;
    }

    public PlayerAction(PlayerAction oldPlayerAction)
    {
        _controllerMapping = oldPlayerAction._controllerMapping;
        _controllerAction = oldPlayerAction._controllerAction;
        _buttonKeyboardName = oldPlayerAction._buttonKeyboardName;
    }

    public bool wasPressed()
    {
        if (_controllerMapping)
            return (_controllerAction.WasPressed);
        else
            return (Input.GetKeyDown(_buttonKeyboardName));
    }

    public bool wasReleased()
    {
        if (_controllerMapping)
            return (_controllerAction.WasReleased);
        else
            return (Input.GetKeyUp(_buttonKeyboardName));
    }

    public float value()
    {
        if (_controllerMapping)
            return (_controllerAction.Value);
        else
            return (Input.GetAxis(_buttonKeyboardName));
    }
}
