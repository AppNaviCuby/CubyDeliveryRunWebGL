﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    //変数定義
    Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector;
    Vector2 DefaultPos;
    Vector2 PrevPos;

    [SerializeField] float MovedistanceX;
    [SerializeField] float MovedistanceY;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DefaultPos = transform.position;
        surfaceEffector = GetComponent<SurfaceEffector2D>();
    }

    void FixedUpdate()
    {
        PrevPos = rb.position;
        
        if(MovedistanceX>0){
        // X座標のみ横移動　Mathf.PingPongの数値部分変更で移動距離が変わる
        Vector2 pos = new Vector2(DefaultPos.x + Mathf.PingPong(Time.time,MovedistanceX), DefaultPos.y);
        rb.MovePosition(pos);

        // 速度を逆算する
        Vector2 velocity = (pos - PrevPos) / Time.deltaTime * 50;

        // 速度のX成分を SurfaceEffector2D に適用
        surfaceEffector.speed = velocity.x;
        }else{
            Vector2 pos = new Vector2(DefaultPos.x , DefaultPos.y+ + Mathf.PingPong(Time.time,MovedistanceY));
        rb.MovePosition(pos);

        // 速度を逆算する
        Vector2 velocity = (pos - PrevPos) / Time.deltaTime * 50;

        // 速度のX成分を SurfaceEffector2D に適用
        surfaceEffector.speed = velocity.y;

        }
    }
}