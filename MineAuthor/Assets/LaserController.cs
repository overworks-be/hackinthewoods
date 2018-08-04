using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class LaserController : MonoBehaviour {
    public Collider terrainCollider;
    public Transform ParentTransform;
    public GameObject IndicatorPrefab;
    public bool SelectWasPressed = false;
    

    GameEngine gameEngine;

    // Use this for initialization
    void Start () {
        //InteractionManager.InteractionSourcePressed += InteractionManager_InteractionSourcePressed;
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
        var interactionSourceStates = InteractionManager.GetCurrentReading();

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
                    Debug.Log("Collision X = " + Mathf.Floor(-cursorPos.x) + " Z = " + Mathf.Floor(cursorPos.z));

                    IndicatorPosition = getCellCenterPosition(cursorPos);

                    int minevalue = getCellMineNeighbourValue(cursorPos);
                    bool visible = getCellIndicatorVisibility(cursorPos);
                    if (!visible)
                    {
                        if (minevalue == -1)
                        {
                            // Show explosion
                            Debug.Log("Explosion");
                        }
                        else
                        {
                            GameObject MineTextindicator = Instantiate(IndicatorPrefab, Vector3.zero, Quaternion.identity);
                            MineTextindicator.transform.GetComponent<TextMesh>().transform.position = IndicatorPosition;
                            MineTextindicator.transform.GetComponent<TextMesh>().transform.Rotate(new Vector3(90.0f, -90.0f, 0.0f));
                            MineTextindicator.transform.GetComponent<TextMesh>().text = minevalue.ToString();
                        }
                    }
                    
                    

                }
            }

            SelectWasPressed = interactionSourceState.selectPressed;

        }
    }

    public Vector3 getCellCenterPosition(Vector3 initialPosition)
    {
        return new Vector3(Mathf.Floor(initialPosition.x)-0.5f, initialPosition.y + 0.5f, Mathf.Floor(initialPosition.z) + 0.5f);

    }

    public int getCellMineNeighbourValue(Vector3 initialPosition)
    {
        // Ask GameEngine
        return 0;
    }

    public bool getCellIndicatorVisibility(Vector3 initialPosition)
    {
        // Ask GameEngine
        return false;
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

                }
            }
        }
    }
}
