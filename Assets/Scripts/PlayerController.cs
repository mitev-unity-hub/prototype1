using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private float speed;
    [SerializeField] private float rpm;

    private Rigidbody playerRb;

    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
        
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f); //3.6 for kph
        rpm = Mathf.Round((speed % 30) * 40);

        speedometerText.SetText("Speed: " + speed + "mph");
        rpmText.SetText("RPM: " + rpm);

        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
