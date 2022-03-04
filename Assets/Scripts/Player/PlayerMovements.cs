using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float leftRightSpeed = 3f;
    [SerializeField] private Rigidbody rb;
    void Update()
    {
        MoveForward();
        rd();
      //  RightLeftMovement();
       // RightAndLeftMovement();
    }

    private void rd()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < Screen.width / 2 )
                {
                    Left();
                    //transform.position = new Vector3.Lerp(transform.position.x - 1f, transform.position.y);

                }
                if (touch.position.x > Screen.width / 2)
                {
                    Right();
                    //transform.position = new Vector3.Lerp(transform.position.x - 1f, transform.position.y);

                }
            }
        }

    }

    private void Left()
    {
        rb.velocity = new Vector2(-speed, 0);
    }


    private void Right()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    private void RightLeftMovement()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                if(touch.position.x < Screen.width / 2  && transform.position.x > -2.67f)
                {
                    //transform.position = new Vector3.Lerp(transform.position.x - 1f, transform.position.y);

                }
            }
        }
    }
    private void RightAndLeftMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
        }
    }
    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
    }
}
