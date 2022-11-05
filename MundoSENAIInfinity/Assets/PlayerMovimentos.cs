using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimentos : MonoBehaviour
{
    public float hSpeed;
    public float limiteH;
    public float forcaPulo;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movH = Input.GetAxisRaw("Horizontal");
        float movV = Input.GetAxisRaw("Vertical");

        playerRb.AddForce(Vector3.right * movH * hSpeed, ForceMode.Impulse);

        if (transform.position.x >= limiteH)
        {
            transform.position = new Vector3(limiteH, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= -limiteH){
            transform.position = new Vector3(-limiteH, transform.position.y, transform.position.z);
        }

        Pular();
    }

    public void Pular()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            playerRb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        }
    }
}
