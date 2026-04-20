using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 10F;
    public float sensitivityY = 10F;
    public float MaxVerticalRotaion = 45F;
    public float MinVerticalRotaion = -45F;

    float mouseX;
    float mouseY;
    float verticalRotation = 0F;

    void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            //just rotate around X axis
            // transform.Rotate(0, mouseX * sensitivityX * Time.deltaTime, 0);
            float yRotation = mouseX * sensitivityX * Time.deltaTime;
            transform.Rotate(0, yRotation, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            //just rotate around Y axis
            //verticalRotation -= mouseY * sensitivityY * Time.deltaTime;
            //verticalRotation = Mathf.Clamp(verticalRotation, MinVerticalRotaion, MaxVerticalRotaion);
            //float horizontalRotation = transform.localEulerAngles.y;
            //transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
            verticalRotation -= mouseY * sensitivityY * Time.deltaTime;
            verticalRotation = Mathf.Clamp(verticalRotation, MinVerticalRotaion, MaxVerticalRotaion);

            transform.localEulerAngles = new Vector3(verticalRotation, 0f, 0f);

        }
        else
        {
            //rotate around both X and Y axis
            verticalRotation -= mouseY * sensitivityY * Time.deltaTime;
            verticalRotation = Mathf.Clamp(verticalRotation, MinVerticalRotaion, MaxVerticalRotaion);

            float deltaRotation = mouseX * sensitivityX * Time.deltaTime;
            float horizontalRotation = transform.localEulerAngles.y + deltaRotation;
            transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
        }

    }
    public void LookValue(InputAction.CallbackContext ctx)
    {
        //Debug.Log(ctx.ReadValue<Vector2>());
        mouseX = ctx.ReadValue<Vector2>().x;
        mouseY = ctx.ReadValue<Vector2>().y;
    }


}
