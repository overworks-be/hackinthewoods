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
        mineList.Add(new Coordinates(6,4));
        mineList.Add(new Coordinates(9, 7));
        mineList.Add(new Coordinates(13, 2));
        mineList.Add(new Coordinates(12,10 ));
        mineList.Add(new Coordinates(15,9 ));
        mineList.Add(new Coordinates(9, 13));
        mineList.Add(new Coordinates(7,16 ));
        mineList.Add(new Coordinates(9, 18));
        mineList.Add(new Coordinates(4, 20));
        mineList.Add(new Coordinates(12,20 ));
        mineList.Add(new Coordinates(8,21 ));
        mineList.Add(new Coordinates(13,23 ));
        mineList.Add(new Coordinates(10, 23));
        mineList.Add(new Coordinates(5, 24));
        mineList.Add(new Coordinates(9,26));
        mineList.Add(new Coordinates(11, 28));
        mineList.Add(new Coordinates(8, 30));
        mineList.Add(new Coordinates(6,32 ));

        List<Coordinates> targetZone = new List<Coordinates>();
        targetZone.Add(new Coordinates(10, 32));
        targetZone.Add(new Coordinates(11, 32));

        this.gameService = new GameService();
        gameService.startNewGame(20, 45, mineList, new List<Coordinates>(), targetZone, 0);


 
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

    public int checkMine(float x, float y)
    {
        return this.gameService.checkMine(x, y);
    }

    public bool isCellRevealed(float x, float y)
    {
        return this.getCellState(x, y) == CellState.Revealed;
    }

}
