using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    int curExp = 0;
    int expToNextLvl = 100;
    float damage = 3f;
    int production = 1;
    int storedResources = 0;
    public GameObject workingMaterial;
    float speed = 0.6f;
    float startDurability = 10f, durability;
    public Text exp;
    public Text lvl;
    float xDiff, yDiff;

    void Start()
    {
        durability = startDurability;
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -speed * Time.deltaTime;

        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.up * -speed * Time.deltaTime;

        }
    }


    void Update()
    {
        exp.text = curExp.ToString();
        lvl.text = production.ToString();

        xDiff = Math.Abs(workingMaterial.transform.position.x - gameObject.transform.position.x);
        yDiff = Math.Abs(workingMaterial.transform.position.y - gameObject.transform.position.y);

        Move();
        if (xDiff < 1 && yDiff < 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                durability -= damage;
                DoWork();
            }
        }
    }

    void DoWork()
    {
        if(durability <= 0)
        {
            curExp += 10;
            storedResources += production;
            if (curExp >= expToNextLvl)
            {
                curExp -= expToNextLvl;
                expToNextLvl += 100;
                production++;
            }
            startDurability += 2;
            durability = startDurability;
        }
    }
}