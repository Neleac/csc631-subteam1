using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform camera;
    public float speed = 6.0f;
    private Vector3 originalPosition;
    bool topView;

    // variable for referencing the CharacterController
    private CharacterController charController;

    void Start()
    {
        // set original position to initial camera position
        originalPosition = camera.localPosition;

        // access other components attached to the same object
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // limit diagonal movement to the same speed as movement along an axis
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;

        // transform the movement vector from local to global coordinates
        movement = transform.TransformDirection(movement);

        // tell the CharacterController to move by that vector
        charController.Move(movement);

        transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);

        // if we press space key down (one frame)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (topView)
            {
                camera.eulerAngles = Vector3.zero; // set rotation to 0 on every axis
                camera.localPosition = originalPosition;
                topView = false;
            }
            else
            {
                // move camera up
                camera.localPosition = Vector3.up * 5f;

                // rotate camera down
                camera.eulerAngles = new Vector3(90f, 0, 0);
                topView = true;
            }
            

            
        }
    }
}
