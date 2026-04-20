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
    public GameObject endingPanel1;
    public GameObject endingPanel2;
    public GameObject endingPanel3;

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
            if (enteredPassword == password1)
            {
                keypadDisplay.text = "Correct Password";
                endingPanel1.SetActive(true);
                this.gameObject.SetActive(false);
            }
            else if (enteredPassword == password2)
            {
                keypadDisplay.text = "Correct Password";
                endingPanel2.SetActive(true);
                this.gameObject.SetActive(false);
            }
            else if (enteredPassword == password3)
            {
                keypadDisplay.text = "Correct Password";
                endingPanel3.SetActive(true);
                this.gameObject.SetActive(false);
            }
            else
            {
                keypadDisplay.text = "Wrong Password";
                enteredPassword = "";
            }
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
