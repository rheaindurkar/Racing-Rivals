using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortoise : MonoBehaviour
{
    public float speed = 2.0f;
    
    //public float forwardInput;
    //Vector2 Vec;

    // Start is called before the first frame update
    void Start()
    {
        
    }
void Update()
    { 
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector2.right * Time.deltaTime * speed);
        }}
public void SpeedBoost(float multiplier)
    {
        speed *= multiplier;
    }
    
    public void ResetSpeed()
    {
        speed = 2.0f; 
    }
}
