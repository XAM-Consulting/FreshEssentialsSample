using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.ComponentModel;

namespace FreshEssentialSamples
{
    public class BindableViewModel  : INotifyPropertyChanged
    {
        public List<Car> MyCars { get; set; }

        public Car SelectedCar { get; set; }

        public BindableViewModel()
        {
            MyCars = new List<Car>
            {
                new Car
                {
                    Make = "Ford",
                    Model = "Mustang"
                },
                new Car
                {
                    Make = "Nissan",
                    Model = "Pulsar"
                },
                new Car
                {
                    Make = "Honda",
                    Model = "Civic"
                },
            };
        }

        int _index;

        public int SelectIndex
        { 
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                OnPropertyChanged("SelectIndex");
            }
        }

        string _displayText;

        public string DisplayText
        { 
            get
            {
                return _displayText;
            }
            set
            {
                _displayText = value;
                OnPropertyChanged("DisplayText");
            }
                
        }

        bool _showButton = true;

        public bool ShowButton
        {
            get
            {
                return _showButton;
            }set
            {
                _showButton = value;
                OnPropertyChanged("ShowButton");
            }
        }

        public Command InverseCommand
        {
            get
            {
                return new Command((o) =>
                    {
                        ShowButton = !ShowButton;
                    });
            }
        }

        public Command ItemTapCommand
        {
            get
            {
                return new Command((o) =>
                    {
                        var item = o as Car;
                        if (item != null)
                        {
                            DisplayText = string.Format("You click the {0} item", item.MakeAndModel);
                        }
                    });
            }
        }

        int _clickTimes = 0;

        public Command ImageTappedCommnad
        {
            get
            { 
                return new Command(() =>
                    {
                        if (_clickTimes == 0)
                        {
                            DisplayText = "You Click the image";
                        }
                        else if (_clickTimes < 2)
                        {
                            DisplayText = "You Click the image again";
                        }
                        else if (_clickTimes < 30)
                        {
                            DisplayText = "You are so boring!";
                        }
                        else if (_clickTimes < 31)
                        {
                            DisplayText = "I will crash if you click me one more time!";
                        }
                        else
                        {
                            throw new Exception();
                        }
                        _clickTimes++;
                    });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

