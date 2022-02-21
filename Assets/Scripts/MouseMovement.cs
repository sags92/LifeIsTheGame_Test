using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private float mouseSensitivity = 100;
    private float xRotation = 0f;
    public Transform playerBody;

    void Update()
    {
        UpdateMouseMovement();   
    }

    private void UpdateMouseMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
