using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    [SerializeField] private int column_pool_size = 5;
    [SerializeField] private GameObject column;
    [SerializeField] private Vector2 object_pool_position = new Vector2(-15f, -25f);
    [SerializeField] private float spawn_rate = 4f;
    [SerializeField] private float column_min = -1f;
    [SerializeField] private float column_max = 3.5f;
    private GameObject[] column_pool;

    private float time_since_last_spawn = 0f;
    private float spawn_x_pos = 10f;
    private int current_column = 0;

    private void Start()
    {
        column_pool = new GameObject[column_pool_size];
        for (int i = 0; i < column_pool_size; i++)
        {
            column_pool[i] = (GameObject)Instantiate(column, object_pool_position, Quaternion.identity);
        }
    }

    private void Update()
    {
        time_since_last_spawn += Time.deltaTime;
        if(time_since_last_spawn >= spawn_rate && !GameController.instance.game_over)
        {
            time_since_last_spawn = 0f;
            float spawn_y_pos = Random.Range(column_min, column_max);
            column_pool[current_column].transform.position = new Vector2(spawn_x_pos, spawn_y_pos);
            current_column++;
            if(current_column == column_pool_size)
            {
                current_column = 0;
            }
        }
    }
}
