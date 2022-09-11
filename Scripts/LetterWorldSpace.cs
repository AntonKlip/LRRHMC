using UnityEngine;

public class LetterWorldSpace : MonoBehaviour
{
    public LetterCloseLook letterCloseLook;
    public BoxCollider colliderFolded, colliderOpen;
    bool zooming;
    public void LetterZoom()
    {
        SoundManager.instance.PlayOpenList();
        zooming = true;
        Debug.Log("Letter zoom.");
        //transform.position = GameManager.instance.zoomPlace.position;
        //transform.parent = GameManager.instance.zoomPlace;
        //transform.localRotation = zoomPlace.localRotation;
        //transform.eulerAngles = new Vector3(-90, 180, 0);
        GameManager.instance.LetterPanel.SetActive(true);
        //colliderFolded.enabled = false;
        //colliderOpen.enabled = true;
        //letterCloseLook.enabled = true;
        this.enabled = false;
        gameObject.SetActive(false);
    }
    Ray ray;
    RaycastHit hit;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.name);
                if (hit.transform.name == "Letter" && !zooming)
                {
                    LetterZoom();
                }
            }
        }
    }
}
