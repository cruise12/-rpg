using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : Singleton<MouseManager>
{
    public Texture2D target, portal, attack;
    RaycastHit hitInfo;

    public event UnityAction<Vector3> OnMouseClicked;
    public event UnityAction<GameObject> OnEnemyClicked;
    void Update()
    {
        SetCursorTexture();
        MouseControl();
    }
    void SetCursorTexture()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hitInfo))
        {
            switch(hitInfo.collider.gameObject.tag)
            {
                case "Ground":
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                    break;
                case "Portal":
                    Cursor.SetCursor(portal, new Vector2(16, 16), CursorMode.Auto);
                    break;
                case "Enemy":
                    Cursor.SetCursor(attack, new Vector2(16, 16), CursorMode.Auto);
                    break;
            }

        }


    }
    void MouseControl()
    { if(Input.GetMouseButtonDown(0)&&hitInfo.collider!=null)
        {
            switch(hitInfo.collider.gameObject.tag)
            {
                case "Ground":
                    OnMouseClicked?.Invoke(hitInfo.point);
                    break;
                case "Enemy":
                    OnEnemyClicked?.Invoke(hitInfo.collider.gameObject);
                    break;
                case "Portal":
                    OnMouseClicked?.Invoke(hitInfo.point);
                    break;

            }

        }


    }
}
