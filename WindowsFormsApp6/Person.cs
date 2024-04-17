using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WindowsFormsApp6
{

    public interface ITimeDependant
    {
        Thread PersonalThread { get; set; }
        int PersonalMsInTick { get; set; }
        object Locker { get; set; }
        bool Exists { get; set; }

        event EventHandler<EventArgs> OnTick;
        void Live();
    }

    //Общий класс человека
    //IDisposable – это встроенный.NET интерфейс.Согласно документации. Microsoft, он обеспечивает механизм высвобождения неуправляемых ресурсов.
    //Интерфейс предоставляет метод Dispose, который при реализации должен очистить все соответствующие ресурсы
    public abstract class Person : ITimeDependant, IDisposable
    {
        //------------------Интерфейсы----------------------

        public Thread PersonalThread { get; set; }  //Личный поток сущности для симулирования "жизни"
        public int PersonalMsInTick { get; set; }   //Личное кол-во мс в одном тике для сущности
        public object Locker { get; set; }          //Объект для синхронизации
        public bool Exists { get; set; }            //Флаг, отвечающий за то, что объект еще не был уничтожен вызовом Dispose()

        public event EventHandler<EventArgs> OnTick;    //Эвент, происходящий каждый тик

        //Оператор lock получает взаимоисключающую блокировку заданного объекта перед выполнением определенных операторов,
        //    а затем снимает блокировку.Во время блокировки поток, удерживающий блокировку,
        //        может снова поставить и снять блокировку. Любой другой поток не может получить блокировку и ожидает ее снятия.
        //        Оператор lock гарантирует, что в любой момент времени только один поток выполняет свой текст.
        public virtual void Live()          //Функция, симулирующая "жизнь" объекта
        {
            lock (Locker)
            {
                while (Exists)
                {
                    Thread.Sleep(PersonalMsInTick);         //Пропускаем тик
                    OnTick?.Invoke(this, EventArgs.Empty);  //Делаем действия на тик
                }
            }
        }

        public void Dispose()
        {
            Exists = false;
        }

        //-------------------------------------------------

        public string PersonalName = "";    //Имя человека
        public List<Publication> TakenPublications;

        static private string[] PeopleNames = new string[] { "Josh", "Anna", "David", "Joe", "Chris", "Leon", "Ithan", "Mia", "Helen", "Carl" }; //Имена для людей
        public Person()
        {
            TakenPublications = new List<Publication>();
            Random rnd = new Random();
            PersonalName = PeopleNames[rnd.Next(0, PeopleNames.Length)];    //Задаем случайное имя из глобального списка

            PersonalThread = new Thread(Live);  //Заводим поток для функции, ставим его на фон
            PersonalThread.IsBackground = true;

            Locker = new object();  //Заводим объект для синхронизации
            PersonalMsInTick = 20;   //Устанавливаем личное кол-во мс в 1 тике
            Exists = true;
            PersonalThread.Start(); //Устанавливаем флаг и запускаем поток
        }
    }
}
