using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementControler : MonoBehaviour
{
    private Controls controls;
    private new Camera camera;
    private Coroutine zoom;
    private Coroutine move;

    private void Awake()
    {
        //setting up game
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToLandscapeLeft = true;

        //setting up controls
        camera = Camera.main;
        controls = new Controls();
        GetComponent<GridLayoutGroup>().cellSize =new Vector2(0.5f*Screen.height/4,Screen.height/4);
    }

    private void OnEnable(){
        controls.Enable();
    }

    private void OnDisable(){
        controls.Disable();
    }
    void Start()
    {
        controls.Touch.SecondaryTouchContact.started += _ => zoomStart();
        controls.Touch.SecondaryTouchContact.canceled += _ => zoomEnd();
        controls.Touch.primaryFingerPress.started += _ => moveStart();
        controls.Touch.primaryFingerPress.canceled += _ => moveEnd();
    }
    IEnumerator MoveMent()
    {
        Vector2 pos, prePos, difference;
        Vector3 campos;
        pos = controls.Touch.primaryFingerPosition.ReadValue<Vector2>();
        prePos = pos;
        while (true)
        {
            pos = controls.Touch.primaryFingerPosition.ReadValue<Vector2>();
            difference = pos - prePos;
            campos = camera.transform.position;
            camera.transform.position = new Vector3(campos.x -= difference.x * 0.1f, 10, campos.z -= difference.y * 0.1f);
            prePos = controls.Touch.primaryFingerPosition.ReadValue<Vector2>();
            yield return null;
        }
    }
    private void moveStart()
    {
        move = StartCoroutine(MoveMent());
    }
    private void moveEnd()
    {
        StopCoroutine(move);
    }

    private void zoomStart()
    {
        zoom =StartCoroutine(ZoomDetection());
    }
    private void zoomEnd()
    {
        StopCoroutine(zoom);
    }

    IEnumerator ZoomDetection() {
        float previousDistance, distance, difference; 

        previousDistance = Vector2.Distance(controls.Touch.primaryFingerPosition.ReadValue<Vector2>(), controls.Touch.SecondaryFingerPosition.ReadValue<Vector2>());
       while(true)
       {
            distance = Vector2.Distance(controls.Touch.primaryFingerPosition.ReadValue<Vector2>(), controls.Touch.SecondaryFingerPosition.ReadValue<Vector2>());
            difference = distance - previousDistance;
            camera.GetComponent<Camera>().fieldOfView =Mathf.Clamp(camera.GetComponent<Camera>().fieldOfView -= difference*0.1f, 105f, 150f);
            previousDistance = distance;
            yield return null;
        }
    }
}
