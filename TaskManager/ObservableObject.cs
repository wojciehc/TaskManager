using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskManager
{   
    /// <summary>
    /// Klasa reprezentujaca obserwowalny obiekt
    /// </summary>
    internal class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
            
        /// <summary>
        /// Funckja odpowiadajca za zmiane wlasnosci
        /// </summary>
        /// <param name="name">Nazwa wywolujacego metode - null</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
