using UnityEngine;
using UnityEngine.Events;

public class BaseCharacter : MonoBehaviour
{
    public float hp;
    public float maxHp = 100;
    [SerializeField] private GameObject bloodFx;

    public UnityEvent<float, float> onHpUpdate = new UnityEvent<float, float>();

    private void OnEnable()
    {
        hp = maxHp;
    }

    public void Damage(float damage, Vector3 position)
    {
        hp -= damage;

        if (hp < 0)
        {
            Dead();
        }

        if (bloodFx)
        {
            Instantiate(bloodFx, position, Quaternion.LookRotation(transform.forward));
        }
        
        onHpUpdate.Invoke(hp, maxHp);
    }

    void Dead()
    {
        Destroy();
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
