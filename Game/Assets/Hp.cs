using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public GameObject HP;
    script = GameObject.Find("Player").GetComponent<Player>();

    // Update is called once per frame
    void Start()
    {
        Instantiate(HP, new Vector3(transform.position.x-1.65f, transform.position.y +1.30f, transform.position.z+2.27f), Quaternion.identity, transform);
        Instantiate(HP, new Vector3(transform.position.x-1.54f, transform.position.y +1.30f, transform.position.z+2.27f), Quaternion.identity, transform);
        Instantiate(HP, new Vector3(transform.position.x-1.43f, transform.position.y +1.30f, transform.position.z+2.27f), Quaternion.identity, transform);
        Instantiate(HP, new Vector3(transform.position.x-1.32f, transform.position.y +1.30f, transform.position.z+2.27f), Quaternion.identity, transform);
        Instantiate(HP, new Vector3(transform.position.x-1.21f, transform.position.y +1.30f, transform.position.z+2.27f), Quaternion.identity, transform);
    }

    private void Update()
    {
        if (isHp < 5) ;
        { }
    }
}
