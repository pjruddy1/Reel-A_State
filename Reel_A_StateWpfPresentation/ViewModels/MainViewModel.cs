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
            db = new MongoCRUD("PropertyDB");
            db.UpsertEstate("Estates", _selectedProperty.Id, new EstateProperties
            {
                Address = _selectedProperty.Address,
                Bathrooms = _selectedProperty.Bathrooms,
                Bedrooms = _selectedProperty.Bedrooms,
                City = _selectedProperty.City,
                Description = _selectedProperty.Description,
                Fireplace = _selectedProperty.Fireplace,
                Pool = _selectedProperty.Pool,
                Price = _selectedProperty.Price,
                State = _selectedProperty.State,
                Zipcode = _selectedProperty.Zipcode
            });
            _estateProperties.Remove(_selectedProperty);
            _estateProperties.Add(_selectedProperty);
        }

        private void AddEstate()
        {
            db = new MongoCRUD("PropertyDB");
            db.InsertEstate("Estates", new EstateProperties 
            { 
                Address = _selectedProperty.Address, 
                Bathrooms = _selectedProperty.Bathrooms, 
                Bedrooms = _selectedProperty.Bedrooms, 
                City = _selectedProperty.City, 
                Description = _selectedProperty.Description, 
                Comment = _selectedProperty.Comment,
                Fireplace = _selectedProperty.Fireplace, 
                Pool = _selectedProperty.Pool, 
                Price = _selectedProperty.Price, 
                State = _selectedProperty.State, 
                SqrFeet = _selectedProperty.SqrFeet,
                Zipcode = _selectedProperty.Zipcode });
        }

        private void DeleteEstate()
        {
            db = new MongoCRUD("PropertyDB");
            db.DeleteEstate("Estates", _selectedProperty.Id, _selectedProperty);
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
            var collection = db.LoadEstates<EstateProperties>("Estates");
            _estateProperties = new ObservableCollection<EstateProperties>(collection);
            _selectedProperty = new EstateProperties();
        }
    }
}
