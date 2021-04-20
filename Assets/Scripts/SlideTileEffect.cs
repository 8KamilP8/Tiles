using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class SlideTileEffect {

    private Transform _transform;
    private ClickableBoardElement _target;
    private Tile _tile;
    private GameObject _effectPrefab;
    //private const float EFFECT_DURATION = .3f;
    private const float SPEED = 4000f;
    public SlideTileEffect(Transform transform, ClickableBoardElement target, Tile tile, GameObject effectPrefab ) {
        _transform = transform;
        _target = target;
        _effectPrefab = effectPrefab;
        float effectDuration = (_target.transform.position - _transform.position).magnitude / SPEED;
        _tile = tile;
        new Utilities.Coroutine(()=> { },Frame, Clean, effectDuration, true);
    }

    private void Frame(float timer, float time) {
        Vector3 dir = (_target.transform.position - _transform.position).normalized;
        _transform.position += dir * SPEED * Time.deltaTime;
    }
    private void Clean() {
        _target.SetToTile(_tile);
        GameObject obj = Object.Instantiate(_effectPrefab);
        obj.AddComponent<MakeCanvasChild>();
        obj.transform.position = _target.transform.position - new Vector3(0,12f,0);
        Object.Destroy(_transform.gameObject);        
    }
}
