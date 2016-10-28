using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MTG_DeckTester.UserClasses
{
    public class Game : INotifyPropertyChanged
    {
        private static Game instance;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion

        public Player J1_Player { get; set; }
        public ObservableCollection<Card> J1_Main { get; set; }
        public Deck J1_Deck { get; set; }
        public ObservableCollection<Card> J1_Cimetiere { get; set; }
        public ObservableCollection<Card> J1_Exil { get; set; }
        public ObservableCollection<Land_Card> J1_Board_Lands { get; set; }

        public ObservableCollection<Creature_Card> J1_Board_Creatures { get; set; }
        public ObservableCollection<Special_Card> J1_Board_Specials { get; set; }

        public Player J2_Player { get; set; }
        public ObservableCollection<Card> J2_Main { get; set; }
        public Deck J2_Deck { get; set; }
        public ObservableCollection<Card> J2_Cimetiere { get; set; }
        public ObservableCollection<Card> J2_Exil { get; set; }
        public ObservableCollection<Land_Card> J2_Board_Lands { get; set; }
        public ObservableCollection<Creature_Card> J2_Board_Creatures { get; set; }
        public ObservableCollection<Special_Card> J2_Board_Specials { get; set; }

        /// <summary>
        /// Constructeur d'une partie (privé car Singleton)
        /// </summary>
        private Game()
        {
            J1_Player = new Player();
            J1_Main = new ObservableCollection<Card>();
            J1_Deck = new Deck();
            J1_Cimetiere = new ObservableCollection<Card>();
            J1_Exil = new ObservableCollection<Card>();
            J1_Board_Lands = new ObservableCollection<Land_Card>();
            J1_Board_Creatures = new ObservableCollection<Creature_Card>();
            J1_Board_Specials = new ObservableCollection<Special_Card>();

            J2_Player = new Player();
            J2_Main = new ObservableCollection<Card>();
            J2_Deck = new Deck();
            J2_Cimetiere = new ObservableCollection<Card>();
            J2_Exil = new ObservableCollection<Card>();
            J2_Board_Lands = new ObservableCollection<Land_Card>();
            J2_Board_Creatures = new ObservableCollection<Creature_Card>();
            J2_Board_Specials = new ObservableCollection<Special_Card>();
        }

        /// <summary>
        /// GetInstance de l'objet Game
        /// </summary>
        /// <returns>L'objet Game</returns>
        public static Game GetInstance()
        {
            if (instance == null)
            {
                instance = new Game();
            }
            return instance;
        }
    }
}

