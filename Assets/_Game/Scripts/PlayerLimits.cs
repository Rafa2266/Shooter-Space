using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimits : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private float distanceX, distanceY;
    // Start is called before the first frame update
    void Start()
    {
        SetMinAndMaxWidthHeight();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateX();
        CalculateY();
    }

    private void SetMinAndMaxWidthHeight()
    {
        Vector2 screenDimensions = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.width, Screen.safeArea.height));
        maxX= screenDimensions.x - distanceX;
        minX= - screenDimensions.x + distanceX;
        maxY= screenDimensions.y - distanceY;
        minY= - screenDimensions.y + distanceY;
    }

    private void CalculateX()
    {
        float value = 0;
        bool change = false;
        if (transform.position.x < minX)
        {
            value = minX;
            change= true;
        }
        if (transform.position.x > maxX)
        {
            value = maxX;
            change= true;
        }
        if (change)
        { 
            Vector2 temp=transform.position;
            temp.x = value;
            transform.position = temp;
        }
        

    }

    private void CalculateY()
    {
        float value = 0;
        bool change = false;
        if (transform.position.y < minY)
        {
            value = minY;
            change = true;
        }
        if (transform.position.y > maxY)
        {
            value = maxY;
            change = true;
        }
        if (change)
        {
            Vector2 temp = transform.position;
            temp.y = value;
            transform.position = temp;
        }


    }
}
