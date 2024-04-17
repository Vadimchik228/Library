using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WindowsFormsApp6
{
    public class ListControlsEventArgs : EventArgs
    {
        public ReaderControl readerControl;
        public ListControlsEventArgs(ReaderControl readerControl) { this.readerControl = readerControl; }
    }
    public enum Action { Take, Return }
    //Класс читателя
    public class Reader : Person
    {
        
        public Action action;
        public List<Publication> PublicationsToTake;
        public List<Publication> PublicationsToReturn;


        public int PositionInQueue; //Позиция в очереди клиента

        public event EventHandler<EventArgs> OnLibraryEntry;   //Происходит, когда читатель заходит в магазин
        public event EventHandler<EventArgs> OnQueueMove;      //Происходит, когда читатель передвигается в очереди
        public event EventHandler<EventArgs> OnReturnStart;    //Происходит, когда читатель становится первым в очереди и просит работника забрать старые издания
        public event EventHandler<EventArgs> OnTakingStart;    //Происходит, когда читатель становится первым в очереди и просит работника выдать новые издания
        public event EventHandler<EventArgs> OnReaderServed;   //Происходит, когда читатель обслужен

        public void EnterLibrary() //"Вход в библиотеку", вызов всех обработчиков данного события
        {
            OnLibraryEntry?.Invoke(this, EventArgs.Empty);
        }

        public void EnterQueue(Table table)  //Занимание места в очереди
        {
            table.AddReaderToQueue(this);
        }

        public void CheckIfFirstInQueue()       //Проверка того, что читатель стоит у стола библиотекаря
        {                                       //В случае верности, читатель просит выполнить действие (забрать книги или выдать новые книги)
            if (PositionInQueue == 0)
            {
                if (action == Action.Return)
                    OnReturnStart?.Invoke(this, EventArgs.Empty);
                else
                    OnTakingStart?.Invoke(this, EventArgs.Empty);
            }
                
        }

        public void MoveInQueue(object sender, EventArgs args)  // Передвижение внутри очереди, происходит, когда из очереди выходит 
        {                                                       // обслуженный читатель, т.е. все участники очереди одновременно двигаются
            PositionInQueue--;
            OnQueueMove?.Invoke(this, EventArgs.Empty);
        }

        public void ReaderIsServed(List<Publication> publications)   
        {
            TakenPublications.AddRange(publications);
            LosePublication();
            GenerateNextAction();

            OnReaderServed?.Invoke(this, EventArgs.Empty);
        }

        public Reader()
        {
            //TakenPublications = Helper.GenerateListOfPublications();
            //action = GenerateAction();
            //if (action == Action.Return && TakenPublications.Count > 0)
            //{
            //    PublicationsToTake = new List<Publication>();
            //    PublicationsToReturn = GenerateListOfPublicationsToReturn();
            //}
            //else
            //{
            //    PublicationsToReturn = new List<Publication>();
            //    PublicationsToTake = Helper.GenerateListOfPublications();
            //}
            TakenPublications = new List<Publication>();
            action = Action.Take;
            PublicationsToReturn = new List<Publication>();
            PublicationsToTake = Helper.GenerateListOfPublications();

        }


        public Action GenerateAction()
        {
            if (TakenPublications.Count != 0)
            {
                Random rnd = new Random();
                int NumberOfAction = rnd.Next(0, 2);
                if (NumberOfAction == 0)
                    return Action.Take;
                return Action.Return;
            }        
            return Action.Take;
        }

        public List<Publication> GenerateListOfPublicationsToReturn()
        {
            List<Publication> ListOfPublicationsToReturn = new List<Publication>();
            Random rnd = new Random();
            int NumberOfPublicationsToReturn = rnd.Next(1, TakenPublications.Count);
            for (int i = 0; i < NumberOfPublicationsToReturn; ++i)
            {
                ListOfPublicationsToReturn.Add(TakenPublications[rnd.Next(0, TakenPublications.Count)]);
            }
            return ListOfPublicationsToReturn;
        }

        public void LosePublication()
        {
            if (TakenPublications.Count != 0)
            {
                Random rnd = new Random();
                int ProbabilityOfLosing = rnd.Next(0, 5);
                if (ProbabilityOfLosing == 0)
                {
                    int IndexOfPublicationToLose = rnd.Next(0, TakenPublications.Count);
                    TakenPublications.RemoveAt(IndexOfPublicationToLose);
                }
            }
        }

        public void GenerateNextAction()
        {
            action = GenerateAction();
            if (action == Action.Return)
            {
                PublicationsToReturn = GenerateListOfPublicationsToReturn();
            }
            else
            {
                PublicationsToTake = Helper.GenerateListOfPublications();
            }
        }
    }
}
