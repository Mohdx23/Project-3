using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used while held acts as a physics based projectile instantiator
/// </summary>
public class NerfGunItem : InteractiveItem
{
    public GameObject nerfDartPrefab;
    public Transform nerfDartSpawnLocation;
    public float fireRate = 1;
    public float launchForce = 10;
    protected float fireRateCounter;
    //This game object right here is used to give the nerf dart a name so i can mention it in other codes related to it.
    GameObject bullet;

    protected void Update()
    {

    }
    //The OnUse event gets called whenever the nerf gun gets fired, when that takes place, this code right here is used to make the bullet shoot.
    public override void OnUse()
    {
        base.OnUse();


        bullet = Instantiate(nerfDartPrefab, nerfDartSpawnLocation.position, Quaternion.identity);

        FireNow();


        //TODO: we need to determine if we can fire and if so, make the thing
    }
    //FireNow is used to fire the bullet as it takes the rigidbody component which gives adds physics to it since it is needed to make the bullet launch forward.
    //The destory bullet code is there to make the bullet dissapear after a set amount of seconds which is currently 2 seconds.
    public void FireNow()
    {
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * launchForce);
        Destroy(bullet, 2);
        //TODO: this is where we would actually create the thing and get it on its way
    }
}

