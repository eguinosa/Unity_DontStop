using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class BoxUserControl : MonoBehaviour
{

    private BoxControllerScript _character;
    private bool _jump;
    public float velocity = 1f;
    /// <summary>
    /// Intervalo para incrementar la velocidad(segundos)
    /// </summary>
    public float improveVelocityInterval = 5f;
    public float maxSpeed = 5;
    private float extraVelocity;
    private float time;

    private void Awake()
    {
        _character = GetComponent<BoxControllerScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_jump)
        {
            _jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
        time += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //float move = CrossPlatformInputManager.GetAxis("Horizontal");
        extraVelocity = (time / improveVelocityInterval) * 0.1f;
        extraVelocity = extraVelocity < maxSpeed ? extraVelocity : maxSpeed;
        _character.Move(velocity + extraVelocity, _jump);
        _jump = false;
    }
}
