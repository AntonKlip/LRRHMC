using UnityEngine;

public class LetterCloseLook : MonoBehaviour
{
    public float scrollingMultiply = 0.5f;
    Ray ray;
    RaycastHit hit;
    Touch touch;
    Vector3 touchPos;
    bool scrolling;

    private void Update()
    {
        if (Input.touchCount != 1)
        {
            scrolling = false;
            return;
        }
        touch = Input.touches[0];
        touchPos = touch.position;
        //Debug.Log(touchPos);
        if (touch.phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(touchPos);
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.name);
                if (hit.transform == transform)
                {
                    //Debug.Log("down");
                    scrolling = true;
                }
            }
        }
        if (scrolling && touch.phase == TouchPhase.Moved)
        {
            float h = touch.deltaPosition.y * Time.deltaTime * scrollingMultiply;
            transform.position += new Vector3(0, h, 0);
        }
        if(scrolling && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            scrolling = false;
        }
    }
}
