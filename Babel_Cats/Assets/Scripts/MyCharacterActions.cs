using System.Collections;
using InControl;

public class MyCharacterActions
{
    public PlayerAction _leftAction;
    public PlayerAction _rightAction;
    public PlayerAction _moveAction;

    public PlayerAction _jumpAction;
    public PlayerAction _dashAction;
    public PlayerAction _attackAction;
    public PlayerAction _specialAction;

    public PlayerAction _staminaRecoveryAction;
    public PlayerAction _tauntAction;

    public PlayerAction _grabDropItemAction;
    public PlayerAction _grabPlayerAction;
    public PlayerAction _shieldAction;

    public PlayerAction _menuAction;

    public InputDevice _controller;
    public int _nbDevice;
    public bool _controllerMapping;

    public MyCharacterActions(InputDevice inputController, bool newControllerMapping, int nbDevice = 0)
    {
        _controllerMapping = newControllerMapping;
        _controller = inputController;
        _nbDevice = nbDevice;

        if (_controllerMapping)
        {
            _leftAction = new PlayerAction(_controller.DPadLeft, _controllerMapping);
            _rightAction = new PlayerAction(_controller.DPadRight, _controllerMapping);
            _moveAction = new PlayerAction(_controller.LeftStickX, _controllerMapping);

            _jumpAction = new PlayerAction(_controller.Action1, _controllerMapping);
            _dashAction = new PlayerAction(_controller.Action2, _controllerMapping);
            _attackAction = new PlayerAction(_controller.Action3, _controllerMapping);
            _specialAction = new PlayerAction(_controller.Action4, _controllerMapping);

            _staminaRecoveryAction = new PlayerAction(_controller.RightStickButton, _controllerMapping);
            _tauntAction = new PlayerAction(_controller.DPadDown, _controllerMapping);

            _grabDropItemAction = new PlayerAction(_controller.RightBumper, _controllerMapping);
            _grabPlayerAction = new PlayerAction(_controller.LeftBumper, _controllerMapping);
            _shieldAction = new PlayerAction(_controller.LeftTrigger, _controllerMapping);

            _menuAction = new PlayerAction(_controller.LeftStickX, _controllerMapping);
        }
        else
        {
            _leftAction = new PlayerAction("left", _controllerMapping);
            _rightAction = new PlayerAction("right", _controllerMapping);
            _moveAction = new PlayerAction("Horizontal", _controllerMapping);

            _jumpAction = new PlayerAction("space", _controllerMapping);
            _dashAction = new PlayerAction("d", _controllerMapping);
            _attackAction = new PlayerAction("q", _controllerMapping);
            _specialAction = new PlayerAction("s", _controllerMapping);

            _staminaRecoveryAction = new PlayerAction("r", _controllerMapping);
            _tauntAction = new PlayerAction("t", _controllerMapping);

            _grabDropItemAction = new PlayerAction("f", _controllerMapping);
            _grabPlayerAction = new PlayerAction("g", _controllerMapping);
            _shieldAction = new PlayerAction("left alt", _controllerMapping);

            _menuAction = new PlayerAction("left", _controllerMapping);
        }
    }

    public MyCharacterActions(MyCharacterActions oldCharacterActions) // copy constructor
    {
        _controllerMapping = oldCharacterActions._controllerMapping;
        _controller = oldCharacterActions._controller;
        _nbDevice = oldCharacterActions._nbDevice;

        _leftAction = new PlayerAction(oldCharacterActions._leftAction);
        _rightAction = new PlayerAction(oldCharacterActions._rightAction);
        _moveAction = new PlayerAction(oldCharacterActions._moveAction);

        _jumpAction = new PlayerAction(oldCharacterActions._jumpAction);
        _dashAction = new PlayerAction(oldCharacterActions._dashAction);
        _attackAction = new PlayerAction(oldCharacterActions._attackAction);
        _specialAction = new PlayerAction(oldCharacterActions._specialAction);

        _staminaRecoveryAction = new PlayerAction(oldCharacterActions._staminaRecoveryAction);
        _tauntAction = new PlayerAction(oldCharacterActions._tauntAction);

        _grabDropItemAction = new PlayerAction(oldCharacterActions._grabDropItemAction);
        _grabPlayerAction = new PlayerAction(oldCharacterActions._grabPlayerAction);
        _shieldAction = new PlayerAction(oldCharacterActions._shieldAction);

        _menuAction = new PlayerAction(oldCharacterActions._menuAction);
    }


    public void changeInput(InputDevice inputController, bool newControllerMapping, int nbDevice = 0)
    {
        _controllerMapping = newControllerMapping;
        _controller = inputController;
        _nbDevice = nbDevice;

        if (_controllerMapping)
        {
            _leftAction = new PlayerAction(_controller.DPadLeft, _controllerMapping);
            _rightAction = new PlayerAction(_controller.DPadRight, _controllerMapping);
            _moveAction = new PlayerAction(_controller.LeftStickX, _controllerMapping);

            _jumpAction = new PlayerAction(_controller.Action1, _controllerMapping);
            _dashAction = new PlayerAction(_controller.Action2, _controllerMapping);
            _attackAction = new PlayerAction(_controller.Action3, _controllerMapping);
            _specialAction = new PlayerAction(_controller.Action4, _controllerMapping);

            _staminaRecoveryAction = new PlayerAction(_controller.RightStickButton, _controllerMapping);
            _tauntAction = new PlayerAction(_controller.DPadDown, _controllerMapping);

            _grabDropItemAction = new PlayerAction(_controller.RightBumper, _controllerMapping);
            _grabPlayerAction = new PlayerAction(_controller.LeftBumper, _controllerMapping);
            _shieldAction = new PlayerAction(_controller.LeftTrigger, _controllerMapping);

            _menuAction = new PlayerAction(_controller.LeftStickX, _controllerMapping);
        }
        else
        {
            _leftAction = new PlayerAction("left", _controllerMapping);
            _rightAction = new PlayerAction("right", _controllerMapping);
            _moveAction = new PlayerAction("Horizontal", _controllerMapping);

            _jumpAction = new PlayerAction("space", _controllerMapping);
            _dashAction = new PlayerAction("d", _controllerMapping);
            _attackAction = new PlayerAction("q", _controllerMapping);
            _specialAction = new PlayerAction("s", _controllerMapping);

            _staminaRecoveryAction = new PlayerAction("r", _controllerMapping);
            _tauntAction = new PlayerAction("t", _controllerMapping);

            _grabDropItemAction = new PlayerAction("f", _controllerMapping);
            _grabPlayerAction = new PlayerAction("g", _controllerMapping);
            _shieldAction = new PlayerAction("left alt", _controllerMapping);

            _menuAction = new PlayerAction("left", _controllerMapping);
        }
    }
}
