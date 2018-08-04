using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int x;
    public int y;
    public GameEngine gameEngine;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y++;
            updatePosition();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            y--;
            updatePosition();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x--;
            updatePosition();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x++;
            updatePosition();
        }
    }

    private void updatePosition()
    {
        Debug.Log("current pos: " + x + "," + y);
        transform.position = gameEngine.getPosition(x, y);
        gameEngine.checkCell(x, y);
    }
}
