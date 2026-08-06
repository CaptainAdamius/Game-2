using UnityEngine;

public class handshaking : MonoBehaviour
{
    private Animator anim;
    int handShakeIndex;
    [SerializeField] int handShakeGoal;
    bool handPos;

    void Start()
    {
        anim=GetComponent<Animator>();
        handPos = true;
    }

    void Update()
    {
        if (SceneIntroManager.IsIntroActive) return;

        if (Input.GetKeyDown(KeyCode.W) && handPos)
        {
            handShakeIndex++;
            anim.SetBool("Hand_down", true);
            handPos = false;

        }
        else if (Input.GetKeyDown(KeyCode.S)&& !handPos)
        {
            anim.SetBool("Hand_down", false);
            handPos = true;

        }
        if (handShakeIndex >= handShakeGoal)
        {
            GameData.GDTaskComplete = true;
        }
    }

    
}


