using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Hint;

    public void Awake()
    {
        Cursor.visible = true;
        Global.TotalDragonsLeft = 15;
        Global.DragonsEntered = 0;
        Global.Level = 1;
    }
    public void play()
    {
        Hint.SetActive(true);
        Invoke("NextScene", 2f);

    }
    public void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
