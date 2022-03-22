using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour, IHit
{
    private static CharacterManager instance;
    public static CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<CharacterManager>();
            }

            return instance;
        }
    }

    [SerializeField] int heal;

    [SerializeField] float range;

    [SerializeField] List<GameObject> CharacterList = new List<GameObject>();

    Transform character;
    private void Start()
    {

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Character"))
    //    {
    //            gameObject.GetComponent<Animator>().SetBool("IsAttack", true);

    //            transform.LookAt(new Vector3(other.gameObject.transform.position.x, 0.866f, other.gameObject.transform.position.z));

    //            transform.LookAt(new Vector3(gameObject.transform.position.x, 0.866f, gameObject.transform.position.z));

    //            StartCoroutine(ResetAnim());
    //    }
    //}



    //IEnumerator ResetAnim()
    //{
    //    yield return new WaitForSeconds(0.6f);
    //    gameObject.GetComponent<Animator>().SetBool("IsAttack", false);
    //}

    public void Update()
    {
        //Attack();
        
    }
    //public void Attack()
    //{
    //    dist = Vector3.Distance()
    //    foreach(GameObject character in CharacterList)
    //    {
    //        if(Vector3.Distance(transform.position, character.transform.position) < range)
    //        {
    //            Debug.Log("Character in range");
    //        }
    //    }
    //}

    public void OnHit(int damage)
    {
        heal -= damage;
    }

    
}
