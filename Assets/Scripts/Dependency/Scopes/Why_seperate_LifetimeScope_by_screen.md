## LifetimeScope란
- VContainer 프레임워크에서 의존성 주입을 관리하는 컨테이너임.
- 예를 들어, `CoreLifetimeScope`에 `GameManager`가 등록되어 있다고 하면 `CoreLifetimeScope`를 참조하는 다른 객체가 `GameManager`를 꺼내쓸 수 있는 방식.

## LifetimeScope 분리 기준 (왜 화면 단위인가?)

- 현재 LifetimeScope는 화면 단위로 분리되어 있음. 예) HomeScreenLifetimeScope, LoadingScreenLifetimeScope, etc.

### CoreLifetimeScope의 존재 의의

- 특정 시스템과 특정 화면의 역할이 명확히 구분되어 있지 않기 때문임.
  - 예를 들어 '병사 목록 화면'에서는 병사 목록을 보여주기 위해 플레이어의 데이터와 병사 설정 테이블을 받아와야 함.
  - 하지만 플레이어의 데이터와 병사 설정 테이블은 '병사 목록 화면'에서만 사용되는 것이 아니라, 게임의 다른 부분에서도 사용될 수 있음.


- 따라서 '병사 목록 화면'에 필요한 의존성들을 CoreLifetimeScope에 등록하는 것이 적절함


### CoreLifetimeScope만 사용하는 경우의 문제점

- 앞서 설명했듯이 거의 모든 시스템은 CoreLifetimeScope에 등록되게 될 것임.


- 하지만 씬 위에 배치된 오브젝트들은 참조할 수 있는 LifetimeScope가 필요함.
  - 예를 들어 SoldierListUI는 LifetimeScope(PlayerSessionHolder와 SoldierDatabase가 등록되어 있는 컨테이너)를 참조하고 있어야 필요한 정보를 받아올 수 있음
  - 하지만 CoreLifetimeScope는 '병사 목록 화면' 씬 위에 배치되어 있지 않기 때문에 참조가 불가능함


- 따라서 CoreLifetimeScope를 상속한 하위 LifetimeScope를 화면 단위로 만들어, 화면 위에 있는 오브젝트들이 CoreLifetimeScope의 의존성도 당겨올 수 있게 설계함.


### 결론

- LifetimeScope를 화면 단위로 분리한 것은
  - 컨테이너를 역할 별로 분리할 수 없고
  - VContainer가 컨테이너를 컴포넌트 기반으로 관리하며
  - 씬 위에 배치된 오브젝트들이 LifetimeScope를 참조해야 하기 때문임
