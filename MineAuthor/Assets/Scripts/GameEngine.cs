﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Assets;
using System;
using UnityEngine.UI;
using Assets.Scripts.GameBoard;

public class GameEngine : MonoBehaviour
{
    #region Public Fields
    public Text timerText;
    public Vector2 cellSize;
    #endregion

    #region Private Fields
    private Assets.Grid grid;
    private float timer;
    private bool timerOn;
    #endregion

    #region Unity Methods
    // Use this for initialization
    void Start()
    {
        List<Assets.Scripts.Data.Position> positions = new List<Assets.Scripts.Data.Position>();
        positions.Add(new Assets.Scripts.Data.Position(7, 32));
        positions.Add(new Assets.Scripts.Data.Position(9, 30));
        positions.Add(new Assets.Scripts.Data.Position(12, 28));
        positions.Add(new Assets.Scripts.Data.Position(10, 26));
        positions.Add(new Assets.Scripts.Data.Position(6, 24));
        positions.Add(new Assets.Scripts.Data.Position(11, 23));
        positions.Add(new Assets.Scripts.Data.Position(14, 23));
        positions.Add(new Assets.Scripts.Data.Position(9, 21));
        positions.Add(new Assets.Scripts.Data.Position(5, 22));
        positions.Add(new Assets.Scripts.Data.Position(13, 22));
        positions.Add(new Assets.Scripts.Data.Position(10, 20));
        positions.Add(new Assets.Scripts.Data.Position(8, 18));
        positions.Add(new Assets.Scripts.Data.Position(10, 15));
        positions.Add(new Assets.Scripts.Data.Position(13, 12));
        positions.Add(new Assets.Scripts.Data.Position(16, 11));
        positions.Add(new Assets.Scripts.Data.Position(10, 9));
        positions.Add(new Assets.Scripts.Data.Position(7, 6));
        positions.Add(new Assets.Scripts.Data.Position(14, 4));


        int[][] filler =  Assets.Scripts.Data.DataSeed.getMap(20, 45, positions);


        grid = GridEngine.buildGrid(20, 45, filler);
        Debug.Log(grid.toString());
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
            gameOver("Exceeded Time");
        }

        timerText.text = ((int)timer).ToString();
    }

    #endregion

    #region Init
    private void initTimer(float time)
    {
        timer = time;
        timerText.text = time.ToString();
        timerOn = false;
    }
    #endregion


    public void startGame()
    {
        timerOn = true;
    }

    public void pauseGame()
    {
        timerOn = false;
    }


    private String gameOver(string reason)
    {
        // timerOn = false;
        // check cell is mine
        // 3 minutes time exceeded
        return reason;
    }

    private void win()
    {
        timerOn = false;
    }


    public void revealCell(float xF, float yF)
    {
        int x = (int)xF;
        int y = (int)yF;
        grid.Cells[y][x].IsRevealead = true;
        checkCell(xF, yF);
    }

    public bool isCellRevealed(float xF, float yF)
    {
        int x = (int)xF;
        int y = (int)yF;

        return grid.Cells[y][x].IsRevealead;

    }


    internal Vector3 getPosition(int x, int y)
    {
        return new Vector3(x * cellSize.x, 0.0F, y * cellSize.y);
    }

    public int checkCell(float xF, float yF)
    {
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
            Debug.Log("near bomb: " + grid.Cells[y][x].AdjacentBomb);
            return grid.Cells[y][x].AdjacentBomb;
        }
    }

}
