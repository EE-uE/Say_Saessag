using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject tutorialMenu;

    public void MainGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnMenu()
    {
        tutorialMenu.SetActive(!tutorialMenu.activeSelf);
    }
}
