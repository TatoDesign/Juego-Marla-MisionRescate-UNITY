using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using Photon.Pun;
=======
using UnityEngine.Rendering;
>>>>>>> Stashed changes

public class Player : MonoBehaviourPunCallbacks
{
    Rigidbody rb;

    [Space]
    [Header("Configuracion de Movimiento")]
    [SerializeField] private float speed;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float LookClamp;

    [Header("Variables locales")]
    private float xRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

<<<<<<< Updated upstream
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
=======
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -LookClamp, LookClamp);
>>>>>>> Stashed changes

            Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        }
    }
}