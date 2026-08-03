using UnityEngine;

public class handshaking : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim=GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
        
            anim.SetBool("Hand_down", true);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Hand_down", false);

        }
    }

    
}


