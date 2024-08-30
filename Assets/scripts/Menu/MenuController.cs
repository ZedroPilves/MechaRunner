using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [SerializeField] bool firstMenu;
    [SerializeField] GameObject menu1;
    [SerializeField] GameObject btn_RunGO;

    private void Awake()
    {
        firstMenu = true;
    }

    private void Update()
    {
        if (firstMenu)
        {
            if (Input.anyKey)
            {
                TouchTheMenu();
            }
        }
    }
    public void TouchTheMenu()
    {

       Destroy(menu1);  

    }


    public void PlayRun()
    {


        SceneManager.LoadScene(1);



    }

    public void setMouseHoverTrigger()
    {
        btn_RunGO.GetComponent<Animator>().SetTrigger("mouseHover");
    }
    public void setMouseExitTrigger()
    {
        btn_RunGO.GetComponent<Animator>().SetTrigger("mouseExit");
    }
}
