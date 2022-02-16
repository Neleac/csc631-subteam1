using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Camera cam;
    private bool drag;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        drag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (drag) {
            Vector3 screenCoord = Input.mousePosition;
            float camDist = this.transform.position.z - cam.transform.position.z;
            Vector3 worldCoord = cam.ScreenToWorldPoint(new Vector3(screenCoord.x, screenCoord.y, camDist));
            this.transform.position = worldCoord;
        }
    }

    void OnMouseDown()
    {
        drag = true;
    }

    void OnMouseUp()
    {
        drag = false;
    }
}
