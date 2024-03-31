# 솔리드 원칙(SOLID Principle)

## 목차

* [Single Responsibility Principle(단일 책임 원칙)](#단일-책임-원칙single-responsibility-principle)
* [Open/Closed Principle(개방 폐쇄 원칙)](#개방-폐쇄-원칙openclosed-principle)
* [Liskov's Substitution Principle(리스코프 치환 원칙)](#리스코프-치환-원칙liskovs-substitution-principle)
* [Interface Segregation Principle(인터페이스 분리 원칙)](#인터페이스-분리-원칙interface-segregation-principle)
* [Dependency Inversion Principle(의존성 역전 원칙)](#의존성-역전-원칙dependency-inversion-principle)

## 단일 책임 원칙(Single Responsibility Principle)

하나의 클래스는 하나의 책임만 갖는다.       
하나의 클래스에 여러가지 기능을 한번에 구현하지 않고,
별도의 클래스로 나눠서 만들고 이것들을 각각 별도의 컴포넌트로 오브젝트에 부착한다.
이렇게 코드를 구성할 경우에는 플레이어의 특정 기능만 수정하고 싶을 때 해당하는
스크립트만 수정하면 되지만, 단일 책임 원칙을 지키지 않은 경우 모든 코드를 수정해야한다.

1. 가독성이 좋아진다.                     
   단일 기능 단위로 분리했기 때문에 코드의 길이가 짧고 명확해진다.
2. 확장성이 좋아진다.    
   하나의 기능으로만 이뤄졌기 때문에 이 클래스를 상속받아 확장하기에 용이하다.
3. 재사용성이 좋아진다.       
   단일 기능으로 이뤄져있기 때문에 모듈식으로 여러 부분에서 재사용할 수 있게 된다.

### 예시

Worst Practice: 모든 기능을 한 클래스에 작성한다.

``` csharp
public class Player : MonoBehaviour
{
    private AudioSource _bounceSfx;

    private void Update()
    {
        // 키 입력 인식 기능
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
    
        // 이동 기능
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 효과음 재생 기능
        _bounceSfx.Play();
    }
}
```

Best Practice: 각 기능을 담당하는 클래스를 나누어 관리한다.

```csharp
public class Player : MonoBehaviour
{
    AudioComponent _audioComponent;
    InputComponent _inputComponent;
    MovementComponent _movementComponent;

    private void Start()
    {
        _audioComponent = new AudioComponent();
        _inputComponent = new InputComponent();
        _movementComponent = new MovementComponent();
    }

    private void Update()
    {
        _inputComponent.InputAxis();
        _movementComponent.Move(transform, 
            _inputComponent.horizontalInput, _inputComponent.verticalInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioComponent.PlayBounce();
    }
}

public class MovementComponent
{
    private Vector3 _moveDirection;

    public void Move(Transform transform, float horizontalInput, float verticalInput)
    {
        _moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(_moveDirection * Time.deltaTime);
    }
}

public class InputComponent
{
    public float horizontalInput;
    public float verticalInput;

    public void InputAxis()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
}

public class AudioComponent
 {
     private AudioSource _bounceSfx;

     public void PlayBounce()
     {
         _bounceSfx.Play();
     }
 }
```

## 개방 폐쇄 원칙(Open/Closed Principle)

## 리스코프 치환 원칙(Liskov's Substitution Principle)

## 인터페이스 분리 원칙(Interface Segregation Principle)

## 의존성 역전 원칙(Dependency Inversion Principle)
