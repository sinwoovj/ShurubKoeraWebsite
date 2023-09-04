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

    void Start()
    {
        MouseSetting.mouseSetting();
    }
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEditor.EditorApplication.isPlaying = false;
#endif
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

    public static void mouseSetting()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
