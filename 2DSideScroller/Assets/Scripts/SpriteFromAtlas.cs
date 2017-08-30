using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using BNG.Sprites.Enumeration;

public class SpriteFromAtlas : MonoBehaviour {

    //Must be selected in Editor
    [SerializeField]
    private SpriteAtlas m_atlas;
    
    private SpriteRenderer m_renderer;

    public Placeholder SpriteName;
    private Placeholder previousSprite;

	// Use this for initialization
	void Start () {
        m_renderer = GetComponent<SpriteRenderer>();
        SetSprite();
    }
	
	// Update is called once per frame
	void Update () {
        if (SpriteName != previousSprite)
        {
            SetSprite();
        }
	}

    void SetSprite()
    {
        previousSprite = SpriteName;
        m_renderer.sprite = m_atlas.GetSprite(SpriteName.ToString());
    }
}
