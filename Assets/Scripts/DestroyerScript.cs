using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour
{
    HUDScript _hud;
    public GameObject character;
    private BoxControllerScript _controller;

    private void Awake()
    {
        _controller = character.GetComponent<BoxControllerScript>();
        _hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (_controller.godMode)
            {
                _controller.GetSave();
            }
            else if(_hud.AnotherLife)
            {
                _controller.GetSave();                
                return;
            }
            else
            {
                Application.LoadLevel(0);
                //Debug.Break();
            }
            return;
        }

        if (other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
