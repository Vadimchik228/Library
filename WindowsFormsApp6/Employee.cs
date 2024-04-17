using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp6
{
    public class ListEventArgs : EventArgs
    {
        public List<Publication> publications;
        public ListEventArgs(List<Publication> publications) { this.publications = publications; }
    }

    //Класс работника библиотеки
    public class Employee : Person
    {
        private List<Publication> PublicationsToGive;
        private List<Publication> PublicationsToAccept;
        private List<Publication> PublicationsAtTheEndOfService;
        public Catalogue catalogue;

        public event EventHandler<ListEventArgs> OnGivePublicationsStart;    // Происходит, когда библиотекаря просят выдать новые издания
        public event EventHandler<ListEventArgs> OnAcceptPublicationsStart;  // Происходит, когда библиотекаря просят забрать издания
        public event EventHandler<EventArgs> OnActionIsDone;
        public event EventHandler<ListEventArgs> OnReturnToTable;            // Происходит, когда библиотекарь вернулся к столу

        public Employee()
        {
            PublicationsToGive = new List<Publication>();
            PublicationsToAccept = new List<Publication>();
            PublicationsAtTheEndOfService = new List<Publication>();
            catalogue = new Catalogue();
        }
        public void StartAcceptingPublications(List<Publication> PublicationsToReturn)   
        {
            PublicationsToAccept = PublicationsToReturn;
            OnAcceptPublicationsStart?.Invoke(this, new ListEventArgs(PublicationsToReturn));
        }

        public void StartGivingPublications(List<Publication> PublicationsToTake)
        {
            PublicationsToGive = PublicationsToTake;
            OnGivePublicationsStart?.Invoke(this, new ListEventArgs(PublicationsToTake));
        }

        public void AddPublicatoinsToCatalogue()
        {
            catalogue.AddPublicationsToCatalogue(PublicationsToAccept);
            PublicationsAtTheEndOfService.Clear();
            OnActionIsDone?.Invoke(this, EventArgs.Empty);
        }

        public void GetPublicationsFromCatalogue()
        {
            PublicationsAtTheEndOfService = catalogue.GetPublicationsFromCatalogue(PublicationsToGive);
            OnActionIsDone?.Invoke(this, EventArgs.Empty);
        }

        
        public void EndService() 
        {
            OnReturnToTable?.Invoke(this, new ListEventArgs(PublicationsAtTheEndOfService));
        }
    }
}
