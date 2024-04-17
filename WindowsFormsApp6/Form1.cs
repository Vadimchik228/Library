using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp6
{
    
    public partial class Form1 : Form
    {
        private int currImage = 0;
        private int currReader = 0;
        public TableControl tableControl;
        private object GenLocker = new object();
        public int toGenerate;
        public int intTotalNumber = 0;
        public int intNumberIssuedOnHand = 0;
        public event EventHandler<EventArgs> Generated;
        public List<ReaderControl> ReaderControls = new List<ReaderControl>();
        Employee employee;
        System.Windows.Forms.Timer timerEntry;
        public event EventHandler<intEventArgs> OnReplenishTheLibrary;
        public event EventHandler<ListControlsEventArgs> OnAddControlToList;

        public Form1()
        {
            InitializeComponent();       
            Helper.SetTablePointFromEmployeeSide(this);
            Helper.SetExitPoint(this);
            Helper.SetBookcasePoint(this);
            Helper.SetTablePointFromReaderSide(this);
            Helper.SetReaderSpawnPoint(this);
            OnReplenishTheLibrary += IncreaseTotalNumber;
            OnAddControlToList += AddControlToList;
        }

        public void LetReadersIntoTheLibrary()
        {
            timerEntry = new System.Windows.Forms.Timer();
            timerEntry.Interval = 1000;
            timerEntry.Tick += new EventHandler(LetReaderIntoTheLibrary);
            timerEntry.Start();
        }

        public void LetReaderIntoTheLibrary(object sender, EventArgs args)
        {
            if (currReader < ReaderControls.Count)
            {
                ReaderControls.ElementAt(currReader).Location = Helper.ReaderSpawnPoint;
                ReaderControls.ElementAt(currReader)._Reader.EnterLibrary();
                currReader++;
            }
            else
                timerEntry.Stop();


        }

        public void AddControlToList(object sender, ListControlsEventArgs args)
        {
            ReaderControls.Add(args.readerControl);
        }
        public void Generate()
        {
            lock (GenLocker)
            {
                Random rnd = new Random();
                for (int i = 0; i < toGenerate; ++i)
                {
                    //Thread.Sleep(3000);
                    Generated?.Invoke(this, EventArgs.Empty);
                    
                }
            }
        }

        public void GenerateReaders(int amount)
        {
            Thread readerThread = new Thread(Generate);
            readerThread.IsBackground = true;
            toGenerate = amount;
            readerThread.Start();
        }

        private void CreateLibrary()
        {
            employee = new Employee();
            intTotalNumber += employee.catalogue.NumberOfPublications;
            tableControl = new TableControl(employee);
            tableControl.Table.OnGivePublications += IncreaseNumberIssuedOnHand;
            tableControl.Table.OnTakePublications += ReduceNumberIssuedOnHand;
            EmployeeControl employeeControl = new EmployeeControl();
            employeeControl._Employee = employee;
            Controls.Add(employeeControl);
            employeeControl.Location = Helper.TablePointFromEmployeeSide;
            Generated += CreateReader;         
            GenerateReaders(4);
        }

        private void CreateReader()
        {

            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    CreateReader();
                });
                return;
            }
            Reader reader = new Reader();        
            
            ReaderControl readerControl = new ReaderControl(tableControl); 
            OnAddControlToList?.Invoke(this, new ListControlsEventArgs(readerControl));    
            readerControl._Reader = reader; 
            Controls.Add(readerControl);   
            readerControl.Location = Helper.ReaderSpawnPoint;
            //reader.EnterLibrary();
        }


        private void IncreaseTotalNumber(object sender, intEventArgs args)
        {
            intTotalNumber += args.number;
            TotalNumber.Text = "Всего экземпляров: " + intTotalNumber.ToString();
        }

        private void IncreaseNumberIssuedOnHand(object sender, intEventArgs args)
        {
            
            intNumberIssuedOnHand += args.number;
            NumberIssuedOnHand.Text = "Выданных на руки: " + intNumberIssuedOnHand.ToString();
            
        }

        private void ReduceNumberIssuedOnHand(object sender, intEventArgs args)
        {
            
            intNumberIssuedOnHand -= args.number;
            NumberIssuedOnHand.Text = "Выданных на руки: " + intNumberIssuedOnHand.ToString();
            
        }

    

        private void CreateReader(object sender, EventArgs args)
        {
            CreateReader();
        }

        

        private void ChangeImage(object sender, EventArgs e)
        {
            List<Bitmap> b1 = new List<Bitmap>();
            b1.Add(Properties.Resources.Fall);
            b1.Add(Properties.Resources.Winter);
            b1.Add(Properties.Resources.Spring);
            b1.Add(Properties.Resources.Summer);
            

            if (currImage == b1.Count - 1)
                currImage = 0;
            else currImage++;
            
            this.BackgroundImage = b1[currImage];
            ReplenishLibrary();
            currReader = 0;
            LetReadersIntoTheLibrary();
        }

        

        private void ChangeSeasonsOfTheYear()
        {
            this.BackgroundImage = Properties.Resources.Fall;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 40000;
            List<Bitmap> b1 = new List<Bitmap>();
            b1.Add(Properties.Resources.Winter);
            b1.Add(Properties.Resources.Spring);
            b1.Add(Properties.Resources.Summer);
            b1.Add(Properties.Resources.Fall);
            timer.Tick += new EventHandler(ChangeImage);
            timer.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ReplenishLibrary()
        {
            List<Publication> NewPublications = Helper.GenerateListOfPublications();
            employee.catalogue.AddPublicationsToCatalogue(NewPublications);
            OnReplenishTheLibrary?.Invoke(this, new intEventArgs(NewPublications.Count));
        }
    

        private void StartButton_Click(object sender, EventArgs e)
        {
            TotalNumber.Visible = true;
            NumberIssuedOnHand.Visible = true;

            ChangeSeasonsOfTheYear();
            CreateLibrary();

            TotalNumber.Text = "Всего экземпляров: " + intTotalNumber.ToString();
            NumberIssuedOnHand.Text = "Выданных на руки: " + intNumberIssuedOnHand.ToString();

            LetReadersIntoTheLibrary();
        }
    }
}
