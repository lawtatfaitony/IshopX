using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LanguageResource;
using Ishop.Utilities;
namespace Ishop.ViewModes.Public
{
    public class TreeView
    {
        public string text { get; set; }
        public string nodeid { get; set; }
        public string custom { get; set; }

        public string href { get; set; }

        public string Target { get; set; }
        public string ForRoleName { get; set; }
    }
    public class CompoundInterestView
    { 
        [LocalizedDisplayName("复利终值", KeyName = "CompoundInterestView_F", KeyType = KeyType.ModalView)]
        public double F { get; set; }

        [LocalizedDisplayName("复利初值", KeyName = "CompoundInterestView_P", KeyType = KeyType.ModalView)]
        public double P { get; set; }

        [LocalizedDisplayName("利率", KeyName = "CompoundInterestView_i", KeyType = KeyType.ModalView)]
        public double i { get; set; }

        [LocalizedDisplayName("年期", KeyName = "CompoundInterestView_n", KeyType = KeyType.ModalView)]
        public double n { get; set; }
    }

}