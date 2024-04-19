using Unity.Burst.Intrinsics;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float speed = 10f;
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
            Vector3 right = new Vector3(1, 0, 0);
            Debug.Log(AngleBetweenTwoVectors(direction, right) );
            if (AngleBetweenTwoVectors(direction, right) > 35 && AngleBetweenTwoVectors(direction, right) < 135){
                direction = new Vector3(0, direction.y, 0);
            } else if (AngleBetweenTwoVectors(direction,right)>135) {
                direction = new Vector3(direction.x, 0, 0);
            } 
            else {
                direction = new Vector3(direction.x, 0, 0);
            }
            direction.Normalize();
            Debug.Log(direction);
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    public float AngleBetweenTwoVectors(Vector3 vec1, Vector3 vec2) {
        float angle = Vector3.Dot(vec1, vec2);
        float cosAngle = angle / (AbsVector(vec1) * AbsVector(vec2));
        float radian = Mathf.Acos(cosAngle);
        return radian * 180 / Mathf.PI;
    }

    public float AbsVector(Vector3 vec) {
        return Mathf.Sqrt(vec.x * vec.x + vec.y * vec.y);
    }
}