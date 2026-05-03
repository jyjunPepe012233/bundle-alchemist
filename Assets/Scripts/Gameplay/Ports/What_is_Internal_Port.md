## Internal Port란

Internal Port는 Gameplay 어셈블리 내부적으로 사용되는 포트임.

Gameplay 어셈블리만 접근할 수 있으며, 외부 어셈블리에서는 접근할 수 없음.

## 목적
- DI 프로젝트에서는 같은 계층(=Gameplay 어셈블리)에 있더라도 '구현체 전환 가능성'을 위해 인터페이스를 사용해야 하기 때문임.

## 설명 예시

- 예를 들어, 데미지 계산 로직을 제공하는 시스템이 있음

```cs
// Gameplay
public class DamageCalculator
{
    public int CalculateDamage(Attack attack, Defense defense)
    {
        // 데미지 계산 로직
    }
}
```

- 그리고 이 시스템을 외부에서 주입받으면 이렇게 됨

```cs
// Gameplay
public class Player
{
    private readonly DamageCalculator _damageCalculator;

    public Player(DamageCalculator damageCalculator)
    {
        _damageCalculator = damageCalculator;
    }
}
```

- 하지만 이 경우, DamageCalculator의 구현체를 바꿀 수 없음. (예: TestDamageCalculator)


- 따라서, 인터페이스를 사용하여 구현체 전환 가능성을 확보해야 함

```cs
// Gameplay.Ports.Internal
public interface IDamageCalculator
{
    int CalculateDamage(Attack attack, Defense defense);
}
```

```cs
public class DamageCalculator : IDamageCalculator
{
    public int CalculateDamage(Attack attack, Defense defense)
    {
        // 데미지 계산 로직
    }
}
```

- 그러면 인터페이스만으로 구현체를 바꿀 수 있게 됨

```cs
public class Player
{
    // 여기에 DamageCalculator가 들어가는지, TestDamageCalculator가 들어가는지 모름(=전환 가능성 확보됨)
    private readonly IDamageCalculator _damageCalculator;

    public Player(IDamageCalculator damageCalculator)
    {
        _damageCalculator = damageCalculator;
    }
}
```