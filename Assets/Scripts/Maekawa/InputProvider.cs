using UnityEngine;

public class InputProvider : IInput
{
    bool IInput.GetUp()
    {
        return Input.GetButtonDown("Up");
    }
    bool IInput.GetLeft()
    {
        return Input.GetButtonDown("Left");
    }
    bool IInput.GetRight()
    {
        return Input.GetButtonDown("Right");
    }
    bool IInput.GetDown()
    {
        return Input.GetButtonDown("Down");
    }

    bool IInput.GetAction()
    {
        return Input.GetButtonDown("Action");
    }

    bool IInput.GetAttack()
    {
        return Input.GetButtonDown("Attack");
    }
}
