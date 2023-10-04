using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public Text itemCount;
    [SerializeField]
    public static int ItemCount = 5;
    [SerializeField]
    public GameObject Exit;
    [SerializeField]
    public GameObject Map;
    [SerializeField]
    public Material newskybox;

    public bool isFScreen = false;
    private FirstPersonCam firstPersonCam; // 마우스 이동으로 카메라 회전
    void Awake()
    {
        firstPersonCam = GetComponent<FirstPersonCam>();
    }

    void Update()
    {
        UpdateRotate();
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFScreen = !isFScreen;
        }
        if (isFScreen)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Screen.fullScreen = true;
        }
        if (ItemCount == -1)
        {
            RenderSettings.skybox = newskybox;
            Destroy(Map); 
            itemCount.text = "Congratulations!";
        }
        else if (ItemCount == 0)
        {
            Destroy(Exit);
            itemCount.text = "Now, Find an exit and escape the maze";
        }
        else
        {
            itemCount.text = $"Number of items you need to get : {ItemCount}";
        }
    }

    void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        firstPersonCam.CalculateRotation(mouseX, mouseY);
    }
}
