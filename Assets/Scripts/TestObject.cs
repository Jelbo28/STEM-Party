using UnityEngine;

public class TestObject : PoolObject
{
    [SerializeField]
    float speed;

    void Update()
    {
        //transform.Translate(new Vector3(1, 1, 1) * speed * Time.smoothDeltaTime);
        transform.position += transform.forward * Time.deltaTime * speed;
        transform.Rotate(0, 0, speed * Time.deltaTime * 5);
    }

    public override void OnObjectReuse()
    {

    }
}
