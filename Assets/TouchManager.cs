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
            //attention !
            //ici on saut que context.control est de type TouchControl, mais si on change �a dans l'inputAction Asset
            //on bug la ligne ici
            TouchControl t = (TouchControl)context.control;

            //position sur l'�cran
            Vector2 ScreenPos = new Vector2(t.position.x.ReadValue(), t.position.y.ReadValue());

            Camera cam = Camera.main;

            //conversion de la position � l'�cran en position "world"
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(ScreenPos.x, ScreenPos.y, 0));
            point.z = 0;

            //Debug.Log("On a touch� "+point.x+" "+point.y);

            point = new Vector2(point.x, point.y);

            //on cherche si on a touch� un collider
            //TODO : mettre les morceaux de corde sur un layer d�di�
            Collider2D c = Physics2D.OverlapCircle(point, 0.2f);
            if(c != null)
            {
                c.GetComponent<HingeJoint2D>().enabled = false;
            }

        }
    }
}
