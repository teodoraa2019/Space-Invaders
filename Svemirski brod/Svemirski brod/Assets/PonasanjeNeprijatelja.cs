using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonasanjeNeprijatelja : MonoBehaviour
{
    public GameObject projektil;
    public float snaga = 150;
    public float PucanjuSekundi = 4f;
    public float brzinaProjektila = 10;
    public int rezultatValue = 150;
    private PrikazRezultata prikazRezultata;

    void Start()
    {
        prikazRezultata = GameObject.Find("Rezultat").GetComponent<PrikazRezultata>();
    }
    // Use this for initialization
    void Update()
    {
        float vjerojatnost = PucanjuSekundi * Time.deltaTime;
        if(Random.value < vjerojatnost)
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 offset = new Vector3(0, -1.0f, 0);
        Vector3 polozajPucnja = transform.position + offset;
        GameObject missile = Instantiate(projektil, polozajPucnja, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -brzinaProjektila);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projektil missile = collider.gameObject.GetComponent<Projektil>();
        if (missile)
        {
            missile.Hit();
            snaga -= missile.GetDamage();
            if (snaga <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        prikazRezultata.Rezultat(rezultatValue);
        Destroy(gameObject);
    }
}
