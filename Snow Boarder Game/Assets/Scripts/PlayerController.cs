using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Flt_torqueAmount = 1f;
    [SerializeField] float Flt_boostSpeed = 30f;
    [SerializeField] float Flt_baseSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool bol_canMove = true;

    // Start is called before the first frame update
    void Start()
    {
      rb2d = GetComponent<Rigidbody2D>();
      surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bol_canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        bol_canMove = false;
    } 

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = Flt_boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = Flt_baseSpeed;
        }
       
    }

    void RotatePlayer()
    { 
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(Flt_torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-Flt_torqueAmount);
        }
    }
}
