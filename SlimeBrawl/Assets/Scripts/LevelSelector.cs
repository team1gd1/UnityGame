using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int SelectedLevel = 1;
    public Text LevelName;
    public GameObject LevelSelectorBG;
    public Sprite[] previews;
    public Image currentPreview;
    public GameObject previewImage;
    private int MaxLevel = 2;
    // Start is called before the first frame update
    void Start()
    {
        currentPreview = previewImage.GetComponent<Image>();
        currentPreview.sprite = previews[0];
    }

    // Update is called once per frame
    void Update()
    {
        LevelName.text = "" + SelectedLevel;
    }

   public void AddLevel()
    {
        if (SelectedLevel < MaxLevel ) //&& SelectedLevel >= SaveSystem.LoadData().i_UnlockedLevels)
        {
            SelectedLevel = SelectedLevel + 1;
            currentPreview.sprite = previews[SelectedLevel - 1];
        }
    }

  public  void SubtractLevel()
    {
        if (SelectedLevel > 1)
        {
            SelectedLevel = SelectedLevel - 1;
            currentPreview.sprite = previews[SelectedLevel - 1];
        }
    }

    public void LoadLevel()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + SelectedLevel);
    }

    public void SwitchSelector()
    {
        if (!LevelSelectorBG.activeInHierarchy)
        {
            LevelSelectorBG.SetActive(true);
        }
        else
        {
            LevelSelectorBG.SetActive(false);
        }
    }

}
