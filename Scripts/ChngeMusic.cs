using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChngeMusic : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    Touch touch;
    Vector3 touchPos;
    bool changed;
    private void Update()
    {
        if (Input.touchCount != 1)
        {
            return;
        }
        touch = Input.touches[0];
        touchPos = touch.position;
        //Debug.Log(touchPos);
        if (touch.phase == TouchPhase.Began && !changed)
        {
            ray = Camera.main.ScreenPointToRay(touchPos);
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.name);
                if (hit.transform == transform)
                {
                    //Debug.Log("down");
                    changed = true;
                    SoundManager.instance.changeMusicToTick();
                }
            }
        }
    }
}
