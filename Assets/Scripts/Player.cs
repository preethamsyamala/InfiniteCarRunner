using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -5)
        {
            Vector3 newPosition = transform.position; // We store the current position
            newPosition.x += -5; // We set a axis, in this case the y axis
            transform.position = newPosition;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 5)
        {
            Vector3 newPosition = transform.position; // We store the current position
            newPosition.x += 5; // We set a axis, in this case the y axis
            transform.position = newPosition;
        }
    }
}
