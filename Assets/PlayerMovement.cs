using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Camera playerCamera;
    public float speed = 12f;
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // View bobbing
        if (x != 0 || z != 0)
        {
            timer += bobbingSpeed * Time.deltaTime;
            float bobbingSin = Mathf.Sin(timer) * bobbingAmount;
            playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, bobbingSin, playerCamera.transform.localPosition.z);
        }
        else
        {
            // If not moving, reset the position to the original
            timer = 0f;
            playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, 0f, playerCamera.transform.localPosition.z);
        }
    }
}