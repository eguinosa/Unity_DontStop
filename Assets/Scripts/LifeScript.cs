using UnityEngine;
using System.Collections;

public class LifeScript : MonoBehaviour
{
    private HUDScript _hud;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
            _hud.FindLive();
            Destroy(this.gameObject);
        }
    }
}
