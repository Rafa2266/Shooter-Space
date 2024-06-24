using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{

    private Rigidbody2D myRb;
    private float dirX,dirY;
    [SerializeField] float movSpeedX, movSpeedY;
    // Start is called before the first frame update
    void Start()
    {
        myRb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.acceleration.x * (movSpeedX * Time.deltaTime);
        dirY = Input.acceleration.y * (movSpeedY * Time.deltaTime);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), Mathf.Clamp(transform.position.y, -7.5f, 7.5f));
    }

    private void FixedUpdate()
    {
        myRb.velocity= new Vector2(dirX,dirY);
    }
}
