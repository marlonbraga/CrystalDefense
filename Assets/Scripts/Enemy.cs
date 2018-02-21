using UnityEngine;
using System.Reflection;

public class Enemy : MonoBehaviour
{
    #region Fields

    public int life = 10;
    bool isIdleAnimationPlaying;
    bool isActiveAnimator = true;
    Vector3 lastPosition;

    #endregion Fields

    #region UnityMethods

    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }

        if (IsAnimationSpawnFinished())
        {
            WalkAtTower();
        }
    }

    #endregion UnityMethods

    #region Methods
    
    private void WalkAtTower()
    {
        if (Vector3.Distance(Tower.Position, transform.position) >= 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Tower.Position, 0.1f * Time.deltaTime);
		}
    }

    private bool IsAnimationSpawnFinished()
    {
        if (isIdleAnimationPlaying)
        {
            isIdleAnimationPlaying = false;
            isActiveAnimator = false;
            GetComponent<Animator>().enabled = false;
            transform.position = lastPosition;
        }

        if (isActiveAnimator)
        {
            isIdleAnimationPlaying = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle");
            lastPosition = transform.position;
            return false;
        }

        return true;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
    }

    #endregion Methods
}
