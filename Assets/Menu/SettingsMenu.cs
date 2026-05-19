using UnityEngine;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [Header("Input Fields")]
    public TMP_InputField forwardInput;
    public TMP_InputField backwardInput;
    public TMP_InputField leftInput;
    public TMP_InputField rightInput;
    public TMP_InputField jumpInput;
    public TMP_InputField sprintInput;
    public TMP_InputField crouchInput;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        // Listen for typing ONLY when field is focused
        if (forwardInput.isFocused)
            ListenKey("Forward", forwardInput);

        if (backwardInput.isFocused)
            ListenKey("Backward", backwardInput);

        if (leftInput.isFocused)
            ListenKey("Left", leftInput);

        if (rightInput.isFocused)
            ListenKey("Right", rightInput);

        if (jumpInput.isFocused)
            ListenKey("Jump", jumpInput);

        if (sprintInput.isFocused)
            ListenKey("Sprint", sprintInput);

        if (crouchInput.isFocused)
            ListenKey("Crouch", crouchInput);
    }

    void ListenKey(string action, TMP_InputField field)
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                InputManager.Instance.Rebind(action, key);
                field.text = key.ToString();
                field.DeactivateInputField();
            }
        }
    }

    void UpdateUI()
    {
        forwardInput.text = InputManager.Instance.GetBind("Forward").ToString();
        backwardInput.text = InputManager.Instance.GetBind("Backward").ToString();
        leftInput.text = InputManager.Instance.GetBind("Left").ToString();
        rightInput.text = InputManager.Instance.GetBind("Right").ToString();

        jumpInput.text = InputManager.Instance.GetBind("Jump").ToString();
        sprintInput.text = InputManager.Instance.GetBind("Sprint").ToString();
        crouchInput.text = InputManager.Instance.GetBind("Crouch").ToString();
    }
}