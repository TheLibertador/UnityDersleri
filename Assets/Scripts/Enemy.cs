using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;

    public Ease myEase;
    // Start is called before the first frame update
    void Start()
    {
        enemy1.GetComponent<Transform>().DOLocalMove(new Vector3(31.34653f, -3.24f, 0f),0.9f).SetLoops(-1, LoopType.Yoyo).SetEase(myEase);
        enemy2.GetComponent<Transform>().DORotate(new Vector3(0, 0, 180), 1f).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
