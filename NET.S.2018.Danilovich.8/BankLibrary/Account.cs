﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    /// <summary>   Values that represent gradations. </summary>
    public enum Gradation
    {
        Base = 1,
        Silver,
        Gold,
        Platinum
    }

    public class Account
    {
        #region private Fields
        /// <summary>   The counter of all accounts. </summary>
        private static uint counter = 0;

        /// <summary>   The identifier of account. </summary>
        private uint id;

        /// <summary>   The person. </summary>
        private Client man;

        /// <summary>   Bonus points on the account. </summary>
        private int bonusPoints;

        /// <summary>   Bonus points on the account. </summary>
        private decimal balance;

        /// <summary>   The gradation. </summary>
        private Gradation gradation;
        #endregion
        #region Constructor
        /// <summary>   Constructor. </summary>
        /// <param name="man">          The person with properties: string, string, string, string. </param>
        /// <param name="gradation">    The gradation of account rarity. </param>
        public Account(Client man, Gradation gradation, decimal balance, decimal points)
        {
            this.man = new Client(man.Name, man.Surname, man.Lastname, man.NumberOfPassport);
            this.gradation = gradation;
            this.Balance = balance;
            this.BonusePoints = points;
            id = ++counter;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Getter and setter for identifier of account
        /// </summary>
        public int Id
        {
            get => this.id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{(nameof(value))} cant be less than zero");
                }

                id = value;
            }
        }

        /// <summary>   Gets or sets the balance. </summary>
        /// <value> The balance. </value>
        public decimal Balance
        {
            get => balance;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException($"{(nameof(value))} cant be less than zero");
                }

                balance = value;
            }
        }

        /// <summary>   Gets or sets the bonuse points. </summary>
        /// <value> The bonuse points. </value>
        public decimal BonusPoints
        {
            get => bonusPoints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{(nameof(value))} cant be less than zero");
                }

                bonusPoints = value;
            }
        }

        /// <summary>   Gets the cost of balance, prop for calculate points. </summary>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <value> The cost of balance. </value>
        public uint CostOfBalance
        {
            get
            {
                switch (gradation)
                {
                    case Gradation.Base:
                        return 1;
                    case Gradation.Silver:
                        return 2;
                    case Gradation.Gold:
                        return 3;
                    case Gradation.Platinum:
                        return 5;
                }

                throw new ArgumentOutOfRangeException(nameof(gradation));
            }
        }
        
        /// <summary>   Define gradation of account. </summary>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <value> Gradation of account. </value>
        public uint CostOfFiiling
        {
            get
            {
                switch (gradation)
                {
                    case Gradation.Base:
                        return 2;
                    case Gradation.Silver:
                        return 3;
                    case Gradation.Gold:
                        return 4;
                    case Gradation.Platinum:
                        return 6;
                }

                throw new ArgumentOutOfRangeException(nameof(gradation));
            }
        }
        #endregion

        #region Methods
        /// <summary>   Puts the given money on account. </summary>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <param name="money">    The money to put. </param>
        public virtual void Put(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException($"{(nameof(money))} cant be less then zero");
            }

            Balance += money;
            BonusePoints += (uint)(money / 50) * (CostOfBalance + CostOfFiiling);
        }
        
        /// <summary>   Withdraws the given money from account. </summary>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <param name="money">    The money for withdrawal. </param>
        public virtual void Withdraw(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException($"{(nameof(money))} cant be less then zero");
            }

            if (Balance < money)
            {
                throw new ArgumentOutOfRangeException($"{(nameof(money))} cant be more then {nameof(Balance)} when withdrawing money");
            }

            Balance -= money;
            if (BonusePoints > 0)
            {
                if ((uint)(money / 40) * (CostOfBalance + CostOfFiiling) > BonusePoints)
                {
                    BonusePoints = 0;
                }
                else
                {
                    BonusePoints -= (uint)(money / 40) * (CostOfBalance + CostOfFiiling);
                }
            }
        }
        
        /// <summary>   Tests if this Account is considered equal to another. </summary>
        /// <param name="other">    The account to compare to this object. </param>
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        public bool Equals(Account other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (!man.Equals(other.man) || id != other.id || gradation != other.gradation)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
