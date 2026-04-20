using UnityEngine;
using UnityEngine.InputSystem;
    public class Clue : MonoBehaviour
    {
        public GameObject clueUI;

        public void OpenClue()
        {
            clueUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void CloseClue()
        {
            clueUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


