using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //variabelen
    float speed = 2;
    public Rigidbody rb;
    private void Start()
    {
        //zet het zo dat de telefoon niet automatisch uit gaat bij inactiviteit
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //geef rigidbody waarde aan variabel rb
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //krijg horizontale acceleration van de accelerator van de telefoon
        var moveHorizontal = Input.acceleration.x;
        /*krijg de verticale acceleration, maar + 0.7f zodat de 0 positie een comfortabele telefoon houding is
        ipv telefoon plat op de tafel, en clamp het zodat er geen imbalans in snelheid is van voren en achteren*/
        var moveVertical = Mathf.Clamp(Input.acceleration.y + 0.7f, -0.4f, 0.3f);
        //krijg de movement van de accelerator, maar de bal kan niet omhoog en omlaag bewegen, want dat word door zwaartekracht bepaald
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        //pas het toe en beweeg met movement en snelheid
        rb.AddForce(movement * speed * 6);
    }

    public static explicit operator GameObject(Movement v)
    {
        //als je telefoon geen accelerator heeft of als het niet te vinden is, word het een exception
        throw new NotImplementedException();
    }
}