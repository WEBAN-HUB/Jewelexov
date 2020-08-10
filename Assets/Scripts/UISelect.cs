using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISelect : MonoBehaviour
{
    Image mpTNImage = null;
    Text mpTNText = null;
    public List<string> TNImagePath = new List<string>();
    public List<string> WorldText = new List<string>();
    int GridIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        mpTNImage = GetComponentInChildren<Image>();
        mpTNText = GetComponentInChildren<Text>();

        TNImagePath.Add("Thumbnails/thumbnail_world_1");
        WorldText.Add("World 1");
        TNImagePath.Add("Thumbnails/thumbnail_world_2");
        WorldText.Add("World 2");

        MoveSelectGrid(TNImagePath[GridIndex - 1], WorldText[GridIndex - 1]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadingSceneManager.LoadScene("SceneWorld_" + (GridIndex));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (GridIndex > 1))
        {
            OnClickBtnLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && (GridIndex < TNImagePath.Count))
        {
            OnClickBtnRight();
        }
    }

    void MoveSelectGrid(string image, string text)
    {
        mpTNImage.sprite = Resources.Load<Sprite>(image);
        mpTNText.text = text;
    }

    public void OnClickBtnEnter()
    {
        LoadingSceneManager.LoadScene("SceneWorld_" + (GridIndex));
    }
    public void OnClickBtnLeft()
    {
        if (GridIndex > 1)
        {
            GridIndex--;
            MoveSelectGrid(TNImagePath[GridIndex - 1], WorldText[GridIndex - 1]);
        }
    }
    public void OnClickBtnRight()
    {
        if (GridIndex < TNImagePath.Count)
        {
            GridIndex++;
            MoveSelectGrid(TNImagePath[GridIndex - 1], WorldText[GridIndex - 1]);
        }
    }
}
