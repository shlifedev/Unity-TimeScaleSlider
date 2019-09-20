using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

 
public class UnityTimeSlider : MonoBehaviour
{
    private VisualElement rootElement = null;
    private Slider timeSlider = null;
    private Label sliderValueLabel = null; 
    
    public Slider CreateTimeSlider()
    {
        Slider timeSlider = new Slider();
        timeSlider.style.alignSelf = new StyleEnum<Align>() { value = Align.Center };
        timeSlider.style.width = 100;
        timeSlider.style.height = 19;
        timeSlider.style.marginTop = -20;
        timeSlider.style.marginLeft = -100;
        timeSlider.value = 1.0f;
        timeSlider.lowValue = 0;
        timeSlider.highValue = 10;
        return timeSlider;
    }

    public Label CreateTimeSliderValue()
    {
        Label label = new Label();
        label.text = Time.timeScale.ToString();
        label.style.color = Color.white;
        label.style.width = 50;
        label.style.unityTextAlign = new StyleEnum<TextAnchor>() { value = TextAnchor.MiddleCenter };
        label.style.marginTop = -10;
        label.style.backgroundColor = new Color(0, 0, 0, 0.25f);
        label.style.marginLeft = -100;
        label.style.alignSelf = new StyleEnum<Align>() { value = Align.Center };
        label.style.height = 19;
        return label;

    }

    private void Start()
    { 
        if (rootElement != null)
            rootElement.MarkDirtyRepaint();
    }

    private void Attach()
    {
        SceneView scene = SceneView.sceneViews[0] as SceneView;
        var rootVisualElement = scene.rootVisualElement;
        rootElement = rootVisualElement;
        timeSlider = CreateTimeSlider();
        timeSlider.name = "timeSlider";
        rootVisualElement.Add(timeSlider);

        timeSlider.RegisterValueChangedCallback(x =>
        {
            UnityEngine.Time.timeScale = x.newValue;
            Time.timeScale = x.newValue;
            sliderValueLabel.text = x.newValue.ToString("0.00");
        });
 
        sliderValueLabel = CreateTimeSliderValue();
        sliderValueLabel.name = "sliderValueLabel";
        sliderValueLabel.text = Time.timeScale.ToString("0.00");
        rootElement.Add(sliderValueLabel); 
    } 

    private void Dettach()
    {
        rootElement.Remove(timeSlider);
        rootElement.Remove(sliderValueLabel); 
    }
     
    private void OnEnable()
    {
        Attach();
    }

    private void OnDisable()
    {
        Dettach();
    }

} 
