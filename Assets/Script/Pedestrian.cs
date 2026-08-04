using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public bool facingLeft;
    public Animator anim;
    public float speed = 2.0f;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();

        if (!facingLeft)
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!facingLeft) transform.position += transform.right * speed * Time.deltaTime;
        if (facingLeft) transform.position -= transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIT");
        if (this.facingLeft && collision.tag == "Left Side") Destroy(this.gameObject);
        if (!this.facingLeft && collision.tag == "Right Side") Destroy(this.gameObject);

    }
}
