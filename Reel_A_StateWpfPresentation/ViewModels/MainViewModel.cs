using Reel_A_State.BusinessLayer;
using Reel_A_StateData.DataAccessLayer;
using Reel_A_StateData.Models;
using Reel_A_StatePresentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reel_A_StateWpfPresentation.ViewModels
{
    class MainViewModel : ObservableObject
    {
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
            set
            {
                _estateProperties = value;
            }
        }

        private void ClearEstate()
        {
            _selectedProperty = new EstateProperties()
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

        }
        private void UpdateEstate()
        {
            db = new MongoCRUD("PropertyDB");
            db.UpdateEstate("Estates", _selectedProperty.Id, _selectedProperty, _selectedProperty);
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
                Zipcode = _selectedProperty.Zipcode
            });
            _estateProperties.Add(_selectedProperty);
        }

        private void DeleteEstate()
        {
            db = new MongoCRUD("PropertyDB");
            db.DeleteEstate("Estates", _selectedProperty.Id, _selectedProperty);
            _estateProperties.Remove(_selectedProperty);
        }


        public MainViewModel(MongoCRUD db)
        {
            db = new MongoCRUD("PropertyDB");
            var collection = db.LoadEstates<EstateProperties>("Estates");
            _estateProperties = new ObservableCollection<EstateProperties>(collection);
            _selectedProperty = new EstateProperties();
        }

        private static void EstatePropertiesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

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
    }
}
