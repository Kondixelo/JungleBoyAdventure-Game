using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private Vector3 lastCameraPosition;
    private Transform cameraTransform;

    private float textureUnitSizeX;
    private float textureUnitSizeY;
    void Start()
    {

        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;


        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        //textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeX = (texture.width / sprite.pixelsPerUnit) * transform.localScale.x;
        textureUnitSizeY = (texture.height / sprite.pixelsPerUnit) * transform.localScale.y;
    }

    void LateUpdate()   
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3( deltaMovement.x * parallaxEffectMultiplier.x,deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;


        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x, transform.position.y);
        }
        if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
        {
            float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
            transform.position = new Vector3(transform.position.x, cameraTransform.position.y);
        }
    }
}