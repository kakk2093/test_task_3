using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGCController : MonoBehaviour
{
   

    [SerializeField] private Text _rText, _gText, _bText;
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _rButtonPlus, _rButtonMinus, _bRandomButton;
    [SerializeField] private bool _isCube;

    public float _rValue, _gValue, _bValue;
    private bool _plus, _minus;
    private float _clickDration = 2f;
    private float _startClickDuration;
    private float _rVolueToConvert, _gVovueToConvert, _bValueToConvert;
    private Image _image;
    private MeshRenderer _meshRenderer;
   
    


    private void Start()
    {
        _plus = false;
        _minus = false;
        _startClickDuration = _clickDration;
        if (_isCube == true)
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
        else
        {
            _image = GetComponent<Image>();
        }
      
       
    }

    private void Update()
    {
        Slider();
        RPlus();
        RMinus();
        VolueConvert();
        TextVisual();
        SetRGB();
        

        if ( _rVolueToConvert < 0)
        {
            _rVolueToConvert = 0;
        }
        if (_rVolueToConvert > 256)
        {
            _rVolueToConvert = 256;
        }

        if(_plus== true || _minus == true)
        {
            _startClickDuration -= Time.deltaTime;

        }
        
      


    }


    
    private void SetRGB()
    {
        if (_isCube)
        {
            _meshRenderer.material.color =new Color(_rValue, _gValue, _bValue);
        }
        else
        {
            _image.color = new Color(_rValue, _gValue, _bValue);
        }
       
    }


    private void TextVisual()
    {
        _rText.text = _rVolueToConvert.ToString();
        _bText.text = _bValueToConvert.ToString();
        _gText.text = _gVovueToConvert.ToString();
    }

    private void VolueConvert()
    {
        _rValue = _rVolueToConvert / 256;
        _bValue = _bValueToConvert / 256;
        _gValue = _gVovueToConvert / 256;
    }

    public void Slider()
    {
        _gVovueToConvert = _slider.value;
    }

    public void RandomButton()
    {
        _bValueToConvert = Random.Range(0, 257);
       
    }

    public void RPlus()
    {
        if(_plus==true && _startClickDuration<=0)
        {
          
                _rVolueToConvert++;
              
        }
        
    }
    public void RMinus()
    {
        if (_minus == true && _startClickDuration<=0)
        {
            
            _rVolueToConvert--;
          
        }
    }


    public void RPlusOnClic()
    {
        _rVolueToConvert++;
       
        
    }

    public void RMinusOnClic()
    {
        _rVolueToConvert--;

    }

   

    public void RPlusButtonDown()
    {
        _plus = true;
    }

    public void RPlusButtonUp()
    {
        _plus = false;
    }

    public void RMinusButtonDown()
    {
        _minus = true;
        _startClickDuration = _clickDration;
    }

    public void RMinusButtonUp()
    {
        _minus = false;
        _startClickDuration = _clickDration;
    }

  


}
