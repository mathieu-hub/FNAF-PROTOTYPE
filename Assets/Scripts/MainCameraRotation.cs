using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraRotation : MonoBehaviour
{
    public float speed = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    [SerializeField]
    private float maxHorizontalAngle;

    private Camera cam;

    Vector2 mousePos;

    [SerializeField]
    [Range (0f,2f)]
    private float automaticalInputValue;

    [SerializeField]
    private float leftCameraMoveRange;
    [SerializeField]
    private float rightCameraMoveRange;


    void Start()
    {
        cam = Camera.main;
    }

    private void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        mousePos = new Vector2();

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }

    private float ClampHorizontalAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxHorizontalAngle, maxHorizontalAngle);
    }

    void Update()
    {
        if (mousePos.x <= leftCameraMoveRange)
        {
            yaw += speed * -automaticalInputValue;
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
        else if (mousePos.x >= rightCameraMoveRange)
        {
            yaw += speed * automaticalInputValue;
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }             

        yaw = ClampHorizontalAngle(yaw);               
    }
}
