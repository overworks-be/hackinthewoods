using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Assets;
using System;
using UnityEngine.UI;

using Assets.Scripts.Core;
using Assets.Scripts.Service;

public class GameEngine : MonoBehaviour
{

    private GameService gameService;

    public Text timerText;
    public Vector2 cellSize;
    private float timer;
    private bool timerOn;


    // Use this for initialization
    void Start()
    {

        List<Coordinates> mineList = new List<Coordinates>();
        mineList.Add(new Coordinates(7, 32));
        mineList.Add(new Coordinates(9, 30));
        mineList.Add(new Coordinates(12, 28));
        mineList.Add(new Coordinates(10, 26));
        mineList.Add(new Coordinates(6, 24));
        mineList.Add(new Coordinates(11, 23));
        mineList.Add(new Coordinates(14, 23));
        mineList.Add(new Coordinates(9, 21));
        mineList.Add(new Coordinates(5, 22));
        mineList.Add(new Coordinates(13, 22));
        mineList.Add(new Coordinates(10, 20));
        mineList.Add(new Coordinates(8, 18));
        mineList.Add(new Coordinates(10, 15));
        mineList.Add(new Coordinates(13, 12));
        mineList.Add(new Coordinates(16, 11));
        mineList.Add(new Coordinates(10, 9));
        mineList.Add(new Coordinates(7, 6));
        mineList.Add(new Coordinates(14, 4));

        List<Coordinates> targetZone = new List<Coordinates>();
        targetZone.Add(new Coordinates(11, 32));
        targetZone.Add(new Coordinates(12, 32));

        this.gameService = new GameService();
        gameService.startNewGame(20, 45, mineList, new List<Coordinates>(), targetZone, 32);


 
        Debug.Log(gameService.Grid.ToString());
        initTimer(180);
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            timerOn = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            timerOn = true;
        }
        if (timerOn)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timerOn = false;
        }
        timerText.text = ((int)timer).ToString();
    }

    private void initTimer(float time)
    {
        timer = time;
        timerText.text = time.ToString();
        timerOn = false;
    }

    public CellState getCellState(float x, float y)
    {
        return this.gameService.getCellState(x,y);
    }

    public int checkCell(float x, float y)
    {
        return this.gameService.checkCell(x, y);
    }

    public bool isCellRevealed(float x, float y)
    {
<<<<<<< HEAD
        int x = (int)xF;
        int y = (int)yF;

        if (grid.Cells[y][x].IsBomb)
        {
            Debug.Log("BOUM!");
            gameOver("Mine Detonation");
            return -1;
        }
        else
        {
            //Debug.Log("near bomb: " + grid.Cells[y][x].AdjacentBomb);
            if(grid.Cells[y][x].AdjacentBomb == -2)
            {

                Debug.Log("Time: " + timer);
            }


            return grid.Cells[y][x].AdjacentBomb;
        }
=======
        return this.getCellState(x, y) == CellState.Revealed;
>>>>>>> 3a8263cbe9acf65405bf6d9c52cf2d1c48288904
    }

}
