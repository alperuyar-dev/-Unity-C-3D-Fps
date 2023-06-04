using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;
    public ParticleSystem muzzleFlash;

    Animator anim;

    AudioSource pistolAS;
    public AudioClip shootAC;
    public AudioClip emptyFire;


    bool isReloading;
    public int currentAmmo = 12;
    public int maxAmmo = 12;
    public int carriedAmmo = 60;
    float rateOfFire = 0.2f;
    float nextFire = 0;
    [SerializeField] float weaponRange;
    public Transform shootPoint;

    public float damage = 20f;

    EnemyHealth enemy;
    public Text currentAmmoText;
    public Text carriedAmmoText;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        pistolAS = GetComponent<AudioSource>();
        muzzleFlash.Stop();
        enemy = FindObjectOfType<EnemyHealth>();
        UpdateAmmoUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && currentAmmo > 0)
        {
            Shoot();
        }
        else if (Input.GetButton("Fire1") && currentAmmo <= 0 && !isReloading)
        {
            EmptyFire();
        }
        else if (Input.GetKeyDown(KeyCode.R) && currentAmmo <= maxAmmo && !isReloading)
        {
            isReloading = true;
            Reload();
        }
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {

            nextFire = Time.time + rateOfFire;
            anim.SetTrigger("Shoot");
            currentAmmo--;
            ShootRay();
            UpdateAmmoUI();
        }
    }
    void ShootRay()
    {

        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange))
        {
            if (hit.transform.tag == "Enemy")
            {
                enemy.ReduceHealth(damage);
                Debug.Log(damage);
            }
            else
            {
                Debug.Log("Something Else");
            }
        }
    }
    void Reload()
    {
        if (carriedAmmo <= 0) return;
        anim.SetTrigger("Reload");
        StartCoroutine(ReloadCountDown(2f));
    }
    public void UpdateAmmoUI()
    {
        currentAmmoText.text = currentAmmo.ToString();
        carriedAmmoText.text = carriedAmmo.ToString();
    }
    void EmptyFire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            pistolAS.PlayOneShot(emptyFire);
            anim.SetTrigger("Empty");
        }
    }

    IEnumerator pistolEffect()
    {
        muzzleFlash.Play();
        pistolAS.PlayOneShot(shootAC);
        yield return new WaitForEndOfFrame();
        muzzleFlash.Stop();
    }
    IEnumerator ReloadCountDown(float timer)
    {
        while (timer > 0f)
        {

            timer -= Time.deltaTime;
            yield return null;
        }
        if (timer <= 0)
        {
            isReloading = false;
            int bulletNeeded = maxAmmo - currentAmmo;
            int bulletsToDeduct = (carriedAmmo >= bulletNeeded) ? bulletNeeded : carriedAmmo;
            carriedAmmo -= bulletsToDeduct;
            currentAmmo += bulletsToDeduct;
            UpdateAmmoUI();
        }
    }
}
