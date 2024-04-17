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
    public partial class EmployeeControl : PersonControl
    {

        public EmployeeControl()
        {
            InitializeComponent();
            Speed = 2;
            TablePointFromEmployeeSide = Helper.TablePointFromEmployeeSide;
            BookcasePoint = Helper.BookcasePoint;
            pictureBox1.Image = Properties.Resources.бабуля2;

        }

        private Point TablePointFromEmployeeSide; 
        private Point BookcasePoint; 
        private Employee employee;  

        public Employee _Employee
        {
            get => employee;
            set
            {
                employee = value;
                _Person = employee;
                if (employee == null)
                    return;

                employee.OnAcceptPublicationsStart += StartMovingToBookcaseToAccept;
                employee.OnGivePublicationsStart += StartMovingToBookcaseToGive;
                employee.OnActionIsDone += MoveToTable;
                
               
            }
        }

        private void StartMovingToBookcaseToAccept(object sender, ListEventArgs args)
        {
            ArrivedToDest += AddPublicatoinsToCatalogue;    
            MoveToBookcase(null, new ListEventArgs(args.publications));    
        }

        private void StartMovingToBookcaseToGive(object sender, ListEventArgs args)
        {
            ArrivedToDest += GetPublicationsFromCatalogue;    
            MoveToBookcase(null, new ListEventArgs(args.publications));   
        }

        private void MoveToBookcase(object sender, EventArgs args)
        {
            StartMove(BookcasePoint); 
        }

        private void MoveToTable(object sender, EventArgs args)
        {
            ArrivedToDest -= AddPublicatoinsToCatalogue;
            ArrivedToDest -= GetPublicationsFromCatalogue;
            ArrivedToDest += EndServing;
            StartMove(TablePointFromEmployeeSide);
            
        }


        private void EndServing(object sender, EventArgs args)
        {
            ArrivedToDest -= EndServing;    
            employee.EndService(); 
        }

        public void AddPublicatoinsToCatalogue(object sender, EventArgs args)
        {
            employee.AddPublicatoinsToCatalogue();
        }

        public void GetPublicationsFromCatalogue(object sender, EventArgs args)
        {
            employee.GetPublicationsFromCatalogue();
        }


      
    }
}
