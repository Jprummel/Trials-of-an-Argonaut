using UnityEngine;
using System.Collections;

public class AttackRangeCheck : MonoBehaviour {

    [SerializeField]private float _attackRange;
                    private bool _attackIsEnabled;

                    private int _enemyUnitMask;
                    private int _playerUnitMask;
                    private int _firstTarget = 0;
                    private int _currentTarget;
 
                    public Collider[] enemyUnits;
                    public Collider[] playerUnits;
    
    void Start()
    {
        _enemyUnitMask  = LayerMask.GetMask("EnemyUnit");
        _playerUnitMask = LayerMask.GetMask("PlayerUnit");
    }

    void Update()
    {
        FindTarget();
    }

    void FindTarget()
    {
        if(this.tag == "PlayerUnit")
        {
            enemyUnits = Physics.OverlapSphere(this.transform.position, _attackRange, _enemyUnitMask);
            for (int i = 0; i < enemyUnits.Length; i++)
            {
                _firstTarget = enemyUnits.Length-1;
                Debug.Log("Targeted " + enemyUnits[_firstTarget]);
                Debug.Log("Enemy Entered");
                this.transform.LookAt(enemyUnits[_firstTarget].transform.position);

                _attackIsEnabled = true;

            }
        }
        else if (this.tag == "EnemyUnit")
        {
            playerUnits = Physics.OverlapSphere(this.transform.position, _attackRange, _playerUnitMask);
            for (int i = 0; i < playerUnits.Length; i++)
            {
                Debug.Log("Player Entered");
                _attackIsEnabled = true;

            }
        }
    }

    public int CurrentTarget()
    {
        //if(enemyUnits[i] ++ < enemyUnits.Length )
        return _currentTarget++;
    }

    void Attack()
    {
        if (_attackIsEnabled)
        {
            //target enemy from collider array
            
        }
    }
        

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "RangeRing")
        {
            Debug.Log("Collision");
        }
    }
}
