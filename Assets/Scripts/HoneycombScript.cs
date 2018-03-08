﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneycombScript : MonoBehaviour {

    [SerializeField]
    private GameObject _honeycombLid;

    [SerializeField]
    private float _howLongToDo = 0.2f;
    [SerializeField]
    private float _howFarToMove = 2f;

    public void Move()
    {
        StartCoroutine(DoMove());
    }

    IEnumerator DoMove()
    {
        float timer = Time.time + _howLongToDo;

        while (Time.time < timer)
        {
            _honeycombLid.transform.position = new Vector3(_honeycombLid.transform.position.x, _honeycombLid.transform.position.y, _honeycombLid.transform.position.z + _howFarToMove);

            yield return null;
        }

        //canvasGroup.interactable = false;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                if (_hit.collider.tag == "target")
                {
                    Move();
                }
            }
        }
    }
}
