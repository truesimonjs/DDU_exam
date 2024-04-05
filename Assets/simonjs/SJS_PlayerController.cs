using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SJS_PlayerController : MonoBehaviour
{
    //stats
    public float jumpPower;
    public float speed;
    public float mouseSens = 5;
    //references
    public Transform cam;
    //private Transform player;
    Rigidbody Rb;
    //
    
    private bool grounded;
    float camXRotation = 0;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * mouseSens, Space.Self);
        //move camera up and down 
        camXRotation += -mouseSens * Input.GetAxis("Mouse Y");
        camXRotation = Mathf.Clamp(camXRotation, -90, 90);
        cam.localRotation = Quaternion.Euler(camXRotation, cam.localEulerAngles.y, cam.localEulerAngles.z);
        //move wasd
        Vector3 movement = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")).normalized;
       
        transform.position += movement*Time.deltaTime*speed;

        if (Input.GetButtonDown("Jump"))
        {
            Rb.AddForce(Vector3.up*jumpPower, ForceMode.VelocityChange);
        }
    }
}
