using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager inst;

    public SpriteRenderer doodleSpriteRenderer;
    public Sprite defaultSprite;
    public Sprite[] availableSprites;
    public bool ChangeSprite;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        int spriteIndex = PlayerPrefs.GetInt("SelectedSpriteIndex", -1);
        SetDoodleSprite(spriteIndex);
    }

    public void ChangeDoodleSprite(int spriteIndex)
    {
        if (ChangeSprite)
        {
            Debug.Log("spritechanged");
            SetDoodleSprite(spriteIndex);
            PlayerPrefs.SetInt("SelectedSpriteIndex", spriteIndex);
        }
    }

    public void ResetDoodleSprite()
    {
        SetDoodleSprite(-1);
        PlayerPrefs.DeleteKey("SelectedSpriteIndex");
    }

    private void SetDoodleSprite(int spriteIndex)
    {
        Sprite selectedSprite;

        if (spriteIndex >= 0 && spriteIndex < availableSprites.Length)
        {
            selectedSprite = availableSprites[spriteIndex];
        }
        else
        {
            selectedSprite = defaultSprite;
        }

        doodleSpriteRenderer.sprite = selectedSprite;
    }

}
