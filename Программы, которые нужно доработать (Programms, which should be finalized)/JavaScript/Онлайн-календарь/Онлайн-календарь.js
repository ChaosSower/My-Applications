///Сделать так, чтобы можно было узнать, сколько дней осталось до указанной даты, а также чтобы можно было добавить свой праздник (с названием и датой)///!!!



// Сбор данных о текущем времени //

let Time_now = new Date(),
  Current_year = Time_now.getFullYear(),
  Current_month = Time_now.getMonth() + 1, // +1 т.к. отсчёт начинается с 0
  Current_day = Time_now.getDate();

// Установка временных меток праздников //

// Фиксированные даты праздников

let New_Year = new Date(Current_year + 1, 0, 1), // Новый год всегда в следующем году
  Winter_Holydays = new Date(Current_year, 0, 1),
  Christmas = new Date(Current_year, 0, 7),
  Defender_Of_The_Fatherland_Day = new Date(Current_year, 1, 23),
  Womens_Day = new Date(Current_year, 2, 8),
  Fools_Day = new Date(Current_year, 3, 1),
  Spring_And_Labour_Day = new Date(Current_year, 4, 1),
  Victory_Day = new Date(Current_year, 4, 9),
  Summer_Holidays = new Date(Current_year, 5, 1),
  Russia_Day = new Date(Current_year, 5, 12),
  Knowledge_Day = new Date(Current_year, 8, 1),
  Teachers_Day = new Date(Current_year, 9, 5),
  Halloween = new Date(Current_year, 9, 31),
  National_Unity_Day = new Date(Current_year, 10, 4);

  // Динамические даты праздников

  let Easter = new Date(Current_year, 3, 16);

// Фунция замены дат праздников в случаи наступления в следующем году
function Events_Data_Replace()
{
  if (Current_month >= 1 && (Current_month >= 1 || Current_day > 1))
  {
    Winter_Holydays = new Date(Current_year + 1, 0, 1);
  }

  if (Current_month >= 1 && (Current_month >= 1 || Current_day > 7))
  {
    Christmas = new Date(Current_year + 1, 0, 7);
  }

  if (Current_month >= 2 && (Current_month >= 2 || Current_day > 23))
  {
    Defender_Of_The_Fatherland_Day = new Date(Current_year + 1, 1, 23);
  }

  if (Current_month >= 3 && (Current_month >= 3 || Current_day > 8))
  {
    Womens_Day = new Date(Current_year + 1, 2, 8);
  }

  if (Current_month >= 4 && (Current_month >= 4 || Current_day > 1))
  {
    Fools_Day = new Date(Current_year + 1, 3, 1);
  }

  if (Current_month >= 4 && (Current_month >= 4 || Current_day > 16))
  {
    Easter = new Date(Current_year + 1, 3, 16);
  }

  if (Current_month >= 5 && (Current_month >= 5 || Current_day > 1))
  {
    Spring_And_Labour_Day = new Date(Current_year + 1, 4, 1);
  }

  if (Current_month >= 5 && (Current_month >= 5 || Current_day > 9))
  {
    Victory_Day = new Date(Current_year + 1, 4, 9);
  }

  if (Current_month >= 6 && (Current_month >= 6 || Current_day > 1))
  {
    Summer_Holidays = new Date(Current_year + 1, 5, 1);
  }

  if (Current_month >= 6 && (Current_month >= 6 || Current_day > 12))
  {
    Russia_Day = new Date(Current_year + 1, 5, 12);
  }

  if (Current_month >= 9 && (Current_month >= 9 || Current_day > 1))
  {
    Knowledge_Day = new Date(Current_year + 1, 8, 1);
  }

  if (Current_month >= 10 && (Current_month >= 10 || Current_day > 5))
  {
    Teachers_Day = new Date(Current_year + 1, 9, 5);
  }

  if (Current_month >= 10 && (Current_month >= 10 || Current_day > 31))
  {
    Halloween = new Date(Current_year + 1, 9, 31);
  }

  if (Current_month >= 11 && (Current_month >= 11 || Current_day > 4))
  {
    National_Unity_Day = new Date(Current_year + 1, 10, 4);
  }
}

Events_Data_Replace();

// Вычисление оставшихся дней до праздников //

let Remain_Days_Before_Event =
{
  "НОВЫЙ ГОД": [Math.round ( (New_Year - Time_now) / (1000*60*60*24) ) + 1],
  "ЗИМНИЕ КАНИКУЛЫ": [Math.round ( (Winter_Holydays - Time_now) / (1000*60*60*24) ) + 1],
  "РОЖДЕСТВО": [Math.round ( (Christmas - Time_now) / (1000*60*60*24) ) + 1],
  "ДЕНЬ ЗАЩИТНИКА ОТЕЧЕСТВА": [Math.round ( (Defender_Of_The_Fatherland_Day - Time_now) / (1000*60*60*24) ) + 1],
  "ДЕНЬ ЖЕНЩИН": [Math.round ( (Womens_Day - Time_now) / (1000*60*60*24) ) + 1],
  "ДЕНЬ ДУРАКА": [Math.round ( (Fools_Day - Time_now) / (1000*60*60*24) ) + 1],
  "ПАСХА": [Math.round ( (Easter - Time_now) / (1000*60*60*24) ) + 1],
  "ПРАЗДНИК ВЕСНЫ И ТРУДА": [Math.round ( (Spring_And_Labour_Day - Time_now) / (1000*60*60*24) ) + 1],
  "ДЕНЬ ПОБЕДЫ" : [Math.round ( (Victory_Day - Time_now) / (1000*60*60*24) ) + 1],
  "ЛЕТНИЕ КАНИКУЛЫ": [Math.round ( (Summer_Holidays - Time_now) / (1000*60*60*24) ) + 1],
  "ДЕНЬ РОССИИ": [Math.round ( (Russia_Day - Time_now) / (1000*60*60*24) ) + 1],
  "ДЕНЬ ЗНАНИЙ": [Math.round ( (Knowledge_Day - Time_now) / (1000*60*60*24) ) + 1],
  "ДЕНЬ УЧИТЕЛЯ": [Math.round ( (Teachers_Day - Time_now) / (1000*60*60*24) ) + 1],
  "ХЭЛЛОУИН": [Math.round ( (Halloween - Time_now) / (1000*60*60*24) ) + 1],
  "ДЕНЬ НАРОДНОГО ЕДИНСТВА": [Math.round ( (National_Unity_Day - Time_now) / (1000*60*60*24) ) + 1]
}

// Функция первоначального запроса названия праздника
function Event_Request_Input()
{
  let Event_Request = prompt(`Начну с того, что в моей базе данных есть следующие праздники:
  ·Новый год
  ·Зимние каникулы
  ·Рождество
  ·День защитника Отечества
  ·День женщин
  ·День дурака
  ·Пасха
  ·Праздник Весны и Труда
  ·День Победы
  ·Летние каникулы
  ·День России
  ·День знаний
  ·День учителя
  ·Хэллоуин
  ·День народного единства

  Итак, давайте начнём. О каком празднике вы хотите получить информацию? (Пожалуйста, укажите интересующее вас событие в формате, данном выше):`, "");

  let Input_Type = typeof Event_Request;
    //Incorrect_Event_Name = false;

  let Not_Only_Spaces_Status = false;

  // Функция, проверяющяя наличие любых других символов, кроме пробелов
  function Check_For_Not_Only_Spaces()
  {
    if (Event_Request.trim() == "")
    {
      Not_Only_Spaces_Status = false;
    }

    else
    {
      Not_Only_Spaces_Status = true;
    }
  }

  if (Event_Request != null)
  {
   Check_For_Not_Only_Spaces();
  }

  //let separator = " "; // проверка на случай пустой строки
  //separator = seperator.replace(/^\s+|\s+$/g, '')
  //!separator

  //console.log(Not_Only_Spaces_Status)

  if (Input_Type == "string" && Event_Request != null)
  {
    switch (Event_Request.toUpperCase())
    {
      case "НОВЫЙ ГОД":

        alert("До Нового года осталось " + Remain_Days_Before_Event ["НОВЫЙ ГОД"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ЗИМНИЕ КАНИКУЛЫ":

        alert("До зимних каникул осталось " + Remain_Days_Before_Event ["ЗИМНИЕ КАНИКУЛЫ"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "РОЖДЕСТВО":

        alert("До Рождества осталось " + Remain_Days_Before_Event ["РОЖДЕСТВО"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ДЕНЬ ЗАЩИТНИКА ОТЕЧЕСТВА":

        alert("До Дня защитника Отечества осталось " + Remain_Days_Before_Event ["ДЕНЬ ЗАЩИТНИКА ОТЕЧЕСТВА"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ДЕНЬ ЖЕНЩИН":

        alert("До Дня женщин осталось " + Remain_Days_Before_Event ["ДЕНЬ ЖЕНЩИН"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ДЕНЬ ДУРАКА":

        alert("До Дня дурака осталось " + Remain_Days_Before_Event ["ДЕНЬ ДУРАКА"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ПАСХА":

        alert("До Пасхи осталось " + Remain_Days_Before_Event ["ПАСХА"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ПРАЗДНИК ВЕСНЫ И ТРУДА":

        alert("До Праздника Весны и Труда " + Remain_Days_Before_Event ["ПРАЗДНИК ВЕСНЫ И ТРУДА"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ДЕНЬ ПОБЕДЫ":

        alert("До Дня Победы осталось " + Remain_Days_Before_Event ["ДЕНЬ ПОБЕДЫ"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ЛЕТНИЕ КАНИКУЛЫ":

        alert("До летних каникул осталось " + Remain_Days_Before_Event ["ЛЕТНИЕ КАНИКУЛЫ"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ДЕНЬ РОССИИ":

        alert("До Дня России осталось " + Remain_Days_Before_Event ["ДЕНЬ РОССИИ"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ДЕНЬ ЗНАНИЙ":

        alert ("До Дня знаний осталось " + Remain_Days_Before_Event ["ДЕНЬ ЗНАНИЙ"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ДЕНЬ УЧИТЕЛЯ":

        alert("До Дня учителя осталось " + Remain_Days_Before_Event ["ДЕНЬ УЧИТЕЛЯ"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ХЭЛЛОУИН":

        alert("До Хэллоуина осталось " + Remain_Days_Before_Event ["ХЭЛЛОУИН"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;

      case "ДЕНЬ НАРОДНОГО ЕДИНСТВА":

        alert("До Дня народного единства осталось " + Remain_Days_Before_Event ["ДЕНЬ НАРОДНОГО ЕДИНСТВА"] + " дня!");

        Question_For_Another_Event_Request();
        //Checker();

        break;
        
      case (Not_Only_Spaces_Status == true):

        /*Event_Request.match(/\d/g) == true /* если строка не содержит символ / ||

        (Object.keys
        (
          [Event_Request]
          .reduce( (r,ch) => (/[А-ЯЁ]/i.test(ch) && (r[ch.toUpperCase()] = 1 ), r), {})
        ).length === 33) == null /* если строка не содержит русский алфавит / ||

        (Object.keys
        (
          [Event_Request]
          .reduce( (r,ch) => (/[A-Z]/i.test(ch) && (r[ch.toUpperCase()] = 1 ), r), {})
        ).length === 26) == null /* если строка не содержит английсикий алфавит */

        alert("Пусто!");

        break

        //Question_For_Another_Event_Request();
        //Checker();

        //break;

      /*case (Event_Request.includes('123')):

        alert("f[f[f[");

        Question_For_Another_Event_Request();
        //Checker();

        break;*/

      default:

        alert("Извините, я не знаю о таком празднике О_0. Возможно, вы написали название праздника с ошибками, попробуйте ещё раз.");
  
        Incorrect_Event_Name = true;
        //Checker();
  
        break;
    }
  }
  
  else if (Event_Request == null)
  {
    alert("Очень жаль, что вы не выбрали никакой праздник :/");
  }
}

// Поставка вопроса для последующего вывода других праздников
function Question_For_Another_Event_Request()
{
  let Event_Request = confirm("Хотите узнать о ещё каком-либо грядущем празднике?");
  
  if (Event_Request == null)
  {
    alert("Я рад, что вы воспользовались моим функционалом и получили информацию о интересующем вас празднике! :) Для презапуска бота, перезагрузите страницу; для выхода - просто закройте вкладку.");
  }

  else //вставить функцию
  {
    prompt(`Отлично! Пожалуйста, впишите название интересующего вас праздника. Я предотсавлю образцы ниже:
    ·Новый год
    ·Зимние каникулы
    ·Рождество
    ·День защитника Отечества
    ·День женщин
    ·День дурака
    ·Пасха
    ·Праздник Весны и Труда
    ·День Победы
    ·Летние каникулы
    ·День России
    ·День знаний
    ·День учителя
    ·Хэллоуин
    ·День народного единства`,"");
  }
}

alert("Здравствуйте, меня зовут Олег - я ваш текстовый веб-помощник. Я подскажу вам сколько осталось дней до указанного вами праздника (по крайней мере расскажу о всём том, что есть в моей базе данных ^_^)");

Event_Request_Input();

/*if (Incorrect_Event_Name == true)
{
  Event_Request_Input();
}*/


//console.log(typeof Event_Request);
//console.log(Event_Request);

 // }
/*if (Event_Request == 0) {
  alert ("123")
//} */