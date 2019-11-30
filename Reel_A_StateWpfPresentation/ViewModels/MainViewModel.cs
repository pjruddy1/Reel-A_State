using FluentValidation.Results;
using Reel_A_State.BusinessLayer;
using Reel_A_State.Validators;
using Reel_A_StateData.DataAccessLayer;
using Reel_A_StateData.Models;
using Reel_A_StatePresentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Reel_A_StateWpfPresentation.ViewModels
{
    class MainViewModel : ObservableObject
    {
        #region ICOMMANDS
        public ICommand ClearEstateCommand
        {
            get { return new DelegateCommand(ClearEstate); }
        }
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
        public ICommand SortListByPriceCommand
        {
            get { return new DelegateCommand(SortListByPrice); }
        }
        public ICommand SortListByCityCommand
        {
            get { return new DelegateCommand(SortListByCity); }
        }
        public ICommand SortListByBedroomCommand
        {
            get { return new DelegateCommand(SortListByBedroom); }
        }
        public ICommand SortListBySqrFeetCommand
        {
            get { return new DelegateCommand(SortListBySqrFeet); }
        }
        public ICommand SortListByZipCommand
        {
            get { return new DelegateCommand(SortListByZip); }
        }
        public ICommand SortListByAcresCommand
        {
            get { return new DelegateCommand(SortListByState); }
        }
        public ICommand ViewEstateCommand
        {
            get { return new DelegateCommand(ViewEstate); }
        }
        public ICommand SearchAddressCommand
        {
            get { return new DelegateCommand(SearchAddress); }
        }
        #endregion

        #region Fields

        private MongoCRUD db;
        private ObservableCollection<EstateProperties> _estateProperties;
        private EstateProperties _selectedProperty;
        private EstateProperties _workingProperty;
        private ObservableCollection<string> _errors;
        private string _searchedAddress;

        #endregion

        #region Properties
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
            set
            {
                _estateProperties = value;
                OnPropertyChanged("EstateProperties");
            }
        }

        public EstateProperties WorkingProperty
        {
            get { return _workingProperty; }
            set 
            { 
                _workingProperty = value;
                OnPropertyChanged("WorkingProperty");
            }
        }
        public ObservableCollection<string> Errors
        {
            get { return _errors; }
            set
            {
                _errors = value;
                OnPropertyChanged("Errors");
            }
        }

        public string SearchedAddress
        {
            get { return _searchedAddress; }
            set { _searchedAddress = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// View the properties of the selected Estate
        /// </summary>
        private void ViewEstate()
        {
            //_workingProperty = _selectedProperty;
            _workingProperty = new EstateProperties();
            _workingProperty.Address = _selectedProperty.Address;
            _workingProperty.Bathrooms = _selectedProperty.Bathrooms;
            _workingProperty.Bedrooms = _selectedProperty.Bedrooms;
            _workingProperty.City = _selectedProperty.City;
            _workingProperty.Comment = _selectedProperty.Comment;
            _workingProperty.Description = _selectedProperty.Description;
            _workingProperty.Fireplace = _selectedProperty.Fireplace;
            _workingProperty.Id = _selectedProperty.Id;
            _workingProperty.Pool = _selectedProperty.Pool;
            _workingProperty.Price = _selectedProperty.Price;
            _workingProperty.SqrFeet = _selectedProperty.SqrFeet;
            _workingProperty.State = _selectedProperty.State;
            _workingProperty.Zipcode = _selectedProperty.Zipcode;
            OnPropertyChanged("WorkingProperty");
        }
        /// <summary>
        /// Cleater out all properties and also reset the list
        /// </summary>
        private void ClearEstate()
        {
            db = new MongoCRUD("PropertyDB");
            var collection = db.LoadEstates<EstateProperties>("Estates");
            _estateProperties = new ObservableCollection<EstateProperties>(collection);
            OnPropertyChanged("EstateProperties");
            foreach (EstateProperties estate in _estateProperties)
            {
                estate.Dollars = Reel_A_StateData.Models.EstateProperties.GetDollarAmount(estate.Price);
            }

            _workingProperty = new EstateProperties()
            {
                Address = "",
                City = "",
                Zipcode = 0,
                Price = 0,
                Bedrooms = 0,
                Bathrooms = 0,
                Fireplace = false,
                Pool = false,
                Comment = "",
                Description = "",
                SqrFeet = 0,
                State = ""
            };
            OnPropertyChanged("WorkingProperty");

        }
        /// <summary>
        /// Validates the working property and then calls the update crud operation
        /// </summary>
        private void UpdateEstate()
        {
            // Instantiate the validator and save the result
            EstateValidator validator = new EstateValidator();
            ValidationResult results = validator.Validate(_workingProperty);

            // if the result is false spit out errors
            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {

                    _errors.Add($"{failure.ErrorMessage}");
                    OnPropertyChanged("Errors");
                }
            }
            // if no errors call the CRUD operations update method
            else
            {
                _workingProperty = new EstateProperties();
                _workingProperty = _selectedProperty;
                db = new MongoCRUD("PropertyDB");
                db.UpdateEstate("Estates", _workingProperty.Id, _workingProperty, _workingProperty);

                _errors = new ObservableCollection<string>();
                OnPropertyChanged("Errors");
            }
                
        }
        /// <summary>
        /// Calls the method to insert entry into the database 
        /// and adds the entry to the end of the list
        /// </summary>
        private void AddEstate()
        {
            EstateValidator validator = new EstateValidator();

            ValidationResult results = validator.Validate(_workingProperty);

            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                   
                    _errors.Add($"{failure.ErrorMessage}");
                    OnPropertyChanged("Errors");
                }
            }
            else
            {
                db = new MongoCRUD("PropertyDB");
                db.InsertEstate("Estates", new EstateProperties
                {
                    Address = _workingProperty.Address,
                    Bathrooms = _workingProperty.Bathrooms,
                    Bedrooms = _workingProperty.Bedrooms,
                    City = _selectedProperty.City,
                    Description = _workingProperty.Description,
                    Comment = _workingProperty.Comment,
                    Fireplace = _workingProperty.Fireplace,
                    Pool = _workingProperty.Pool,
                    Price = _workingProperty.Price,
                    State = _workingProperty.State,
                    SqrFeet = _workingProperty.SqrFeet,
                    Zipcode = _workingProperty.Zipcode
                });
                _estateProperties.Add(_workingProperty);

                _errors = new ObservableCollection<string>();
                OnPropertyChanged("Errors");
            }
            
        }
        /// <summary>
        /// Calls the method to delete entry from the database
        /// and deletes entry from the list
        /// </summary>
        private void DeleteEstate()
        {
            if (_selectedProperty != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Are you sure you want to delete this entry?", "Delete Entry", System.Windows.MessageBoxButton.OKCancel);

                if (messageBoxResult == MessageBoxResult.OK)
                {
                    db = new MongoCRUD("PropertyDB");
                    db.DeleteEstate("Estates", _selectedProperty.Id, _selectedProperty);
                    _estateProperties.Remove(_selectedProperty);
                }
            }
           
        }
        /// <summary>
        /// Sorts the list by state
        /// </summary>
        private void SortListByState()
        {
            ObservableCollection<EstateProperties> newProperties = new ObservableCollection<EstateProperties>(_estateProperties.OrderBy(x => x.State));
            foreach (EstateProperties estate in newProperties)
            {
                _estateProperties.Remove(estate);
            }
            foreach (EstateProperties estateProperties in newProperties)
            {
                _estateProperties.Add(estateProperties);
            }
        }
        /// <summary>
        /// sorts list by zip
        /// </summary>
        private void SortListByZip()
        {
            ObservableCollection<EstateProperties> newProperties = new ObservableCollection<EstateProperties>(_estateProperties.OrderBy(x => x.Zipcode));
            foreach (EstateProperties estate in newProperties)
            {
                _estateProperties.Remove(estate);
            }
            foreach (EstateProperties estateProperties in newProperties)
            {
                _estateProperties.Add(estateProperties);
            }
        }
        /// <summary>
        /// Sorts list by SqrFeet
        /// </summary>
        private void SortListBySqrFeet()
        {
            ObservableCollection<EstateProperties> newProperties = new ObservableCollection<EstateProperties>(_estateProperties.OrderBy(x => x.SqrFeet));
            foreach (EstateProperties estate in newProperties)
            {
                _estateProperties.Remove(estate);
            }
            foreach (EstateProperties estateProperties in newProperties)
            {
                _estateProperties.Add(estateProperties);
            }
        }
        /// <summary>
        /// Sorts list by bedroom
        /// </summary>
        private void SortListByBedroom()
        {
            ObservableCollection<EstateProperties> newProperties = new ObservableCollection<EstateProperties>(_estateProperties.OrderBy(x => x.Bedrooms));
            foreach (EstateProperties estate in newProperties)
            {
                _estateProperties.Remove(estate);
            }
            foreach (EstateProperties estateProperties in newProperties)
            {
                _estateProperties.Add(estateProperties);
            }
        }
        /// <summary>
        /// Sort list by city
        /// </summary>
        private void SortListByCity()
        {
            ObservableCollection<EstateProperties> newProperties = new ObservableCollection<EstateProperties>(_estateProperties.OrderBy(x => x.City));
            foreach (EstateProperties estate in newProperties)
            {
                _estateProperties.Remove(estate);
            }
            foreach (EstateProperties estateProperties in newProperties)
            {
                _estateProperties.Add(estateProperties);
            }
        }
        /// <summary>
        /// Sort list by price
        /// </summary>
        private void SortListByPrice()
        {
            ObservableCollection<EstateProperties> newProperties = new ObservableCollection<EstateProperties>(_estateProperties.OrderBy(x => x.Price));
            foreach (EstateProperties estate in newProperties)
            {
                _estateProperties.Remove(estate);
            }
            foreach (EstateProperties estateProperties in newProperties)
            {
                _estateProperties.Add(estateProperties);
            }
        }
        /// <summary>
        /// called when user is searching for address value
        /// </summary>
        private void SearchAddress()
        {
            db = new MongoCRUD("PropertyDB");
            var collection = db.LoadEstates<EstateProperties>("Estates");
            ObservableCollection<EstateProperties> newProperties = new ObservableCollection<EstateProperties>();
            ObservableCollection<EstateProperties> deleteProperties = new ObservableCollection<EstateProperties>(collection);

            foreach (EstateProperties estate in _estateProperties)
            {
                if (estate.Address.ToUpper().Contains(SearchedAddress.ToUpper()))
                {
                    newProperties.Add(estate);
                }
            }
            
            foreach (EstateProperties estate in deleteProperties)
            {
                _estateProperties.Clear();
            }
            foreach (EstateProperties estateProperties in newProperties)
            {
                _estateProperties.Add(estateProperties);
            }
            foreach (EstateProperties estate in _estateProperties)
            {
                estate.Dollars = Reel_A_StateData.Models.EstateProperties.GetDollarAmount(estate.Price);
            }

        }
        #endregion

        #region CONSTRUCTOR
        public MainViewModel(MongoCRUD db)
        {
            db = new MongoCRUD("PropertyDB");
            var collection = db.LoadEstates<EstateProperties>("Estates");
            _estateProperties = new ObservableCollection<EstateProperties>(collection);
            foreach (EstateProperties estate in _estateProperties)
            {
                estate.Dollars = Reel_A_StateData.Models.EstateProperties.GetDollarAmount(estate.Price);
            }
            _selectedProperty = new EstateProperties();
            _workingProperty = new EstateProperties();
            _errors = new ObservableCollection<string>();
        }
        #endregion

      
    }
}
