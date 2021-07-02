using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool inventory;
    public GameObject Inventory;

    bool menu;
    public GameObject Mainmenu;

    void Start()
    {
        inventory = false;
        Inventory.SetActive(false);

        menu = false;
        Mainmenu.SetActive(false);
    }

    void Update()
    {
        Menu();
        InventoryUI();
        
    }
    void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu = true;
            Mainmenu.SetActive(true);
        }
      
    }
    void InventoryUI()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory = true;
            Inventory.SetActive(true);
        }
   
        if (Input.GetKeyDown(KeyCode.B))
        {
            inventory = false;
            Inventory.SetActive(false);
        }
    }
    public void Continue()
    {
        menu = false;
        if (menu == false)
        {
            Mainmenu.SetActive(false);
        }
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void quit()
    {
        Application.Quit();
    }
}
