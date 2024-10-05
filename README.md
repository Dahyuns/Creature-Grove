Creature Grove
==============
## 개요
스팀 게임인 팰 월드(Palworld)에서 영감을 받아 제작을 시작했으며, **몬스터 AI**와 **건설 경영 기능**을 구현해 보고자 제작을 시작했습니다.  <br/>
몬스터의 습격으로 사라진 마을과 실종된 주민들을 되찾아 다시 마을을 재건한 후, 몬스터 재해의 원인을 추적하여 없애는 것을 목표로 하는 게임입니다.


## 프로젝트 요약
|게임 이름|Creature Grove|
|:---|:---|
|게임 장르|서바이벌, TPS|
|개발 기간|2024.07.14 ~ 개발중|
|개발 인원|1인 개발|
|게임 영상|[Youtube](https://www.youtube.com/)|

## 개발일지 (미작성)

|Section|Description|Blog Link|
|:---|:---|:---|
|인터페이스 구성, 플레이어와 무기 생성||[Tistory 링크](https://dev-dahyun.tistory.com/25)|
|상호작용 오브젝트 랜덤 생성|좌표로 영역구분하여 오브젝트 생성|[Tistory 링크](https://dev-dahyun.tistory.com/54)|
|아이템 json 활용 제작, 인벤토리 생성||[Tistory 링크](https://dev-dahyun.tistory.com/55)|
|Enemy AI(1)|FSM을 활용하여 제작한 일반 몬스터 AI|[Tistory 링크](https://dev-dahyun.tistory.com/64)|
|Enemy AI(2)|Animation 연결|[Tistory 링크](https://dev-dahyun.tistory.com/65)|
|건물 업그레이드, 상호작용 기능||[Tistory 링크](https://dev-dahyun.tistory.com/66)|
|상호작용 오브젝트||[Tistory 링크](https://dev-dahyun.tistory.com/67)|
|프로젝트 회고|프로젝트를 진행하며 느낀 점과 개선점|[Tistory 링크](https://dev-dahyun.tistory.com/69)|

<details>
<summary>open(개발기간 및 내용)</summary>
  
|Duration|Goal|Status(☐☑)|
|:---|:---|:---:|
|0502 ~ 0608|1차 개발|🔹|
|0609 ~ 0713|개발지식 공부|🔹|
|0714|객체지향 공부 이후 전체 재개발시작|🔹|
|~0716|객체다이어그램 작성|☑|
|7월 3주|인터페이스 구성|☑|
|7월 4주|플레이어 관련 파트 구현|☑|
|8월 1주|기본 요소들 구현(필드, 인벤토리, 아이템 등)|☑|
|8월 2-3주|맵 제작(영역 설정, 하위 오브젝트 + 생성기 개발)|☑|
|8월 4주|타입별 하위 몬스터 구현|☑|
|9월 1주|캐릭터 생성창, 캐릭터 모델 추가 및 애니메이션 작업, 추가 Scene구성|☐|
|9월 2주|플레이어 1인칭 - 3인칭 시점 구현|☐|
|9월 3주|하위 몬스터 AI 구현 + 애니메이션|☑|
|9월 4주|UI 리소스 통합|☐|

+ 건축모드 : 건물 생성 및 업그레이드 + 상호작용기능
+ 상세 아이템
+ 엔딩
+ 보스 몬스터 , 몬스터 웨이브 
+ 저장기능

+ 개발 고민중!
고급 강화, 건축 아이템을 파는 상점
마을회관 "시장모드" 구현
업적 구현
&nbsp;

</details>


## 플레이화면

### 다이어그램
![다이어그램](https://github.com/user-attachments/assets/4a2e30b3-a1d9-45c3-94ec-3fa75972a295)

### 인터페이스 표
![image](https://github.com/user-attachments/assets/85f022a9-6394-4d60-b210-3d30c80759ba)

### AI 

