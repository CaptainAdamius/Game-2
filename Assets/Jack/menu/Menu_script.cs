using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{


    [SerializeField] bool mainMenu;
    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && mainMenu)
        {
            SceneManager.LoadScene("Tranitions");
        }
        
        if (!mainMenu)
        {
            Invoke("endScene", 3f);
        }

    }


    void endScene()
    {
        SceneManager.LoadScene("menu");
        GameData.GDMiniGameNumber = 0;
    }
}
