using UnityEngine;

public static class GameInitializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Init()
    {
        CreateGround();
        CreatePlayer();
    }

    static void CreateGround()
    {
        var ground = new GameObject("Ground");
        ground.transform.position = new Vector2(0f, -2f);
        var sr = ground.AddComponent<SpriteRenderer>();
        sr.sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0,0,1,1), new Vector2(0.5f,0.5f));
        sr.color = Color.gray;
        ground.transform.localScale = new Vector3(10f, 1f, 1f);
        ground.AddComponent<BoxCollider2D>();
    }

    static void CreatePlayer()
    {
        var player = new GameObject("Player");
        player.transform.position = new Vector2(0f, 0f);
        var sr = player.AddComponent<SpriteRenderer>();
        sr.sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0,0,1,1), new Vector2(0.5f,0.5f));
        sr.color = Color.green;
        player.AddComponent<BoxCollider2D>();
        var rb = player.AddComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        player.AddComponent<PlayerController>();
    }
}
