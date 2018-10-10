﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.SceneManagement;
using HoloToolkit.Unity.InputModule;

public class LaserController : MonoBehaviour {
    public Collider terrainCollider;
    public Transform ParentTransform;
    public GameObject IndicatorPrefab;
    public GameObject ExplosionPrefab;
    public GameObject TracePrefab;
    public bool SelectWasPressed = false;
    public MixedRealityTeleport teleport;
    AudioSource clicsound;
    private float timer;
    private bool timerOn;
    public GameEngine gameEngine;
    private List<GameObject> instList;
    //public Projector projector;

    // Use this for initialization
    void Start () {
        //InteractionManager.InteractionSourcePressed += InteractionManager_InteractionSourcePressed;

        clicsound = GetComponent<AudioSource>();
        teleport.SetWorldPosition(new Vector3(-1.62f,3.0f,9.01f));
        instList = new List<GameObject>();
        timerOn = false;
        //projector = GetComponent<Projector>();
    }

    IEnumerator waitEndOfAnimation()
    {
        yield return new WaitForSeconds(7);
    }

    private bool ValidRotation(Quaternion newRotation)
    {
        return !float.IsNaN(newRotation.x) && !float.IsNaN(newRotation.y) && !float.IsNaN(newRotation.z) && !float.IsNaN(newRotation.w) &&
            !float.IsInfinity(newRotation.x) && !float.IsInfinity(newRotation.y) && !float.IsInfinity(newRotation.z) && !float.IsInfinity(newRotation.w);
    }

    private bool ValidPosition(Vector3 newPosition)
    {
        return !float.IsNaN(newPosition.x) && !float.IsNaN(newPosition.y) && !float.IsNaN(newPosition.z) &&
            !float.IsInfinity(newPosition.x) && !float.IsInfinity(newPosition.y) && !float.IsInfinity(newPosition.z);
    }


    void Update()
    {
        if (timerOn)
        {
            timer -= Time.deltaTime;
            if (timer<0)
            {
                timerOn = false;
                teleport.SetWorldPosition(new Vector3(-1.62f, 3.0f, 9.01f));
            }
        }

        var interactionSourceStates = InteractionManager.GetCurrentReading();

        

        //Debug.Log("Position X = " + Mathf.Round(teleport.transform.position.x) + " Z = " + Mathf.Round(teleport.transform.position.z));
        //Vector3 Position = getCellCenterPosition(teleport.transform.position);
        Vector3 Position = getCellCenterPosition(Camera.main.transform.position);
        //projector.transform.position = new Vector3(Position.x-0.5f, Position.y-1.0f, Position.z-0.5f);

        int minev = getCellMineValue(Position);
        if (minev == -1)
        {
            //GameObject trace = Instantiate(TracePrefab, Vector3.zero, Quaternion.identity);
            //trace.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));
            //trace.transform.position = new Vector3(Position.x, Position.y + 0.1f, Position.z);

            GameObject explosion = Instantiate(ExplosionPrefab, Vector3.zero, Quaternion.identity);
            explosion.transform.position = Position;
            instList.Add(explosion);



            teleport.SetWorldPosition(new Vector3(teleport.transform.position.x + 3, teleport.transform.position.y, teleport.transform.position.z));
        }

        foreach (var interactionSourceState in interactionSourceStates)
        {
            Vector3 newPosition, IndicatorPosition;
            Quaternion newRotation;

            if (!SelectWasPressed
                && interactionSourceState.selectPressed
                && interactionSourceState.sourcePose.TryGetPosition(out newPosition, InteractionSourceNode.Pointer) && ValidPosition(newPosition)
                && interactionSourceState.sourcePose.TryGetRotation(out newRotation, InteractionSourceNode.Pointer) && ValidRotation(newRotation))
            {
                var ray = new Ray(
                    ParentTransform.TransformPoint(newPosition),
                    ParentTransform.TransformDirection(newRotation * Vector3.forward)
                    );

                //Debug.DrawRay(ray.origin, ray.direction, Color.red);

                RaycastHit raycastHit;
                if (terrainCollider.Raycast(ray, out raycastHit, 10))
                {
                    var cursorPos = raycastHit.point;
                    //Debug.Log("Collision X = " + Mathf.Round(cursorPos.x) + " Z = " + Mathf.Round(cursorPos.z));

                    
                    IndicatorPosition = getCellCenterPosition(cursorPos);
                    Debug.Log("Centres = " + IndicatorPosition);

                    bool visible = getCellIndicatorVisibility(IndicatorPosition);
                    int minevalue = getCellMineNeighbourValue(IndicatorPosition);
                    Debug.Log("Nb voisins = " + minevalue);
                    
                    Debug.Log("Visible = " + visible);
                    if (!visible)
                    {
                        if (minevalue == -1)
                        {
                            GameObject explosion = Instantiate(ExplosionPrefab, Vector3.zero, Quaternion.identity);
                            explosion.transform.position = IndicatorPosition;
                            instList.Add(explosion);

                            GameObject trace = Instantiate(TracePrefab, Vector3.zero, Quaternion.identity);
                            trace.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));
                            trace.transform.position = new Vector3(IndicatorPosition.x, IndicatorPosition.y+0.1f, IndicatorPosition.z);
                            instList.Add(trace);

                            teleport.SetWorldPosition(new Vector3(teleport.transform.position.x+3, teleport.transform.position.y, teleport.transform.position.z));
                        }
                        else if (minevalue == -2)
                        {
                            //Application.LoadLevel(Application.loadedLevel);
                            teleport.SetWorldPosition(new Vector3(8.0f, 8.0f, 9.01f));
                            
                            gameEngine.ReinitGame();
                            
                            for (int i = 0; i < instList.Count; i++)
                            {
                                GameObject g = instList[i];
                                Destroy(g);
                            }
                            timer = 5;
                            timerOn = true;
                            //SceneManager.LoadScene("WinScene");
                        }
                        else if (minevalue != -3)
                        {
                            clicsound.Play();

                            GameObject MineTextindicator = Instantiate(IndicatorPrefab, Vector3.zero, Quaternion.identity);
                            MineTextindicator.transform.GetComponent<TextMesh>().transform.Rotate(new Vector3(90.0f, -90.0f, 0.0f));
                            MineTextindicator.transform.GetComponent<TextMesh>().transform.position = IndicatorPosition;
                            MineTextindicator.transform.GetComponent<TextMesh>().text = minevalue.ToString();
                            instList.Add(MineTextindicator);

                            gameEngine.checkCell(IndicatorPosition.z, -IndicatorPosition.x);
                        }
                    }
                    
                    

                }
            }

            SelectWasPressed = interactionSourceState.selectPressed;

        }
    }

    public Vector3 getCellCenterPosition(Vector3 initialPosition)
    {
        return new Vector3(Mathf.Floor(initialPosition.x)+0.5f, initialPosition.y, Mathf.Floor(initialPosition.z)+0.5f);

    }

    public int getCellMineNeighbourValue(Vector3 initialPosition)
    {
        return gameEngine.checkCell(initialPosition.z, -initialPosition.x);
    }

    public int getCellMineValue(Vector3 initialPosition)
    {
        return gameEngine.checkMine(initialPosition.z, -initialPosition.x);
    }

    public bool getCellIndicatorVisibility(Vector3 initialPosition)
    {
        return gameEngine.isCellRevealed(initialPosition.z, -initialPosition.x);
    }

    // Update is called once per frame
    void InteractionManager_InteractionSourcePressed(InteractionSourcePressedEventArgs args) {
        var interactionSourceStates = InteractionManager.GetCurrentReading();

        foreach (var interactionSourceState in interactionSourceStates)
        {
            Vector3 newPosition;
            Quaternion newRotation;

            if (interactionSourceState.sourcePose.TryGetPosition(out newPosition, InteractionSourceNode.Pointer) && ValidPosition(newPosition)
                && interactionSourceState.sourcePose.TryGetRotation(out newRotation, InteractionSourceNode.Pointer) && ValidRotation(newRotation))
            {
                var ray = new Ray(
                    ParentTransform.TransformPoint( newPosition ),
                    ParentTransform.TransformDirection(newRotation * Vector3.forward)
                    );

                //Debug.DrawRay(ray.origin, ray.direction, Color.red);

                RaycastHit raycastHit;
                if (terrainCollider.Raycast(ray, out raycastHit, 10))
                {
                    var cursorPos = raycastHit.point;
                    Debug.Log("Collision X = " + Mathf.Floor(-cursorPos.x) + " Z = " + Mathf.Floor(cursorPos.z));

                    GameObject MineTextindicator = Instantiate(IndicatorPrefab, Vector3.zero, Quaternion.identity);
                    MineTextindicator.transform.GetComponent<TextMesh>().text = "0";
                    instList.Add(MineTextindicator);
                }
            }
        }
    }
}
