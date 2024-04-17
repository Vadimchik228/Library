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
    public partial class TableControl : UserControl
    {
        public TableControl(Employee employee)
        {
            InitializeComponent();
            table = new Table(employee);
            QueueStartPoint = Helper.TablePointFromReaderSide;
        }

        
        private object Locker = new object(); 

        private Point QueueStartPoint;

        private Table table; 

        public Table Table
        {
            get => table;
            set
            {
                table = value;
                
            }
            
        }

        public Point GetQueueEndPoint()
        {
            lock (Locker)
            {
                return new Point(QueueStartPoint.X - 200 * (table.ReaderQueue.Count - 1), QueueStartPoint.Y );
            }
        }
    }
}
