using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private Dictionary<string, KeyCode> binds;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        binds = new Dictionary<string, KeyCode>();

        // ONLY set defaults ONCE
        binds["Forward"] = KeyCode.W;
        binds["Backward"] = KeyCode.S;
        binds["Left"] = KeyCode.A;
        binds["Right"] = KeyCode.D;

        binds["Jump"] = KeyCode.Space;
        binds["Sprint"] = KeyCode.LeftShift;
        binds["Crouch"] = KeyCode.LeftControl;
    }

    public bool GetKey(string action)
    {
        return Input.GetKey(binds[action]);
    }

    public bool GetKeyDown(string action)
    {
        return Input.GetKeyDown(binds[action]);
    }

    public KeyCode GetBind(string action)
    {
        return binds[action];
    }

    public void Rebind(string action, KeyCode newKey)
    {
        binds[action] = newKey;
        Debug.Log(action + " = " + newKey);
    }
}