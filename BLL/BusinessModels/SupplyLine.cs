﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace BLL.BusinessModels
{
    public class SupplyLine: INotifyPropertyChanged
    {
        private int id { get; set; }
        private int supplyid { get; set; }
        private int commodityid { get; set; }

        private string commodityname { get; set; }
        private string commoditytype { get; set; }
        private int quantity { get; set; }
        private decimal cost { get; set; }

        public int Id 
        { 
            get 
            {
                return id;
            } 
            set 
            {
                id = value;
                OnPropertyChanged("Id");
            } 
        }

        public int SupplyId
        {
            get
            {
                return supplyid;
            }
            set
            {
                supplyid = value;
                OnPropertyChanged("SupplyId");
            }
        }

        public int CommodityId
        {
            get
            {
                return commodityid;
            }
            set
            {
                commodityid = value;
                OnPropertyChanged("CommodityId");
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public decimal Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }

        public string CommodityName
        {         
            get
            {
                return commodityname;
            }
            set
            {
                commodityname = value;
                OnPropertyChanged("CommodityName");
            }
            
        }
        public string CommodityType
        {
            get
            {
                return commoditytype;
            }
            set
            {
                commoditytype = value;
                OnPropertyChanged("CommodityType");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
