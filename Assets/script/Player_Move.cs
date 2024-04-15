using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float speed = 100f;
    private Vector3 startTouchPosition, endTouchPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            startTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startTouchPosition.z = 0;
        }

        if (Input.GetMouseButtonUp(0)) {
            endTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endTouchPosition.z = 0;

            Vector3 direction = endTouchPosition - startTouchPosition;
            direction.Normalize();

            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}