﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.BusinessModels
{
    public class Provider
    {
        private int id { get; set; }
        private string familyname { get; set; }
        private string initials { get; set; }
        private string fullname { get; set; }
        private string companyname { get; set; }

        private DateTime possibledeliverydate { get; set; }

        public Provider(){ }
        public Provider(DAL.Provider provider)
        {
            CompanyName = provider.CompanyName;
            FamilyName = provider.FamilyName;
            Id = provider.Id;
            Initials = provider.Initials;
            FullName = provider.FamilyName + " " + provider.Initials;
            PossibleDeliveryDate = provider.PossibleDeliveryDate;
        }
        public int Id 
        { 
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string FamilyName
        {
            get
            {
                return familyname;
            }
            set
            {
                familyname = value;
            }
        }
        public string Initials
        {
            get
            {
                return initials;
            }
            set
            {
                initials = value;
            }
        }
        public string FullName
        {
            get
            {
                return fullname;
            }
            set
            {
                fullname = value;
            }
        }
        public string CompanyName
        {
            get
            {
                return companyname;
            }
            set
            {
                companyname = value;
            }
        }

        public DateTime PossibleDeliveryDate
        {
            get
            {
                return possibledeliverydate;
            }
            set
            {
                possibledeliverydate = value;
            }
        }
    }
}
