using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Select_Menu : MonoBehaviour
{
    public GameObject CharacterSelectMenu;


    
    public void PlayGame() //this is a temp place holder for when selecting character to move to next scene
    {
        SceneManager.LoadScene("CityTech_Brawl");
    }
    public void Loadmenu()
    {
        SceneManager.LoadScene("Title_MainMenu");
    }
}
