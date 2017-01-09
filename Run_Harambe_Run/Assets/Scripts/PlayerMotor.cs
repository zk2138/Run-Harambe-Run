using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float lockLeft = -4.0f;
    private float lockRight = 4.0f;
    private Transform playerTransform;
    public AudioSource bonus;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerTransform = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        if (controller.isGrounded)
            verticalVelocity = 0.0f;
        else
            verticalVelocity -= 10.0f;
        moveVector.y = verticalVelocity;
        Vector3 playerPos = playerTransform.position;
        if (playerPos.x < lockLeft)
            moveVector = new Vector3(0.2f, 0, 0);
        if (playerPos.x > lockRight)
            moveVector = new Vector3(-0.2f, 0, 0);
        //Da se gorila ziblje sm in tja in lepse hodi
        controller.transform.localRotation = Quaternion.identity;
        controller.Move(moveVector * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bonus1" || other.tag == "Bonus")
        {
            bonus.Play();
        }
    }
}