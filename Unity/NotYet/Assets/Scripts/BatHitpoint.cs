using UnityEngine;
using System.Collections;

public class BatHitpoint : MonoBehaviour
{

    public AudioClip bang;
    public AudioClip dogcry1;
    public AudioClip dogcry2;
    public AudioClip catcry1;
    public AudioClip bow1;
    public AudioClip bow2;
    public AudioClip bow3;
    private AudioSource source;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag.Contains("Enemy") && !col.gameObject.GetComponent<Enemy>().IsHit)
        {
            if (ChairController.Instance.isHitting)
            {
                source.pitch = Random.Range(lowPitchRange, highPitchRange);

                Vector2 diff = col.gameObject.transform.position - this.transform.position;

                col.gameObject.GetComponent<Rigidbody2D>().AddForce(diff.normalized * 3000);

                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);


                col.gameObject.GetComponent<Enemy>().IsHit = true;

                source.PlayOneShot(bang, 1);

                int randInt = Random.Range(1, 3);
                if (randInt == 1)
                    source.PlayOneShot(bow1, 1);
                else if (randInt == 2)
                    source.PlayOneShot(bow2, 1);
                else
                    source.PlayOneShot(bow3, 1);

                if (col.gameObject.GetComponent<Enemy>().name.Contains("Dog"))
                    yield return StartCoroutine(dogsound());
                else if (col.gameObject.GetComponent<Enemy>().name.Contains("Cat"))
                    yield return StartCoroutine(catsound());


            }
        }
    }

    IEnumerator dogsound()
    {
        yield return new WaitForSeconds(0);
        if (Random.Range(1, 2) > 1)
            source.PlayOneShot(dogcry1, 1);
        else
            source.PlayOneShot(dogcry2, 1);
    }

    IEnumerator catsound()
    {
        yield return new WaitForSeconds(0);
        source.PlayOneShot(catcry1, 1);
    }


}
