using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{


    [SerializeField] bool mainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

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
    }
}
