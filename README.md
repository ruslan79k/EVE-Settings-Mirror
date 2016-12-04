#EVE Online копирование профилей настроек
Программа позволяет быстро перенести пользовательские настройки основного вашего персонажа на другие аккаунты и персонажи.

![Окно программы](https://github.com/ruslan79k/EVE-Settings-Mirror/blob/master/window.png?raw=true)

## Инструкция использования:
**1)** Скачать программу [download](https://github.com/ruslan79k/EVE-Settings-Mirror/raw/master/bin/Release/EVE_SettingsMirror.exe)

**2)** Помещаем файл программы в папку где хранятся настройки игры. 

Найти папку можно или самостоятельно в папке `%LOCALAPPDATA%\CCP\EVE\`
Откроется окно с несколькими папками в этой папке. Одна из них будет названа в соответствии с названием папки с общими файлами данных на диске; например:
(c_programdata_eve_sharedcache_tq_tranquility)

**или** 
запустить скаченный файл EVE_SettingsMirror.exe, щелкнуть правой кнопкой мыши в окне программы и выбрать нужную папку с настройками игры.

**3)** Запускаем программу уже из папки с настройками игры. 

### Настройки программы
В окне программы имеется два поля.

В первое поле char вписывается название файла из папки, который будет образцом для всех остальных файлов, например: `core_char_12345678.dat` . Этот файл содержит настройки интерфейса в игре, для каждого персонажа этот файл индивидуален.

Во второе поле user вписывается название файла из папки, который будет образцом для всех остальных файлов на других аккаунтах, например: `core_user_15462365.dat` . Этот файл содержит общие настройки игры (звуки, графика, клавиши и т.д.) для всех персонажей на аккаунте. Если у вас всего один аккаунт то поле user можно пропустить.

**Как определить файлы user и char которые нам нужны для образца?**

1. Заходим в игру на основного персонажа, где у вас настроено все как надо и вы хотите перенести эти настройки на остальные персонажи. Вылетаем из дока и залетаем обратно. Выходим из игры.

2. Сортируем в папке с настройками файлы по дате изменения, находим два последних по изменениям файла `core_char_****.dat` и `core_user_****.dat`

3. Копируем названия этих фалов в соответствующие поля в программе.

**4)** Жмем кнопку **Update all files** что бы перенести настройки на всех остальных персонажей

**5)** `Не обязательно` Пожертвовать пару ISK начинающему капсулеру на плекс. Персонаж: x989
