using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using static Controls;

public class TouchManager : MonoBehaviour, IDefaultActions
{

    public GameObject TouchDebug;

    public void OnCut(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //attention ?
            TouchControl t = (TouchControl)context.control;

            Vector2 ScreenPos = new Vector2(t.position.x.ReadValue(), t.position.y.ReadValue());

            Camera cam = Camera.main;

            Vector3 point = cam.ScreenToWorldPoint(new Vector3(ScreenPos.x, ScreenPos.y, 0));
            point.z = 0;

            //Debug.Log("On a touché "+point.x+" "+point.y);

            // overlap box ?
            Instantiate(TouchDebug, point, Quaternion.identity);
            

        }
    }
}
