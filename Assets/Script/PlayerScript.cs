using Unity.Content;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerScript : MonoBehaviour
{
    public float speed = 6f;
    CharacterController controller;
    float h, v;

    float velocity;

    public Clue currentClue;

    public GameObject popUp;
    public GameObject endPanel;
    public GameObject deathPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = h * speed;
        float moveZ = v * speed;
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        if (controller.isGrounded)
        {
            velocity = -1f; // small stick-to-ground force
        }
        else
        {
            velocity += -9.8f * Time.deltaTime;
        }

        movement.y = velocity;
        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        controller.Move(movement);
    }

    public void MoveInput(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();

        // Deadzone
        if (input.magnitude < 0.1f)
            input = Vector2.zero;

        h = input.x;
        v = input.y;
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && currentClue != null)
        {
            Debug.Log("clue");
            currentClue.OpenClue();
        }
    }

    public void list(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !popUp.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            popUp.SetActive(true);
        }
        else if (ctx.performed && popUp.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            popUp.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clue"))
        {
            currentClue = other.GetComponent<Clue>();
        }
        if (other.CompareTag("Collect"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("EndDoor"))
        {
            endPanel.SetActive(true);
        }
        if (other.CompareTag("BadDoor"))
        { 
            deathPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Clue"))
        {
            if (currentClue == other.GetComponent<Clue>())
            {
                currentClue = null;
            }
        }
    }


}
