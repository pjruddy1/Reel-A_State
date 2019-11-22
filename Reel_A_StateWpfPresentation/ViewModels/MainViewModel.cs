using Reel_A_State.BusinessLayer;
using Reel_A_StateData.DataAccessLayer;
using Reel_A_StateData.Models;
using Reel_A_StatePresentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reel_A_StateWpfPresentation.ViewModels
{
    class MainViewModel : ObservableObject
    {

        
        public ICommand DeleteEstateCommand
        {
            get { return new DelegateCommand(DeleteEstate); }
        }

        public ICommand AddEstateCommand
        {
            get { return new DelegateCommand(AddEstate); }
        }

        public ICommand UpdateEstateCommand
        {
            get { return new DelegateCommand(UpdateEstate); }
        }


        private void UpdateEstate()
        {
            _estateProperties.Remove(_selectedProperty);
            _estateProperties.Add(_selectedProperty);
        }

        private void AddEstate()
        {
            db = new MongoCRUD("PropertyDB");
            db.InsertEstate("Estates", new EstateProperties { Address = "yellow st", Bathrooms = 3, Bedrooms = 3, City = "THere", 
                Description = "This is your place", Fireplace = false, Pool = false, Price = 50000, State = "MI", Zipcode = 49686 });
        }

        private void DeleteEstate()
        {
            _estateProperties.Remove(_selectedProperty);
        }

        private MongoCRUD db;
        private ObservableCollection<EstateProperties> _estateProperties;
        private EstateProperties _selectedProperty;
       


        public EstateProperties SelectedProperty
        {
            get { return _selectedProperty; }
            set 
            {
                if (_selectedProperty == value)
                {
                    return;
                }
                _selectedProperty = value;
                OnPropertyChanged("SelectedProperty");
            }
        }


        public ObservableCollection<EstateProperties> EstateProperties
        {
            get { return _estateProperties; }
            set { _estateProperties = value; }
        }

       
        public MainViewModel(MongoCRUD db)
        {            
            db = new MongoCRUD("PropertyDB");
            _estateProperties = db.LoadEstates<EstateProperties>("Estates");
        }
    }
}
