Контрольні питання ЛР1:

-Які мови програмування підтримує CLR?  
Microsoft надає три мови програмування, здатних використовувати CLR: Visual Basic.NET, Visual C#.NET та Visual C++

-З яких компонентів складається CLR?  
Біблеотики базових класів та ядро.

-Скільки рівнів має Garbage Collector?  
Garbage Collector має три рівні, а саме: стискання, маркування, чистка.

-Коли викликається останній рівень GC?  
Останній рівень GC викликається після рівню чистки.

-Що таке CLS?  
CLS (Common Language Specification — загальна специфікація для мов програмування) є набором правил, яка описує усі можливості, які повинні підтримувати мови програмування.  

Контрольні питання ЛР2:  

-Які базові бібліотеки використовувались для .NET Framework, .NET Core та Xamarin?  
.NET Framework бібліотеки: ASP.NET, WPF, ADO.NET, Windows Forms.  
.NET Core бібліотеки: Entity Framework Core, ASP.NET Core, .NET Standard Library.  
Xamarin бібліотеки: Xamarin.iOS, Xamarin.Forms, Xamarin.Android.  

-Що таке .NET Standard?  
.NET Standart - це офіційна специфікація API, яка визначає набір бібліотек класів, які мають бути підтримувані на всіх платформах, які підтримують .NET.  

-Скільки існує видів бібліотек і які?  
1.Platform-specific class libraries  
2. .NET Standard class libraries  
3. Portable class libraries  
4. Mono class libraries  

-Для чого використовується Mono class libraries?  
Mono class libraries - набір бібліотек для .NET, які використовуються для створення крос-платформних програм на платформах, які підтримують Mono, таких як Linux, macOS, Android та інші.  

-Яка бібліотека містить фундаментальні та базові класи?  
System namespace.  

Контрольні питання ЛР3:  

-У чому відмінність асинхронного і багатопоточного програмування?  
Асинхронне програмування полягає у виконанні завдань без очікування їх завершення перед переходом до наступного завдання. Замість цього, програма відправляє запити на виконання завдання та переходить до наступного без очікування результату виконання запиту. Коли результат буде готовий, програма буде сповіщена та зможе продовжити виконання. Багатопоточне програмування передбачає розділення програми на декілька потоків виконання, які працюють паралельно один з одним. Кожен потік виконує свою частину коду та може взаємодіяти з іншими потоками, виконуючи спільні завдання.  

-Які типи даних може повертати async – await?  
Task, Task void, IAsyncEnumerable  

-Які модифікатори для параметрів не можна використовувати  в асинхронних методах?  
ref, out, params  

-Які властивості надає клас Thread? Опишіть їх.  
Клас Thread надає властивості, такі як обслуговування часу, призупинення, продовження, переривання. В мові програмування C# клас Thread також надає методи для завантаження або ініціалізації потоку, отримання стану потоку, порівняння двох потоків.  

-Які методи надає клас Thread? Опишіть їх.  
Abort() використовується для завершення потоку. Interrupt() використовується для переривання потоку, який знаходиться в стані WaitSleepJoin. Join() використовується для блокування всіх викликаючих потоків, доки цей потік не завершиться. ResetAbort() використовується для скасування запиту Abort для поточного потоку. Sleep() використовується для призупинення поточного потоку на вказані мілісекунди. Start() змінює поточний стан потоку на Runnable.  

Контрольні питання ЛР4:  

-Що таке рефлексія?  
Рефлексія - це механізм, що дозволяє отримувати інформацію про типи, класи, інтерфейси, атрибути та інші елементи програми виконання .NET, а також взаємодіяти з ними за допомогою коду.  

-Для чого використовується Reflection?  
Reflection використовується для взаємодії з типами та об'єктами під час виконання програми. Це дозволяє динамічно створювати об'єкти, викликати методи, встановлювати та отримувати значення властивостей та поля, робити інші операції, що були визначені під час компіляції.  

-Чи можна працювати за допомогою Reflection з компілюваними збірками?
Так, можна. Reflection дозволяє отримувати інформацію про класи та інші елементи збірки навіть якщо вона була скомпільована до DLL або EXE файлу.  

-Який namespace у Reflection?  
Namespace для Reflection - System.Reflection.  

-Якщо збірка містить поле/метод з модифікатором доступу private, чи маємо ми можливість працювати з полем/методом за допомогою Reflection?  
Так, можливо. Reflection дозволяє отримати доступ до елементів з модифікатором доступу private за допомогою методу BindingFlags.NonPublic.

Контрольні питання ЛР5:  

-Що таке HTTP?  
HTTP (Hypertext Transfer Protocol) - це протокол передачі даних в мережі Інтернет. Він використовується для взаємодії між клієнтом і сервером, при цьому клієнт може отримувати різні ресурси (текстові документи, зображення, відео тощо) з сервера.  

-Які групи статус кодів існують? Привести приклади з StatusCodes.  
1xx (Інформаційні) - ці коди повідомляють про те, що запит отриманий і обробляється.
2xx (Успішні) - ці коди повідомляють про те, що запит був успішно оброблений.
3xx (Перенаправлення) - ці коди повідомляють про те, що клієнт повинен зробити додатковий запит для отримання ресурсу.
4xx (Помилки клієнта) - ці коди повідомляють про те, що запит містить помилку, зокрема відсутність прав доступу або неправильну адресу запитуваного ресурсу.
5xx (Помилки сервера) - ці коди повідомляють про те, що сервер не зміг успішно обробити запит клієнта.  

-Для яких протоколів HTTP використовується, як базовий «транспортний» протокол?
HTTP використовується як базовий транспортний протокол для TCP/IP.  

-На які групи поділяють програмне забезпечення для роботи з протоколом HTTP?  
Клієнтське ПЗ, яке відповідає за створення запитів і обробку відповідей сервера.
Серверне ПЗ, яке відповідає за обробку запитів і надання відповідей клієнтам.  

-Який з методів HTTP запитів не може мати body?  
Метод HEAD у HTTP запитах не може мати body. Цей метод повертає лише заголовки відповіді на запит, але не повертає тіло вміст ресурсу, який був запитаний. Він використовується для отримання метаданих про запитуваний ресурс, таких як заголовок дати модифікації, заголовок Content-Type тощо. Таким чином, метод HEAD дозволяє клієнту перевірити наявність та параметри ресурсу, не завантажуючи його вмісту повністю, що зменшує трафік в мережі.
