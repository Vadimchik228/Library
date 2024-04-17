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
    
    public partial class ReaderControl : PersonControl
    {
        public ReaderControl(TableControl TableControl)
        {
            InitializeComponent();
            Speed = 5;
            this.TableControl = TableControl;
            PointInQueue = Helper.TablePointFromReaderSide;
            ExitPoint = Helper.ExitPoint;

            pictureBox1.Image = Properties.Resources.девочка_кисонька2;
        }

        //Позиция, к которой идет контрол, при смещении очереди
        private Point PointInQueue;
        private Point ExitPoint;
        private TableControl TableControl;

        private Reader reader;  //Внутренний клиент
        public Reader _Reader
        {
            get => reader;
            set
            {
                reader = value;
                _Person = reader;
                if (reader == null)
                    return;

                reader.OnLibraryEntry += GetInQueue; // Когда читатель заходит в библиотеку, он встает в очередь
                reader.OnQueueMove += Proceed;       // Когда читатель сдвинулся в очереди, двигается контрол
                reader.OnReaderServed += LeaveQueue; // Когда читатель обслужен, он покидает очередь

            }

        }

        //Выбор позиции, в которую встать и занимание внутренним клиентов очереди
        private void GetInQueue(object sender, EventArgs args)
        {
            reader.EnterQueue(TableControl.Table);  //Внутренний клиент становится в очередь внутри контрола 
            ArrivedToDest += Check; //По достижении очереди нужно проверить, не является ли клиент сейчас первым в очереди
            PointInQueue = TableControl.GetQueueEndPoint();    //Ставим позицию последнего места в очереди
            StartMove(PointInQueue); //Двигаемся к ней
        }

        //Продвинуться по очереди
        private void Proceed(object sender, EventArgs args)
        {
            ArrivedToDest += Check;
            PointInQueue.X += 200; 
            StartMove(PointInQueue);    
        }

        //Проверка внутренним контролои, является ли он первым в очереди
        private void Check(object sender, EventArgs args)
        {
            ArrivedToDest -= Check; //Отписываемся от события по достижению
            reader.CheckIfFirstInQueue(); //Проверяем, встал ли клиент первым в очереди
        }

        //Выйти из очереди
        private void LeaveQueue(object sender, EventArgs args)
        {
            ArrivedToDest += GoToExit;  //По выходу из очереди двигаемся к выходу
            StartMove(new Point(Location.X, Location.Y + Height)); 

        }

        //Идти к выходу
        private void GoToExit(object sender, EventArgs args)
        {
            ArrivedToDest -= GoToExit; 
            ArrivedToDest += Exit;  
            StartMove(ExitPoint);  
        }

        //Выйти из магазина 
        private void Exit(object sender, EventArgs args)
        {
            ArrivedToDest -= Exit;  
        }

    }
}
