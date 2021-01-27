using System.Collections;
using UnityEngine;

public class Objects : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float objectSpeed = 1;

    [SerializeField]
    private float resetPosition = -21.65f;

    [SerializeField]
    private float startPosition = 79.67f;
    #endregion

    protected virtual void Update()
    {
        if(!GameManager.instance.GameOver)
        {
            transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

            if(transform.localPosition.x <= resetPosition)
            {
                Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
    }
}
