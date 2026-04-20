using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class CodeScript : MonoBehaviour
{

    public string password1;
    public string password2;
    public string password3;
    public string enteredPassword;
    public TMP_Text keypadDisplay;
    public int passDigits;
    public Camera playerCamera;

    public GameObject player;
    public GameObject keypad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        passDigits = 4;
        keypadDisplay.text = "Enter Code";
      //  seed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enteredPassword.Length == passDigits)
        {
            if (enteredPassword == password1 || enteredPassword == password2 || enteredPassword == password3)
            {
                keypadDisplay.text = "Correct Password";
                this.gameObject.SetActive(false);
            }
            else
            {
                keypadDisplay.text = "Wrong Password";
                enteredPassword = "";
            }
        }

        if (enteredPassword == password1)
        {
            //open ending one
        }
        else if (enteredPassword == password2)
        {
            //open ending two
        }
        else if (enteredPassword == password3)
        {
            //open ending three
        }
    }

    public void ShowCursor(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void ButtonNumber(string btnNum)
    {
        EnterCode(btnNum);
    }

    private void EnterCode(string btnNum)
    {
        enteredPassword += btnNum;
        keypadDisplay.text = enteredPassword;
    }

}
