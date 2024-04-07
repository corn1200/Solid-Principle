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

클래스가 확장에는 개방되어 있고 수정에는 닫혀 있어야 한다.      
원본 코드를 수정하지 않고 새로운 동작을 추가할 수 있어야 한다.      
타입이 추가될 때마다 클래스가 계속 수정된다면 여러가지 휴먼에러가 발생할 가능성이 높다.

### 예시

Worst Practice: 타입이 추가될 때마다 클래스가 계속 수정되어야 한다.

```csharp
public class Calculator
{
    public float GetRectangleArea(Rectangle rectangle)
    {
        return rectangle.width * rectangle.height;
    }
    
    public float GetCircleArea(Circle circle)
    {
        return circle.radius * circle.radius * Mathf.PI;
    }
    
    public float GetPentagonArea(Pentagon pentagon)
    {
        // 오각형 넓이 구하는 코드
    }
}
```

Best Practice: 수정을 하지 않고도 계속 기능을 추가할 수 있도록 추상화와 상속을 활용한다.

```csharp
public abstract class Shape
{
    public abstract float CalculateArea();
}

public class Circle : Shape
{
    public float radius;

    public override float CalculateArea()
    {
        return radius * radius * Mathf.PI;
    }
}

public class Rectangle : Shape
{
    public float width;
    public float height;

    public override float CalculateArea()
    {
        return width * height;
    }
}

public class Calculator
{
    public float GetArea(Shape shape)
    {
        return shape.CalculateArea();
    }
}
```

## 리스코프 치환 원칙(Liskov's Substitution Principle)

파생 클래스가 기본 클래스를 대체할 수 있어야 한다.       
상속을 할 때 지켜야하는 원칙이다.     
예를 들어, 탈것을 만들기 위해 Vehicle 클래스를 만들고 
앞으로 가는 함수와 좌회전, 우회전 함수도 만든다.        
이 탈것 클래스를 상속 받아서 자동차, 트럭 클래스를 만들고 기차 클래스도 만들어낸다.        
기차는 상식적으로 좌회전이나, 우회전을 할 수 없지만 상속을 받았기 때문에 회전 관련 코드들은 여전히 존재한다.      
그러나 기차의 경우엔 메소드를 비워두거나 예외처리를 해주어야 동작을 안 하거나 오류를 피할 수 있다.        
즉, 리스코프 치환 원칙이란 하위 클래스가 어떠한 경우에도 부모 클래스를 대체할 수 있어야 한다는 것을 의미한다.

해당 원칙을 잘 지키기 위해선:

1. 추상 클래스를 간단하게 만든다.
2. 더 분류를 세분화한다.
3. 상속을 쓰는 것보다는 인터페이스를 생성해서 여러 인터페이스를 조합한다.

### 예시

Worst Practice: 사용하지 않거나 사용할 수 없는 기능까지 상속 받은 클래스를 만든다.

```csharp
public class Vehicle
{
    public void GoForward() {}
    public void TurnRight() {}
    public void TurnLeft() {}
}

public class Truck : Vehicle {}
public class Train : Vehicle {}
public class Car : Vehicle {}

public class Navigator
{
    public void Move(Vehicle vehicle)
    {
        // 상속을 받아버려서, 기차도 회전이 됨
        Train train = vehicle as Train;
        train.TurnLeft();
        
        vehicle.GoForward();
        vehicle.TurnLeft();
        vehicle.GoForward();
        vehicle.TurnRight();
        vehicle.GoForward();
    }
}
```

Best Practice: 단순하게 특정 목적의 클래스를 만드는게 아니라 여러 기능을 인터페이스로 분리하고 조합하여 클래스를 만들어 상속한다.

```csharp
public interface IMovable
{
    public void GoForward();
    public void Reverse();
}

public interface ITurnable
{
    public void TurnRight();
    public void TurnLeft();
}

public class RailVehicle : IMovable
{
    public void GoForward() {}
    public void Reverse() {}
}

public class RoadVehicle : IMovable, ITurnable
{
    public void GoForward() {}
    public void Reverse() {}
    public void TurnRight() {}
    public void TurnLeft() {}
}

public class Train : RailVehicle {}

public class Car : RoadVehicle {}
```

## 인터페이스 분리 원칙(Interface Segregation Principle)

인터페이스를 사용할 때 한번에 크게 사용하지 말고 작은 단위로 나눠서 사용해야 한다.     
예를 들어 유닛 스테이터스 관련 인터페이스가 있다면, 한 클래스에 모든 요소를 넣지 말고 최대한 나눠야 한다.   
이동 인터페이스, 데미지 인터페이스, 스텟 인터페이스 등으로 나누어 이런 인터페이스들을 조합하는 형태로 확장시켜 나간다.  

1. 코드 결합도가 낮아진다.
2. 수정이 용이해진다.

### 예시

Worst Practice: 한 인터페이스에 모든 요소를 넣어서 구현한다.

```csharp
public interface IUnitStats
{
    public float Health { get; set; }
    public int Defense { get; set; }
    public void TakeDamage();
    public float MoveSpeed { get; set; }
    public void GoForward();
    public int Strength { get; set; }
    public int Dexterity { get; set; }
}
```

Best Practice: 각 기능 관련 요소로 인터페이스를 나누고 조합하여 코드를 확장한다.

```csharp
public interface IDamageable
{
    public float Health { get; set; }
    public int Defense { get; set; }
    public void Die();
    public void TakeDamage();
    public void RestoreHealth();
}

public interface IMovable
{
    public float MoveSpeed { get; set; }
    public float Acceleration { get; set; }
    public void GoForward();
    public void Reverse();
}

public interface IUnitStats
{
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Endurance { get; set; }
}

public class EnemyUnit : MonoBehaviour, IDamageable, IMovable, IUnitStats
{
    public float Health { get; set; }
    public int Defense { get; set; }
    public void Die() {}
    public void TakeDamage() {}
    public void RestoreHealth() {}
    public float MoveSpeed { get; set; }
    public float Acceleration { get; set; }
    public void GoForward() {}
    public void Reverse() {}
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Endurance { get; set; }
}

public class UnDeadEnemyUnit : MonoBehaviour, IMovable, IUnitStats
{
    public float MoveSpeed { get; set; }
    public float Acceleration { get; set; }
    public void GoForward() {}
    public void Reverse() {}
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Endurance { get; set; }
}
```

## 의존성 역전 원칙(Dependency Inversion Principle)

고수준 모듈이 저수준 모듈에서 직접 요소를 가져오면 안 된다.      
예를 들어 스위치 클래스가 토글할 객체를 직접적으로 알고 있으면(멤버 변수로 가지고 있으면) 그 객체만 컨트롤할 수 있게 된다.     
하지만, 스위치라는 건 여러가지를 열고 닫거나, 활성/비활성화할 수 있어야 한다.

1. 특정 클래스에 직접적으로 의존하면 안 된다.
2. 인터페이스를 거쳐서 사용하여 느슨한 결합을 구현해야 한다.

### 예시

Worst Practice: 공통 기능을 수행하는 클래스가 특정 클래스만을 직접적으로 참조하도록 설계한다.

```csharp
public class Door : MonoBehaviour
{
    public void Open()
    {
        Debug.Log("The door is open.");
    }

    public void Close()
    {
        Debug.Log("The door is closed.");
    }
}

public class Switch : MonoBehaviour
{
    public Door Door;
    public bool IsActivated;

    public void Toggle()
    {
        if (IsActivated)
        {
            IsActivated = false;
            Door.Close();
        }
        else
        {
            IsActivated = true;
            Door.Open();
        }
    }
}
```

Best Practice: 특정 기능을 수행할 수 있는 인터페이스로 클래스를 연결하여 사용한다.

```csharp
public interface ISwitchable
{
    public bool IsActive { get; }
    public void Activate();
    public void Deactivate();
}

public class Switch : MonoBehaviour
{
    public ISwitchable client;

    public void Toggle()
    {
        if (client.IsActive)
        {
            client.Deactivate();
        }
        else
        {
            client.Activate();
        }
    }
}

public class Door : MonoBehaviour, ISwitchable
{
    private bool _isActive;
    public bool IsActive => _isActive;
    
    public void Activate()
    {
        _isActive = true;
        Debug.Log("The door is open.");
    }

    public void Deactivate()
    {
        _isActive = false;
        Debug.Log("The door is closed.");
    }
}
```