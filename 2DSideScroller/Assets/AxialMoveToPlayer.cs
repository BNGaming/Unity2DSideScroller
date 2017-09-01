using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxialMoveToPlayer : MonoBehaviour {

    public float MoveSpeed;
    public int LockedFrames;
    GameObject Player;
    Transform OwnTransform;

    private Vector3 axis;
    private int LockedCount = 1;

    public bool ShouldMove = true;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        OwnTransform = GetComponent<Transform>();
        Random.InitState(Time.frameCount);
    }
	
	// Update is called once per frame
	void Update () {
        LockedCount = (LockedCount == 0) ? LockedFrames : LockedCount - 1;
        if (LockedCount == 0 && Random.value > 0.5)
        {
            if (Random.value > 0.5f) { axis = Vector3.right; }
            else { axis = Vector3.up; }
        }
	}

    private void OnCollisionStayFromChild2D(Collision2D collision)
    {
        print("Collision!");
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            ShouldMove = false;
        }
    }


    private void FixedUpdate()
    {
        if (ShouldMove)
        {
            Vector3 TargetPosition = Player.transform.position;
            Vector3 TargetDirection = TargetPosition - OwnTransform.position;
            DrawArrow.ForDebug(OwnTransform.position, TargetDirection);
            TargetDirection.x = (Mathf.Abs(TargetDirection.x) < 0.1f) ? 0 : TargetDirection.x;
            TargetDirection.y = (Mathf.Abs(TargetDirection.y) < 0.1f) ? 0 : TargetDirection.y;
            Vector3 newPosition = OwnTransform.position;
            if (TargetDirection.x == 0 || TargetDirection.y == 0)
            {
                if (TargetDirection.x == 0)
                {
                    newPosition.y += Mathf.Sign(TargetDirection.y) * MoveSpeed * Time.fixedDeltaTime;
                }
                else if (TargetDirection.y == 0)
                {
                    newPosition.x += Mathf.Sign(TargetDirection.x) * MoveSpeed * Time.fixedDeltaTime;
                }
            }
            else if (axis == Vector3.right)
            {
                newPosition.x += Mathf.Sign(TargetDirection.x) * MoveSpeed * Time.fixedDeltaTime;
            }
            else if (axis == Vector3.up)
            {
                newPosition.y += Mathf.Sign(TargetDirection.y) * MoveSpeed * Time.fixedDeltaTime;
            }
            OwnTransform.position = newPosition;
        }
        ShouldMove = true;
    }
}

public static class DrawArrow
{
    public static void ForGizmo(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
        Gizmos.DrawRay(pos, direction);

        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
        Gizmos.DrawRay(pos + direction, left * arrowHeadLength);
    }

    public static void ForGizmo(Vector3 pos, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
        Gizmos.color = color;
        Gizmos.DrawRay(pos, direction);

        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
        Gizmos.DrawRay(pos + direction, left * arrowHeadLength);
    }

    public static void ForDebug(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
        Debug.DrawRay(pos, direction);

        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Debug.DrawRay(pos + direction, right * arrowHeadLength);
        Debug.DrawRay(pos + direction, left * arrowHeadLength);
    }
    public static void ForDebug(Vector3 pos, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
        Debug.DrawRay(pos, direction, color);

        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Debug.DrawRay(pos + direction, right * arrowHeadLength, color);
        Debug.DrawRay(pos + direction, left * arrowHeadLength, color);
    }
}

