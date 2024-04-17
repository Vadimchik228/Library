using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class intEventArgs : EventArgs
    {
        public int number;
        public intEventArgs(int number) { this.number = number; }
    }

    public class Table
    {

        public Employee Employee;   

        public List<Reader> ReaderQueue; 

        public event EventHandler<EventArgs> OnQueueMoved;
        public event EventHandler<intEventArgs> OnTakePublications;
        public event EventHandler<intEventArgs> OnGivePublications;
        private object Locker = new object();   

        public void StartServingCurrentReader(object sender, EventArgs args)
        {
            lock (Locker)
            {
                if ((sender as Reader).action == Action.Return)
                {
                    Employee.StartAcceptingPublications((sender as Reader).PublicationsToReturn);
                    OnTakePublications?.Invoke(this, new intEventArgs((sender as Reader).PublicationsToReturn.Count));
                }
                else
                {
                    Employee.StartGivingPublications((sender as Reader).PublicationsToTake);
                    
                }
                    
            }
        }

        
        public void StopServingCurrentReader(object sender, ListEventArgs args)
        {
            lock (Locker)
            {
                
                if (ReaderQueue[0].action == Action.Return)
                {
                    ReaderQueue[0].ReaderIsServed(args.publications);
                    ReaderQueue[0].OnReturnStart -= StartServingCurrentReader;
                }
                else
                {
                    ReaderQueue[0].ReaderIsServed(args.publications);
                    ReaderQueue[0].OnTakingStart -= StartServingCurrentReader;
                    OnGivePublications?.Invoke(this, new intEventArgs(args.publications.Count));
                } 
                
                OnQueueMoved -= ReaderQueue[0].MoveInQueue; 
                ReaderQueue.RemoveAt(0);        
                OnQueueMoved?.Invoke(this, EventArgs.Empty);    
            }
        }

        
        public void AddReaderToQueue(Reader reader)
        {
            lock (Locker)
            {
                reader.PositionInQueue = ReaderQueue.Count;
                ReaderQueue.Add(reader);    
                if (reader.action == Action.Return)
                    reader.OnReturnStart += StartServingCurrentReader;
                else reader.OnTakingStart += StartServingCurrentReader;
                OnQueueMoved += reader.MoveInQueue; 
            }
        }

        public Table(Employee employee)
        {
            Employee = employee;   
            Employee.OnReturnToTable += StopServingCurrentReader; 
            ReaderQueue = new List<Reader>();
        }
    }
}
