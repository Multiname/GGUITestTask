# GGUITestTask

### Usage
- UI скрывается \ открывается по нажатию на ESC
- Управлять содержимым UI можно через **ScriptableObjects/DataSources/** (ExternalStorage):
    - AchievementsDataSource - вкладка Achievements
    - MatchHistoryDataSource - вкладка Overview, история матчей (будет показано только 3 последних)
    - ProfileDataSource - профиль игрока слева сверху
    - StatsDataSource - вкладка Overview, список параметров профиля
- Изменять данные можно и во время PlayMode: после изменения данных нажмите ПКМ по инспектору и выберите **Apply Changes In Runtime**
- Настраивать анимации можно через **ScriptableObjects/UiEffectsConfig**
- Параметры профиля изменяемы:
    - нажмите на текст очков (**99 000 PT.**)
    - введите новое значение
    - измененные поля сменят цвет на красный
    - чтобы сохранить изменения, нажмите кнопку **Save**
- UI поддерживает разрешения 16:9 и 4:3

### Assets
- [Zenject](https://assetstore.unity.com/packages/tools/utilities/extenject-dependency-injection-ioc-157735)
- Addressables (загрузка аватарок и иконок достижений)
- [UniTask](https://github.com/cysharp/UniTask?tab=readme-ov-file#upm-package) (в связке с Addressables)
- [DoTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676) (анимация 2 тогглов в топ-баре, переключения вкладки в окне с информацией)
- [SoftMaskForUGUI](https://github.com/mob-sakai/SoftMaskForUGUI?tab=readme-ov-file#install-via-upm-with-package-manager-ui) (анимация переключения вкладки)

### Troubleshooting
Если после импорта проекта вкладка в окне с информацией выглядит как розовый прямоугольник:

**Assets/Samples/UI Soft Mask -> ПКМ -> Reimport**