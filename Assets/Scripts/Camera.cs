using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float cameraSpeed = 10.0f;
    public float mouseSensitivity = 2.0f;
    private Vector3 cameraMovement;


    void Follow(){
        Cursor.lockState = CursorLockMode.Confined;
        //mover camara con mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - mouseY, transform.rotation.eulerAngles.y + mouseX, 0);
    }



    private void Update() {
        Follow();
    }
}
