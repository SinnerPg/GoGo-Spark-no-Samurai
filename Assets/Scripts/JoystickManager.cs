using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    public PlayerManager player;
    public Joystick joystick;
    private bool stop;

    void Update()
    {
        var input = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
        {
            player.move();
        }
    }
}