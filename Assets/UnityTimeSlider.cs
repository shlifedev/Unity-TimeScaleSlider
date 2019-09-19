using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class UnityTimeSlider : MonoBehaviour
{
    VisualElement rootElement = null;
    public Slider CreateTimeSlider() 
    {
        Slider timeSlider = new Slider();
        timeSlider.style.alignSelf = new StyleEnum<Align>() { value = Align.Center };
        timeSlider.style.width = 100;
        timeSlider.style.height = 19;
        timeSlider.style.marginTop = -20;
        timeSlider.style.marginLeft = -100;
        timeSlider.style.position = new StyleEnum<Position>() { value = Position.Absolute };
        timeSlider.value = 1.0f;
        timeSlider.lowValue = 0;
        timeSlider.highValue = 10;
        return timeSlider;
    }

    private void Start()
    {
        if(rootElement != null)
            rootElement.MarkDirtyRepaint();
    }
    private void OnEnable() 
    {
        SceneView scene = SceneView.sceneViews[0] as SceneView;
        var rootVisualElement = scene.rootVisualElement;
        rootElement = rootVisualElement;
        var slider = CreateTimeSlider(); 
        rootVisualElement.Add(slider); 

        slider.RegisterValueChangedCallback(x => {
            UnityEngine.Time.timeScale = x.newValue;
        });
    } 
}
