using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    //Общий контрол человека, в котором реализуется движение по тикам
    public partial class PersonControl : UserControl
    {
        public PersonControl()
        {
            InitializeComponent();
            
        }

        public event EventHandler<EventArgs> ArrivedToDest; //Срабатывает, когда была достигнута заданная точка
        public Point LastDestination;   //Точка, в которую идет контрол
        

        public double Speed;    //Скорость контрола
        private int LengthX { get => LastDestination.X - Location.X; } //Проекция длины до точки назначения по координате Х
        private int LengthY { get => LastDestination.Y - Location.Y; }  //Проекция длины по координате Y
        private double Length { get => Math.Sqrt(LengthX * LengthX + LengthY * LengthY); }  //Длина до точки назначения
        private double Cos { get => LengthX / Length; } //Косинус угла между горизонталью и прямой, соединяющей точку назначения и нынешнюю позицию
        private double Sin { get => LengthY / Length; } //Синус угла

        private Person person;    //Внутренний человек
        public Person _Person
        {
            get => person;
            set
            {
                person = value;
                if (person == null)
                    return;

                //При получении человека, ставим на контроле его имя
                //NameLabel.Text = human.PersonalName;
            }
        }

        //Начало движения в точку с заданными координатами
        public void StartMove(Point NewDestination)
        {
            LastDestination = NewDestination;   //Ставим пункт назначения
            person.OnTick += MoveBit; //Начинаем двигаться каждый тик
        }


        //"Передвинуться немного" - передвижение за один тик, 
        private void MoveBit(object sender, EventArgs args)
        {
            if (InvokeRequired) //Обход ограничений для работы с контролом, созданным не в потоке двигающейся сущности
            {
                Invoke((Action<object, EventArgs>)MoveBit, sender, args);
                return;
            }
            if (Math.Abs(LengthX) < 5 && Math.Abs(LengthY) < 5) //Проверяем, не достигли ли мы точки
            {
                Location = LastDestination; //Если попали в квадрат 5х5, то ставим точное местоположение
                person.OnTick -= MoveBit; //Отписываемся от передвижения
                ArrivedToDest?.Invoke(this, EventArgs.Empty); //Сигнализируем о конце движения
                return;
            }
            //Если не достигли, двигаемся, изменяя позицию контрола
            Location = new Point(Location.X + (int)Math.Floor(Speed * Cos), Location.Y + (int)Math.Floor(Speed * Sin));
        }

    }
}
