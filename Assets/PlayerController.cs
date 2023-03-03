using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 inputVector;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        inputVector = Vector2.zero;
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("wychylenie kontrolera: " + inputVector.ToString());

        //metoda bez uzycia fizyki
        //Vector3 movement = new Vector3(0, 0, inputVector.y);
        //transform.Translate(movement);

    }
    private void FixedUpdate()
    {
        if(inputVector.y == 0)
        {
            //nie trzymamy wcisnietego w ani s
            rb.velocity = Vector3.zero;
        }
        else
        {
            //metoda z fizyka
            //wez kierunek do przodu wzgledem postaci i przemnoz przez wychylenie kontrolera
            Vector3 movement = transform.forward * inputVector.y;
            rb.AddForce(movement, ForceMode.Impulse);
        }
        if(inputVector.x == 0)
        {
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            Vector3 rotation = transform.up * inputVector.x;
            rb.AddTorque(rotation, ForceMode.Impulse);
        }
       

    }

    void OnMove(InputValue inputValue)
    {
        inputVector = inputValue.Get<Vector2>();

        
    }
}
