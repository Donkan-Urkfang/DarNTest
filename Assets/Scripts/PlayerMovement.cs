using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Camera cameraPlayer;
    public float speed;
    public float mouseSensitivity = 2.0f;
    public bool onFloor;
    public bool weapon;
    public Animator animator;


    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    //Movimientos de Jugador
    private void Movement() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        rb.MovePosition(rb.position + move * speed * Time.deltaTime);

        //Saltar
        if (Input.GetKeyDown(KeyCode.Space) && onFloor) {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }

        //Correr
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = 5;
        } else {
            speed = 2;
        }
    }

    //Seguimiento de Camara
    private void CameraFollow(){
        Cursor.lockState = CursorLockMode.Locked;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - mouseY, transform.rotation.eulerAngles.y + mouseX, 0);

    }

    //Ataque
    private void Attack(){
        if (Input.GetMouseButtonDown(0) && weapon) {
            Debug.Log("Atacando");
            //animator.SetBool("Attack", true);
        } else {
            //animator.SetBool("Attack", false);
        }
    }

    //Raycast Jugador
    private void TakeWeapon() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2)) {
            if (hit.collider.gameObject.tag == "Weapon") {
                weapon = true;
                Destroy(hit.collider.gameObject);
            }
        }
    }


    /////////////////////////////////////////


    //Colisiones

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Floor")
            onFloor = true;
    }

    private void OnCollisionStay(Collision other) {
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Floor")
            onFloor = false;
    }

    /////////////////////////////////////////


    //Triggers

    private void OnTriggerEnter(Collider other) {
    }

    private void OnTriggerStay(Collider other) {   
    }

    private void OnTriggerExit(Collider other) {  
    }

    ///////////////////////////////////////////


    private void Update() {
        Movement();
        CameraFollow();
        Attack();
    }
}
