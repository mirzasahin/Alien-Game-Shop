using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;

    void Start()
    {
        // Initially, only the first camera is active
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
        camera4.enabled = false;
    }

    void Update()
    {
        // Switch cameras when keys are pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectCamera(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectCamera(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectCamera(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectCamera(4);
        }
    }

    void SelectCamera(int activeCamera)
    {
        // Disable all cameras
        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = false;
        camera4.enabled = false;

        // Enable the selected camera
        switch (activeCamera)
        {
            case 1:
                camera1.enabled = true;
                break;
            case 2:
                camera2.enabled = true;
                break;
            case 3:
                camera3.enabled = true;
                break;
            case 4:
                camera4.enabled = true;
                break;
            default:
                Debug.LogError("Invalid camera selection!");
                break;
        }
    }
}
